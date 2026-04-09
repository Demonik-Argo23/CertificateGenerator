namespace CertificateGenerator.Models;

/// <summary>
/// Representa un alumno leído desde el archivo Excel.
/// </summary>
public class Alumno
{
    public string Nombre { get; set; } = string.Empty;
    public string Grado { get; set; } = string.Empty;
    public string Codigo { get; set; } = string.Empty;
    public string Profesor { get; set; } = string.Empty;
    public string Profesor2 { get; set; } = string.Empty;

    /// <summary>
    /// Genera el nombre de archivo seguro para el certificado PDF.
    /// Ejemplo: "Adrián López" → "certificado_Adrian_Lopez.pdf"
    /// </summary>
    public string GenerarNombreArchivo()
    {
        var nombreLimpio = Nombre
            .Normalize(System.Text.NormalizationForm.FormD);

        var sinAcentos = new string(nombreLimpio
            .Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                != System.Globalization.UnicodeCategory.NonSpacingMark)
            .ToArray());

        var seguro = sinAcentos
            .Replace(" ", "_")
            .Replace(".", "")
            .Replace(",", "");

        return $"{seguro}.pdf";
    }
}
