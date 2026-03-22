using CertificateGenerator.Models;
using CertificateGenerator.Services;
using System.Text.RegularExpressions;

namespace CertificateGenerator;

public partial class MainForm : Form
{
    private string? _rutaExcel;
    private string? _rutaPlantilla;
    private string? _carpetaDestino;
    private readonly CertificateGeneratorService _generador = new();

    public MainForm()
    {
        InitializeComponent();
        ActualizarPreview();
    }

    // ─── Seleccionar archivo Excel ─────────────────────────────────────
    private void BtnSeleccionarExcel_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Seleccionar archivo Excel",
            Filter = "Archivos Excel (*.xlsx)|*.xlsx",
            RestoreDirectory = true
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _rutaExcel = dialog.FileName;
            lblExcel.Text = Path.GetFileName(_rutaExcel);
            lblExcel.ForeColor = Color.DarkGreen;
        }
    }

    // ─── Seleccionar plantilla PNG ─────────────────────────────────────
    private void BtnSeleccionarPlantilla_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Seleccionar plantilla de certificado",
            Filter = "Imágenes PNG (*.png)|*.png|Todas las imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
            RestoreDirectory = true
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _rutaPlantilla = dialog.FileName;
            lblPlantilla.Text = Path.GetFileName(_rutaPlantilla);
            lblPlantilla.ForeColor = Color.DarkGreen;
            ActualizarPreview();
        }
    }

    // ─── Seleccionar carpeta de destino ────────────────────────────────
    private void BtnSeleccionarCarpeta_Click(object? sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Seleccionar carpeta para guardar los certificados",
            UseDescriptionForTitle = true
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _carpetaDestino = dialog.SelectedPath;
            lblCarpeta.Text = _carpetaDestino;
            lblCarpeta.ForeColor = Color.DarkGreen;
        }
    }

    // ─── Generar certificados ──────────────────────────────────────────
    private async void BtnGenerar_Click(object? sender, EventArgs e)
    {
        // Validar que todo esté seleccionado
        if (string.IsNullOrEmpty(_rutaExcel))
        {
            MostrarError("Seleccione el archivo Excel.");
            return;
        }
        if (string.IsNullOrEmpty(_rutaPlantilla))
        {
            MostrarError("Seleccione la plantilla PNG del certificado.");
            return;
        }
        if (string.IsNullOrEmpty(_carpetaDestino))
        {
            MostrarError("Seleccione la carpeta de destino.");
            return;
        }
        if (!File.Exists(_rutaExcel))
        {
            MostrarError("El archivo Excel seleccionado no existe.");
            return;
        }
        if (!File.Exists(_rutaPlantilla))
        {
            MostrarError("La plantilla seleccionada no existe.");
            return;
        }
        if (string.IsNullOrWhiteSpace(txtNumeroExamen.Text))
        {
            MostrarError("Capture el número de examen.");
            return;
        }

        var numeroExamenFormateado = FormatearNumeroExamen(txtNumeroExamen.Text);
        if (string.IsNullOrWhiteSpace(numeroExamenFormateado))
        {
            MostrarError("El número de examen debe contener solo números.");
            return;
        }

        // Deshabilitar botón mientras genera
        btnGenerar.Enabled = false;
        progressBar.Value = 0;
        lblEstado.Text = "Leyendo archivo Excel...";

        try
        {
            // 1. Leer alumnos del Excel
            List<Alumno> alumnos = await Task.Run(() =>
                ExcelReaderService.LeerAlumnos(_rutaExcel));

            if (alumnos.Count == 0)
            {
                MostrarError("El archivo Excel no contiene alumnos.");
                return;
            }

            var codigosInvalidos = alumnos
                .Where(a => string.IsNullOrWhiteSpace(a.Codigo) || !Regex.IsMatch(a.Codigo, "^[A-Z]{2}[0-9]{2}$"))
                .Select(a => a.Nombre)
                .ToList();

            if (codigosInvalidos.Count > 0)
            {
                MostrarError(
                    "Hay alumnos con código inválido. Formato esperado: 2 letras + 2 números (ej. PL01).\n\n" +
                    string.Join("\n", codigosInvalidos.Take(8)) +
                    (codigosInvalidos.Count > 8 ? "\n..." : string.Empty));
                return;
            }

            progressBar.Maximum = alumnos.Count;

            // 2. Generar certificados
            var errores = new List<string>();
            AplicarAjustesDesdeInterfaz();
            _generador.NumeroExamen = numeroExamenFormateado;

            string rutaPlantilla = _rutaPlantilla;
            string carpetaDestino = _carpetaDestino;

            await Task.Run(() =>
            {
                for (int i = 0; i < alumnos.Count; i++)
                {
                    var alumno = alumnos[i];

                    try
                    {
                        _generador.GenerarCertificado(alumno, rutaPlantilla, carpetaDestino);
                    }
                    catch (Exception ex)
                    {
                        errores.Add($"{alumno.Nombre}: {ex.Message}");
                    }

                    // Reportar progreso al hilo de UI
                    int progreso = i + 1;
                    string nombre = alumno.Nombre;
                    this.Invoke(() =>
                    {
                        progressBar.Value = progreso;
                        lblEstado.Text = $"Generando {progreso}/{alumnos.Count}: {nombre}";
                    });
                }
            });

            // 3. Mostrar resultado
            if (errores.Count == 0)
            {
                progressBar.Value = progressBar.Maximum;
                lblEstado.Text = $"✅ {alumnos.Count} certificados generados correctamente.";
                MessageBox.Show(
                    $"Se generaron {alumnos.Count} certificados en:\n{_carpetaDestino}",
                    "Completado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                int exitosos = alumnos.Count - errores.Count;
                lblEstado.Text = $"⚠️ {exitosos} generados, {errores.Count} errores.";
                MessageBox.Show(
                    $"Se generaron {exitosos} certificados.\n\nErrores:\n" +
                    string.Join("\n", errores),
                    "Completado con errores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MostrarError($"Error inesperado: {ex.Message}");
            lblEstado.Text = "Error al generar certificados.";
        }
        finally
        {
            btnGenerar.Enabled = true;
        }
    }

    private static void MostrarError(string mensaje)
    {
        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void BtnActualizarPreview_Click(object? sender, EventArgs e)
    {
        ActualizarPreview();
    }

    private void CampoAjuste_Changed(object? sender, EventArgs e)
    {
        ActualizarPreview();
    }

    private void AplicarAjustesDesdeInterfaz()
    {
        _generador.Layout.NombreX = (float)numNombreX.Value;
        _generador.Layout.NombreY = ConvertirYDesdePlanoCartesiano((float)numNombreY.Value);
        _generador.Layout.NombreFontSize = (float)numNombreFuente.Value;
        _generador.Layout.NombreMaxWidth = (float)numNombreAncho.Value;

        _generador.Layout.GradoX = (float)numGradoX.Value;
        _generador.Layout.GradoY = ConvertirYDesdePlanoCartesiano((float)numGradoY.Value);
        _generador.Layout.GradoFontSize = (float)numGradoFuente.Value;
        _generador.Layout.GradoMaxWidth = (float)numGradoAncho.Value;

        _generador.Layout.CodigoX = (float)numCodigoX.Value;
        _generador.Layout.CodigoY = ConvertirYDesdePlanoCartesiano((float)numCodigoY.Value);
        _generador.Layout.CodigoFontSize = (float)numCodigoFuente.Value;
        _generador.Layout.CodigoMaxWidth = (float)numCodigoAncho.Value;

        _generador.Layout.NumeroExamenX = (float)numExamenX.Value;
        _generador.Layout.NumeroExamenY = ConvertirYDesdePlanoCartesiano((float)numExamenY.Value);
        _generador.Layout.NumeroExamenFontSize = (float)numExamenFuente.Value;
        _generador.Layout.NumeroExamenMaxWidth = (float)numExamenAncho.Value;

        _generador.NumeroExamen = FormatearNumeroExamen(txtNumeroExamen.Text);
    }

    private static float ConvertirYDesdePlanoCartesiano(float valorY)
    {
        var convertido = 1f - valorY;
        return Math.Clamp(convertido, 0f, 1f);
    }

    private static string FormatearNumeroExamen(string texto)
    {
        var match = Regex.Match(texto ?? string.Empty, @"^\s*(\d+)\s*$");
        if (!match.Success)
        {
            return string.Empty;
        }

        return $"{match.Groups[1].Value}º";
    }

    private void ActualizarPreview()
    {
        if (string.IsNullOrWhiteSpace(_rutaPlantilla) || !File.Exists(_rutaPlantilla))
        {
            return;
        }

        try
        {
            AplicarAjustesDesdeInterfaz();
            var bytes = _generador.GenerarVistaPrevia(_rutaPlantilla);

            using var ms = new MemoryStream(bytes);
            using var tempImage = Image.FromStream(ms);
            var newImage = new Bitmap(tempImage);

            var oldImage = picturePreview.Image;
            picturePreview.Image = newImage;
            oldImage?.Dispose();

            lblEstado.Text = "Preview actualizado";
        }
        catch (Exception ex)
        {
            lblEstado.Text = $"Error en preview: {ex.Message}";
        }
    }
}
