namespace BiFurcation {

  partial class NonLineairSystemsForm {

    #region fields
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Panel panelImage;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labelFunctionX;
    private System.Windows.Forms.Label labelFunctionY;
    private System.Windows.Forms.Button buttonGenerate;
    private System.Windows.Forms.Panel panelColorPictures;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button buttonReset;
    private System.Windows.Forms.TextBox textBoxYMax;
    private System.Windows.Forms.TextBox textBoxYMin;
    private System.Windows.Forms.TextBox textBoxXMax;
    private System.Windows.Forms.TextBox textBoxXMin;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox textBoxEscapeRadius;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.TextBox textBoxMaxIterations;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Panel panelParameters;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem imageToEditorMenuItem;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Label labelJuliaType;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Label labelCurrY;
    private System.Windows.Forms.Label labelCurrX;
    private System.Windows.Forms.ToolStripMenuItem createGIFMenuItem;
    private System.Windows.Forms.TextBox textBoxJuliaY;
    private System.Windows.Forms.TextBox textBoxJuliaX;
    private System.Windows.Forms.Panel panelGeneralSettings;
    private System.Windows.Forms.TextBox textBoxNumGifImages;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.TextBox textBoxGIFFilename;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label labelGIFProgress;
    private System.Windows.Forms.Button buttonCancelGif;
    private System.Windows.Forms.PictureBox pictureBoxColorsSingle;
    private System.Windows.Forms.Button buttonDefineColors;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label label27;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton radioButtonSingle;
    private System.Windows.Forms.RadioButton radioButtonType3;
    private System.Windows.Forms.RadioButton radioButtonType2;
    private System.Windows.Forms.RadioButton radioButtonType1;
    private System.Windows.Forms.TextBox textBoxjuliaMandelPowerA;
    private System.Windows.Forms.Label labeljuliaMandelPowerA;
    private System.Windows.Forms.Panel panelJuliaTypeGraph;
    private System.Windows.Forms.PictureBox pictureBoxJuliaTypes;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label288;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.PictureBox pictureBoxColors3;
    private System.Windows.Forms.PictureBox pictureBoxColors2;
    private System.Windows.Forms.PictureBox pictureBoxColors1;
    private System.Windows.Forms.CheckBox checkBoxAddReverseGif;
    private System.Windows.Forms.Panel panelExamples;
    private System.Windows.Forms.Button buttonDoneExamples;
    private System.Windows.Forms.Button buttonSelectType;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Panel panelMiraTypes;
    private System.Windows.Forms.HScrollBar hScrollBarMiraB;
    private System.Windows.Forms.HScrollBar hScrollBarMiraA;
    private System.Windows.Forms.Label labelScrollB;
    private System.Windows.Forms.Label labelScrollA;
    private System.Windows.Forms.CheckBox checkBoxSpreadA;
    private System.Windows.Forms.Label label54;
    private System.Windows.Forms.HScrollBar hScrollBarIterations;
    private System.Windows.Forms.Label labelIterations;
    private System.Windows.Forms.Panel panelJuliaTypes;
    private System.Windows.Forms.TabControl tabControlFractalExamples;
    private System.Windows.Forms.TabPage tabPageGeneral;
    private System.Windows.Forms.TabPage tabPageJulia;
    private System.Windows.Forms.TabPage tabPageLinetype;
    private System.Windows.Forms.Panel panelGenerateButtons;
    private System.Windows.Forms.TextBox textBoxStartYLineplot;
    private System.Windows.Forms.TextBox textBoxStartXLineplot;
    private System.Windows.Forms.Label labelStartY;
    private System.Windows.Forms.Label labelStartX;
    private System.Windows.Forms.TextBox textBoxBVal;
    private System.Windows.Forms.TextBox textBoxAVal;
    private System.Windows.Forms.Button buttonResetLineplot;
    private System.Windows.Forms.TabPage tabPageMiraLineTypes;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.RadioButton radioButtonHighQuality;
    private System.Windows.Forms.RadioButton radioButtonNormalQuality;
    private System.Windows.Forms.RadioButton radioButtonLowQuality;
    #endregion

