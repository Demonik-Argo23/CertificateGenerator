using CertificateGenerator.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace CertificateGenerator.Services;

/// <summary>
/// Genera certificados PDF a partir de una plantilla PNG y los datos del alumno.
/// </summary>
public class CertificateGeneratorService
{
    public CertificateLayoutOptions Layout { get; } = new();

    public string NumeroExamen { get; set; } = string.Empty;

    /// <summary>
    /// Genera un certificado PDF para un alumno dado.
    /// </summary>
    /// <param name="alumno">Datos del alumno</param>
    /// <param name="rutaPlantilla">Ruta a la imagen PNG de la plantilla</param>
    /// <param name="carpetaDestino">Carpeta donde guardar el PDF</param>
    /// <returns>Ruta completa del PDF generado</returns>
    public string GenerarCertificado(Alumno alumno, string rutaPlantilla, string carpetaDestino)
    {
        // 1. Cargar la plantilla y dibujar el texto
        byte[] imagenConTexto = DibujarTextoEnPlantilla(alumno, rutaPlantilla, NumeroExamen, false);

        // 2. Generar el PDF con QuestPDF
        var nombreArchivo = alumno.GenerarNombreArchivo();
        var rutaPdf = Path.Combine(carpetaDestino, nombreArchivo);

        GenerarPdf(imagenConTexto, rutaPdf);

        return rutaPdf;
    }

    /// <summary>
    /// Genera todos los certificados de una lista de alumnos.
    /// Reporta progreso mediante el callback.
    /// </summary>
    public List<string> GenerarTodos(
        List<Alumno> alumnos,
        string rutaPlantilla,
        string carpetaDestino,
        Action<int, int, string>? onProgreso = null)
    {
        var archivosGenerados = new List<string>();

        for (int i = 0; i < alumnos.Count; i++)
        {
            var alumno = alumnos[i];
            onProgreso?.Invoke(i + 1, alumnos.Count, alumno.Nombre);

            var ruta = GenerarCertificado(alumno, rutaPlantilla, carpetaDestino);
            archivosGenerados.Add(ruta);
        }

        return archivosGenerados;
    }

    /// <summary>
    /// Usa SkiaSharp para dibujar nombre, grado, código y número de examen sobre la plantilla PNG.
    /// Devuelve la imagen resultante como byte[] PNG.
    /// </summary>
    private byte[] DibujarTextoEnPlantilla(
        Alumno alumno,
        string rutaPlantilla,
        string numeroExamen,
        bool dibujarGuias)
    {
        using var plantillaStream = File.OpenRead(rutaPlantilla);
        using var plantilla = SKBitmap.Decode(plantillaStream);

        int ancho = plantilla.Width;
        int alto = plantilla.Height;

        using var surface = SKSurface.Create(new SKImageInfo(ancho, alto));
        var canvas = surface.Canvas;

        // Dibujar la plantilla de fondo
        canvas.DrawBitmap(plantilla, 0, 0);

        DibujarCampoTexto(
            canvas,
            alumno.Nombre,
            ancho,
            alto,
            Layout.NombreX,
            Layout.NombreY,
            Layout.NombreFontSize,
            Layout.NombreMaxWidth,
            Layout.NombreColor,
            Layout.NombreFontFamily,
            true,
            SKTextAlign.Center,
            dibujarGuias,
            "NOMBRE");

        DibujarCampoTexto(
            canvas,
            alumno.Grado,
            ancho,
            alto,
            Layout.GradoX,
            Layout.GradoY,
            Layout.GradoFontSize,
            Layout.GradoMaxWidth,
            Layout.GradoColor,
            Layout.GradoFontFamily,
            false,
            SKTextAlign.Center,
            dibujarGuias,
            "GRADO");

        DibujarCampoTexto(
            canvas,
            alumno.Codigo,
            ancho,
            alto,
            Layout.CodigoX,
            Layout.CodigoY,
            Layout.CodigoFontSize,
            Layout.CodigoMaxWidth,
            Layout.CodigoColor,
            Layout.CodigoFontFamily,
            true,
            SKTextAlign.Left,
            dibujarGuias,
            "CODIGO");

        DibujarCampoTexto(
            canvas,
            numeroExamen,
            ancho,
            alto,
            Layout.NumeroExamenX,
            Layout.NumeroExamenY,
            Layout.NumeroExamenFontSize,
            Layout.NumeroExamenMaxWidth,
            Layout.NumeroExamenColor,
            Layout.NumeroExamenFontFamily,
            false,
            SKTextAlign.Left,
            dibujarGuias,
            "EXAMEN");

        canvas.Flush();

        // Codificar como PNG en memoria
        using var imagen = surface.Snapshot();
        using var data = imagen.Encode(SKEncodedImageFormat.Png, 100);
        return data.ToArray();
    }

