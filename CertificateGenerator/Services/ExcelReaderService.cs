using ClosedXML.Excel;
using CertificateGenerator.Models;

namespace CertificateGenerator.Services;

/// <summary>
/// Lee el archivo Excel y devuelve la lista de alumnos.
/// </summary>
public static class ExcelReaderService
{
    /// <summary>
    /// Lee un archivo .xlsx y retorna la lista de alumnos.
    /// Espera Columna A = Nombre, Columna B = Grado, Columna C = Codigo,
    /// Columna D = Profesor, Columna E = Profesor2 (opcional),
    /// con encabezados en fila 1.
    /// </summary>
    public static List<Alumno> LeerAlumnos(string rutaExcel)
    {
        var alumnos = new List<Alumno>();

        using var workbook = new XLWorkbook(rutaExcel);
        var worksheet = workbook.Worksheets.First();

        // Empezar desde la fila 2 (fila 1 = encabezados)
        int fila = 2;
        while (!worksheet.Cell(fila, 1).IsEmpty())
        {
            var nombre = worksheet.Cell(fila, 1).GetString().Trim();
            var grado = worksheet.Cell(fila, 2).GetString().Trim();
            var codigo = worksheet.Cell(fila, 3).GetString().Trim();
            var profesor = worksheet.Cell(fila, 4).GetString().Trim();
            var profesor2 = worksheet.Cell(fila, 5).GetString().Trim();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                alumnos.Add(new Alumno
                {
                    Nombre = nombre,
                    Grado = grado,
                    Codigo = codigo,
                    Profesor = profesor,
                    Profesor2 = profesor2
                });
            }

            fila++;
        }

        return alumnos;
    }
}