    #region Windows Form Designer generated code

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      //editControl.Model.clearSourceCityboxes();
      disposing = false;
      if (this == instance && instance != null)
        instance.Visible = false;
      return;
      //if (disposing && (components != null)) {
      //  components.Dispose();
      //}
      //base.Dispose(disposing);
    }


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NonLineairSystemsForm));
      this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.imageToEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createGIFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.panelImage = new System.Windows.Forms.Panel();
      this.panelExamples = new System.Windows.Forms.Panel();
      this.tabControlFractalExamples = new System.Windows.Forms.TabControl();
      this.tabPageGeneral = new System.Windows.Forms.TabPage();
      this.tabPageJulia = new System.Windows.Forms.TabPage();
      this.tabPageLinetype = new System.Windows.Forms.TabPage();
      this.tabPageMiraLineTypes = new System.Windows.Forms.TabPage();
      this.buttonDoneExamples = new System.Windows.Forms.Button();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.labelFunctionX = new System.Windows.Forms.Label();
      this.labelFunctionY = new System.Windows.Forms.Label();
      this.panelColorPictures = new System.Windows.Forms.Panel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.checkBoxAddReverseGif = new System.Windows.Forms.CheckBox();
      this.textBoxNumGifImages = new System.Windows.Forms.TextBox();
      this.label24 = new System.Windows.Forms.Label();
      this.textBoxGIFFilename = new System.Windows.Forms.TextBox();
      this.labelGIFProgress = new System.Windows.Forms.Label();
      this.label25 = new System.Windows.Forms.Label();
      this.label288 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.pictureBoxColors3 = new System.Windows.Forms.PictureBox();
      this.pictureBoxColors2 = new System.Windows.Forms.PictureBox();
      this.pictureBoxColors1 = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radioButtonType3 = new System.Windows.Forms.RadioButton();
      this.radioButtonType2 = new System.Windows.Forms.RadioButton();
      this.radioButtonType1 = new System.Windows.Forms.RadioButton();
      this.radioButtonSingle = new System.Windows.Forms.RadioButton();
      this.pictureBoxColorsSingle = new System.Windows.Forms.PictureBox();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panelJuliaTypeGraph = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.pictureBoxJuliaTypes = new System.Windows.Forms.PictureBox();
      this.panelMiraTypes = new System.Windows.Forms.Panel();
      this.buttonResetLineplot = new System.Windows.Forms.Button();
      this.textBoxBVal = new System.Windows.Forms.TextBox();
      this.textBoxAVal = new System.Windows.Forms.TextBox();
      this.textBoxStartYLineplot = new System.Windows.Forms.TextBox();
      this.textBoxStartXLineplot = new System.Windows.Forms.TextBox();
      this.labelStartY = new System.Windows.Forms.Label();
      this.labelStartX = new System.Windows.Forms.Label();
      this.labelIterations = new System.Windows.Forms.Label();
      this.label54 = new System.Windows.Forms.Label();
      this.hScrollBarIterations = new System.Windows.Forms.HScrollBar();
      this.checkBoxSpreadA = new System.Windows.Forms.CheckBox();
      this.hScrollBarMiraB = new System.Windows.Forms.HScrollBar();
      this.hScrollBarMiraA = new System.Windows.Forms.HScrollBar();
      this.labelScrollB = new System.Windows.Forms.Label();
      this.labelScrollA = new System.Windows.Forms.Label();
      this.panelGenerateButtons = new System.Windows.Forms.Panel();
      this.buttonCancelGif = new System.Windows.Forms.Button();
      this.buttonGenerate = new System.Windows.Forms.Button();
      this.panelJuliaTypes = new System.Windows.Forms.Panel();
      this.textBoxjuliaMandelPowerA = new System.Windows.Forms.TextBox();
      this.labelJuliaType = new System.Windows.Forms.Label();
      this.textBoxJuliaX = new System.Windows.Forms.TextBox();
      this.labeljuliaMandelPowerA = new System.Windows.Forms.Label();
      this.textBoxJuliaY = new System.Windows.Forms.TextBox();
      this.buttonSelectType = new System.Windows.Forms.Button();
      this.buttonDefineColors = new System.Windows.Forms.Button();
      this.panelGeneralSettings = new System.Windows.Forms.Panel();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.radioButtonHighQuality = new System.Windows.Forms.RadioButton();
      this.radioButtonNormalQuality = new System.Windows.Forms.RadioButton();
      this.radioButtonLowQuality = new System.Windows.Forms.RadioButton();
      this.label27 = new System.Windows.Forms.Label();
      this.label26 = new System.Windows.Forms.Label();
      this.textBoxXMin = new System.Windows.Forms.TextBox();
      this.labelCurrY = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.labelCurrX = new System.Windows.Forms.Label();
      this.textBoxXMax = new System.Windows.Forms.TextBox();
      this.textBoxYMin = new System.Windows.Forms.TextBox();
      this.buttonReset = new System.Windows.Forms.Button();
      this.textBoxYMax = new System.Windows.Forms.TextBox();
      this.label16 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.textBoxEscapeRadius = new System.Windows.Forms.TextBox();
      this.label21 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.textBoxMaxIterations = new System.Windows.Forms.TextBox();
      this.panelParameters = new System.Windows.Forms.Panel();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.contextMenuStrip.SuspendLayout();
      this.panelImage.SuspendLayout();
      this.panelExamples.SuspendLayout();
      this.tabControlFractalExamples.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.panelColorPictures.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColors3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColors2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColors1)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorsSingle)).BeginInit();
      this.panel1.SuspendLayout();
      this.panelJuliaTypeGraph.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJuliaTypes)).BeginInit();
      this.panelMiraTypes.SuspendLayout();
      this.panelGenerateButtons.SuspendLayout();
      this.panelJuliaTypes.SuspendLayout();
      this.panelGeneralSettings.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip
      // 
      this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(17, 17);
      this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToEditorMenuItem,
            this.createGIFMenuItem});
      this.contextMenuStrip.Name = "contextMenuStrip";
      this.contextMenuStrip.Size = new System.Drawing.Size(262, 48);
      // 
      // imageToEditorMenuItem
      // 
      this.imageToEditorMenuItem.Name = "imageToEditorMenuItem";
      this.imageToEditorMenuItem.Size = new System.Drawing.Size(261, 22);
      this.imageToEditorMenuItem.Text = "Image to Editor";
      this.imageToEditorMenuItem.Click += new System.EventHandler(this.imageToEditorMenuItem_Click);
      // 
      // createGIFMenuItem
      // 
      this.createGIFMenuItem.Name = "createGIFMenuItem";
      this.createGIFMenuItem.Size = new System.Drawing.Size(261, 22);
      this.createGIFMenuItem.Text = "Create GIF zooming in at cursor";
      this.createGIFMenuItem.Click += new System.EventHandler(this.createGIFMenuItem_Click);
      // 
      // panelImage
      // 
      this.panelImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panelImage.Controls.Add(this.panelExamples);
      this.panelImage.Controls.Add(this.pictureBox);
      this.panelImage.Location = new System.Drawing.Point(0, 0);
      this.panelImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panelImage.Name = "panelImage";
      this.panelImage.Size = new System.Drawing.Size(692, 670);
      this.panelImage.TabIndex = 2;
      // 
      // panelExamples
      // 
      this.panelExamples.BackColor = System.Drawing.Color.Azure;
      this.panelExamples.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelExamples.Controls.Add(this.tabControlFractalExamples);
      this.panelExamples.Controls.Add(this.buttonDoneExamples);
      this.panelExamples.Location = new System.Drawing.Point(7, 58);
      this.panelExamples.Name = "panelExamples";
      this.panelExamples.Size = new System.Drawing.Size(678, 562);
      this.panelExamples.TabIndex = 2;
      this.panelExamples.Visible = false;
      // 
      // tabControlFractalExamples
      // 
      this.tabControlFractalExamples.Appearance = System.Windows.Forms.TabAppearance.Buttons;
      this.tabControlFractalExamples.Controls.Add(this.tabPageGeneral);
      this.tabControlFractalExamples.Controls.Add(this.tabPageJulia);
      this.tabControlFractalExamples.Controls.Add(this.tabPageLinetype);
      this.tabControlFractalExamples.Controls.Add(this.tabPageMiraLineTypes);
      this.tabControlFractalExamples.Location = new System.Drawing.Point(5, 9);
      this.tabControlFractalExamples.Name = "tabControlFractalExamples";
      this.tabControlFractalExamples.SelectedIndex = 0;
      this.tabControlFractalExamples.Size = new System.Drawing.Size(669, 460);
      this.tabControlFractalExamples.TabIndex = 352;
      // 
      // tabPageGeneral
      // 
      this.tabPageGeneral.BackColor = System.Drawing.Color.Azure;
      this.tabPageGeneral.Font = new System.Drawing.Font("Calibri", 12.11881F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
      this.tabPageGeneral.Location = new System.Drawing.Point(4, 29);
      this.tabPageGeneral.Name = "tabPageGeneral";
      this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageGeneral.Size = new System.Drawing.Size(661, 427);
      this.tabPageGeneral.TabIndex = 0;
      this.tabPageGeneral.Text = "General fractals";
      // 
      // tabPageJulia
      // 
      this.tabPageJulia.BackColor = System.Drawing.Color.Azure;
      this.tabPageJulia.Font = new System.Drawing.Font("Calibri", 12.11881F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
      this.tabPageJulia.Location = new System.Drawing.Point(4, 25);
      this.tabPageJulia.Name = "tabPageJulia";
      this.tabPageJulia.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageJulia.Size = new System.Drawing.Size(661, 431);
      this.tabPageJulia.TabIndex = 1;
      this.tabPageJulia.Text = "Julia fractals";
      // 
      // tabPageLinetype
      // 
      this.tabPageLinetype.BackColor = System.Drawing.Color.Azure;
      this.tabPageLinetype.Font = new System.Drawing.Font("Calibri", 12.11881F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
      this.tabPageLinetype.Location = new System.Drawing.Point(4, 25);
      this.tabPageLinetype.Name = "tabPageLinetype";
      this.tabPageLinetype.Size = new System.Drawing.Size(661, 431);
      this.tabPageLinetype.TabIndex = 2;
      this.tabPageLinetype.Text = "Line fractals";
      // 
      // tabPageMiraLineTypes
      // 
      this.tabPageMiraLineTypes.BackColor = System.Drawing.Color.Azure;
      this.tabPageMiraLineTypes.Location = new System.Drawing.Point(4, 25);
      this.tabPageMiraLineTypes.Name = "tabPageMiraLineTypes";
      this.tabPageMiraLineTypes.Size = new System.Drawing.Size(661, 431);
      this.tabPageMiraLineTypes.TabIndex = 3;
      this.tabPageMiraLineTypes.Text = "Mira Linetypes";
      this.tabPageMiraLineTypes.Click += new System.EventHandler(this.pictureBoxMiraType);
      // 
      // buttonDoneExamples
      // 
      this.buttonDoneExamples.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDoneExamples.BackgroundImage")));
      this.buttonDoneExamples.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonDoneExamples.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.buttonDoneExamples.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonDoneExamples.Location = new System.Drawing.Point(20, 495);
      this.buttonDoneExamples.Name = "buttonDoneExamples";
      this.buttonDoneExamples.Size = new System.Drawing.Size(630, 51);
      this.buttonDoneExamples.TabIndex = 321;
      this.buttonDoneExamples.Text = "Done";
      this.buttonDoneExamples.UseVisualStyleBackColor = true;
      this.buttonDoneExamples.Click += new System.EventHandler(this.buttonDoneExamples_Click);
      // 
      // pictureBox
      // 
      this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureBox.ContextMenuStrip = this.contextMenuStrip;
      this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox.Location = new System.Drawing.Point(0, 0);
      this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(692, 670);
      this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
      this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
      this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Calibri", 10.69307F);
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(121, 19);
      this.label1.TabIndex = 3;
      this.label1.Text = "General function:";
      // 
      // labelFunctionX
      // 
      this.labelFunctionX.AutoSize = true;
      this.labelFunctionX.Font = new System.Drawing.Font("Calibri", 10.69307F);
      this.labelFunctionX.Location = new System.Drawing.Point(3, 34);
      this.labelFunctionX.Name = "labelFunctionX";
      this.labelFunctionX.Size = new System.Drawing.Size(297, 19);
      this.labelFunctionX.TabIndex = 4;
      this.labelFunctionX.Text = "X\' = a0 + a1X + a2 X^2 + a3XY + a4Y + a5Y^2";
      // 
      // labelFunctionY
      // 
      this.labelFunctionY.AutoSize = true;
      this.labelFunctionY.Font = new System.Drawing.Font("Calibri", 10.69307F);
      this.labelFunctionY.Location = new System.Drawing.Point(3, 55);
      this.labelFunctionY.Name = "labelFunctionY";
      this.labelFunctionY.Size = new System.Drawing.Size(297, 19);
      this.labelFunctionY.TabIndex = 5;
      this.labelFunctionY.Text = "Y\' = b0 + b1X + b2 X^2 + b3XY + b4Y + b5Y^2";
      // 
      // panelColorPictures
      // 
      this.panelColorPictures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.panelColorPictures.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panelColorPictures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelColorPictures.Controls.Add(this.groupBox2);
      this.panelColorPictures.Controls.Add(this.label288);
      this.panelColorPictures.Controls.Add(this.label19);
      this.panelColorPictures.Controls.Add(this.label18);
      this.panelColorPictures.Controls.Add(this.label3);
      this.panelColorPictures.Controls.Add(this.pictureBoxColors3);
      this.panelColorPictures.Controls.Add(this.pictureBoxColors2);
      this.panelColorPictures.Controls.Add(this.pictureBoxColors1);
      this.panelColorPictures.Controls.Add(this.groupBox1);
      this.panelColorPictures.Controls.Add(this.pictureBoxColorsSingle);
      this.panelColorPictures.Controls.Add(this.progressBar);
      this.panelColorPictures.Location = new System.Drawing.Point(7, 466);
      this.panelColorPictures.Name = "panelColorPictures";
      this.panelColorPictures.Size = new System.Drawing.Size(436, 202);
      this.panelColorPictures.TabIndex = 278;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.checkBoxAddReverseGif);
      this.groupBox2.Controls.Add(this.textBoxNumGifImages);
      this.groupBox2.Controls.Add(this.label24);
      this.groupBox2.Controls.Add(this.textBoxGIFFilename);
      this.groupBox2.Controls.Add(this.labelGIFProgress);
      this.groupBox2.Controls.Add(this.label25);
      this.groupBox2.Location = new System.Drawing.Point(218, 117);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(208, 78);
      this.groupBox2.TabIndex = 345;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "GIF\'s";
      // 
      // checkBoxAddReverseGif
      // 
      this.checkBoxAddReverseGif.AutoSize = true;
      this.checkBoxAddReverseGif.Location = new System.Drawing.Point(103, 59);
      this.checkBoxAddReverseGif.Name = "checkBoxAddReverseGif";
      this.checkBoxAddReverseGif.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBoxAddReverseGif.Size = new System.Drawing.Size(97, 21);
      this.checkBoxAddReverseGif.TabIndex = 299;
      this.checkBoxAddReverseGif.Text = "Add Reverse";
      this.checkBoxAddReverseGif.UseVisualStyleBackColor = true;
      this.checkBoxAddReverseGif.CheckedChanged += new System.EventHandler(this.checkBoxAddReverseGif_CheckedChanged);
      // 
      // textBoxNumGifImages
      // 
      this.textBoxNumGifImages.Location = new System.Drawing.Point(4, 31);
      this.textBoxNumGifImages.Name = "textBoxNumGifImages";
      this.textBoxNumGifImages.Size = new System.Drawing.Size(89, 25);
      this.textBoxNumGifImages.TabIndex = 295;
      this.textBoxNumGifImages.Tag = "0";
      this.textBoxNumGifImages.Text = "150";
      // 
      // label24
      // 
      this.label24.AutoSize = true;
      this.label24.Location = new System.Drawing.Point(3, 16);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(71, 17);
      this.label24.TabIndex = 30;
      this.label24.Text = "No. images";
      // 
      // textBoxGIFFilename
      // 
      this.textBoxGIFFilename.Location = new System.Drawing.Point(107, 31);
      this.textBoxGIFFilename.Name = "textBoxGIFFilename";
      this.textBoxGIFFilename.Size = new System.Drawing.Size(89, 25);
      this.textBoxGIFFilename.TabIndex = 297;
      this.textBoxGIFFilename.Tag = "0";
      this.textBoxGIFFilename.Text = "FractalGif";
      // 
      // labelGIFProgress
      // 
      this.labelGIFProgress.AutoSize = true;
      this.labelGIFProgress.Location = new System.Drawing.Point(4, 58);
      this.labelGIFProgress.Name = "labelGIFProgress";
      this.labelGIFProgress.Size = new System.Drawing.Size(60, 17);
      this.labelGIFProgress.TabIndex = 298;
      this.labelGIFProgress.Text = "Progress:";
      // 
      // label25
      // 
      this.label25.AutoSize = true;
      this.label25.Location = new System.Drawing.Point(106, 16);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(59, 17);
      this.label25.TabIndex = 296;
      this.label25.Text = "Filename";
      // 
      // label288
      // 
      this.label288.AutoSize = true;
      this.label288.Location = new System.Drawing.Point(6, 3);
      this.label288.Name = "label288";
      this.label288.Size = new System.Drawing.Size(72, 17);
      this.label288.TabIndex = 307;
      this.label288.Text = "Single color";
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Location = new System.Drawing.Point(114, 2);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(44, 17);
      this.label19.TabIndex = 306;
      this.label19.Text = "Type 1";
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Location = new System.Drawing.Point(223, 2);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(44, 17);
      this.label18.TabIndex = 305;
      this.label18.Text = "Type 2";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(333, 3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(44, 17);
      this.label3.TabIndex = 304;
      this.label3.Text = "Type 3";
      // 
      // pictureBoxColors3
      // 
      this.pictureBoxColors3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBoxColors3.Location = new System.Drawing.Point(331, 21);
      this.pictureBoxColors3.Name = "pictureBoxColors3";
      this.pictureBoxColors3.Size = new System.Drawing.Size(95, 95);
      this.pictureBoxColors3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxColors3.TabIndex = 303;
      this.pictureBoxColors3.TabStop = false;
      this.pictureBoxColors3.Click += new System.EventHandler(this.pictureBoxColors3_Click);
      // 
      // pictureBoxColors2
      // 
      this.pictureBoxColors2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBoxColors2.Location = new System.Drawing.Point(223, 21);
      this.pictureBoxColors2.Name = "pictureBoxColors2";
      this.pictureBoxColors2.Size = new System.Drawing.Size(95, 95);
      this.pictureBoxColors2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxColors2.TabIndex = 302;
      this.pictureBoxColors2.TabStop = false;
      this.pictureBoxColors2.Click += new System.EventHandler(this.pictureBoxColors2_Click);
      // 
      // pictureBoxColors1
      // 
      this.pictureBoxColors1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBoxColors1.Location = new System.Drawing.Point(115, 21);
      this.pictureBoxColors1.Name = "pictureBoxColors1";
      this.pictureBoxColors1.Size = new System.Drawing.Size(95, 95);
      this.pictureBoxColors1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxColors1.TabIndex = 301;
      this.pictureBoxColors1.TabStop = false;
      this.pictureBoxColors1.Click += new System.EventHandler(this.pictureBoxColors1_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.radioButtonType3);
      this.groupBox1.Controls.Add(this.radioButtonType2);
      this.groupBox1.Controls.Add(this.radioButtonType1);
      this.groupBox1.Controls.Add(this.radioButtonSingle);
      this.groupBox1.Location = new System.Drawing.Point(6, 117);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(208, 78);
      this.groupBox1.TabIndex = 300;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Palette selection";
      // 
      // radioButtonType3
      // 
      this.radioButtonType3.Location = new System.Drawing.Point(143, 48);
      this.radioButtonType3.Name = "radioButtonType3";
      this.radioButtonType3.Size = new System.Drawing.Size(62, 21);
      this.radioButtonType3.TabIndex = 3;
      this.radioButtonType3.Text = "Type 3";
      this.radioButtonType3.UseVisualStyleBackColor = true;
      this.radioButtonType3.CheckedChanged += new System.EventHandler(this.radioButtonCheckedChanged);
      // 
      // radioButtonType2
      // 
      this.radioButtonType2.Checked = true;
      this.radioButtonType2.Location = new System.Drawing.Point(75, 48);
      this.radioButtonType2.Name = "radioButtonType2";
      this.radioButtonType2.Size = new System.Drawing.Size(62, 21);
      this.radioButtonType2.TabIndex = 2;
      this.radioButtonType2.TabStop = true;
      this.radioButtonType2.Text = "Type 2";
      this.radioButtonType2.UseVisualStyleBackColor = true;
      this.radioButtonType2.CheckedChanged += new System.EventHandler(this.radioButtonCheckedChanged);
      // 
      // radioButtonType1
      // 
      this.radioButtonType1.Location = new System.Drawing.Point(9, 48);
      this.radioButtonType1.Name = "radioButtonType1";
      this.radioButtonType1.Size = new System.Drawing.Size(72, 21);
      this.radioButtonType1.TabIndex = 1;
      this.radioButtonType1.Text = "Type 1";
      this.radioButtonType1.UseVisualStyleBackColor = true;
      this.radioButtonType1.CheckedChanged += new System.EventHandler(this.radioButtonCheckedChanged);
      // 
      // radioButtonSingle
      // 
      this.radioButtonSingle.AutoSize = true;
      this.radioButtonSingle.Location = new System.Drawing.Point(9, 21);
      this.radioButtonSingle.Name = "radioButtonSingle";
      this.radioButtonSingle.Size = new System.Drawing.Size(90, 21);
      this.radioButtonSingle.TabIndex = 0;
      this.radioButtonSingle.Text = "Single color";
      this.radioButtonSingle.UseVisualStyleBackColor = true;
      this.radioButtonSingle.CheckedChanged += new System.EventHandler(this.radioButtonCheckedChanged);
      // 
      // pictureBoxColorsSingle
      // 
      this.pictureBoxColorsSingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBoxColorsSingle.Location = new System.Drawing.Point(7, 21);
      this.pictureBoxColorsSingle.Name = "pictureBoxColorsSingle";
      this.pictureBoxColorsSingle.Size = new System.Drawing.Size(95, 95);
      this.pictureBoxColorsSingle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxColorsSingle.TabIndex = 299;
      this.pictureBoxColorsSingle.TabStop = false;
      this.pictureBoxColorsSingle.Click += new System.EventHandler(this.pictureBoxColorsSingle_Click);
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(6, 3);
      this.progressBar.Maximum = 2000;
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(421, 23);
      this.progressBar.TabIndex = 2;
      this.progressBar.Visible = false;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel1.Controls.Add(this.panelJuliaTypeGraph);
      this.panel1.Controls.Add(this.panelMiraTypes);
      this.panel1.Controls.Add(this.panelGenerateButtons);
      this.panel1.Controls.Add(this.panelJuliaTypes);
      this.panel1.Controls.Add(this.buttonSelectType);
      this.panel1.Controls.Add(this.buttonDefineColors);
      this.panel1.Controls.Add(this.panelGeneralSettings);
      this.panel1.Controls.Add(this.panelParameters);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.panelColorPictures);
      this.panel1.Controls.Add(this.labelFunctionX);
      this.panel1.Controls.Add(this.labelFunctionY);
      this.panel1.Location = new System.Drawing.Point(698, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(455, 675);
      this.panel1.TabIndex = 280;
      // 
      // panelJuliaTypeGraph
      // 
      this.panelJuliaTypeGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelJuliaTypeGraph.Controls.Add(this.label2);
      this.panelJuliaTypeGraph.Controls.Add(this.pictureBoxJuliaTypes);
      this.panelJuliaTypeGraph.Location = new System.Drawing.Point(2, 158);
      this.panelJuliaTypeGraph.Name = "panelJuliaTypeGraph";
      this.panelJuliaTypeGraph.Size = new System.Drawing.Size(155, 156);
      this.panelJuliaTypeGraph.TabIndex = 2;
      this.panelJuliaTypeGraph.Visible = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Top;
      this.label2.Font = new System.Drawing.Font("Calibri", 9.267326F, System.Drawing.FontStyle.Bold);
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(125, 15);
      this.label2.TabIndex = 7;
      this.label2.Text = "Julia fractal at mouse:";
      // 
      // pictureBoxJuliaTypes
      // 
      this.pictureBoxJuliaTypes.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pictureBoxJuliaTypes.Location = new System.Drawing.Point(0, 17);
      this.pictureBoxJuliaTypes.Name = "pictureBoxJuliaTypes";
      this.pictureBoxJuliaTypes.Size = new System.Drawing.Size(151, 135);
      this.pictureBoxJuliaTypes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxJuliaTypes.TabIndex = 0;
      this.pictureBoxJuliaTypes.TabStop = false;
      // 
      // panelMiraTypes
      // 
      this.panelMiraTypes.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panelMiraTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelMiraTypes.Controls.Add(this.buttonResetLineplot);
      this.panelMiraTypes.Controls.Add(this.textBoxBVal);
      this.panelMiraTypes.Controls.Add(this.textBoxAVal);
      this.panelMiraTypes.Controls.Add(this.textBoxStartYLineplot);
      this.panelMiraTypes.Controls.Add(this.textBoxStartXLineplot);
      this.panelMiraTypes.Controls.Add(this.labelStartY);
      this.panelMiraTypes.Controls.Add(this.labelStartX);
      this.panelMiraTypes.Controls.Add(this.labelIterations);
      this.panelMiraTypes.Controls.Add(this.label54);
      this.panelMiraTypes.Controls.Add(this.hScrollBarIterations);
      this.panelMiraTypes.Controls.Add(this.checkBoxSpreadA);
      this.panelMiraTypes.Controls.Add(this.hScrollBarMiraB);
      this.panelMiraTypes.Controls.Add(this.hScrollBarMiraA);
      this.panelMiraTypes.Controls.Add(this.labelScrollB);
      this.panelMiraTypes.Controls.Add(this.labelScrollA);
      this.panelMiraTypes.Location = new System.Drawing.Point(135, 34);
      this.panelMiraTypes.Name = "panelMiraTypes";
      this.panelMiraTypes.Size = new System.Drawing.Size(346, 269);
      this.panelMiraTypes.TabIndex = 349;
      this.panelMiraTypes.Visible = false;
      // 
      // buttonResetLineplot
      // 
      this.buttonResetLineplot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonResetLineplot.BackgroundImage")));
      this.buttonResetLineplot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonResetLineplot.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.buttonResetLineplot.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonResetLineplot.Location = new System.Drawing.Point(26, 206);
      this.buttonResetLineplot.Name = "buttonResetLineplot";
      this.buttonResetLineplot.Size = new System.Drawing.Size(278, 43);
      this.buttonResetLineplot.TabIndex = 287;
      this.buttonResetLineplot.Text = "Reset";
      this.buttonResetLineplot.UseVisualStyleBackColor = true;
      this.buttonResetLineplot.Click += new System.EventHandler(this.buttonResetLineplot_Click);
      // 
      // textBoxBVal
      // 
      this.textBoxBVal.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.textBoxBVal.Location = new System.Drawing.Point(279, 160);
      this.textBoxBVal.Name = "textBoxBVal";
      this.textBoxBVal.Size = new System.Drawing.Size(60, 28);
      this.textBoxBVal.TabIndex = 302;
      this.textBoxBVal.Tag = "6";
      this.textBoxBVal.Text = "0";
      this.textBoxBVal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxABVal_KeyDown);
      // 
      // textBoxAVal
      // 
      this.textBoxAVal.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.textBoxAVal.Location = new System.Drawing.Point(277, 94);
      this.textBoxAVal.Name = "textBoxAVal";
      this.textBoxAVal.Size = new System.Drawing.Size(62, 28);
      this.textBoxAVal.TabIndex = 30;
      this.textBoxAVal.Tag = "6";
      this.textBoxAVal.Text = "0";
      this.textBoxAVal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxABVal_KeyDown);
      // 
      // textBoxStartYLineplot
      // 
      this.textBoxStartYLineplot.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.textBoxStartYLineplot.Location = new System.Drawing.Point(235, 10);
      this.textBoxStartYLineplot.Name = "textBoxStartYLineplot";
      this.textBoxStartYLineplot.Size = new System.Drawing.Size(62, 28);
      this.textBoxStartYLineplot.TabIndex = 301;
      this.textBoxStartYLineplot.Tag = "0";
      this.textBoxStartYLineplot.Text = "0";
      this.textBoxStartYLineplot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LineplotStartPoint);
      // 
      // textBoxStartXLineplot
      // 
      this.textBoxStartXLineplot.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.textBoxStartXLineplot.Location = new System.Drawing.Point(107, 10);
      this.textBoxStartXLineplot.Name = "textBoxStartXLineplot";
      this.textBoxStartXLineplot.Size = new System.Drawing.Size(63, 28);
      this.textBoxStartXLineplot.TabIndex = 300;
      this.textBoxStartXLineplot.Tag = "0";
      this.textBoxStartXLineplot.Text = "12";
      this.textBoxStartXLineplot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LineplotStartPoint);
      // 
      // labelStartY
      // 
      this.labelStartY.AutoSize = true;
      this.labelStartY.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.labelStartY.Location = new System.Drawing.Point(175, 13);
      this.labelStartY.Name = "labelStartY";
      this.labelStartY.Size = new System.Drawing.Size(57, 21);
      this.labelStartY.TabIndex = 18;
      this.labelStartY.Text = "Start Y";
      // 
      // labelStartX
      // 
      this.labelStartX.AutoSize = true;
      this.labelStartX.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.labelStartX.Location = new System.Drawing.Point(44, 13);
      this.labelStartX.Name = "labelStartX";
      this.labelStartX.Size = new System.Drawing.Size(57, 21);
      this.labelStartX.TabIndex = 17;
      this.labelStartX.Text = "Start X";
      // 
      // labelIterations
      // 
      this.labelIterations.AutoSize = true;
      this.labelIterations.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.labelIterations.Location = new System.Drawing.Point(275, 55);
      this.labelIterations.Name = "labelIterations";
      this.labelIterations.Size = new System.Drawing.Size(37, 21);
      this.labelIterations.TabIndex = 16;
      this.labelIterations.Text = "400";
      // 
      // label54
      // 
      this.label54.AutoSize = true;
      this.label54.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.label54.Location = new System.Drawing.Point(15, 54);
      this.label54.Name = "label54";
      this.label54.Size = new System.Drawing.Size(40, 21);
      this.label54.TabIndex = 15;
      this.label54.Text = "Iter.";
      // 
      // hScrollBarIterations
      // 
      this.hScrollBarIterations.LargeChange = 1000;
      this.hScrollBarIterations.Location = new System.Drawing.Point(59, 52);
      this.hScrollBarIterations.Maximum = 10000;
      this.hScrollBarIterations.Minimum = 100;
      this.hScrollBarIterations.Name = "hScrollBarIterations";
      this.hScrollBarIterations.Size = new System.Drawing.Size(213, 27);
      this.hScrollBarIterations.SmallChange = 100;
      this.hScrollBarIterations.TabIndex = 14;
      this.hScrollBarIterations.Value = 400;
      this.hScrollBarIterations.ValueChanged += new System.EventHandler(this.hScrollBarIterations_ValueChanged);
      // 
      // checkBoxSpreadA
      // 
      this.checkBoxSpreadA.AutoSize = true;
      this.checkBoxSpreadA.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.checkBoxSpreadA.Location = new System.Drawing.Point(34, 129);
      this.checkBoxSpreadA.Name = "checkBoxSpreadA";
      this.checkBoxSpreadA.Size = new System.Drawing.Size(222, 25);
      this.checkBoxSpreadA.TabIndex = 13;
      this.checkBoxSpreadA.Text = "Spread A (+ 4 times +/- 0.1)";
      this.checkBoxSpreadA.UseVisualStyleBackColor = true;
      this.checkBoxSpreadA.CheckedChanged += new System.EventHandler(this.checkBoxSpreadA_CheckedChanged);
      // 
      // hScrollBarMiraB
      // 
      this.hScrollBarMiraB.Location = new System.Drawing.Point(63, 161);
      this.hScrollBarMiraB.Maximum = 1000;
      this.hScrollBarMiraB.Minimum = -1000;
      this.hScrollBarMiraB.Name = "hScrollBarMiraB";
      this.hScrollBarMiraB.Size = new System.Drawing.Size(213, 27);
      this.hScrollBarMiraB.TabIndex = 10;
      this.hScrollBarMiraB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarMiraA_Scroll);
      // 
      // hScrollBarMiraA
      // 
      this.hScrollBarMiraA.Location = new System.Drawing.Point(61, 94);
      this.hScrollBarMiraA.Maximum = 1000;
      this.hScrollBarMiraA.Minimum = -1000;
      this.hScrollBarMiraA.Name = "hScrollBarMiraA";
      this.hScrollBarMiraA.Size = new System.Drawing.Size(213, 27);
      this.hScrollBarMiraA.TabIndex = 9;
      this.hScrollBarMiraA.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarMiraA_Scroll);
      // 
      // labelScrollB
      // 
      this.labelScrollB.AutoSize = true;
      this.labelScrollB.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.labelScrollB.Location = new System.Drawing.Point(30, 164);
      this.labelScrollB.Name = "labelScrollB";
      this.labelScrollB.Size = new System.Drawing.Size(25, 21);
      this.labelScrollB.TabIndex = 8;
      this.labelScrollB.Text = "B:";
      // 
      // labelScrollA
      // 
      this.labelScrollA.AutoSize = true;
      this.labelScrollA.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.labelScrollA.Location = new System.Drawing.Point(31, 101);
      this.labelScrollA.Name = "labelScrollA";
      this.labelScrollA.Size = new System.Drawing.Size(25, 21);
      this.labelScrollA.TabIndex = 7;
      this.labelScrollA.Text = "A:";
      // 
      // panelGenerateButtons
      // 
      this.panelGenerateButtons.Controls.Add(this.buttonCancelGif);
      this.panelGenerateButtons.Controls.Add(this.buttonGenerate);
      this.panelGenerateButtons.Location = new System.Drawing.Point(2, 285);
      this.panelGenerateButtons.Name = "panelGenerateButtons";
      this.panelGenerateButtons.Size = new System.Drawing.Size(446, 56);
      this.panelGenerateButtons.TabIndex = 353;
      // 
      // buttonCancelGif
      // 
      this.buttonCancelGif.BackColor = System.Drawing.Color.Red;
      this.buttonCancelGif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancelGif.BackgroundImage")));
      this.buttonCancelGif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonCancelGif.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonCancelGif.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonCancelGif.Location = new System.Drawing.Point(287, 4);
      this.buttonCancelGif.Name = "buttonCancelGif";
      this.buttonCancelGif.Size = new System.Drawing.Size(154, 51);
      this.buttonCancelGif.TabIndex = 286;
      this.buttonCancelGif.Text = "STOP Plotting!";
      this.buttonCancelGif.UseVisualStyleBackColor = false;
      this.buttonCancelGif.Click += new System.EventHandler(this.buttonCancelGif_Click);
      // 
      // buttonGenerate
      // 
      this.buttonGenerate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGenerate.BackgroundImage")));
      this.buttonGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonGenerate.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.buttonGenerate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonGenerate.Location = new System.Drawing.Point(4, 4);
      this.buttonGenerate.Name = "buttonGenerate";
      this.buttonGenerate.Size = new System.Drawing.Size(260, 51);
      this.buttonGenerate.TabIndex = 30;
      this.buttonGenerate.Text = "Generate ";
      this.buttonGenerate.UseVisualStyleBackColor = true;
      this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
      // 
      // panelJuliaTypes
      // 
      this.panelJuliaTypes.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panelJuliaTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelJuliaTypes.Controls.Add(this.textBoxjuliaMandelPowerA);
      this.panelJuliaTypes.Controls.Add(this.labelJuliaType);
      this.panelJuliaTypes.Controls.Add(this.textBoxJuliaX);
      this.panelJuliaTypes.Controls.Add(this.labeljuliaMandelPowerA);
      this.panelJuliaTypes.Controls.Add(this.textBoxJuliaY);
      this.panelJuliaTypes.Location = new System.Drawing.Point(227, 118);
      this.panelJuliaTypes.Name = "panelJuliaTypes";
      this.panelJuliaTypes.Size = new System.Drawing.Size(212, 162);
      this.panelJuliaTypes.TabIndex = 349;
      // 
      // textBoxjuliaMandelPowerA
      // 
      this.textBoxjuliaMandelPowerA.Location = new System.Drawing.Point(46, 9);
      this.textBoxjuliaMandelPowerA.Name = "textBoxjuliaMandelPowerA";
      this.textBoxjuliaMandelPowerA.Size = new System.Drawing.Size(42, 25);
      this.textBoxjuliaMandelPowerA.TabIndex = 302;
      this.textBoxjuliaMandelPowerA.Tag = "10";
      this.textBoxjuliaMandelPowerA.Text = "0";
      this.textBoxjuliaMandelPowerA.Visible = false;
      this.textBoxjuliaMandelPowerA.TextChanged += new System.EventHandler(this.textBoxLambdaA_TextChanged);
      // 
      // labelJuliaType
      // 
      this.labelJuliaType.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.labelJuliaType.Location = new System.Drawing.Point(8, 97);
      this.labelJuliaType.Name = "labelJuliaType";
      this.labelJuliaType.Size = new System.Drawing.Size(139, 25);
      this.labelJuliaType.TabIndex = 298;
      this.labelJuliaType.Text = "User defined Julia";
      this.labelJuliaType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.labelJuliaType.Visible = false;
      // 
      // textBoxJuliaX
      // 
      this.textBoxJuliaX.Enabled = false;
      this.textBoxJuliaX.Location = new System.Drawing.Point(10, 125);
      this.textBoxJuliaX.Name = "textBoxJuliaX";
      this.textBoxJuliaX.Size = new System.Drawing.Size(80, 25);
      this.textBoxJuliaX.TabIndex = 30;
      this.textBoxJuliaX.Tag = "10";
      this.textBoxJuliaX.Text = "0";
      this.textBoxJuliaX.Visible = false;
      this.textBoxJuliaX.TextChanged += new System.EventHandler(this.textBoxJuliaX_TextChanged);
      this.textBoxJuliaX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxJuliaX_KeyDown);
      // 
      // labeljuliaMandelPowerA
      // 
      this.labeljuliaMandelPowerA.AutoSize = true;
      this.labeljuliaMandelPowerA.Font = new System.Drawing.Font("Calibri", 14.25743F, System.Drawing.FontStyle.Bold);
      this.labeljuliaMandelPowerA.Location = new System.Drawing.Point(17, 6);
      this.labeljuliaMandelPowerA.Name = "labeljuliaMandelPowerA";
      this.labeljuliaMandelPowerA.Size = new System.Drawing.Size(31, 26);
      this.labeljuliaMandelPowerA.TabIndex = 301;
      this.labeljuliaMandelPowerA.Text = "A:";
      this.labeljuliaMandelPowerA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.labeljuliaMandelPowerA.Visible = false;
      // 
      // textBoxJuliaY
      // 
      this.textBoxJuliaY.Enabled = false;
      this.textBoxJuliaY.Location = new System.Drawing.Point(116, 125);
      this.textBoxJuliaY.Name = "textBoxJuliaY";
      this.textBoxJuliaY.Size = new System.Drawing.Size(80, 25);
      this.textBoxJuliaY.TabIndex = 299;
      this.textBoxJuliaY.Tag = "10";
      this.textBoxJuliaY.Text = "0";
      this.textBoxJuliaY.Visible = false;
      this.textBoxJuliaY.TextChanged += new System.EventHandler(this.textBoxJuliaY_TextChanged);
      this.textBoxJuliaY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxJuliaY_KeyDown);
      // 
      // buttonSelectType
      // 
      this.buttonSelectType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSelectType.BackgroundImage")));
      this.buttonSelectType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonSelectType.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.buttonSelectType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonSelectType.Location = new System.Drawing.Point(7, 75);
      this.buttonSelectType.Name = "buttonSelectType";
      this.buttonSelectType.Size = new System.Drawing.Size(426, 39);
      this.buttonSelectType.TabIndex = 303;
      this.buttonSelectType.Text = "Select type";
      this.buttonSelectType.UseVisualStyleBackColor = true;
      this.buttonSelectType.Click += new System.EventHandler(this.buttonSelectType_Click);
      // 
      // buttonDefineColors
      // 
      this.buttonDefineColors.BackColor = System.Drawing.SystemColors.Control;
      this.buttonDefineColors.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDefineColors.BackgroundImage")));
      this.buttonDefineColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonDefineColors.Cursor = System.Windows.Forms.Cursors.Default;
      this.buttonDefineColors.Font = new System.Drawing.Font("Calibri", 9.980198F, System.Drawing.FontStyle.Bold);
      this.buttonDefineColors.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.buttonDefineColors.Location = new System.Drawing.Point(344, 1);
      this.buttonDefineColors.Name = "buttonDefineColors";
      this.buttonDefineColors.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.buttonDefineColors.Size = new System.Drawing.Size(99, 35);
      this.buttonDefineColors.TabIndex = 303;
      this.buttonDefineColors.Text = "Define Colors";
      this.buttonDefineColors.UseVisualStyleBackColor = false;
      this.buttonDefineColors.Click += new System.EventHandler(this.buttonDefineColors_Click);
      // 
      // panelGeneralSettings
      // 
      this.panelGeneralSettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panelGeneralSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelGeneralSettings.Controls.Add(this.groupBox3);
      this.panelGeneralSettings.Controls.Add(this.label27);
      this.panelGeneralSettings.Controls.Add(this.label26);
      this.panelGeneralSettings.Controls.Add(this.textBoxXMin);
      this.panelGeneralSettings.Controls.Add(this.labelCurrY);
      this.panelGeneralSettings.Controls.Add(this.label23);
      this.panelGeneralSettings.Controls.Add(this.labelCurrX);
      this.panelGeneralSettings.Controls.Add(this.textBoxXMax);
      this.panelGeneralSettings.Controls.Add(this.textBoxYMin);
      this.panelGeneralSettings.Controls.Add(this.buttonReset);
      this.panelGeneralSettings.Controls.Add(this.textBoxYMax);
      this.panelGeneralSettings.Controls.Add(this.label16);
      this.panelGeneralSettings.Controls.Add(this.label17);
      this.panelGeneralSettings.Controls.Add(this.textBoxEscapeRadius);
      this.panelGeneralSettings.Controls.Add(this.label21);
      this.panelGeneralSettings.Controls.Add(this.label20);
      this.panelGeneralSettings.Controls.Add(this.textBoxMaxIterations);
      this.panelGeneralSettings.Location = new System.Drawing.Point(8, 346);
      this.panelGeneralSettings.Name = "panelGeneralSettings";
      this.panelGeneralSettings.Size = new System.Drawing.Size(434, 114);
      this.panelGeneralSettings.TabIndex = 2;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.radioButtonHighQuality);
      this.groupBox3.Controls.Add(this.radioButtonNormalQuality);
      this.groupBox3.Controls.Add(this.radioButtonLowQuality);
      this.groupBox3.Location = new System.Drawing.Point(243, 57);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(174, 51);
      this.groupBox3.TabIndex = 301;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Quality";
      // 
      // radioButtonHighQuality
      // 
      this.radioButtonHighQuality.AutoSize = true;
      this.radioButtonHighQuality.Location = new System.Drawing.Point(118, 22);
      this.radioButtonHighQuality.Name = "radioButtonHighQuality";
      this.radioButtonHighQuality.Size = new System.Drawing.Size(52, 21);
      this.radioButtonHighQuality.TabIndex = 3;
      this.radioButtonHighQuality.Text = "High";
      this.radioButtonHighQuality.UseVisualStyleBackColor = true;
      this.radioButtonHighQuality.CheckedChanged += new System.EventHandler(this.radioButtonHighQuality_CheckedChanged);
      // 
      // radioButtonNormalQuality
      // 
      this.radioButtonNormalQuality.AutoSize = true;
      this.radioButtonNormalQuality.Checked = true;
      this.radioButtonNormalQuality.Location = new System.Drawing.Point(54, 22);
      this.radioButtonNormalQuality.Name = "radioButtonNormalQuality";
      this.radioButtonNormalQuality.Size = new System.Drawing.Size(68, 21);
      this.radioButtonNormalQuality.TabIndex = 2;
      this.radioButtonNormalQuality.TabStop = true;
      this.radioButtonNormalQuality.Text = "Normal";
      this.radioButtonNormalQuality.UseVisualStyleBackColor = true;
      this.radioButtonNormalQuality.CheckedChanged += new System.EventHandler(this.radioButtonNormalQuality_CheckedChanged);
      // 
      // radioButtonLowQuality
      // 
      this.radioButtonLowQuality.AutoSize = true;
      this.radioButtonLowQuality.Location = new System.Drawing.Point(6, 21);
      this.radioButtonLowQuality.Name = "radioButtonLowQuality";
      this.radioButtonLowQuality.Size = new System.Drawing.Size(49, 21);
      this.radioButtonLowQuality.TabIndex = 1;
      this.radioButtonLowQuality.Text = "Low";
      this.radioButtonLowQuality.UseVisualStyleBackColor = true;
      this.radioButtonLowQuality.CheckedChanged += new System.EventHandler(this.radioButtonLowQuality_CheckedChanged);
      // 
      // label27
      // 
      this.label27.AutoSize = true;
      this.label27.Location = new System.Drawing.Point(108, 3);
      this.label27.Name = "label27";
      this.label27.Size = new System.Drawing.Size(15, 17);
      this.label27.TabIndex = 298;
      this.label27.Text = "Y";
      // 
      // label26
      // 
      this.label26.AutoSize = true;
      this.label26.Location = new System.Drawing.Point(53, 3);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(15, 17);
      this.label26.TabIndex = 297;
      this.label26.Text = "X";
      // 
      // textBoxXMin
      // 
      this.textBoxXMin.Location = new System.Drawing.Point(50, 23);
      this.textBoxXMin.Name = "textBoxXMin";
      this.textBoxXMin.Size = new System.Drawing.Size(45, 25);
      this.textBoxXMin.TabIndex = 283;
      this.textBoxXMin.Tag = "0";
      this.textBoxXMin.Text = "-2";
      this.textBoxXMin.TextChanged += new System.EventHandler(this.textBoxXmin_TextChanged);
      // 
      // labelCurrY
      // 
      this.labelCurrY.Location = new System.Drawing.Point(108, 88);
      this.labelCurrY.Name = "labelCurrY";
      this.labelCurrY.Size = new System.Drawing.Size(47, 17);
      this.labelCurrY.TabIndex = 295;
      this.labelCurrY.Text = "x";
      this.labelCurrY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label23
      // 
      this.label23.Location = new System.Drawing.Point(151, 88);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(107, 17);
      this.label23.TabIndex = 296;
      this.label23.Text = ": Mouse(X,Y)";
      // 
      // labelCurrX
      // 
      this.labelCurrX.AutoSize = true;
      this.labelCurrX.Location = new System.Drawing.Point(17, 88);
      this.labelCurrX.Name = "labelCurrX";
      this.labelCurrX.Size = new System.Drawing.Size(14, 17);
      this.labelCurrX.TabIndex = 30;
      this.labelCurrX.Text = "x";
      this.labelCurrX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxXMax
      // 
      this.textBoxXMax.Location = new System.Drawing.Point(50, 54);
      this.textBoxXMax.Name = "textBoxXMax";
      this.textBoxXMax.Size = new System.Drawing.Size(45, 25);
      this.textBoxXMax.TabIndex = 284;
      this.textBoxXMax.Tag = "0";
      this.textBoxXMax.Text = "2";
      this.textBoxXMax.TextChanged += new System.EventHandler(this.textBoxXMax_TextChanged);
      // 
      // textBoxYMin
      // 
      this.textBoxYMin.Location = new System.Drawing.Point(110, 23);
      this.textBoxYMin.Name = "textBoxYMin";
      this.textBoxYMin.Size = new System.Drawing.Size(37, 25);
      this.textBoxYMin.TabIndex = 285;
      this.textBoxYMin.Tag = "0";
      this.textBoxYMin.Text = "-2";
      this.textBoxYMin.TextChanged += new System.EventHandler(this.textBoxYMin_TextChanged);
      // 
      // buttonReset
      // 
      this.buttonReset.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.buttonReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonReset.BackgroundImage")));
      this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonReset.Location = new System.Drawing.Point(175, 18);
      this.buttonReset.Name = "buttonReset";
      this.buttonReset.Size = new System.Drawing.Size(64, 56);
      this.buttonReset.TabIndex = 282;
      this.buttonReset.Text = "Reset";
      this.buttonReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.buttonReset.UseVisualStyleBackColor = false;
      this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
      // 
      // textBoxYMax
      // 
      this.textBoxYMax.Location = new System.Drawing.Point(111, 54);
      this.textBoxYMax.Name = "textBoxYMax";
      this.textBoxYMax.Size = new System.Drawing.Size(37, 25);
      this.textBoxYMax.TabIndex = 286;
      this.textBoxYMax.Tag = "0";
      this.textBoxYMax.Text = "2";
      this.textBoxYMax.TextChanged += new System.EventHandler(this.textBoxYMax_TextChanged);
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(17, 26);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(30, 17);
      this.label16.TabIndex = 287;
      this.label16.Text = "Min";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(17, 57);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(33, 17);
      this.label17.TabIndex = 288;
      this.label17.Text = "Max";
      // 
      // textBoxEscapeRadius
      // 
      this.textBoxEscapeRadius.Location = new System.Drawing.Point(383, 32);
      this.textBoxEscapeRadius.Name = "textBoxEscapeRadius";
      this.textBoxEscapeRadius.Size = new System.Drawing.Size(34, 25);
      this.textBoxEscapeRadius.TabIndex = 294;
      this.textBoxEscapeRadius.Tag = "0";
      this.textBoxEscapeRadius.Text = "4";
      this.toolTip.SetToolTip(this.textBoxEscapeRadius, "The smaller the escape radius, the whiter the result");
      this.textBoxEscapeRadius.TextChanged += new System.EventHandler(this.textBoxEscapeRadius_TextChanged);
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(299, 35);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(84, 17);
      this.label21.TabIndex = 293;
      this.label21.Text = "Escape radius";
      this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Location = new System.Drawing.Point(289, 8);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(90, 17);
      this.label20.TabIndex = 291;
      this.label20.Text = "Max iterations";
      this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxMaxIterations
      // 
      this.textBoxMaxIterations.Location = new System.Drawing.Point(383, 5);
      this.textBoxMaxIterations.Name = "textBoxMaxIterations";
      this.textBoxMaxIterations.Size = new System.Drawing.Size(34, 25);
      this.textBoxMaxIterations.TabIndex = 292;
      this.textBoxMaxIterations.Tag = "0";
      this.textBoxMaxIterations.Text = "32";
      this.toolTip.SetToolTip(this.textBoxMaxIterations, "The more iterations, the whiter the result");
      this.textBoxMaxIterations.TextChanged += new System.EventHandler(this.textBoxMaxIterations_TextChanged);
      // 
      // panelParameters
      // 
      this.panelParameters.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panelParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelParameters.Enabled = false;
      this.panelParameters.Location = new System.Drawing.Point(7, 118);
      this.panelParameters.Name = "panelParameters";
      this.panelParameters.Size = new System.Drawing.Size(217, 162);
      this.panelParameters.TabIndex = 2;
      // 
      // NonLineairSystemsForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(1151, 675);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panelImage);
      this.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "NonLineairSystemsForm";
      this.Text = "Julia - Mandelbrot fractals";
      this.contextMenuStrip.ResumeLayout(false);
      this.panelImage.ResumeLayout(false);
      this.panelExamples.ResumeLayout(false);
      this.tabControlFractalExamples.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.panelColorPictures.ResumeLayout(false);
      this.panelColorPictures.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColors3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColors2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColors1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorsSingle)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panelJuliaTypeGraph.ResumeLayout(false);
      this.panelJuliaTypeGraph.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJuliaTypes)).EndInit();
      this.panelMiraTypes.ResumeLayout(false);
      this.panelMiraTypes.PerformLayout();
      this.panelGenerateButtons.ResumeLayout(false);
      this.panelJuliaTypes.ResumeLayout(false);
      this.panelJuliaTypes.PerformLayout();
      this.panelGeneralSettings.ResumeLayout(false);
      this.panelGeneralSettings.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

  }

}