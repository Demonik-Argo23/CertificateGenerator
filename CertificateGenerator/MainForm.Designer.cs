namespace CertificateGenerator;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblTitulo = new Label();
        this.grpArchivos = new GroupBox();
        this.lblNumeroExamen = new Label();
        this.txtNumeroExamen = new TextBox();
        this.btnSeleccionarExcel = new Button();
        this.lblExcel = new Label();
        this.btnSeleccionarPlantilla = new Button();
        this.lblPlantilla = new Label();
        this.btnSeleccionarCarpeta = new Button();
        this.lblCarpeta = new Label();
        this.grpAjustes = new GroupBox();
        this.tableAjustes = new TableLayoutPanel();
        this.lblAjusteNombre = new Label();
        this.lblAjusteGrado = new Label();
        this.lblAjusteCodigo = new Label();
        this.lblAjusteExamen = new Label();
        this.lblColX = new Label();
        this.lblColY = new Label();
        this.lblColFuente = new Label();
        this.lblColAncho = new Label();
        this.numNombreX = new NumericUpDown();
        this.numNombreY = new NumericUpDown();
        this.numNombreFuente = new NumericUpDown();
        this.numNombreAncho = new NumericUpDown();
        this.numGradoX = new NumericUpDown();
        this.numGradoY = new NumericUpDown();
        this.numGradoFuente = new NumericUpDown();
        this.numGradoAncho = new NumericUpDown();
        this.numCodigoX = new NumericUpDown();
        this.numCodigoY = new NumericUpDown();
        this.numCodigoFuente = new NumericUpDown();
        this.numCodigoAncho = new NumericUpDown();
        this.numExamenX = new NumericUpDown();
        this.numExamenY = new NumericUpDown();
        this.numExamenFuente = new NumericUpDown();
        this.numExamenAncho = new NumericUpDown();
        this.btnActualizarPreview = new Button();
        this.grpPreview = new GroupBox();
        this.picturePreview = new PictureBox();
        this.btnGenerar = new Button();
        this.progressBar = new ProgressBar();
        this.lblEstado = new Label();
        this.grpArchivos.SuspendLayout();
        this.grpAjustes.SuspendLayout();
        this.tableAjustes.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numNombreX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numNombreY).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numNombreFuente).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numNombreAncho).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numGradoX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numGradoY).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numGradoFuente).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numGradoAncho).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numCodigoX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numCodigoY).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numCodigoFuente).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numCodigoAncho).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numExamenX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numExamenY).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numExamenFuente).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numExamenAncho).BeginInit();
        this.grpPreview.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.picturePreview).BeginInit();
        this.SuspendLayout();

        // ─── lblTitulo ─────────────────────────────────────────
        this.lblTitulo.Dock = DockStyle.Top;
        this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        this.lblTitulo.ForeColor = Color.FromArgb(26, 26, 46);
        this.lblTitulo.Location = new Point(0, 0);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new Size(1240, 50);
        this.lblTitulo.Text = "Generador de Certificados";
        this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

        // ─── grpArchivos ───────────────────────────────────────
        this.grpArchivos.Controls.Add(this.btnSeleccionarExcel);
        this.grpArchivos.Controls.Add(this.lblExcel);
        this.grpArchivos.Controls.Add(this.btnSeleccionarPlantilla);
        this.grpArchivos.Controls.Add(this.lblPlantilla);
        this.grpArchivos.Controls.Add(this.btnSeleccionarCarpeta);
        this.grpArchivos.Controls.Add(this.lblCarpeta);
        this.grpArchivos.Controls.Add(this.lblNumeroExamen);
        this.grpArchivos.Controls.Add(this.txtNumeroExamen);
        this.grpArchivos.Font = new Font("Segoe UI", 10F);
        this.grpArchivos.Location = new Point(20, 60);
        this.grpArchivos.Name = "grpArchivos";
        this.grpArchivos.Size = new Size(560, 260);
        this.grpArchivos.Text = "Configuración";

        // ─── lblNumeroExamen ─────────────────────────────────
        this.lblNumeroExamen.Location = new Point(15, 200);
        this.lblNumeroExamen.Name = "lblNumeroExamen";
        this.lblNumeroExamen.Size = new Size(170, 30);
        this.lblNumeroExamen.Text = "Número de examen:";
        this.lblNumeroExamen.TextAlign = ContentAlignment.MiddleLeft;

        // ─── txtNumeroExamen ─────────────────────────────────
        this.txtNumeroExamen.Location = new Point(195, 202);
        this.txtNumeroExamen.Name = "txtNumeroExamen";
        this.txtNumeroExamen.Size = new Size(120, 25);
        this.txtNumeroExamen.Text = "12";
        this.txtNumeroExamen.TextChanged += CampoAjuste_Changed;

        // ─── btnSeleccionarExcel ────────────────────────────────
        this.btnSeleccionarExcel.Location = new Point(15, 35);
        this.btnSeleccionarExcel.Name = "btnSeleccionarExcel";
        this.btnSeleccionarExcel.Size = new Size(170, 40);
        this.btnSeleccionarExcel.Text = "Seleccionar Excel";
        this.btnSeleccionarExcel.UseVisualStyleBackColor = true;
        this.btnSeleccionarExcel.Click += BtnSeleccionarExcel_Click;

        // ─── lblExcel ──────────────────────────────────────────
        this.lblExcel.AutoEllipsis = true;
        this.lblExcel.ForeColor = Color.Gray;
        this.lblExcel.Location = new Point(195, 35);
        this.lblExcel.Name = "lblExcel";
        this.lblExcel.Size = new Size(345, 40);
        this.lblExcel.Text = "Ningún archivo seleccionado";
        this.lblExcel.TextAlign = ContentAlignment.MiddleLeft;

        // ─── btnSeleccionarPlantilla ────────────────────────────
        this.btnSeleccionarPlantilla.Location = new Point(15, 90);
        this.btnSeleccionarPlantilla.Name = "btnSeleccionarPlantilla";
        this.btnSeleccionarPlantilla.Size = new Size(170, 40);
        this.btnSeleccionarPlantilla.Text = "Seleccionar Plantilla";
        this.btnSeleccionarPlantilla.UseVisualStyleBackColor = true;
        this.btnSeleccionarPlantilla.Click += BtnSeleccionarPlantilla_Click;

        // ─── lblPlantilla ──────────────────────────────────────
        this.lblPlantilla.AutoEllipsis = true;
        this.lblPlantilla.ForeColor = Color.Gray;
        this.lblPlantilla.Location = new Point(195, 90);
        this.lblPlantilla.Name = "lblPlantilla";
        this.lblPlantilla.Size = new Size(345, 40);
        this.lblPlantilla.Text = "Ningún archivo seleccionado";
        this.lblPlantilla.TextAlign = ContentAlignment.MiddleLeft;

        // ─── btnSeleccionarCarpeta ──────────────────────────────
        this.btnSeleccionarCarpeta.Location = new Point(15, 145);
        this.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
        this.btnSeleccionarCarpeta.Size = new Size(170, 40);
        this.btnSeleccionarCarpeta.Text = "Seleccionar Carpeta";
        this.btnSeleccionarCarpeta.UseVisualStyleBackColor = true;
        this.btnSeleccionarCarpeta.Click += BtnSeleccionarCarpeta_Click;

        // ─── lblCarpeta ────────────────────────────────────────
        this.lblCarpeta.AutoEllipsis = true;
        this.lblCarpeta.ForeColor = Color.Gray;
        this.lblCarpeta.Location = new Point(195, 145);
        this.lblCarpeta.Name = "lblCarpeta";
        this.lblCarpeta.Size = new Size(345, 40);
        this.lblCarpeta.Text = "Ninguna carpeta seleccionada";
        this.lblCarpeta.TextAlign = ContentAlignment.MiddleLeft;

        // ─── grpAjustes ───────────────────────────────────────
        this.grpAjustes.Controls.Add(this.tableAjustes);
        this.grpAjustes.Controls.Add(this.btnActualizarPreview);
        this.grpAjustes.Font = new Font("Segoe UI", 10F);
        this.grpAjustes.Location = new Point(20, 330);
        this.grpAjustes.Name = "grpAjustes";
        this.grpAjustes.Size = new Size(560, 330);
        this.grpAjustes.Text = "Ajustes de Texto (proporcional 0.00 - 1.00)";

        // ─── tableAjustes ─────────────────────────────────────
        this.tableAjustes.ColumnCount = 5;
        this.tableAjustes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        this.tableAjustes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
        this.tableAjustes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
        this.tableAjustes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        this.tableAjustes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        this.tableAjustes.Controls.Add(this.lblColX, 1, 0);
        this.tableAjustes.Controls.Add(this.lblColY, 2, 0);
        this.tableAjustes.Controls.Add(this.lblColFuente, 3, 0);
        this.tableAjustes.Controls.Add(this.lblColAncho, 4, 0);
        this.tableAjustes.Controls.Add(this.lblAjusteNombre, 0, 1);
        this.tableAjustes.Controls.Add(this.lblAjusteGrado, 0, 2);
        this.tableAjustes.Controls.Add(this.lblAjusteCodigo, 0, 3);
        this.tableAjustes.Controls.Add(this.lblAjusteExamen, 0, 4);
        this.tableAjustes.Controls.Add(this.numNombreX, 1, 1);
        this.tableAjustes.Controls.Add(this.numNombreY, 2, 1);
        this.tableAjustes.Controls.Add(this.numNombreFuente, 3, 1);
        this.tableAjustes.Controls.Add(this.numNombreAncho, 4, 1);
        this.tableAjustes.Controls.Add(this.numGradoX, 1, 2);
        this.tableAjustes.Controls.Add(this.numGradoY, 2, 2);
        this.tableAjustes.Controls.Add(this.numGradoFuente, 3, 2);
        this.tableAjustes.Controls.Add(this.numGradoAncho, 4, 2);
        this.tableAjustes.Controls.Add(this.numCodigoX, 1, 3);
        this.tableAjustes.Controls.Add(this.numCodigoY, 2, 3);
        this.tableAjustes.Controls.Add(this.numCodigoFuente, 3, 3);
        this.tableAjustes.Controls.Add(this.numCodigoAncho, 4, 3);
        this.tableAjustes.Controls.Add(this.numExamenX, 1, 4);
        this.tableAjustes.Controls.Add(this.numExamenY, 2, 4);
        this.tableAjustes.Controls.Add(this.numExamenFuente, 3, 4);
        this.tableAjustes.Controls.Add(this.numExamenAncho, 4, 4);
        this.tableAjustes.Location = new Point(12, 30);
        this.tableAjustes.Name = "tableAjustes";
        this.tableAjustes.RowCount = 5;
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        this.tableAjustes.Size = new Size(535, 225);

        // ─── Encabezados columnas ─────────────────────────────
        this.lblColX.Text = "X";
        this.lblColX.TextAlign = ContentAlignment.MiddleCenter;
        this.lblColX.Dock = DockStyle.Fill;
        this.lblColY.Text = "Y (↑ +)";
        this.lblColY.TextAlign = ContentAlignment.MiddleCenter;
        this.lblColY.Dock = DockStyle.Fill;
        this.lblColFuente.Text = "Tamaño fuente";
        this.lblColFuente.TextAlign = ContentAlignment.MiddleCenter;
        this.lblColFuente.Dock = DockStyle.Fill;
        this.lblColAncho.Text = "Ancho máximo";
        this.lblColAncho.TextAlign = ContentAlignment.MiddleCenter;
        this.lblColAncho.Dock = DockStyle.Fill;

        // ─── Etiquetas de filas ───────────────────────────────
        this.lblAjusteNombre.Text = "Nombre";
        this.lblAjusteNombre.TextAlign = ContentAlignment.MiddleLeft;
        this.lblAjusteNombre.Dock = DockStyle.Fill;
        this.lblAjusteGrado.Text = "Grado";
        this.lblAjusteGrado.TextAlign = ContentAlignment.MiddleLeft;
        this.lblAjusteGrado.Dock = DockStyle.Fill;
        this.lblAjusteCodigo.Text = "Código";
        this.lblAjusteCodigo.TextAlign = ContentAlignment.MiddleLeft;
        this.lblAjusteCodigo.Dock = DockStyle.Fill;
        this.lblAjusteExamen.Text = "No. examen";
        this.lblAjusteExamen.TextAlign = ContentAlignment.MiddleLeft;
        this.lblAjusteExamen.Dock = DockStyle.Fill;

        // ─── Numeric controls ─────────────────────────────────
        ConfigurarNumericRango(this.numNombreX, 0.50m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numNombreY, 0.57m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numNombreFuente, 100, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numNombreAncho, 0.60m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numGradoX, 0.50m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numGradoY, 0.49m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numGradoFuente, 90, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numGradoAncho, 0.60m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numCodigoX, 0.78m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numCodigoY, 0.70m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numCodigoFuente, 80, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numCodigoAncho, 0.10m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numExamenX, 0.48m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numExamenY, 0.37m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numExamenFuente, 80, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numExamenAncho, 0.15m, 0.01m, 1m, CampoAjuste_Changed);

        // ─── btnActualizarPreview ─────────────────────────────
        this.btnActualizarPreview.Location = new Point(12, 268);
        this.btnActualizarPreview.Name = "btnActualizarPreview";
        this.btnActualizarPreview.Size = new Size(180, 40);
        this.btnActualizarPreview.Text = "Actualizar Preview";
        this.btnActualizarPreview.UseVisualStyleBackColor = true;
        this.btnActualizarPreview.Click += BtnActualizarPreview_Click;

        // ─── grpPreview ───────────────────────────────────────
        this.grpPreview.Controls.Add(this.picturePreview);
        this.grpPreview.Font = new Font("Segoe UI", 10F);
        this.grpPreview.Location = new Point(600, 60);
        this.grpPreview.Name = "grpPreview";
        this.grpPreview.Size = new Size(620, 600);
        this.grpPreview.Text = "Preview del Certificado";

        // ─── picturePreview ───────────────────────────────────
        this.picturePreview.BackColor = Color.White;
        this.picturePreview.BorderStyle = BorderStyle.FixedSingle;
        this.picturePreview.Dock = DockStyle.Fill;
        this.picturePreview.Name = "picturePreview";
        this.picturePreview.SizeMode = PictureBoxSizeMode.Zoom;

        // ─── btnGenerar ────────────────────────────────────────
        this.btnGenerar.BackColor = Color.FromArgb(22, 33, 62);
        this.btnGenerar.FlatStyle = FlatStyle.Flat;
        this.btnGenerar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        this.btnGenerar.ForeColor = Color.White;
        this.btnGenerar.Location = new Point(600, 670);
        this.btnGenerar.Name = "btnGenerar";
        this.btnGenerar.Size = new Size(620, 50);
        this.btnGenerar.Text = "Generar Certificados";
        this.btnGenerar.UseVisualStyleBackColor = false;
        this.btnGenerar.Click += BtnGenerar_Click;

        // ─── progressBar ───────────────────────────────────────
        this.progressBar.Location = new Point(20, 670);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new Size(560, 25);
        this.progressBar.Style = ProgressBarStyle.Continuous;

        // ─── lblEstado ─────────────────────────────────────────
        this.lblEstado.Font = new Font("Segoe UI", 9F);
        this.lblEstado.ForeColor = Color.DarkSlateGray;
        this.lblEstado.Location = new Point(20, 700);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(560, 25);
        this.lblEstado.Text = "Listo";
        this.lblEstado.TextAlign = ContentAlignment.MiddleCenter;

        // ─── MainForm ──────────────────────────────────────────
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.FromArgb(245, 245, 250);
        this.ClientSize = new Size(1240, 740);
        this.Controls.Add(this.grpPreview);
        this.Controls.Add(this.grpAjustes);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.progressBar);
        this.Controls.Add(this.btnGenerar);
        this.Controls.Add(this.grpArchivos);
        this.Controls.Add(this.lblTitulo);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Generador de Certificados";
        this.grpArchivos.ResumeLayout(false);
        this.grpArchivos.PerformLayout();
        this.grpAjustes.ResumeLayout(false);
        this.tableAjustes.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.numNombreX).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numNombreY).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numNombreFuente).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numNombreAncho).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numGradoX).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numGradoY).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numGradoFuente).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numGradoAncho).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numCodigoX).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numCodigoY).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numCodigoFuente).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numCodigoAncho).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numExamenX).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numExamenY).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numExamenFuente).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numExamenAncho).EndInit();
        this.grpPreview.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.picturePreview).EndInit();
        this.ResumeLayout(false);
    }

    private static void ConfigurarNumericRango(NumericUpDown control, decimal valorInicial, decimal minimo, decimal maximo, EventHandler onChanged)
    {
        control.DecimalPlaces = 2;
        control.Increment = 0.01m;
        control.Minimum = minimo;
        control.Maximum = maximo;
        control.Value = valorInicial;
        control.Dock = DockStyle.Fill;
        control.ValueChanged += onChanged;
    }

    private static void ConfigurarNumericFuente(NumericUpDown control, decimal valorInicial, EventHandler onChanged)
    {
        control.DecimalPlaces = 0;
        control.Increment = 1;
        control.Minimum = 8;
        control.Maximum = 120;
        control.Value = valorInicial;
        control.Dock = DockStyle.Fill;
        control.ValueChanged += onChanged;
    }

    private Label lblTitulo;
    private GroupBox grpArchivos;
    private Label lblNumeroExamen;
    private TextBox txtNumeroExamen;
    private Button btnSeleccionarExcel;
    private Label lblExcel;
    private Button btnSeleccionarPlantilla;
    private Label lblPlantilla;
    private Button btnSeleccionarCarpeta;
    private Label lblCarpeta;
    private GroupBox grpAjustes;
    private TableLayoutPanel tableAjustes;
    private Label lblAjusteNombre;
    private Label lblAjusteGrado;
    private Label lblAjusteCodigo;
    private Label lblAjusteExamen;
    private Label lblColX;
    private Label lblColY;
    private Label lblColFuente;
    private Label lblColAncho;
    private NumericUpDown numNombreX;
    private NumericUpDown numNombreY;
    private NumericUpDown numNombreFuente;
    private NumericUpDown numNombreAncho;
    private NumericUpDown numGradoX;
    private NumericUpDown numGradoY;
    private NumericUpDown numGradoFuente;
    private NumericUpDown numGradoAncho;
    private NumericUpDown numCodigoX;
    private NumericUpDown numCodigoY;
    private NumericUpDown numCodigoFuente;
    private NumericUpDown numCodigoAncho;
    private NumericUpDown numExamenX;
    private NumericUpDown numExamenY;
    private NumericUpDown numExamenFuente;
    private NumericUpDown numExamenAncho;
    private Button btnActualizarPreview;
    private GroupBox grpPreview;
    private PictureBox picturePreview;
    private Button btnGenerar;
    private ProgressBar progressBar;
    private Label lblEstado;
}