    public byte[] GenerarVistaPrevia(string rutaPlantilla)
    {
        var alumnoDemo = new Alumno
        {
            Nombre = "NOMBRE ALUMNO DEMO",
            Grado = "CINTA NEGRA",
            Codigo = "PL01"
        };

        var examenDemo = string.IsNullOrWhiteSpace(NumeroExamen) ? "12" : NumeroExamen;
        return DibujarTextoEnPlantilla(alumnoDemo, rutaPlantilla, examenDemo, true);
    }

    private static void DibujarCampoTexto(
        SKCanvas canvas,
        string texto,
        int ancho,
        int alto,
        float xRatio,
        float yRatio,
        float tamanoFuente,
        float maxWidthRatio,
        string colorHex,
        string fontFamily,
        bool negrita,
        SKTextAlign alineacion,
        bool dibujarGuia,
        string etiqueta)
    {
        float x = ancho * xRatio;
        float y = alto * yRatio;
        float maxWidth = ancho * maxWidthRatio;

        using var paint = new SKPaint
        {
            Color = SKColor.Parse(colorHex),
            TextSize = tamanoFuente,
            IsAntialias = true,
            TextAlign = alineacion,
            Typeface = SKTypeface.FromFamilyName(fontFamily, negrita ? SKFontStyle.Bold : SKFontStyle.Normal)
        };

        var textoSeguro = string.IsNullOrWhiteSpace(texto) ? " " : texto.Trim();
        while (paint.MeasureText(textoSeguro) > maxWidth && paint.TextSize > 10f)
        {
            paint.TextSize -= 1f;
        }

        canvas.DrawText(textoSeguro, x, y, paint);

        if (!dibujarGuia)
        {
            return;
        }

        float left = alineacion switch
        {
            SKTextAlign.Center => x - (maxWidth / 2f),
            SKTextAlign.Right => x - maxWidth,
            _ => x
        };

        using var guidePaint = new SKPaint
        {
            Color = SKColor.Parse("#E53935"),
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 2
        };

        var bounds = new SKRect(left, y - paint.TextSize, left + maxWidth, y + 8f);
        canvas.DrawRect(bounds, guidePaint);

        using var labelPaint = new SKPaint
        {
            Color = SKColor.Parse("#E53935"),
            TextSize = 14,
            IsAntialias = true,
            TextAlign = SKTextAlign.Left,
            Typeface = SKTypeface.FromFamilyName("Segoe UI", SKFontStyle.Bold)
        };
        canvas.DrawText(etiqueta, bounds.Left, bounds.Top - 4, labelPaint);
    }

    /// <summary>
    /// Genera un PDF de una sola página con la imagen del certificado.
    /// La página tiene el mismo tamaño que la imagen.
    /// </summary>
    private static void GenerarPdf(byte[] imagenPng, string rutaPdf)
    {
        // Obtener dimensiones de la imagen para definir el tamaño de página
        using var bitmap = SKBitmap.Decode(imagenPng);
        float anchoEnPuntos = bitmap.Width * 72f / 96f;  // px → puntos (72 DPI PDF)
        float altoEnPuntos = bitmap.Height * 72f / 96f;

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(anchoEnPuntos, altoEnPuntos, Unit.Point);
                page.Margin(0);

                page.Content().Image(imagenPng);
            });
        })
        .GeneratePdf(rutaPdf);
    }
}

public class CertificateLayoutOptions
{
    public float NombreX { get; set; } = 0.50f;
    public float NombreY { get; set; } = 0.43f;
    public float NombreFontSize { get; set; } = 100f;
    public float NombreMaxWidth { get; set; } = 0.60f;
    public string NombreFontFamily { get; set; } = "Monotype Corsiva";
    public string NombreColor { get; set; } = "#1a1a2e";

    public float GradoX { get; set; } = 0.50f;
    public float GradoY { get; set; } = 0.51f;
    public float GradoFontSize { get; set; } = 90f;
    public float GradoMaxWidth { get; set; } = 0.60f;
    public string GradoFontFamily { get; set; } = "Monotype Corsiva";
    public string GradoColor { get; set; } = "#16213e";

    public float CodigoX { get; set; } = 0.78f;
    public float CodigoY { get; set; } = 0.30f;
    public float CodigoFontSize { get; set; } = 80f;
    public float CodigoMaxWidth { get; set; } = 0.10f;
    public string CodigoFontFamily { get; set; } = "Monotype Corsiva";
    public string CodigoColor { get; set; } = "#1a1a2e";

    public float NumeroExamenX { get; set; } = 0.48f;
    public float NumeroExamenY { get; set; } = 0.63f;
    public float NumeroExamenFontSize { get; set; } = 80f;
    public float NumeroExamenMaxWidth { get; set; } = 0.15f;
    public string NumeroExamenFontFamily { get; set; } = "Monotype Corsiva";
    public string NumeroExamenColor { get; set; } = "#1a1a2e";
}
