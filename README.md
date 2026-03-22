# Generador de Certificados

Aplicación de escritorio en C# (.NET 8 / WinForms) para generar certificados PDF de forma masiva a partir de un Excel y una plantilla de imagen.

## Características actuales

- Lectura de alumnos desde Excel (`.xlsx`) con columnas: **Nombre, Grado, Código**.
- Generación de **un PDF por alumno** usando plantilla de imagen (`.png`, `.jpg`, `.jpeg`).
- Renderizado de 4 campos sobre la plantilla:
    - Nombre
    - Grado
    - Código
    - Número de examen
- Validaciones antes de generar:
    - Excel, plantilla y carpeta destino obligatorios.
    - Número de examen obligatorio y numérico (se formatea como `12º`).
    - Código por alumno con formato `AA00` (ejemplo: `PL01`).
- Vista previa en la interfaz con guías de posición para ajustar texto.
- Barra de progreso y resumen final de éxitos/errores.

## Requisitos

- Windows 10/11
- .NET 8 SDK

Verificar instalación:

```powershell
dotnet --version
```

## Ejecución

```powershell
dotnet restore
dotnet build
dotnet run --project CertificateGenerator
```

## Formato del Excel

Encabezados en fila 1 y datos desde fila 2.

| Nombre | Grado | Código |
|--------|-------|--------|
| Adrián López | Cinta Azul | PL01 |
| María Pérez | Cinta Roja | PL02 |
| Carlos Díaz | Cinta Negra | PL03 |

Notas:

- La lectura se realiza sobre la primera hoja del archivo.
- El ciclo termina cuando la columna A (Nombre) aparece vacía.

## Flujo de uso

1. Seleccionar archivo Excel.
2. Seleccionar plantilla de certificado.
3. Seleccionar carpeta destino.
4. Capturar número de examen.
5. Ajustar posiciones/tamaños (opcional) y revisar preview.
6. Generar certificados.

## Nombres de archivos generados

Formato:

```text
certificado_{NombreNormalizado}.pdf
```

Ejemplo:

```text
certificado_Adrian_Lopez.pdf
```

Se eliminan acentos y algunos caracteres para producir nombres seguros.

## Ajustes de layout

La app permite ajustar desde la interfaz (preview en tiempo real):

- Posición X/Y
- Tamaño de fuente
- Ancho máximo del texto

Campos configurables:

- Nombre
- Grado
- Código
- Número de examen

Referencia técnica: `CertificateLayoutOptions` en `CertificateGenerator/Services/CertificateGeneratorService.cs`.

## Dependencias principales

- ClosedXML: lectura de Excel.
- SkiaSharp: dibujo de texto sobre plantilla.
- QuestPDF: creación de PDF final.

## Solución de problemas

| Problema | Solución |
|----------|----------|
| `No .NET SDKs were found` | Instala .NET 8 SDK (no solo Runtime). |
| "Hay alumnos con código inválido" | Corrige códigos al formato `AA00` (2 letras mayúsculas + 2 números). |
| "Capture el número de examen" o error de examen | Ingresa solo dígitos (ej. `12`, se guardará como `12º`). |
| El texto no cae en la posición correcta | Ajusta X/Y y ancho máximo desde la interfaz usando la vista previa. |
| Error al leer Excel | Revisa encabezados en fila 1 y datos desde fila 2 en la primera hoja. |
