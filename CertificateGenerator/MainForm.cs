using CertificateGenerator.Models;
using CertificateGenerator.Services;
using System.Text.RegularExpressions;
using System.Threading;

namespace CertificateGenerator;

public partial class MainForm : Form
{
    private string? _rutaExcel;
    private string? _rutaPlantilla;
    private string? _carpetaDestino;
    private readonly CertificateGeneratorService _generador = new();
    private CancellationTokenSource? _cancelacionCts;

    public MainForm()
    {
        InitializeComponent();
        CargarLogo();
        _generador.RutaFirma = ObtenerRutaFirma();
        ActualizarPreview();
    }

    private void CargarLogo()
    {
        string? rutaLogo = ObtenerRutaLogo();
        if (string.IsNullOrWhiteSpace(rutaLogo) || !File.Exists(rutaLogo))
        {
            return;
        }

        try
        {
            pictureLogo.Image = Image.FromFile(rutaLogo);
            pictureLogo.BringToFront();
        }
        catch
        {
            // Si el logo falla al cargar, la app continúa normalmente.
        }
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

    // ─── Seleccionar plantilla de imagen ───────────────────────────────
    private void BtnSeleccionarPlantilla_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Seleccionar plantilla de certificado",
            Filter = "Todas las imágenes (*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff;*.webp)|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff;*.webp|Imágenes PNG (*.png)|*.png|Imágenes JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Imágenes BMP (*.bmp)|*.bmp|Imágenes GIF (*.gif)|*.gif|Imágenes TIFF (*.tif;*.tiff)|*.tif;*.tiff|Imágenes WEBP (*.webp)|*.webp",
            FilterIndex = 1,
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
            MostrarError("Seleccione la plantilla de imagen del certificado.");
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
        if (string.IsNullOrWhiteSpace(txtFechaExamen.Text))
        {
            MostrarError("Capture la fecha del examen.");
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
        btnCancelar.Enabled = true;
        progressBar.Value = 0;
        lblEstado.Text = "Leyendo archivo Excel...";
        _cancelacionCts?.Dispose();
        _cancelacionCts = new CancellationTokenSource();
        var token = _cancelacionCts.Token;

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
                .Where(a => string.IsNullOrWhiteSpace(a.Codigo) || !Regex.IsMatch(a.Codigo, "^[A-Z]{2}[0-9]{3}$"))
                .Select(a => a.Nombre)
                .ToList();

            if (codigosInvalidos.Count > 0)
            {
                MostrarError(
                    "Hay alumnos con código inválido. Formato esperado: 2 letras + 3 números (ej. PL001).\n\n" +
                    string.Join("\n", codigosInvalidos.Take(8)) +
                    (codigosInvalidos.Count > 8 ? "\n..." : string.Empty));
                return;
            }

            progressBar.Maximum = alumnos.Count;

            // 2. Generar certificados
            var errores = new List<string>();
            AplicarAjustesDesdeInterfaz();
            _generador.NumeroExamen = numeroExamenFormateado;
            _generador.FechaExamen = txtFechaExamen.Text.Trim();

            string rutaPlantilla = _rutaPlantilla;
            string carpetaDestino = _carpetaDestino;

            await Task.Run(() =>
            {
                for (int i = 0; i < alumnos.Count; i++)
                {
                    token.ThrowIfCancellationRequested();

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
            }, token);

            if (token.IsCancellationRequested)
            {
                lblEstado.Text = "Operación cancelada.";
                return;
            }

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
        catch (OperationCanceledException)
        {
            lblEstado.Text = "Operación cancelada por el usuario.";
            MessageBox.Show(
                "La generación de certificados fue cancelada.",
                "Cancelado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MostrarError($"Error inesperado: {ex.Message}");
            lblEstado.Text = "Error al generar certificados.";
        }
        finally
        {
            btnGenerar.Enabled = true;
            btnCancelar.Enabled = false;
            _cancelacionCts?.Dispose();
            _cancelacionCts = null;
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

    private void BtnCancelar_Click(object? sender, EventArgs e)
    {
        _cancelacionCts?.Cancel();
        btnCancelar.Enabled = false;
        lblEstado.Text = "Cancelando operación...";
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

        _generador.Layout.FechaExamenX = (float)numFechaX.Value;
        _generador.Layout.FechaExamenY = ConvertirYDesdePlanoCartesiano((float)numFechaY.Value);
        _generador.Layout.FechaExamenFontSize = (float)numFechaFuente.Value;
        _generador.Layout.FechaExamenMaxWidth = (float)numFechaAncho.Value;

        _generador.Layout.ProfesorX = (float)numProfesorX.Value;
        _generador.Layout.ProfesorY = ConvertirYDesdePlanoCartesiano((float)numProfesorY.Value);
        _generador.Layout.ProfesorFontSize = (float)numProfesorFuente.Value;
        _generador.Layout.ProfesorMaxWidth = (float)numProfesorAncho.Value;
        _generador.Layout.Profesor2X = (float)numProfesor2X.Value;
        _generador.Layout.Profesor2Y = ConvertirYDesdePlanoCartesiano((float)numProfesor2Y.Value);

        _generador.Layout.FirmaX = (float)numFirmaX.Value;
        _generador.Layout.FirmaY = ConvertirYDesdePlanoCartesiano((float)numFirmaY.Value);
        _generador.Layout.FirmaWidth = (float)numFirmaTamano.Value;

        _generador.NumeroExamen = FormatearNumeroExamen(txtNumeroExamen.Text);
        _generador.FechaExamen = txtFechaExamen.Text.Trim();
    }

    private string? ObtenerRutaFirma()
    {
        string baseDir = AppContext.BaseDirectory;
        string[] candidates =
        {
            Path.Combine(baseDir, "Media", "Firma.png"),
            Path.Combine(baseDir, "Firma.png"),
            Path.Combine(Directory.GetCurrentDirectory(), "Media", "Firma.png")
        };

        return candidates.FirstOrDefault(File.Exists);
    }

    private static string? ObtenerRutaLogo()
    {
        string baseDir = AppContext.BaseDirectory;
        string[] candidates =
        {
            Path.Combine(baseDir, "Media", "Jaguares.png"),
            Path.Combine(baseDir, "Jaguares.png"),
            Path.Combine(Directory.GetCurrentDirectory(), "Media", "Jaguares.png")
        };

        return candidates.FirstOrDefault(File.Exists);
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
