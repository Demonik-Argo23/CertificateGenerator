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
        this.lblFechaExamen = new Label();
        this.txtFechaExamen = new TextBox();
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
        this.lblAjusteFecha = new Label();
        this.lblAjusteProfesor = new Label();
        this.lblAjusteFirma = new Label();
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
        this.numFechaX = new NumericUpDown();
        this.numFechaY = new NumericUpDown();
        this.numFechaFuente = new NumericUpDown();
        this.numFechaAncho = new NumericUpDown();
        this.numProfesorX = new NumericUpDown();
        this.numProfesorY = new NumericUpDown();
        this.numProfesorFuente = new NumericUpDown();
        this.numProfesorAncho = new NumericUpDown();
        this.numFirmaX = new NumericUpDown();
        this.numFirmaY = new NumericUpDown();
        this.numFirmaTamano = new NumericUpDown();
        this.numFirmaAncho = new NumericUpDown();
        this.btnActualizarPreview = new Button();
        this.btnCancelar = new Button();
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
        ((System.ComponentModel.ISupportInitialize)this.numFechaX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numFechaY).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numFechaFuente).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numFechaAncho).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numProfesorX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numProfesorY).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numProfesorFuente).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numProfesorAncho).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numFirmaX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numFirmaY).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numFirmaTamano).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numFirmaAncho).BeginInit();
        this.grpPreview.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.picturePreview).BeginInit();
        this.SuspendLayout();

        this.lblTitulo.Dock = DockStyle.Top;
        this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        this.lblTitulo.ForeColor = Color.FromArgb(26, 26, 46);
        this.lblTitulo.Location = new Point(0, 0);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new Size(1260, 50);
        this.lblTitulo.Text = "Generador de Certificados";
        this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

        this.grpArchivos.Controls.Add(this.btnSeleccionarExcel);
        this.grpArchivos.Controls.Add(this.lblExcel);
        this.grpArchivos.Controls.Add(this.btnSeleccionarPlantilla);
        this.grpArchivos.Controls.Add(this.lblPlantilla);
        this.grpArchivos.Controls.Add(this.btnSeleccionarCarpeta);
        this.grpArchivos.Controls.Add(this.lblCarpeta);
        this.grpArchivos.Controls.Add(this.lblNumeroExamen);
        this.grpArchivos.Controls.Add(this.txtNumeroExamen);
        this.grpArchivos.Controls.Add(this.lblFechaExamen);
        this.grpArchivos.Controls.Add(this.txtFechaExamen);
        this.grpArchivos.Font = new Font("Segoe UI", 10F);
        this.grpArchivos.Location = new Point(20, 60);
        this.grpArchivos.Name = "grpArchivos";
        this.grpArchivos.Size = new Size(580, 300);
        this.grpArchivos.Text = "Configuración";

        this.lblNumeroExamen.Location = new Point(15, 200);
        this.lblNumeroExamen.Name = "lblNumeroExamen";
        this.lblNumeroExamen.Size = new Size(170, 30);
        this.lblNumeroExamen.Text = "Número de examen:";
        this.lblNumeroExamen.TextAlign = ContentAlignment.MiddleLeft;

        this.txtNumeroExamen.Location = new Point(195, 202);
        this.txtNumeroExamen.Name = "txtNumeroExamen";
        this.txtNumeroExamen.Size = new Size(120, 25);
        this.txtNumeroExamen.Text = "100";
        this.txtNumeroExamen.TextChanged += CampoAjuste_Changed;

        this.lblFechaExamen.Location = new Point(15, 240);
        this.lblFechaExamen.Name = "lblFechaExamen";
        this.lblFechaExamen.Size = new Size(170, 30);
        this.lblFechaExamen.Text = "Fecha de examen:";
        this.lblFechaExamen.TextAlign = ContentAlignment.MiddleLeft;

        this.txtFechaExamen.Location = new Point(195, 242);
        this.txtFechaExamen.Name = "txtFechaExamen";
        this.txtFechaExamen.Size = new Size(350, 25);
        this.txtFechaExamen.Text = "Querétaro, Qro., a DIA de MES de AÑO";
        this.txtFechaExamen.TextChanged += CampoAjuste_Changed;

        this.btnSeleccionarExcel.Location = new Point(15, 35);
        this.btnSeleccionarExcel.Name = "btnSeleccionarExcel";
        this.btnSeleccionarExcel.Size = new Size(170, 40);
        this.btnSeleccionarExcel.Text = "Seleccionar Excel";
        this.btnSeleccionarExcel.UseVisualStyleBackColor = true;
        this.btnSeleccionarExcel.Click += BtnSeleccionarExcel_Click;

        this.lblExcel.AutoEllipsis = true;
        this.lblExcel.ForeColor = Color.Gray;
        this.lblExcel.Location = new Point(195, 35);
        this.lblExcel.Name = "lblExcel";
        this.lblExcel.Size = new Size(370, 40);
        this.lblExcel.Text = "Ningún archivo seleccionado";
        this.lblExcel.TextAlign = ContentAlignment.MiddleLeft;

        this.btnSeleccionarPlantilla.Location = new Point(15, 90);
        this.btnSeleccionarPlantilla.Name = "btnSeleccionarPlantilla";
        this.btnSeleccionarPlantilla.Size = new Size(170, 40);
        this.btnSeleccionarPlantilla.Text = "Seleccionar Plantilla";
        this.btnSeleccionarPlantilla.UseVisualStyleBackColor = true;
        this.btnSeleccionarPlantilla.Click += BtnSeleccionarPlantilla_Click;

        this.lblPlantilla.AutoEllipsis = true;
        this.lblPlantilla.ForeColor = Color.Gray;
        this.lblPlantilla.Location = new Point(195, 90);
        this.lblPlantilla.Name = "lblPlantilla";
        this.lblPlantilla.Size = new Size(370, 40);
        this.lblPlantilla.Text = "Ningún archivo seleccionado";
        this.lblPlantilla.TextAlign = ContentAlignment.MiddleLeft;

        this.btnSeleccionarCarpeta.Location = new Point(15, 145);
        this.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
        this.btnSeleccionarCarpeta.Size = new Size(170, 40);
        this.btnSeleccionarCarpeta.Text = "Seleccionar Carpeta";
        this.btnSeleccionarCarpeta.UseVisualStyleBackColor = true;
        this.btnSeleccionarCarpeta.Click += BtnSeleccionarCarpeta_Click;

        this.lblCarpeta.AutoEllipsis = true;
        this.lblCarpeta.ForeColor = Color.Gray;
        this.lblCarpeta.Location = new Point(195, 145);
        this.lblCarpeta.Name = "lblCarpeta";
        this.lblCarpeta.Size = new Size(370, 40);
        this.lblCarpeta.Text = "Ninguna carpeta seleccionada";
        this.lblCarpeta.TextAlign = ContentAlignment.MiddleLeft;

        this.grpAjustes.Controls.Add(this.tableAjustes);
        this.grpAjustes.Controls.Add(this.btnActualizarPreview);
        this.grpAjustes.Controls.Add(this.btnCancelar);
        this.grpAjustes.Font = new Font("Segoe UI", 10F);
        this.grpAjustes.Location = new Point(20, 370);
        this.grpAjustes.Name = "grpAjustes";
        this.grpAjustes.Size = new Size(580, 430);
        this.grpAjustes.Text = "Ajustes de Campos (X/Y cartesiano, Y ↑ +)";

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
        this.tableAjustes.Controls.Add(this.lblAjusteFecha, 0, 5);
        this.tableAjustes.Controls.Add(this.lblAjusteProfesor, 0, 6);
        this.tableAjustes.Controls.Add(this.lblAjusteFirma, 0, 7);
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
        this.tableAjustes.Controls.Add(this.numFechaX, 1, 5);
        this.tableAjustes.Controls.Add(this.numFechaY, 2, 5);
        this.tableAjustes.Controls.Add(this.numFechaFuente, 3, 5);
        this.tableAjustes.Controls.Add(this.numFechaAncho, 4, 5);
        this.tableAjustes.Controls.Add(this.numProfesorX, 1, 6);
        this.tableAjustes.Controls.Add(this.numProfesorY, 2, 6);
        this.tableAjustes.Controls.Add(this.numProfesorFuente, 3, 6);
        this.tableAjustes.Controls.Add(this.numProfesorAncho, 4, 6);
        this.tableAjustes.Controls.Add(this.numFirmaX, 1, 7);
        this.tableAjustes.Controls.Add(this.numFirmaY, 2, 7);
        this.tableAjustes.Controls.Add(this.numFirmaTamano, 3, 7);
        this.tableAjustes.Controls.Add(this.numFirmaAncho, 4, 7);
        this.tableAjustes.Location = new Point(12, 30);
        this.tableAjustes.Name = "tableAjustes";
        this.tableAjustes.RowCount = 8;
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        this.tableAjustes.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        this.tableAjustes.Size = new Size(548, 330);

        this.lblColX.Text = "X";
        this.lblColX.TextAlign = ContentAlignment.MiddleCenter;
        this.lblColX.Dock = DockStyle.Fill;
        this.lblColY.Text = "Y (↑ +)";
        this.lblColY.TextAlign = ContentAlignment.MiddleCenter;
        this.lblColY.Dock = DockStyle.Fill;
        this.lblColFuente.Text = "Tamaño";
        this.lblColFuente.TextAlign = ContentAlignment.MiddleCenter;
        this.lblColFuente.Dock = DockStyle.Fill;
        this.lblColAncho.Text = "Ancho";
        this.lblColAncho.TextAlign = ContentAlignment.MiddleCenter;
        this.lblColAncho.Dock = DockStyle.Fill;

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
        this.lblAjusteFecha.Text = "Fecha";
        this.lblAjusteFecha.TextAlign = ContentAlignment.MiddleLeft;
        this.lblAjusteFecha.Dock = DockStyle.Fill;
        this.lblAjusteProfesor.Text = "Profesor";
        this.lblAjusteProfesor.TextAlign = ContentAlignment.MiddleLeft;
        this.lblAjusteProfesor.Dock = DockStyle.Fill;
        this.lblAjusteFirma.Text = "Firma";
        this.lblAjusteFirma.TextAlign = ContentAlignment.MiddleLeft;
        this.lblAjusteFirma.Dock = DockStyle.Fill;

        ConfigurarNumericRango(this.numNombreX, 0.52m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numNombreY, 0.57m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numNombreFuente, 120, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numNombreAncho, 0.70m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numGradoX, 0.50m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numGradoY, 0.49m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numGradoFuente, 100, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numGradoAncho, 0.75m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numCodigoX, 0.78m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numCodigoY, 0.70m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numCodigoFuente, 80, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numCodigoAncho, 0.12m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numExamenX, 0.50m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numExamenY, 0.37m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numExamenFuente, 100, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numExamenAncho, 0.08m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numFechaX, 0.20m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numFechaY, 0.32m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numFechaFuente, 100, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numFechaAncho, 0.60m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numProfesorX, 0.70m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numProfesorY, 0.23m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericFuente(this.numProfesorFuente, 90, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numProfesorAncho, 0.37m, 0.01m, 1m, CampoAjuste_Changed);

        ConfigurarNumericRango(this.numFirmaX, 0.17m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numFirmaY, 0.21m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numFirmaTamano, 0.25m, 0.01m, 1m, CampoAjuste_Changed);
        ConfigurarNumericRango(this.numFirmaAncho, 0.00m, 0.00m, 0.00m, CampoAjuste_Changed);
        this.numFirmaAncho.Enabled = false;

        this.btnActualizarPreview.Location = new Point(12, 372);
        this.btnActualizarPreview.Name = "btnActualizarPreview";
        this.btnActualizarPreview.Size = new Size(180, 40);
        this.btnActualizarPreview.Text = "Actualizar Preview";
        this.btnActualizarPreview.UseVisualStyleBackColor = true;
        this.btnActualizarPreview.Click += BtnActualizarPreview_Click;

        this.btnCancelar.BackColor = Color.FromArgb(198, 40, 40);
        this.btnCancelar.FlatStyle = FlatStyle.Flat;
        this.btnCancelar.ForeColor = Color.White;
        this.btnCancelar.Location = new Point(205, 372);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new Size(180, 40);
        this.btnCancelar.Text = "Cancelar";
        this.btnCancelar.UseVisualStyleBackColor = false;
        this.btnCancelar.Enabled = false;
        this.btnCancelar.Click += BtnCancelar_Click;

        this.grpPreview.Controls.Add(this.picturePreview);
        this.grpPreview.Font = new Font("Segoe UI", 10F);
        this.grpPreview.Location = new Point(620, 60);
        this.grpPreview.Name = "grpPreview";
        this.grpPreview.Size = new Size(620, 740);
        this.grpPreview.Text = "Preview del Certificado";

        this.picturePreview.BackColor = Color.White;
        this.picturePreview.BorderStyle = BorderStyle.FixedSingle;
        this.picturePreview.Dock = DockStyle.Fill;
        this.picturePreview.Name = "picturePreview";
        this.picturePreview.SizeMode = PictureBoxSizeMode.Zoom;

        this.btnGenerar.BackColor = Color.FromArgb(22, 33, 62);
        this.btnGenerar.FlatStyle = FlatStyle.Flat;
        this.btnGenerar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        this.btnGenerar.ForeColor = Color.White;
        this.btnGenerar.Location = new Point(20, 810);
        this.btnGenerar.Name = "btnGenerar";
        this.btnGenerar.Size = new Size(1220, 50);
        this.btnGenerar.Text = "Generar Certificados";
        this.btnGenerar.UseVisualStyleBackColor = false;
        this.btnGenerar.Click += BtnGenerar_Click;

        this.progressBar.Location = new Point(20, 870);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new Size(1220, 22);
        this.progressBar.Style = ProgressBarStyle.Continuous;

        this.lblEstado.Font = new Font("Segoe UI", 9F);
        this.lblEstado.ForeColor = Color.DarkSlateGray;
        this.lblEstado.Location = new Point(20, 895);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(1220, 25);
        this.lblEstado.Text = "Listo";
        this.lblEstado.TextAlign = ContentAlignment.MiddleCenter;

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.FromArgb(245, 245, 250);
        this.ClientSize = new Size(1260, 930);
        this.Controls.Add(this.grpPreview);
        this.Controls.Add(this.grpAjustes);
        this.Controls.Add(this.grpArchivos);
        this.Controls.Add(this.btnGenerar);
        this.Controls.Add(this.progressBar);
        this.Controls.Add(this.lblEstado);
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
        ((System.ComponentModel.ISupportInitialize)this.numFechaX).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numFechaY).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numFechaFuente).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numFechaAncho).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numProfesorX).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numProfesorY).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numProfesorFuente).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numProfesorAncho).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numFirmaX).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numFirmaY).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numFirmaTamano).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numFirmaAncho).EndInit();
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
    private Label lblFechaExamen;
    private TextBox txtFechaExamen;
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
    private Label lblAjusteFecha;
    private Label lblAjusteProfesor;
    private Label lblAjusteFirma;
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
    private NumericUpDown numFechaX;
    private NumericUpDown numFechaY;
    private NumericUpDown numFechaFuente;
    private NumericUpDown numFechaAncho;
    private NumericUpDown numProfesorX;
    private NumericUpDown numProfesorY;
    private NumericUpDown numProfesorFuente;
    private NumericUpDown numProfesorAncho;
    private NumericUpDown numFirmaX;
    private NumericUpDown numFirmaY;
    private NumericUpDown numFirmaTamano;
    private NumericUpDown numFirmaAncho;
    private Button btnActualizarPreview;
    private Button btnCancelar;
    private GroupBox grpPreview;
    private PictureBox picturePreview;
    private Button btnGenerar;
    private ProgressBar progressBar;
    private Label lblEstado;
}
