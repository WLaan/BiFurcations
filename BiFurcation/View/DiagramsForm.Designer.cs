namespace BiFurcation {

  partial class DiagramsForm {

    #region fields
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labelParameter;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label labelFunction;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBoxStartParameter;
    private System.Windows.Forms.TextBox textBoxStopParamater;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panelImage;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Button buttonCreateDiagram;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBoxMaxIterations;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label labelNumFurcations;
    private System.Windows.Forms.ListBox listBoxFurcationGroup;
    private System.Windows.Forms.Panel panelImageFunction;
    private System.Windows.Forms.PictureBox pictureBoxFunction;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem imageToEditorToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem createGIFOverIterationsMenuItem;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox textBoxMaxGifImages;
    private System.Windows.Forms.TextBox textBoxDiagramGifName;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label labelCurrentIteration;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label labelShoozClicker;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label labelCurrY;
    private System.Windows.Forms.Label labelCurrX;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox textBoxXStart;
    private System.Windows.Forms.TextBox textBoxXStop;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Button buttonReset;
    private System.Windows.Forms.Button buttonStop;
    private System.Windows.Forms.Panel panel3;
    public System.Windows.Forms.Button buttonDefineColors;
    private System.Windows.Forms.TextBox textBoxSkipHenion150;
    private System.Windows.Forms.Label labelSkipFirst;
    private System.Windows.Forms.CheckBox checkBoxPlotFeigenbaum;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ListBox listBoxFeigenbaum;
    #endregion

    #region Windows Form Designer generated code
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
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
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiagramsForm));
      this.label1 = new System.Windows.Forms.Label();
      this.labelParameter = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.labelFunction = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.textBoxStartParameter = new System.Windows.Forms.TextBox();
      this.textBoxStopParamater = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.comboBoxChoozenFunction = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.listBoxFeigenbaum = new System.Windows.Forms.ListBox();
      this.checkBoxPlotFeigenbaum = new System.Windows.Forms.CheckBox();
      this.buttonDefineColors = new System.Windows.Forms.Button();
      this.buttonStop = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.textBoxSkipHenion150 = new System.Windows.Forms.TextBox();
      this.labelSkipFirst = new System.Windows.Forms.Label();
      this.buttonCreateDiagram = new System.Windows.Forms.Button();
      this.labelCurrentIteration = new System.Windows.Forms.Label();
      this.textBoxMaxIterations = new System.Windows.Forms.TextBox();
      this.textBoxDiagramGifName = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.textBoxMaxGifImages = new System.Windows.Forms.TextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.buttonReset = new System.Windows.Forms.Button();
      this.textBoxXStart = new System.Windows.Forms.TextBox();
      this.textBoxXStop = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.labelCurrY = new System.Windows.Forms.Label();
      this.labelCurrX = new System.Windows.Forms.Label();
      this.panelImageFunction = new System.Windows.Forms.Panel();
      this.pictureBoxFunction = new System.Windows.Forms.PictureBox();
      this.listBoxFurcationGroup = new System.Windows.Forms.ListBox();
      this.labelNumFurcations = new System.Windows.Forms.Label();
      this.panelImage = new System.Windows.Forms.Panel();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.labelShoozClicker = new System.Windows.Forms.Label();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.imageToEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createGIFOverIterationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.label9 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panelImageFunction.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFunction)).BeginInit();
      this.panelImage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.contextMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(5, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(92, 21);
      this.label1.TabIndex = 0;
      this.label1.Text = "Parameter :";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // labelParameter
      // 
      this.labelParameter.AutoSize = true;
      this.labelParameter.Location = new System.Drawing.Point(101, 7);
      this.labelParameter.Name = "labelParameter";
      this.labelParameter.Size = new System.Drawing.Size(17, 18);
      this.labelParameter.TabIndex = 1;
      this.labelParameter.Text = "A";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(6, 3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(80, 21);
      this.label3.TabIndex = 2;
      this.label3.Text = "Function:";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // labelFunction
      // 
      this.labelFunction.AutoSize = true;
      this.labelFunction.Location = new System.Drawing.Point(84, 4);
      this.labelFunction.Name = "labelFunction";
      this.labelFunction.Size = new System.Drawing.Size(65, 18);
      this.labelFunction.TabIndex = 3;
      this.labelFunction.Text = "Function:";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(63, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(36, 21);
      this.label2.TabIndex = 4;
      this.label2.Text = "Min:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(60, 61);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(39, 21);
      this.label4.TabIndex = 5;
      this.label4.Text = "Max:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxStartParameter
      // 
      this.textBoxStartParameter.Location = new System.Drawing.Point(102, 31);
      this.textBoxStartParameter.Name = "textBoxStartParameter";
      this.textBoxStartParameter.Size = new System.Drawing.Size(59, 25);
      this.textBoxStartParameter.TabIndex = 6;
      this.textBoxStartParameter.Text = "0";
      this.textBoxStartParameter.TextChanged += new System.EventHandler(this.textBoxStartParameter_TextChanged);
      this.textBoxStartParameter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // textBoxStopParamater
      // 
      this.textBoxStopParamater.Location = new System.Drawing.Point(102, 61);
      this.textBoxStopParamater.Name = "textBoxStopParamater";
      this.textBoxStopParamater.Size = new System.Drawing.Size(59, 25);
      this.textBoxStopParamater.TabIndex = 7;
      this.textBoxStopParamater.Text = "0";
      this.textBoxStopParamater.TextChanged += new System.EventHandler(this.textBoxStopParamater_TextChanged);
      this.textBoxStopParamater.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel1.Controls.Add(this.comboBoxChoozenFunction);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.listBoxFeigenbaum);
      this.panel1.Controls.Add(this.checkBoxPlotFeigenbaum);
      this.panel1.Controls.Add(this.buttonDefineColors);
      this.panel1.Controls.Add(this.buttonStop);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Controls.Add(this.panelImageFunction);
      this.panel1.Controls.Add(this.listBoxFurcationGroup);
      this.panel1.Controls.Add(this.labelNumFurcations);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.labelFunction);
      this.panel1.Location = new System.Drawing.Point(753, 1);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(372, 696);
      this.panel1.TabIndex = 8;
      // 
      // comboBoxChoozenFunction
      // 
      this.comboBoxChoozenFunction.FormattingEnabled = true;
      this.comboBoxChoozenFunction.Items.AddRange(new object[] {
            "Ax(1-x)",
            "Ax^2 + Bx + C",
            "Henon"});
      this.comboBoxChoozenFunction.Location = new System.Drawing.Point(21, 23);
      this.comboBoxChoozenFunction.Name = "comboBoxChoozenFunction";
      this.comboBoxChoozenFunction.Size = new System.Drawing.Size(167, 25);
      this.comboBoxChoozenFunction.TabIndex = 306;
      this.comboBoxChoozenFunction.Text = "Ax(1-x)";
      this.comboBoxChoozenFunction.SelectedIndexChanged += new System.EventHandler(this.comboBoxChoozenFunction_SelectedIndexChanged);
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(255, 45);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(104, 21);
      this.label6.TabIndex = 305;
      this.label6.Text = "Feigenbaum\'s:";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // listBoxFeigenbaum
      // 
      this.listBoxFeigenbaum.Font = new System.Drawing.Font("Calibri", 7.841584F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.listBoxFeigenbaum.FormattingEnabled = true;
      this.listBoxFeigenbaum.Items.AddRange(new object[] {
            "3.000000",
            "3.449490",
            "3.544090",
            "3.564400",
            "3.568759",
            "3.569692",
            "3.569890",
            "3.569930"});
      this.listBoxFeigenbaum.Location = new System.Drawing.Point(259, 65);
      this.listBoxFeigenbaum.Name = "listBoxFeigenbaum";
      this.listBoxFeigenbaum.Size = new System.Drawing.Size(99, 108);
      this.listBoxFeigenbaum.TabIndex = 304;
      this.listBoxFeigenbaum.SelectedIndexChanged += new System.EventHandler(this.listBoxFeigenbaum_SelectedIndexChanged);
      // 
      // checkBoxPlotFeigenbaum
      // 
      this.checkBoxPlotFeigenbaum.AutoSize = true;
      this.checkBoxPlotFeigenbaum.Font = new System.Drawing.Font("Calibri", 9.980198F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.checkBoxPlotFeigenbaum.ForeColor = System.Drawing.Color.Red;
      this.checkBoxPlotFeigenbaum.Location = new System.Drawing.Point(187, 366);
      this.checkBoxPlotFeigenbaum.Name = "checkBoxPlotFeigenbaum";
      this.checkBoxPlotFeigenbaum.Size = new System.Drawing.Size(167, 21);
      this.checkBoxPlotFeigenbaum.TabIndex = 303;
      this.checkBoxPlotFeigenbaum.Text = "Mark Feigenbaum values";
      this.checkBoxPlotFeigenbaum.UseVisualStyleBackColor = true;
      this.checkBoxPlotFeigenbaum.CheckedChanged += new System.EventHandler(this.checkBoxPlotFeigenbaum_CheckedChanged);
      // 
      // buttonDefineColors
      // 
      this.buttonDefineColors.BackColor = System.Drawing.SystemColors.Control;
      this.buttonDefineColors.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDefineColors.BackgroundImage")));
      this.buttonDefineColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonDefineColors.Cursor = System.Windows.Forms.Cursors.Default;
      this.buttonDefineColors.Font = new System.Drawing.Font("Calibri", 9.980198F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.buttonDefineColors.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.buttonDefineColors.Location = new System.Drawing.Point(263, 4);
      this.buttonDefineColors.Name = "buttonDefineColors";
      this.buttonDefineColors.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.buttonDefineColors.Size = new System.Drawing.Size(99, 38);
      this.buttonDefineColors.TabIndex = 302;
      this.buttonDefineColors.Text = "Define Colors";
      this.buttonDefineColors.UseVisualStyleBackColor = false;
      this.buttonDefineColors.Click += new System.EventHandler(this.buttonDefineColors_Click);
      // 
      // buttonStop
      // 
      this.buttonStop.BackColor = System.Drawing.Color.Red;
      this.buttonStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStop.BackgroundImage")));
      this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonStop.Location = new System.Drawing.Point(261, 179);
      this.buttonStop.Name = "buttonStop";
      this.buttonStop.Size = new System.Drawing.Size(99, 35);
      this.buttonStop.TabIndex = 285;
      this.buttonStop.Text = "STOP!";
      this.buttonStop.UseVisualStyleBackColor = false;
      this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel3.Controls.Add(this.textBoxSkipHenion150);
      this.panel3.Controls.Add(this.labelSkipFirst);
      this.panel3.Controls.Add(this.buttonCreateDiagram);
      this.panel3.Controls.Add(this.labelCurrentIteration);
      this.panel3.Controls.Add(this.textBoxMaxIterations);
      this.panel3.Controls.Add(this.textBoxDiagramGifName);
      this.panel3.Controls.Add(this.label5);
      this.panel3.Controls.Add(this.label8);
      this.panel3.Controls.Add(this.label7);
      this.panel3.Controls.Add(this.textBoxMaxGifImages);
      this.panel3.Location = new System.Drawing.Point(19, 48);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(231, 171);
      this.panel3.TabIndex = 26;
      // 
      // textBoxSkipHenion150
      // 
      this.textBoxSkipHenion150.Location = new System.Drawing.Point(134, 37);
      this.textBoxSkipHenion150.Name = "textBoxSkipHenion150";
      this.textBoxSkipHenion150.Size = new System.Drawing.Size(59, 25);
      this.textBoxSkipHenion150.TabIndex = 26;
      this.textBoxSkipHenion150.Text = "100";
      this.textBoxSkipHenion150.TextChanged += new System.EventHandler(this.textBoxSkipHenion150_TextChanged);
      // 
      // labelSkipFirst
      // 
      this.labelSkipFirst.Location = new System.Drawing.Point(41, 37);
      this.labelSkipFirst.Name = "labelSkipFirst";
      this.labelSkipFirst.Size = new System.Drawing.Size(93, 21);
      this.labelSkipFirst.TabIndex = 25;
      this.labelSkipFirst.Text = "Skip first:";
      this.labelSkipFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // buttonCreateDiagram
      // 
      this.buttonCreateDiagram.BackColor = System.Drawing.SystemColors.Control;
      this.buttonCreateDiagram.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCreateDiagram.BackgroundImage")));
      this.buttonCreateDiagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonCreateDiagram.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.buttonCreateDiagram.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonCreateDiagram.Location = new System.Drawing.Point(3, 129);
      this.buttonCreateDiagram.Name = "buttonCreateDiagram";
      this.buttonCreateDiagram.Size = new System.Drawing.Size(219, 35);
      this.buttonCreateDiagram.TabIndex = 8;
      this.buttonCreateDiagram.Text = "Create diagram";
      this.buttonCreateDiagram.UseVisualStyleBackColor = false;
      this.buttonCreateDiagram.Click += new System.EventHandler(this.buttonCreateDiagram_Click);
      // 
      // labelCurrentIteration
      // 
      this.labelCurrentIteration.Location = new System.Drawing.Point(200, 72);
      this.labelCurrentIteration.Name = "labelCurrentIteration";
      this.labelCurrentIteration.Size = new System.Drawing.Size(55, 21);
      this.labelCurrentIteration.TabIndex = 24;
      this.labelCurrentIteration.Text = "1";
      this.labelCurrentIteration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxMaxIterations
      // 
      this.textBoxMaxIterations.Location = new System.Drawing.Point(135, 6);
      this.textBoxMaxIterations.Name = "textBoxMaxIterations";
      this.textBoxMaxIterations.Size = new System.Drawing.Size(59, 25);
      this.textBoxMaxIterations.TabIndex = 14;
      this.textBoxMaxIterations.Text = "1000";
      this.textBoxMaxIterations.TextChanged += new System.EventHandler(this.textBoxMaxIterations_TextChanged);
      this.textBoxMaxIterations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // textBoxDiagramGifName
      // 
      this.textBoxDiagramGifName.Location = new System.Drawing.Point(101, 99);
      this.textBoxDiagramGifName.Name = "textBoxDiagramGifName";
      this.textBoxDiagramGifName.Size = new System.Drawing.Size(121, 25);
      this.textBoxDiagramGifName.TabIndex = 23;
      this.textBoxDiagramGifName.Text = "Diagram.GIF";
      this.textBoxDiagramGifName.TextChanged += new System.EventHandler(this.textBoxDiagramGifName_TextChanged);
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(22, 6);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(113, 21);
      this.label5.TabIndex = 13;
      this.label5.Text = "Max. iter. per x:";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(7, 101);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(92, 21);
      this.label8.TabIndex = 22;
      this.label8.Text = "GIF filename: ";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(2, 71);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(132, 21);
      this.label7.TabIndex = 20;
      this.label7.Text = "Max. image for GIF";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxMaxGifImages
      // 
      this.textBoxMaxGifImages.Location = new System.Drawing.Point(135, 70);
      this.textBoxMaxGifImages.Name = "textBoxMaxGifImages";
      this.textBoxMaxGifImages.Size = new System.Drawing.Size(59, 25);
      this.textBoxMaxGifImages.TabIndex = 21;
      this.textBoxMaxGifImages.Text = "20";
      this.textBoxMaxGifImages.TextChanged += new System.EventHandler(this.textBoxMaxGifImages_TextChanged);
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel2.Controls.Add(this.buttonReset);
      this.panel2.Controls.Add(this.textBoxXStart);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.textBoxXStop);
      this.panel2.Controls.Add(this.labelParameter);
      this.panel2.Controls.Add(this.label11);
      this.panel2.Controls.Add(this.textBoxStopParamater);
      this.panel2.Controls.Add(this.label10);
      this.panel2.Controls.Add(this.label4);
      this.panel2.Controls.Add(this.labelCurrY);
      this.panel2.Controls.Add(this.textBoxStartParameter);
      this.panel2.Controls.Add(this.labelCurrX);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Location = new System.Drawing.Point(19, 225);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(340, 121);
      this.panel2.TabIndex = 26;
      // 
      // buttonReset
      // 
      this.buttonReset.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.buttonReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonReset.BackgroundImage")));
      this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonReset.Location = new System.Drawing.Point(237, 30);
      this.buttonReset.Name = "buttonReset";
      this.buttonReset.Size = new System.Drawing.Size(57, 57);
      this.buttonReset.TabIndex = 284;
      this.buttonReset.Text = "Reset";
      this.buttonReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.buttonReset.UseVisualStyleBackColor = false;
      this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
      // 
      // textBoxXStart
      // 
      this.textBoxXStart.Location = new System.Drawing.Point(170, 31);
      this.textBoxXStart.Name = "textBoxXStart";
      this.textBoxXStart.Size = new System.Drawing.Size(59, 25);
      this.textBoxXStart.TabIndex = 37;
      this.textBoxXStart.Text = "0";
      // 
      // textBoxXStop
      // 
      this.textBoxXStop.Location = new System.Drawing.Point(170, 61);
      this.textBoxXStop.Name = "textBoxXStop";
      this.textBoxXStop.Size = new System.Drawing.Size(59, 25);
      this.textBoxXStop.TabIndex = 38;
      this.textBoxXStop.Text = "0";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(191, 7);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(15, 18);
      this.label11.TabIndex = 36;
      this.label11.Text = "x";
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(234, 91);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(99, 21);
      this.label10.TabIndex = 35;
      this.label10.Text = ": Mouse (A,x)";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelCurrY
      // 
      this.labelCurrY.Location = new System.Drawing.Point(170, 91);
      this.labelCurrY.Name = "labelCurrY";
      this.labelCurrY.Size = new System.Drawing.Size(59, 21);
      this.labelCurrY.TabIndex = 34;
      this.labelCurrY.Text = "0";
      this.labelCurrY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // labelCurrX
      // 
      this.labelCurrX.Location = new System.Drawing.Point(98, 91);
      this.labelCurrX.Name = "labelCurrX";
      this.labelCurrX.Size = new System.Drawing.Size(63, 21);
      this.labelCurrX.TabIndex = 33;
      this.labelCurrX.Text = "0";
      this.labelCurrX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // panelImageFunction
      // 
      this.panelImageFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.panelImageFunction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelImageFunction.Controls.Add(this.pictureBoxFunction);
      this.panelImageFunction.Location = new System.Drawing.Point(17, 445);
      this.panelImageFunction.Name = "panelImageFunction";
      this.panelImageFunction.Size = new System.Drawing.Size(337, 244);
      this.panelImageFunction.TabIndex = 19;
      // 
      // pictureBoxFunction
      // 
      this.pictureBoxFunction.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBoxFunction.Location = new System.Drawing.Point(0, 0);
      this.pictureBoxFunction.Name = "pictureBoxFunction";
      this.pictureBoxFunction.Size = new System.Drawing.Size(333, 240);
      this.pictureBoxFunction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxFunction.TabIndex = 0;
      this.pictureBoxFunction.TabStop = false;
      this.pictureBoxFunction.DoubleClick += new System.EventHandler(this.pictureBoxFunction_DoubleClick);
      // 
      // listBoxFurcationGroup
      // 
      this.listBoxFurcationGroup.FormattingEnabled = true;
      this.listBoxFurcationGroup.ItemHeight = 17;
      this.listBoxFurcationGroup.Location = new System.Drawing.Point(19, 366);
      this.listBoxFurcationGroup.Name = "listBoxFurcationGroup";
      this.listBoxFurcationGroup.Size = new System.Drawing.Size(168, 72);
      this.listBoxFurcationGroup.TabIndex = 18;
      // 
      // labelNumFurcations
      // 
      this.labelNumFurcations.AutoSize = true;
      this.labelNumFurcations.Location = new System.Drawing.Point(13, 345);
      this.labelNumFurcations.Name = "labelNumFurcations";
      this.labelNumFurcations.Size = new System.Drawing.Size(199, 18);
      this.labelNumFurcations.TabIndex = 17;
      this.labelNumFurcations.Text = "Number of convergence points";
      // 
      // panelImage
      // 
      this.panelImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panelImage.AutoScroll = true;
      this.panelImage.Controls.Add(this.progressBar);
      this.panelImage.Controls.Add(this.labelShoozClicker);
      this.panelImage.Controls.Add(this.pictureBox);
      this.panelImage.Location = new System.Drawing.Point(1, 1);
      this.panelImage.Name = "panelImage";
      this.panelImage.Size = new System.Drawing.Size(746, 722);
      this.panelImage.TabIndex = 26;
      // 
      // progressBar
      // 
      this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar.Location = new System.Drawing.Point(46, 3);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(663, 23);
      this.progressBar.TabIndex = 1;
      this.progressBar.Visible = false;
      // 
      // labelShoozClicker
      // 
      this.labelShoozClicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelShoozClicker.BackColor = System.Drawing.Color.MediumSeaGreen;
      this.labelShoozClicker.Location = new System.Drawing.Point(43, 700);
      this.labelShoozClicker.Name = "labelShoozClicker";
      this.labelShoozClicker.Size = new System.Drawing.Size(666, 18);
      this.labelShoozClicker.TabIndex = 25;
      this.labelShoozClicker.MouseClick += new System.Windows.Forms.MouseEventHandler(this.choozClicker_MouseClick);
      // 
      // pictureBox
      // 
      this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureBox.ContextMenuStrip = this.contextMenuStrip;
      this.pictureBox.Location = new System.Drawing.Point(0, 0);
      this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(746, 696);
      this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
      this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
      this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
      // 
      // contextMenuStrip
      // 
      this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(17, 17);
      this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToEditorToolStripMenuItem,
            this.createGIFOverIterationsMenuItem});
      this.contextMenuStrip.Name = "contextMenuStrip";
      this.contextMenuStrip.Size = new System.Drawing.Size(225, 48);
      // 
      // imageToEditorToolStripMenuItem
      // 
      this.imageToEditorToolStripMenuItem.Name = "imageToEditorToolStripMenuItem";
      this.imageToEditorToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
      this.imageToEditorToolStripMenuItem.Text = "Image to Editor";
      this.imageToEditorToolStripMenuItem.Click += new System.EventHandler(this.imageToEditorToolStripMenuItem_Click);
      // 
      // createGIFOverIterationsMenuItem
      // 
      this.createGIFOverIterationsMenuItem.Name = "createGIFOverIterationsMenuItem";
      this.createGIFOverIterationsMenuItem.Size = new System.Drawing.Size(224, 22);
      this.createGIFOverIterationsMenuItem.Text = "Create GIF over iterations";
      this.createGIFOverIterationsMenuItem.Click += new System.EventHandler(this.createGIFOverIterationsMenuItem_Click);
      // 
      // label9
      // 
      this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label9.Location = new System.Drawing.Point(758, 700);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(185, 18);
      this.label9.TabIndex = 25;
      this.label9.Text = "<- Click to choose value for A";
      // 
      // DiagramsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1132, 723);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.panelImage);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "DiagramsForm";
      this.Text = "Attraction Diagram";
      this.Resize += new System.EventHandler(this.BifurcationDiagram_Resize);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panelImageFunction.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFunction)).EndInit();
      this.panelImage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.contextMenuStrip.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox comboBoxChoozenFunction;
  }
}