using QuestPDF.Infrastructure;

namespace CertificateGenerator;

static class Program
{
    [STAThread]
    static void Main()
    {
        // QuestPDF Community license (gratis para uso con ingresos < $1M USD/año)
        QuestPDF.Settings.License = LicenseType.Community;

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
