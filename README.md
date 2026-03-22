# Generador de Certificados

Aplicación de escritorio en C# (.NET 8 / WinForms) que genera certificados PDF automáticamente a partir de un archivo Excel y una plantilla PNG.

---

## Características

- Lee una lista de alumnos desde un archivo Excel (`.xlsx`).
- Usa una imagen PNG como plantilla visual del certificado.
- Escribe el **nombre** y el **grado** del alumno sobre la plantilla.
- Genera un archivo **PDF individual** por cada alumno.

---

## Estructura del Proyecto

```
CertificateGenerator/
├── CertificateGenerator.sln
└── CertificateGenerator/
    ├── CertificateGenerator.csproj
    ├── Program.cs                          # Punto de entrada
    ├── MainForm.cs                         # Lógica de la interfaz
    ├── MainForm.Designer.cs                # Diseño de la interfaz
    ├── Models/
    │   └── Alumno.cs                       # Modelo de datos del alumno
    └── Services/
        ├── ExcelReaderService.cs           # Lectura del archivo Excel
        └── CertificateGeneratorService.cs  # Generación de certificados PDF
```

---

## Requisitos Previos

- **Windows 10/11**
- **.NET 8 SDK** 

Verifica la instalación:

```powershell
dotnet --version
```

---

## Instalación y Ejecución

```powershell
# 1. Clonar o descargar el proyecto
cd CertificateGenerator

# 2. Restaurar paquetes NuGet
dotnet restore

# 3. Compilar
dotnet build

# 4. Ejecutar
dotnet run --project CertificateGenerator
```

---

## Paquetes NuGet Utilizados

| Paquete | Versión | Uso |
|---------|---------|-----|
| [ClosedXML](https://github.com/ClosedXML/ClosedXML) | 0.104.2 | Leer archivos Excel `.xlsx` |
| [QuestPDF](https://www.questpdf.com/) | 2024.12.2 | Generar documentos PDF |
| [SkiaSharp](https://github.com/mono/SkiaSharp) | 3.116.1 | Dibujar texto sobre la imagen plantilla |

---

## Cómo Usar

### 1. Preparar el Excel

Crea un archivo `.xlsx` con esta estructura (fila 1 = encabezados):

| Nombre | Grado |
|--------|-------|
| Adrián López | Cinta Azul |
| María Pérez | Cinta Roja |
| Carlos Díaz | Cinta Negra |

### 2. Preparar la Plantilla

Usa una imagen **PNG** con el diseño visual del certificado. El texto del nombre y grado se dibujará centrado sobre esta imagen.

### 3. Ejecutar la Aplicación

1. Clic en **Seleccionar Excel** → elegir el archivo `.xlsx`.
2. Clic en **Seleccionar Plantilla** → elegir la imagen PNG.
3. Clic en **Seleccionar Carpeta** → elegir dónde guardar los PDFs.
4. Clic en **Generar Certificados** → se crearán los PDFs automáticamente.

### 4. Resultado

Los archivos se generan con el formato:

```
certificado_Adrian_Lopez.pdf
certificado_Maria_Perez.pdf
certificado_Carlos_Diaz.pdf
```

---

## Personalización del Texto

En el archivo `Services/CertificateGeneratorService.cs` puedes ajustar la posición y estilo del texto:

```csharp
// Posición vertical (0.0 = arriba, 0.5 = centro, 1.0 = abajo)
public float NombrePosicionY { get; set; } = 0.50f;
public float GradoPosicionY  { get; set; } = 0.58f;

// Tamaño de fuente (en píxeles)
public float NombreFontSize { get; set; } = 72f;
public float GradoFontSize  { get; set; } = 48f;

// Color del texto (hexadecimal)
public string NombreColor { get; set; } = "#1a1a2e";
public string GradoColor  { get; set; } = "#16213e";
```

### Ejemplos de Ajuste

| Qué cambiar | Propiedad | Valor ejemplo |
|-------------|-----------|---------------|
| Nombre más arriba | `NombrePosicionY` | `0.40f` |
| Nombre más abajo | `NombrePosicionY` | `0.60f` |
| Fuente más grande | `NombreFontSize` | `96f` |
| Texto en rojo | `NombreColor` | `"#cc0000"` |

El texto siempre se centra horizontalmente de forma automática.

---

## Solución de Problemas

| Problema | Solución |
|----------|----------|
| `No .NET SDKs were found` | Instala el [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (no solo el Runtime) |
| El texto no se ve en el PDF | Ajusta `NombrePosicionY` / `GradoPosicionY` según el tamaño de tu plantilla |
| Error al leer el Excel | Verifica que la fila 1 tenga encabezados y los datos empiecen en la fila 2 |
| Caracteres extraños en el nombre del archivo | Los acentos se eliminan automáticamente del nombre de archivo |
