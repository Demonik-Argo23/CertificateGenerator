# Generador de Certificados

Aplicacion de escritorio en C# (.NET 8 / WinForms) para generar certificados PDF en lote a partir de un archivo Excel y una plantilla de imagen.

## Que hace la app

- Lee alumnos desde Excel (.xlsx).
- Usa una plantilla de certificado (PNG/JPG/JPEG).
- Dibuja campos configurables en la plantilla:
  - Nombre
  - Grado
  - Codigo
  - No. de examen (se formatea como ordinal: 100 -> 100o)
  - Fecha de examen
  - Profesor
  - Firma (imagen PNG transparente)
- Genera un PDF por cada alumno.
- Muestra preview con guias y controles de posicion/tamano.
- Permite cancelar la generacion en curso.

## Requisitos

- Windows 10/11
- .NET 8 SDK

Verificar:

```powershell
dotnet --version
```

## Estructura principal

```text
CertificateGenerator/
├── CertificateGenerator.sln
└── CertificateGenerator/
    ├── CertificateGenerator.csproj
    ├── Program.cs
    ├── MainForm.cs
    ├── MainForm.Designer.cs
    ├── Models/
    │   └── Alumno.cs
    ├── Services/
    │   ├── ExcelReaderService.cs
    │   └── CertificateGeneratorService.cs
    └── Media/
        └── Firma.png
```

## Formato del Excel

La app toma la primera hoja.
Encabezados en fila 1 y datos desde fila 2.

| Columna | Campo |
|---|---|
| A | Nombre |
| B | Grado |
| C | Codigo |
| D | Profesor |

Ejemplo de codigo valido: `PL001`.

## Reglas de validacion

- Codigo por alumno: `2 letras mayusculas + 3 numeros`.
  - Regex: `^[A-Z]{2}[0-9]{3}$`
- No. de examen: solo numeros.
  - Se guarda/imprime con ordinal automaticamente (`100` -> `100o`).
- Excel, plantilla y carpeta destino: obligatorios.

## Interfaz

### Configuracion

- Seleccionar Excel
- Seleccionar plantilla
- Seleccionar carpeta destino
- Numero de examen (default: `100`)
- Fecha de examen (default: `Queretaro, Qro., a DIA de MES de ANO`)

### Ajustes (plano cartesiano)

- `X`: mas grande = derecha
- `Y`: mas grande = arriba
- Se puede ajustar: X, Y, tamano y ancho para cada campo de texto.
- Para firma: X, Y y tamano.

## Valores default actuales

- Numero de Examen: `100`
- Fecha de Examen: `Queretaro, Qro., a DIA de MES de ANO`

Campos:

- Nombre: X `0.52`, Y `0.57`, Tamano `120`, Ancho `0.70` (negritas)
- Grado: X `0.50`, Y `0.49`, Tamano `100`, Ancho `0.75`
- Codigo: X `0.78`, Y `0.70`, Tamano `80`, Ancho `0.12` (Arial + negritas)
- No. Examen: X `0.50`, Y `0.38`, Tamano `100`, Ancho `0.08`
- Fecha: X `0.20`, Y `0.32`, Tamano `100`, Ancho `0.60`
- Profesor: X `0.70`, Y `0.23`, Tamano `90`, Ancho `0.37`
- Firma: X `0.17`, Y `0.21`, Tamano `0.25`

## Tipografias de impresion

- General: `Edwardian Script ITC`
- Excepcion:
  - Codigo: `Arial` en negritas

## Flujo de uso

1. Seleccionar Excel.
2. Seleccionar plantilla.
3. Seleccionar carpeta destino.
4. Revisar/editar No. de examen y Fecha.
5. Ajustar coordenadas/tamanos si hace falta.
6. Click en `Actualizar Preview`.
7. Click en `Generar Certificados`.
8. Si hace falta, usar `Cancelar` durante el proceso.

## Salida

Se genera un PDF por alumno con nombre seguro:

```text
certificado_Nombre_Apellido.pdf
```

## Compilar y ejecutar

```powershell
cd "c:\Users\EQUIPO\OneDrive\Documentos\CertificateGenerator"
dotnet restore
dotnet build
dotnet run --project CertificateGenerator
```

## Publicar ejecutable para usuarios no tecnicos

```powershell
cd "c:\Users\EQUIPO\OneDrive\Documentos\CertificateGenerator"

dotnet publish CertificateGenerator \
  -c Release \
  -r win-x64 \
  --self-contained true \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true
```

Salida:

```text
CertificateGenerator\bin\Release\net8.0-windows\win-x64\publish\CertificateGenerator.exe
```

## Dependencias

- ClosedXML
- SkiaSharp
- QuestPDF

## Problemas comunes

- `No .NET SDKs were found`
  - Instalar .NET 8 SDK (no solo runtime).
- Error de codigo invalido
  - Revisar formato `AA000`.
- La firma no aparece
  - Verificar `Media/Firma.png` y que se copie a salida (ya configurado en el csproj).
- Texto fuera de lugar
  - Ajustar X, Y y Ancho con la preview.
