namespace BiFurcation {

  partial class FunctionsForm {

    #region fields
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label labelC;
    private System.Windows.Forms.TextBox textBoxC;
    private System.Windows.Forms.Button buttonEmulate;
    private System.Windows.Forms.TextBox textBoxSeed;
    private System.Windows.Forms.Label labelSeed;
    private System.Windows.Forms.Label labelIterations;
    private System.Windows.Forms.TextBox textBoxMaxIterations;
    private System.Windows.Forms.Label labelChoozenFunction;
    private System.Windows.Forms.TextBox textBoxB;
    private System.Windows.Forms.Label labelB;
    private System.Windows.Forms.TextBox textBoxA;
    private System.Windows.Forms.Label labelA;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Panel panelOneDimensiolFunctions;
    private System.Windows.Forms.ListBox listBoxXValues;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel4Image;
    private System.Windows.Forms.ColorDialog colorDialog;
    private System.Windows.Forms.Label labelGeneralFunction;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label labelSetCount;
    private System.Windows.Forms.Button buttonBifurcationDiagram;
    private System.Windows.Forms.RadioButton radioButtonParamaterA;
    private System.Windows.Forms.GroupBox groupBoxParameter;
    private System.Windows.Forms.RadioButton radioButtonParamaterC;
    private System.Windows.Forms.RadioButton radioButtonParamaterB;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Label labelLast1000;
    private System.Windows.Forms.ComboBox comboBoxChoozenFunction;
    private System.Windows.Forms.Button buttonSimulate;
    private System.Windows.Forms.Button buttonSimulatePar;
    private System.Windows.Forms.TextBox textBoxStopParValue;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxEndX;
    private System.Windows.Forms.TextBox textBoxStartX;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Panel panelAttractionIterations;
    private System.Windows.Forms.TextBox textBoxEndY;
    private System.Windows.Forms.TextBox textBoxStartY;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panelMainPanel;
    private System.Windows.Forms.Panel panel6;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.CheckBox checkBoxHideFurcationLines;
    private System.Windows.Forms.TextBox textBoxGIFFilename;
    private System.Windows.Forms.Button buttonCombinations;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem imageToEditorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem createGIFOverIterationsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem createGIFOverParameterMenuItem;
    private System.Windows.Forms.Label labelCurrY;
    private System.Windows.Forms.Label labelCurrX;
    private System.Windows.Forms.Button buttonReset;
    private System.Windows.Forms.Panel panel7;
    private System.Windows.Forms.Button buttonCalcHenon;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Panel panelHenon;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button buttonCancelGif;
    private System.Windows.Forms.ToolStripMenuItem calcTrajectoryAtCursorMenuItem;
    private System.Windows.Forms.Button buttonStopTrajectory;
    private System.Windows.Forms.Button buttonNextTrajectory;
    public System.Windows.Forms.Button buttonDefineColors;
    private System.Windows.Forms.NumericUpDown numericUpDownDotSize;
    private System.Windows.Forms.NumericUpDown numericUpDownMultPointsPerStep;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label labelNoPoints;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.NumericUpDown numericUpDownInitialPoints;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.CheckBox checkBoxSeedWithMouseCursor;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.ListBox listBoxFeigenbaum;
    private System.Windows.Forms.CheckBox checkBoxSetSeed;
    private System.Windows.Forms.Panel panelLogistic;
    private System.Windows.Forms.CheckBox checkBoxOmitFirstIterations;
    private System.Windows.Forms.CheckBox checkBoxShowFn;
    #endregion

    #region Windows Form Designer generated code
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
     //   Constants.settings2XML();
      }
      base.Dispose(disposing);
    }
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionsForm));
      this.label2 = new System.Windows.Forms.Label();
      this.labelC = new System.Windows.Forms.Label();
      this.textBoxC = new System.Windows.Forms.TextBox();
      this.textBoxSeed = new System.Windows.Forms.TextBox();
      this.labelSeed = new System.Windows.Forms.Label();
      this.labelIterations = new System.Windows.Forms.Label();
      this.textBoxMaxIterations = new System.Windows.Forms.TextBox();
      this.labelChoozenFunction = new System.Windows.Forms.Label();
      this.textBoxB = new System.Windows.Forms.TextBox();
      this.labelB = new System.Windows.Forms.Label();
      this.textBoxA = new System.Windows.Forms.TextBox();
      this.labelA = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.panelOneDimensiolFunctions = new System.Windows.Forms.Panel();
      this.checkBoxShowFn = new System.Windows.Forms.CheckBox();
      this.checkBoxOmitFirstIterations = new System.Windows.Forms.CheckBox();
      this.checkBoxHideFurcationLines = new System.Windows.Forms.CheckBox();
      this.buttonDefineColors = new System.Windows.Forms.Button();
      this.panel7 = new System.Windows.Forms.Panel();
      this.label9 = new System.Windows.Forms.Label();
      this.labelCurrY = new System.Windows.Forms.Label();
      this.textBoxStartX = new System.Windows.Forms.TextBox();
      this.buttonReset = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.labelCurrX = new System.Windows.Forms.Label();
      this.textBoxEndX = new System.Windows.Forms.TextBox();
      this.label16 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.textBoxStartY = new System.Windows.Forms.TextBox();
      this.textBoxEndY = new System.Windows.Forms.TextBox();
      this.panel4 = new System.Windows.Forms.Panel();
      this.checkBoxSeedWithMouseCursor = new System.Windows.Forms.CheckBox();
      this.label13 = new System.Windows.Forms.Label();
      this.buttonCancelGif = new System.Windows.Forms.Button();
      this.comboBoxChoozenFunction = new System.Windows.Forms.ComboBox();
      this.panelAttractionIterations = new System.Windows.Forms.Panel();
      this.textBoxGIFFilename = new System.Windows.Forms.TextBox();
      this.buttonSimulatePar = new System.Windows.Forms.Button();
      this.buttonSimulate = new System.Windows.Forms.Button();
      this.buttonEmulate = new System.Windows.Forms.Button();
      this.groupBoxParameter = new System.Windows.Forms.GroupBox();
      this.radioButtonParamaterC = new System.Windows.Forms.RadioButton();
      this.textBoxStopParValue = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.radioButtonParamaterB = new System.Windows.Forms.RadioButton();
      this.radioButtonParamaterA = new System.Windows.Forms.RadioButton();
      this.panelLogistic = new System.Windows.Forms.Panel();
      this.checkBoxSetSeed = new System.Windows.Forms.CheckBox();
      this.listBoxFeigenbaum = new System.Windows.Forms.ListBox();
      this.label14 = new System.Windows.Forms.Label();
      this.panelHenon = new System.Windows.Forms.Panel();
      this.label10 = new System.Windows.Forms.Label();
      this.numericUpDownInitialPoints = new System.Windows.Forms.NumericUpDown();
      this.labelNoPoints = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.numericUpDownMultPointsPerStep = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.numericUpDownDotSize = new System.Windows.Forms.NumericUpDown();
      this.buttonNextTrajectory = new System.Windows.Forms.Button();
      this.buttonStopTrajectory = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.buttonCalcHenon = new System.Windows.Forms.Button();
      this.labelGeneralFunction = new System.Windows.Forms.Label();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.listBoxXValues = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panel4Image = new System.Windows.Forms.Panel();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.imageToEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createGIFOverIterationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createGIFOverParameterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.calcTrajectoryAtCursorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.panelMainPanel = new System.Windows.Forms.Panel();
      this.panel6 = new System.Windows.Forms.Panel();
      this.buttonCombinations = new System.Windows.Forms.Button();
      this.labelLast1000 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.buttonBifurcationDiagram = new System.Windows.Forms.Button();
      this.labelSetCount = new System.Windows.Forms.Label();
      this.colorDialog = new System.Windows.Forms.ColorDialog();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.panelOneDimensiolFunctions.SuspendLayout();
      this.panel7.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panelAttractionIterations.SuspendLayout();
      this.groupBoxParameter.SuspendLayout();
      this.panelLogistic.SuspendLayout();
      this.panelHenon.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialPoints)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMultPointsPerStep)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDotSize)).BeginInit();
      this.panel4Image.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.contextMenuStrip.SuspendLayout();
      this.panelMainPanel.SuspendLayout();
      this.panel6.SuspendLayout();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.label2.Location = new System.Drawing.Point(67, 5);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(171, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "General attraction function:  ";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // labelC
      // 
      this.labelC.Location = new System.Drawing.Point(2, 116);
      this.labelC.Name = "labelC";
      this.labelC.Size = new System.Drawing.Size(123, 32);
      this.labelC.TabIndex = 3;
      this.labelC.Text = "Parameter C:";
      this.labelC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.labelC.Visible = false;
      // 
      // textBoxC
      // 
      this.textBoxC.Location = new System.Drawing.Point(131, 119);
      this.textBoxC.Name = "textBoxC";
      this.textBoxC.Size = new System.Drawing.Size(60, 25);
      this.textBoxC.TabIndex = 6;
      this.textBoxC.Text = "-0.25";
      this.textBoxC.Visible = false;
      this.textBoxC.TextChanged += new System.EventHandler(this.textBoxC_TextChanged);
      this.textBoxC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // textBoxSeed
      // 
      this.textBoxSeed.Location = new System.Drawing.Point(131, 149);
      this.textBoxSeed.Name = "textBoxSeed";
      this.textBoxSeed.Size = new System.Drawing.Size(60, 25);
      this.textBoxSeed.TabIndex = 10;
      this.textBoxSeed.Text = "0.3";
      this.textBoxSeed.TextChanged += new System.EventHandler(this.textBoxSeed_TextChanged);
      this.textBoxSeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // labelSeed
      // 
      this.labelSeed.Location = new System.Drawing.Point(42, 146);
      this.labelSeed.Name = "labelSeed";
      this.labelSeed.Size = new System.Drawing.Size(82, 32);
      this.labelSeed.TabIndex = 8;
      this.labelSeed.Text = "Seed:";
      this.labelSeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // labelIterations
      // 
      this.labelIterations.Location = new System.Drawing.Point(5, 177);
      this.labelIterations.Name = "labelIterations";
      this.labelIterations.Size = new System.Drawing.Size(117, 32);
      this.labelIterations.TabIndex = 11;
      this.labelIterations.Text = "Max. iterations:";
      this.labelIterations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxMaxIterations
      // 
      this.textBoxMaxIterations.Location = new System.Drawing.Point(131, 180);
      this.textBoxMaxIterations.Name = "textBoxMaxIterations";
      this.textBoxMaxIterations.Size = new System.Drawing.Size(60, 25);
      this.textBoxMaxIterations.TabIndex = 12;
      this.textBoxMaxIterations.Text = "100";
      this.textBoxMaxIterations.TextChanged += new System.EventHandler(this.textBoxMaxIterations_TextChanged);
      this.textBoxMaxIterations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // labelChoozenFunction
      // 
      this.labelChoozenFunction.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.labelChoozenFunction.Location = new System.Drawing.Point(250, 23);
      this.labelChoozenFunction.Margin = new System.Windows.Forms.Padding(0);
      this.labelChoozenFunction.Name = "labelChoozenFunction";
      this.labelChoozenFunction.Size = new System.Drawing.Size(300, 23);
      this.labelChoozenFunction.TabIndex = 13;
      this.labelChoozenFunction.Text = "x^2 - 0.25";
      this.labelChoozenFunction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxB
      // 
      this.textBoxB.Enabled = false;
      this.textBoxB.Location = new System.Drawing.Point(131, 89);
      this.textBoxB.Name = "textBoxB";
      this.textBoxB.Size = new System.Drawing.Size(60, 25);
      this.textBoxB.TabIndex = 16;
      this.textBoxB.Text = "0";
      this.textBoxB.TextChanged += new System.EventHandler(this.textBoxB_TextChanged);
      this.textBoxB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // labelB
      // 
      this.labelB.Location = new System.Drawing.Point(2, 86);
      this.labelB.Name = "labelB";
      this.labelB.Size = new System.Drawing.Size(123, 32);
      this.labelB.TabIndex = 15;
      this.labelB.Text = "Parameter B:";
      this.labelB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxA
      // 
      this.textBoxA.Location = new System.Drawing.Point(131, 59);
      this.textBoxA.Name = "textBoxA";
      this.textBoxA.Size = new System.Drawing.Size(60, 25);
      this.textBoxA.TabIndex = 19;
      this.textBoxA.Text = "1";
      this.textBoxA.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
      this.textBoxA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // labelA
      // 
      this.labelA.Location = new System.Drawing.Point(2, 56);
      this.labelA.Name = "labelA";
      this.labelA.Size = new System.Drawing.Size(123, 32);
      this.labelA.TabIndex = 18;
      this.labelA.Text = "Parameter A:";
      this.labelA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label11
      // 
      this.label11.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.label11.Location = new System.Drawing.Point(59, 23);
      this.label11.Margin = new System.Windows.Forms.Padding(0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(191, 23);
      this.label11.TabIndex = 20;
      this.label11.Text = "Choozen function (f0):  ";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // panelOneDimensiolFunctions
      // 
      this.panelOneDimensiolFunctions.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.panelOneDimensiolFunctions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelOneDimensiolFunctions.Controls.Add(this.checkBoxShowFn);
      this.panelOneDimensiolFunctions.Controls.Add(this.checkBoxOmitFirstIterations);
      this.panelOneDimensiolFunctions.Controls.Add(this.buttonCancelGif);
      this.panelOneDimensiolFunctions.Controls.Add(this.checkBoxHideFurcationLines);
      this.panelOneDimensiolFunctions.Controls.Add(this.buttonDefineColors);
      this.panelOneDimensiolFunctions.Controls.Add(this.panel7);
      this.panelOneDimensiolFunctions.Controls.Add(this.panel4);
      this.panelOneDimensiolFunctions.Controls.Add(this.labelGeneralFunction);
      this.panelOneDimensiolFunctions.Controls.Add(this.label11);
      this.panelOneDimensiolFunctions.Controls.Add(this.label2);
      this.panelOneDimensiolFunctions.Controls.Add(this.labelChoozenFunction);
      this.panelOneDimensiolFunctions.Location = new System.Drawing.Point(2, 0);
      this.panelOneDimensiolFunctions.Name = "panelOneDimensiolFunctions";
      this.panelOneDimensiolFunctions.Size = new System.Drawing.Size(538, 487);
      this.panelOneDimensiolFunctions.TabIndex = 21;
      // 
      // checkBoxShowFn
      // 
      this.checkBoxShowFn.Font = new System.Drawing.Font("Calibri", 9.980198F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
      this.checkBoxShowFn.Location = new System.Drawing.Point(359, 438);
      this.checkBoxShowFn.Name = "checkBoxShowFn";
      this.checkBoxShowFn.Size = new System.Drawing.Size(160, 19);
      this.checkBoxShowFn.TabIndex = 302;
      this.checkBoxShowFn.Text = "Show Fn";
      this.checkBoxShowFn.UseVisualStyleBackColor = true;
      this.checkBoxShowFn.CheckedChanged += new System.EventHandler(this.checkBoxShowFn_CheckedChanged);
      // 
      // checkBoxOmitFirstIterations
      // 
      this.checkBoxOmitFirstIterations.Font = new System.Drawing.Font("Calibri", 9.980198F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
      this.checkBoxOmitFirstIterations.Location = new System.Drawing.Point(359, 411);
      this.checkBoxOmitFirstIterations.Name = "checkBoxOmitFirstIterations";
      this.checkBoxOmitFirstIterations.Size = new System.Drawing.Size(160, 19);
      this.checkBoxOmitFirstIterations.TabIndex = 288;
      this.checkBoxOmitFirstIterations.Text = "Show only convergent set";
      this.checkBoxOmitFirstIterations.UseVisualStyleBackColor = true;
      this.checkBoxOmitFirstIterations.CheckedChanged += new System.EventHandler(this.checkBoxOmitFirstIterations_CheckedChanged);
      // 
      // checkBoxHideFurcationLines
      // 
      this.checkBoxHideFurcationLines.AutoSize = true;
      this.checkBoxHideFurcationLines.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Bold);
      this.checkBoxHideFurcationLines.ForeColor = System.Drawing.Color.Red;
      this.checkBoxHideFurcationLines.Location = new System.Drawing.Point(359, 380);
      this.checkBoxHideFurcationLines.Name = "checkBoxHideFurcationLines";
      this.checkBoxHideFurcationLines.Size = new System.Drawing.Size(164, 25);
      this.checkBoxHideFurcationLines.TabIndex = 30;
      this.checkBoxHideFurcationLines.Text = "Hide iteration lines";
      this.checkBoxHideFurcationLines.UseVisualStyleBackColor = true;
      this.checkBoxHideFurcationLines.CheckedChanged += new System.EventHandler(this.checkBoxHideFurcationLines_CheckedChanged);
      // 
      // buttonDefineColors
      // 
      this.buttonDefineColors.BackColor = System.Drawing.SystemColors.Control;
      this.buttonDefineColors.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDefineColors.BackgroundImage")));
      this.buttonDefineColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonDefineColors.Cursor = System.Windows.Forms.Cursors.Default;
      this.buttonDefineColors.Font = new System.Drawing.Font("Calibri", 9.980198F, System.Drawing.FontStyle.Bold);
      this.buttonDefineColors.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.buttonDefineColors.Location = new System.Drawing.Point(429, 5);
      this.buttonDefineColors.Name = "buttonDefineColors";
      this.buttonDefineColors.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.buttonDefineColors.Size = new System.Drawing.Size(99, 38);
      this.buttonDefineColors.TabIndex = 301;
      this.buttonDefineColors.Text = "Define Colors";
      this.buttonDefineColors.UseVisualStyleBackColor = false;
      this.buttonDefineColors.Click += new System.EventHandler(this.ButtonDefineColors_Click);
      // 
      // panel7
      // 
      this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel7.Controls.Add(this.label9);
      this.panel7.Controls.Add(this.labelCurrY);
      this.panel7.Controls.Add(this.textBoxStartX);
      this.panel7.Controls.Add(this.buttonReset);
      this.panel7.Controls.Add(this.label7);
      this.panel7.Controls.Add(this.labelCurrX);
      this.panel7.Controls.Add(this.textBoxEndX);
      this.panel7.Controls.Add(this.label16);
      this.panel7.Controls.Add(this.label6);
      this.panel7.Controls.Add(this.label15);
      this.panel7.Controls.Add(this.textBoxStartY);
      this.panel7.Controls.Add(this.textBoxEndY);
      this.panel7.Location = new System.Drawing.Point(8, 376);
      this.panel7.Name = "panel7";
      this.panel7.Size = new System.Drawing.Size(270, 104);
      this.panel7.TabIndex = 1;
      // 
      // label9
      // 
      this.label9.Location = new System.Drawing.Point(185, 79);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(104, 21);
      this.label9.TabIndex = 284;
      this.label9.Text = ": Mouse (x,f(x))";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelCurrY
      // 
      this.labelCurrY.Location = new System.Drawing.Point(89, 79);
      this.labelCurrY.Name = "labelCurrY";
      this.labelCurrY.Size = new System.Drawing.Size(42, 21);
      this.labelCurrY.TabIndex = 32;
      this.labelCurrY.Text = "0";
      this.labelCurrY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxStartX
      // 
      this.textBoxStartX.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.textBoxStartX.Location = new System.Drawing.Point(142, 25);
      this.textBoxStartX.Name = "textBoxStartX";
      this.textBoxStartX.Size = new System.Drawing.Size(42, 25);
      this.textBoxStartX.TabIndex = 41;
      this.textBoxStartX.Text = "-2";
      this.textBoxStartX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStartX_KeyDown);
      // 
      // buttonReset
      // 
      this.buttonReset.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.buttonReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonReset.BackgroundImage")));
      this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonReset.Location = new System.Drawing.Point(191, 25);
      this.buttonReset.Name = "buttonReset";
      this.buttonReset.Size = new System.Drawing.Size(62, 51);
      this.buttonReset.TabIndex = 283;
      this.buttonReset.Text = "Reset";
      this.buttonReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.buttonReset.UseVisualStyleBackColor = false;
      this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
      // 
      // label7
      // 
      this.label7.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.label7.Location = new System.Drawing.Point(145, 2);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(29, 21);
      this.label7.TabIndex = 39;
      this.label7.Text = "x";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelCurrX
      // 
      this.labelCurrX.Location = new System.Drawing.Point(140, 79);
      this.labelCurrX.Name = "labelCurrX";
      this.labelCurrX.Size = new System.Drawing.Size(44, 21);
      this.labelCurrX.TabIndex = 31;
      this.labelCurrX.Text = "0";
      this.labelCurrX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxEndX
      // 
      this.textBoxEndX.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.textBoxEndX.Location = new System.Drawing.Point(142, 52);
      this.textBoxEndX.Name = "textBoxEndX";
      this.textBoxEndX.Size = new System.Drawing.Size(42, 25);
      this.textBoxEndX.TabIndex = 42;
      this.textBoxEndX.Text = "2";
      this.textBoxEndX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEndX_KeyDown);
      // 
      // label16
      // 
      this.label16.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.label16.Location = new System.Drawing.Point(46, 26);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(40, 21);
      this.label16.TabIndex = 43;
      this.label16.Text = "Min";
      this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label6
      // 
      this.label6.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.label6.Location = new System.Drawing.Point(89, 2);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(31, 21);
      this.label6.TabIndex = 47;
      this.label6.Text = "f(x)";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label15
      // 
      this.label15.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.label15.Location = new System.Drawing.Point(46, 53);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(40, 21);
      this.label15.TabIndex = 44;
      this.label15.Text = "Max";
      this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // textBoxStartY
      // 
      this.textBoxStartY.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.textBoxStartY.Location = new System.Drawing.Point(89, 25);
      this.textBoxStartY.Name = "textBoxStartY";
      this.textBoxStartY.Size = new System.Drawing.Size(42, 25);
      this.textBoxStartY.TabIndex = 45;
      this.textBoxStartY.Text = "-2";
      this.textBoxStartY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStartY_KeyDown);
      // 
      // textBoxEndY
      // 
      this.textBoxEndY.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.textBoxEndY.Location = new System.Drawing.Point(89, 52);
      this.textBoxEndY.Name = "textBoxEndY";
      this.textBoxEndY.Size = new System.Drawing.Size(42, 25);
      this.textBoxEndY.TabIndex = 46;
      this.textBoxEndY.Text = "2";
      this.textBoxEndY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEndY_KeyDown);
      // 
      // panel4
      // 
      this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel4.Controls.Add(this.checkBoxSeedWithMouseCursor);
      this.panel4.Controls.Add(this.label13);
      this.panel4.Controls.Add(this.comboBoxChoozenFunction);
      this.panel4.Controls.Add(this.panelAttractionIterations);
      this.panel4.Controls.Add(this.textBoxMaxIterations);
      this.panel4.Controls.Add(this.labelIterations);
      this.panel4.Controls.Add(this.textBoxSeed);
      this.panel4.Controls.Add(this.labelB);
      this.panel4.Controls.Add(this.labelSeed);
      this.panel4.Controls.Add(this.textBoxB);
      this.panel4.Controls.Add(this.textBoxC);
      this.panel4.Controls.Add(this.labelA);
      this.panel4.Controls.Add(this.labelC);
      this.panel4.Controls.Add(this.textBoxA);
      this.panel4.Controls.Add(this.groupBoxParameter);
      this.panel4.Controls.Add(this.panelLogistic);
      this.panel4.Controls.Add(this.panelHenon);
      this.panel4.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.panel4.Location = new System.Drawing.Point(8, 49);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(520, 320);
      this.panel4.TabIndex = 1;
      // 
      // checkBoxSeedWithMouseCursor
      // 
      this.checkBoxSeedWithMouseCursor.Font = new System.Drawing.Font("Calibri", 7.841584F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
      this.checkBoxSeedWithMouseCursor.Location = new System.Drawing.Point(192, 151);
      this.checkBoxSeedWithMouseCursor.Name = "checkBoxSeedWithMouseCursor";
      this.checkBoxSeedWithMouseCursor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBoxSeedWithMouseCursor.Size = new System.Drawing.Size(104, 23);
      this.checkBoxSeedWithMouseCursor.TabIndex = 287;
      this.checkBoxSeedWithMouseCursor.Text = "Mousecursor >";
      this.toolTip.SetToolTip(this.checkBoxSeedWithMouseCursor, "Set mouse x-value to seed");
      this.checkBoxSeedWithMouseCursor.UseVisualStyleBackColor = true;
      this.checkBoxSeedWithMouseCursor.CheckedChanged += new System.EventHandler(this.checkBoxSeedWithMouseCursor_CheckedChanged);
      // 
      // label13
      // 
      this.label13.Font = new System.Drawing.Font("Calibri", 12.11881F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
      this.label13.Location = new System.Drawing.Point(20, 3);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(167, 24);
      this.label13.TabIndex = 286;
      this.label13.Text = "Type of function:";
      this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // buttonCancelGif
      // 
      this.buttonCancelGif.BackColor = System.Drawing.Color.Red;
      this.buttonCancelGif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancelGif.BackgroundImage")));
      this.buttonCancelGif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonCancelGif.Location = new System.Drawing.Point(284, 378);
      this.buttonCancelGif.Name = "buttonCancelGif";
      this.buttonCancelGif.Size = new System.Drawing.Size(66, 100);
      this.buttonCancelGif.TabIndex = 285;
      this.buttonCancelGif.Text = "STOP!";
      this.buttonCancelGif.UseVisualStyleBackColor = false;
      this.buttonCancelGif.Click += new System.EventHandler(this.buttonCancelGif_Click);
      // 
      // comboBoxChoozenFunction
      // 
      this.comboBoxChoozenFunction.FormattingEnabled = true;
      this.comboBoxChoozenFunction.Items.AddRange(new object[] {
            "Ax(1-x)",
            "Ax^2 + Bx + C",
            "Henon"});
      this.comboBoxChoozenFunction.Location = new System.Drawing.Point(24, 28);
      this.comboBoxChoozenFunction.Name = "comboBoxChoozenFunction";
      this.comboBoxChoozenFunction.Size = new System.Drawing.Size(167, 25);
      this.comboBoxChoozenFunction.TabIndex = 30;
      this.comboBoxChoozenFunction.Text = "Ax(1-x)";
      this.comboBoxChoozenFunction.SelectedIndexChanged += new System.EventHandler(this.comboBoxChoozenFunction_SelectedIndexChanged);
      // 
      // panelAttractionIterations
      // 
      this.panelAttractionIterations.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panelAttractionIterations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelAttractionIterations.Controls.Add(this.textBoxGIFFilename);
      this.panelAttractionIterations.Controls.Add(this.buttonSimulatePar);
      this.panelAttractionIterations.Controls.Add(this.buttonSimulate);
      this.panelAttractionIterations.Controls.Add(this.buttonEmulate);
      this.panelAttractionIterations.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.panelAttractionIterations.Location = new System.Drawing.Point(3, 212);
      this.panelAttractionIterations.Name = "panelAttractionIterations";
      this.panelAttractionIterations.Size = new System.Drawing.Size(503, 100);
      this.panelAttractionIterations.TabIndex = 1;
      // 
      // textBoxGIFFilename
      // 
      this.textBoxGIFFilename.Location = new System.Drawing.Point(160, 65);
      this.textBoxGIFFilename.Name = "textBoxGIFFilename";
      this.textBoxGIFFilename.Size = new System.Drawing.Size(325, 25);
      this.textBoxGIFFilename.TabIndex = 34;
      this.textBoxGIFFilename.Text = "GIF_filename";
      this.textBoxGIFFilename.TextChanged += new System.EventHandler(this.textBoxGIFFilename_TextChanged);
      // 
      // buttonSimulatePar
      // 
      this.buttonSimulatePar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSimulatePar.BackgroundImage")));
      this.buttonSimulatePar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonSimulatePar.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonSimulatePar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonSimulatePar.Location = new System.Drawing.Point(160, 33);
      this.buttonSimulatePar.Name = "buttonSimulatePar";
      this.buttonSimulatePar.Size = new System.Drawing.Size(328, 30);
      this.buttonSimulatePar.TabIndex = 32;
      this.buttonSimulatePar.Text = "Vary Parameter";
      this.buttonSimulatePar.UseVisualStyleBackColor = true;
      this.buttonSimulatePar.Click += new System.EventHandler(this.buttonSimulatePar_Click);
      // 
      // buttonSimulate
      // 
      this.buttonSimulate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSimulate.BackgroundImage")));
      this.buttonSimulate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonSimulate.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonSimulate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonSimulate.Location = new System.Drawing.Point(160, 3);
      this.buttonSimulate.Name = "buttonSimulate";
      this.buttonSimulate.Size = new System.Drawing.Size(328, 30);
      this.buttonSimulate.TabIndex = 31;
      this.buttonSimulate.Text = "Vary max. Iter.";
      this.buttonSimulate.UseVisualStyleBackColor = true;
      this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
      // 
      // buttonEmulate
      // 
      this.buttonEmulate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEmulate.BackgroundImage")));
      this.buttonEmulate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonEmulate.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonEmulate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonEmulate.Location = new System.Drawing.Point(4, 3);
      this.buttonEmulate.Name = "buttonEmulate";
      this.buttonEmulate.Size = new System.Drawing.Size(152, 89);
      this.buttonEmulate.TabIndex = 7;
      this.buttonEmulate.Text = "Seek attractions";
      this.buttonEmulate.UseVisualStyleBackColor = true;
      this.buttonEmulate.Click += new System.EventHandler(this.buttonEmulate_Click);
      // 
      // groupBoxParameter
      // 
      this.groupBoxParameter.Controls.Add(this.radioButtonParamaterC);
      this.groupBoxParameter.Controls.Add(this.textBoxStopParValue);
      this.groupBoxParameter.Controls.Add(this.label3);
      this.groupBoxParameter.Controls.Add(this.radioButtonParamaterB);
      this.groupBoxParameter.Controls.Add(this.radioButtonParamaterA);
      this.groupBoxParameter.Location = new System.Drawing.Point(203, 3);
      this.groupBoxParameter.Name = "groupBoxParameter";
      this.groupBoxParameter.Size = new System.Drawing.Size(93, 145);
      this.groupBoxParameter.TabIndex = 35;
      this.groupBoxParameter.TabStop = false;
      this.toolTip.SetToolTip(this.groupBoxParameter, "Parameter for Bifurcation diagram");
      // 
      // radioButtonParamaterC
      // 
      this.radioButtonParamaterC.AutoSize = true;
      this.radioButtonParamaterC.Location = new System.Drawing.Point(10, 121);
      this.radioButtonParamaterC.Name = "radioButtonParamaterC";
      this.radioButtonParamaterC.Size = new System.Drawing.Size(14, 13);
      this.radioButtonParamaterC.TabIndex = 36;
      this.radioButtonParamaterC.UseVisualStyleBackColor = true;
      this.radioButtonParamaterC.CheckedChanged += new System.EventHandler(this.radioButtonParamater_CheckedChanged);
      // 
      // textBoxStopParValue
      // 
      this.textBoxStopParValue.Location = new System.Drawing.Point(33, 57);
      this.textBoxStopParValue.Name = "textBoxStopParValue";
      this.textBoxStopParValue.Size = new System.Drawing.Size(48, 25);
      this.textBoxStopParValue.TabIndex = 37;
      this.textBoxStopParValue.Text = "4";
      this.textBoxStopParValue.TextChanged += new System.EventHandler(this.textBoxStopParValue_TextChanged);
      this.textBoxStopParValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Calibri", 9.980198F, System.Drawing.FontStyle.Bold);
      this.label3.Location = new System.Drawing.Point(6, 15);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(59, 17);
      this.label3.TabIndex = 36;
      this.label3.Text = "Stop-Par";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // radioButtonParamaterB
      // 
      this.radioButtonParamaterB.AutoSize = true;
      this.radioButtonParamaterB.Location = new System.Drawing.Point(10, 91);
      this.radioButtonParamaterB.Name = "radioButtonParamaterB";
      this.radioButtonParamaterB.Size = new System.Drawing.Size(14, 13);
      this.radioButtonParamaterB.TabIndex = 35;
      this.radioButtonParamaterB.UseVisualStyleBackColor = true;
      this.radioButtonParamaterB.CheckedChanged += new System.EventHandler(this.radioButtonParamater_CheckedChanged);
      // 
      // radioButtonParamaterA
      // 
      this.radioButtonParamaterA.AutoSize = true;
      this.radioButtonParamaterA.Checked = true;
      this.radioButtonParamaterA.Location = new System.Drawing.Point(10, 62);
      this.radioButtonParamaterA.Name = "radioButtonParamaterA";
      this.radioButtonParamaterA.Size = new System.Drawing.Size(14, 13);
      this.radioButtonParamaterA.TabIndex = 34;
      this.radioButtonParamaterA.TabStop = true;
      this.radioButtonParamaterA.UseVisualStyleBackColor = true;
      this.radioButtonParamaterA.CheckedChanged += new System.EventHandler(this.radioButtonParamater_CheckedChanged);
      // 
      // panelLogistic
      // 
      this.panelLogistic.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panelLogistic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelLogistic.Controls.Add(this.checkBoxSetSeed);
      this.panelLogistic.Controls.Add(this.listBoxFeigenbaum);
      this.panelLogistic.Controls.Add(this.label14);
      this.panelLogistic.Location = new System.Drawing.Point(307, 10);
      this.panelLogistic.Name = "panelLogistic";
      this.panelLogistic.Size = new System.Drawing.Size(199, 196);
      this.panelLogistic.TabIndex = 281;
      // 
      // checkBoxSetSeed
      // 
      this.checkBoxSetSeed.Font = new System.Drawing.Font("Calibri", 7.841584F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
      this.checkBoxSetSeed.Location = new System.Drawing.Point(33, 161);
      this.checkBoxSetSeed.Name = "checkBoxSetSeed";
      this.checkBoxSetSeed.Size = new System.Drawing.Size(151, 19);
      this.checkBoxSetSeed.TabIndex = 308;
      this.checkBoxSetSeed.Text = "Set Seed = 1-1/A";
      this.checkBoxSetSeed.UseVisualStyleBackColor = true;
      // 
      // listBoxFeigenbaum
      // 
      this.listBoxFeigenbaum.Font = new System.Drawing.Font("Calibri", 7.841584F);
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
      this.listBoxFeigenbaum.Location = new System.Drawing.Point(33, 31);
      this.listBoxFeigenbaum.Name = "listBoxFeigenbaum";
      this.listBoxFeigenbaum.Size = new System.Drawing.Size(99, 121);
      this.listBoxFeigenbaum.TabIndex = 306;
      this.listBoxFeigenbaum.SelectedIndexChanged += new System.EventHandler(this.listBoxFeigenbaum_SelectedIndexChanged);
      // 
      // label14
      // 
      this.label14.Location = new System.Drawing.Point(29, 11);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(104, 21);
      this.label14.TabIndex = 307;
      this.label14.Text = "Feigenbaum\'s:";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panelHenon
      // 
      this.panelHenon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panelHenon.Controls.Add(this.label10);
      this.panelHenon.Controls.Add(this.numericUpDownInitialPoints);
      this.panelHenon.Controls.Add(this.labelNoPoints);
      this.panelHenon.Controls.Add(this.label8);
      this.panelHenon.Controls.Add(this.numericUpDownMultPointsPerStep);
      this.panelHenon.Controls.Add(this.label5);
      this.panelHenon.Controls.Add(this.numericUpDownDotSize);
      this.panelHenon.Controls.Add(this.buttonNextTrajectory);
      this.panelHenon.Controls.Add(this.buttonStopTrajectory);
      this.panelHenon.Controls.Add(this.label4);
      this.panelHenon.Controls.Add(this.buttonCalcHenon);
      this.panelHenon.Location = new System.Drawing.Point(307, 10);
      this.panelHenon.Name = "panelHenon";
      this.panelHenon.Size = new System.Drawing.Size(199, 196);
      this.panelHenon.TabIndex = 1;
      // 
      // label10
      // 
      this.label10.Font = new System.Drawing.Font("Calibri", 10.69307F);
      this.label10.Location = new System.Drawing.Point(32, 75);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(109, 20);
      this.label10.TabIndex = 50;
      this.label10.Text = "Initional dots:";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // numericUpDownInitialPoints
      // 
      this.numericUpDownInitialPoints.Font = new System.Drawing.Font("Calibri", 12.11881F);
      this.numericUpDownInitialPoints.Location = new System.Drawing.Point(143, 72);
      this.numericUpDownInitialPoints.Name = "numericUpDownInitialPoints";
      this.numericUpDownInitialPoints.Size = new System.Drawing.Size(39, 28);
      this.numericUpDownInitialPoints.TabIndex = 49;
      this.numericUpDownInitialPoints.ValueChanged += new System.EventHandler(this.numericUpDownInitialPoints_ValueChanged);
      // 
      // labelNoPoints
      // 
      this.labelNoPoints.Font = new System.Drawing.Font("Calibri", 10.69307F);
      this.labelNoPoints.Location = new System.Drawing.Point(101, 169);
      this.labelNoPoints.Name = "labelNoPoints";
      this.labelNoPoints.Size = new System.Drawing.Size(83, 20);
      this.labelNoPoints.TabIndex = 48;
      this.labelNoPoints.Text = "0";
      this.labelNoPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label8
      // 
      this.label8.Font = new System.Drawing.Font("Calibri", 10.69307F);
      this.label8.Location = new System.Drawing.Point(16, 169);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(83, 20);
      this.label8.TabIndex = 47;
      this.label8.Text = "No. Points:";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.toolTip.SetToolTip(this.label8, "One pixel can contain several points !!");
      // 
      // numericUpDownMultPointsPerStep
      // 
      this.numericUpDownMultPointsPerStep.Font = new System.Drawing.Font("Calibri", 12.11881F);
      this.numericUpDownMultPointsPerStep.Location = new System.Drawing.Point(143, 102);
      this.numericUpDownMultPointsPerStep.Name = "numericUpDownMultPointsPerStep";
      this.numericUpDownMultPointsPerStep.Size = new System.Drawing.Size(39, 28);
      this.numericUpDownMultPointsPerStep.TabIndex = 46;
      this.numericUpDownMultPointsPerStep.ValueChanged += new System.EventHandler(this.numericUpDownMultPointsPerStep_ValueChanged);
      // 
      // label5
      // 
      this.label5.Font = new System.Drawing.Font("Calibri", 10.69307F);
      this.label5.Location = new System.Drawing.Point(32, 105);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(109, 20);
      this.label5.TabIndex = 45;
      this.label5.Text = "Points/step X:";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // numericUpDownDotSize
      // 
      this.numericUpDownDotSize.Font = new System.Drawing.Font("Calibri", 12.11881F);
      this.numericUpDownDotSize.Location = new System.Drawing.Point(111, 5);
      this.numericUpDownDotSize.Name = "numericUpDownDotSize";
      this.numericUpDownDotSize.Size = new System.Drawing.Size(39, 28);
      this.numericUpDownDotSize.TabIndex = 44;
      this.numericUpDownDotSize.ValueChanged += new System.EventHandler(this.numericUpDownDotSize_ValueChanged);
      // 
      // buttonNextTrajectory
      // 
      this.buttonNextTrajectory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNextTrajectory.BackgroundImage")));
      this.buttonNextTrajectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonNextTrajectory.Enabled = false;
      this.buttonNextTrajectory.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonNextTrajectory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonNextTrajectory.Location = new System.Drawing.Point(8, 132);
      this.buttonNextTrajectory.Name = "buttonNextTrajectory";
      this.buttonNextTrajectory.Size = new System.Drawing.Size(84, 36);
      this.buttonNextTrajectory.TabIndex = 43;
      this.buttonNextTrajectory.Text = "Next Traj.";
      this.buttonNextTrajectory.UseVisualStyleBackColor = true;
      this.buttonNextTrajectory.Click += new System.EventHandler(this.buttonNextTrajectory_Click);
      // 
      // buttonStopTrajectory
      // 
      this.buttonStopTrajectory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStopTrajectory.BackgroundImage")));
      this.buttonStopTrajectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonStopTrajectory.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonStopTrajectory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonStopTrajectory.Location = new System.Drawing.Point(98, 132);
      this.buttonStopTrajectory.Name = "buttonStopTrajectory";
      this.buttonStopTrajectory.Size = new System.Drawing.Size(86, 36);
      this.buttonStopTrajectory.TabIndex = 42;
      this.buttonStopTrajectory.Text = "Stop";
      this.buttonStopTrajectory.UseVisualStyleBackColor = true;
      this.buttonStopTrajectory.Click += new System.EventHandler(this.buttonStopTrajectory_Click);
      // 
      // label4
      // 
      this.label4.Font = new System.Drawing.Font("Calibri", 10.69307F);
      this.label4.Location = new System.Drawing.Point(43, 7);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(65, 20);
      this.label4.TabIndex = 38;
      this.label4.Text = "Dot size:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // buttonCalcHenon
      // 
      this.buttonCalcHenon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCalcHenon.BackgroundImage")));
      this.buttonCalcHenon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonCalcHenon.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonCalcHenon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonCalcHenon.Location = new System.Drawing.Point(8, 34);
      this.buttonCalcHenon.Name = "buttonCalcHenon";
      this.buttonCalcHenon.Size = new System.Drawing.Size(176, 37);
      this.buttonCalcHenon.TabIndex = 35;
      this.buttonCalcHenon.Text = "Calc Henon";
      this.buttonCalcHenon.UseVisualStyleBackColor = true;
      this.buttonCalcHenon.Click += new System.EventHandler(this.buttonCalcHenon_Click);
      // 
      // labelGeneralFunction
      // 
      this.labelGeneralFunction.AutoSize = true;
      this.labelGeneralFunction.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.labelGeneralFunction.Location = new System.Drawing.Point(250, 5);
      this.labelGeneralFunction.Name = "labelGeneralFunction";
      this.labelGeneralFunction.Size = new System.Drawing.Size(114, 17);
      this.labelGeneralFunction.TabIndex = 32;
      this.labelGeneralFunction.Text = "f(x) = Ax^2 + Bx + C";
      this.labelGeneralFunction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // progressBar
      // 
      this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar.Location = new System.Drawing.Point(3, 3);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(694, 23);
      this.progressBar.TabIndex = 280;
      this.progressBar.Visible = false;
      // 
      // listBoxXValues
      // 
      this.listBoxXValues.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.listBoxXValues.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.listBoxXValues.FormattingEnabled = true;
      this.listBoxXValues.ItemHeight = 17;
      this.listBoxXValues.Location = new System.Drawing.Point(12, 31);
      this.listBoxXValues.Name = "listBoxXValues";
      this.listBoxXValues.Size = new System.Drawing.Size(266, 157);
      this.listBoxXValues.TabIndex = 22;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.label1.Location = new System.Drawing.Point(11, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(67, 23);
      this.label1.TabIndex = 23;
      this.label1.Text = "X-Values:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel4Image
      // 
      this.panel4Image.AutoScroll = true;
      this.panel4Image.Controls.Add(this.progressBar);
      this.panel4Image.Controls.Add(this.pictureBox);
      this.panel4Image.Location = new System.Drawing.Point(0, 0);
      this.panel4Image.Name = "panel4Image";
      this.panel4Image.Size = new System.Drawing.Size(700, 700);
      this.panel4Image.TabIndex = 25;
      // 
      // pictureBox
      // 
      this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureBox.ContextMenuStrip = this.contextMenuStrip;
      this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox.Location = new System.Drawing.Point(0, 0);
      this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(700, 700);
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
            this.imageToEditorMenuItem,
            this.createGIFOverIterationsMenuItem,
            this.createGIFOverParameterMenuItem,
            this.calcTrajectoryAtCursorMenuItem});
      this.contextMenuStrip.Name = "contextMenuStrip";
      this.contextMenuStrip.Size = new System.Drawing.Size(409, 92);
      // 
      // imageToEditorMenuItem
      // 
      this.imageToEditorMenuItem.Name = "imageToEditorMenuItem";
      this.imageToEditorMenuItem.Size = new System.Drawing.Size(408, 22);
      this.imageToEditorMenuItem.Text = "Image to editor";
      this.imageToEditorMenuItem.Click += new System.EventHandler(this.imageToEditorMenuItem_Click);
      // 
      // createGIFOverIterationsMenuItem
      // 
      this.createGIFOverIterationsMenuItem.Name = "createGIFOverIterationsMenuItem";
      this.createGIFOverIterationsMenuItem.Size = new System.Drawing.Size(408, 22);
      this.createGIFOverIterationsMenuItem.Text = "Create GIF over iterations";
      this.createGIFOverIterationsMenuItem.Click += new System.EventHandler(this.createGIFOverIterationsMenuItem_Click);
      // 
      // createGIFOverParameterMenuItem
      // 
      this.createGIFOverParameterMenuItem.Name = "createGIFOverParameterMenuItem";
      this.createGIFOverParameterMenuItem.Size = new System.Drawing.Size(408, 22);
      this.createGIFOverParameterMenuItem.Text = "Create GIF over Parameter";
      this.createGIFOverParameterMenuItem.Click += new System.EventHandler(this.createGIFOverParameterMenuItem_Click);
      // 
      // calcTrajectoryAtCursorMenuItem
      // 
      this.calcTrajectoryAtCursorMenuItem.Name = "calcTrajectoryAtCursorMenuItem";
      this.calcTrajectoryAtCursorMenuItem.Size = new System.Drawing.Size(408, 22);
      this.calcTrajectoryAtCursorMenuItem.Text = "Calc trajectory of group of dots at cursor per mouseclick";
      this.calcTrajectoryAtCursorMenuItem.Click += new System.EventHandler(this.calcTrajectoryAtCursorMenuItem_Click);
      // 
      // panelMainPanel
      // 
      this.panelMainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panelMainPanel.Controls.Add(this.panelOneDimensiolFunctions);
      this.panelMainPanel.Controls.Add(this.panel6);
      this.panelMainPanel.Location = new System.Drawing.Point(706, 0);
      this.panelMainPanel.Name = "panelMainPanel";
      this.panelMainPanel.Size = new System.Drawing.Size(543, 699);
      this.panelMainPanel.TabIndex = 1;
      // 
      // panel6
      // 
      this.panel6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel6.Controls.Add(this.buttonCombinations);
      this.panel6.Controls.Add(this.labelLast1000);
      this.panel6.Controls.Add(this.label12);
      this.panel6.Controls.Add(this.buttonBifurcationDiagram);
      this.panel6.Controls.Add(this.label1);
      this.panel6.Controls.Add(this.listBoxXValues);
      this.panel6.Controls.Add(this.labelSetCount);
      this.panel6.Location = new System.Drawing.Point(2, 496);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(538, 203);
      this.panel6.TabIndex = 1;
      // 
      // buttonCombinations
      // 
      this.buttonCombinations.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCombinations.BackgroundImage")));
      this.buttonCombinations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonCombinations.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonCombinations.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonCombinations.Location = new System.Drawing.Point(284, 116);
      this.buttonCombinations.Name = "buttonCombinations";
      this.buttonCombinations.Size = new System.Drawing.Size(239, 73);
      this.buttonCombinations.TabIndex = 30;
      this.buttonCombinations.Text = "Polynomial combinationsdiagram";
      this.buttonCombinations.UseVisualStyleBackColor = true;
      this.buttonCombinations.Click += new System.EventHandler(this.buttonCombinations_Click);
      // 
      // labelLast1000
      // 
      this.labelLast1000.Location = new System.Drawing.Point(84, 3);
      this.labelLast1000.Name = "labelLast1000";
      this.labelLast1000.Size = new System.Drawing.Size(38, 23);
      this.labelLast1000.TabIndex = 29;
      this.labelLast1000.Text = "0";
      this.labelLast1000.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label12
      // 
      this.label12.Font = new System.Drawing.Font("Calibri", 9.980198F);
      this.label12.Location = new System.Drawing.Point(223, 4);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(237, 23);
      this.label12.TabIndex = 26;
      this.label12.Text = "Convergent (STABLE) set point-count:";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // buttonBifurcationDiagram
      // 
      this.buttonBifurcationDiagram.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBifurcationDiagram.BackgroundImage")));
      this.buttonBifurcationDiagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonBifurcationDiagram.Font = new System.Drawing.Font("Calibri", 10.69307F, System.Drawing.FontStyle.Bold);
      this.buttonBifurcationDiagram.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.buttonBifurcationDiagram.Location = new System.Drawing.Point(284, 30);
      this.buttonBifurcationDiagram.Name = "buttonBifurcationDiagram";
      this.buttonBifurcationDiagram.Size = new System.Drawing.Size(239, 73);
      this.buttonBifurcationDiagram.TabIndex = 28;
      this.buttonBifurcationDiagram.Text = "Attractors diagram";
      this.buttonBifurcationDiagram.UseVisualStyleBackColor = true;
      this.buttonBifurcationDiagram.Click += new System.EventHandler(this.buttonBifurcationDiagram_Click);
      // 
      // labelSetCount
      // 
      this.labelSetCount.Location = new System.Drawing.Point(462, 3);
      this.labelSetCount.Name = "labelSetCount";
      this.labelSetCount.Size = new System.Drawing.Size(55, 23);
      this.labelSetCount.TabIndex = 27;
      this.labelSetCount.Text = "0";
      this.labelSetCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // FunctionsForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.ClientSize = new System.Drawing.Size(1250, 700);
      this.Controls.Add(this.panelMainPanel);
      this.Controls.Add(this.panel4Image);
      this.Font = new System.Drawing.Font("Calibri", 9F);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "FunctionsForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Function Furcations, Version 2.0.3.0";
      this.ResizeEnd += new System.EventHandler(this.BiFurcationForm_ResizeEnd);
      this.panelOneDimensiolFunctions.ResumeLayout(false);
      this.panelOneDimensiolFunctions.PerformLayout();
      this.panel7.ResumeLayout(false);
      this.panel7.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panelAttractionIterations.ResumeLayout(false);
      this.panelAttractionIterations.PerformLayout();
      this.groupBoxParameter.ResumeLayout(false);
      this.groupBoxParameter.PerformLayout();
      this.panelLogistic.ResumeLayout(false);
      this.panelHenon.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialPoints)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMultPointsPerStep)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDotSize)).EndInit();
      this.panel4Image.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.contextMenuStrip.ResumeLayout(false);
      this.panelMainPanel.ResumeLayout(false);
      this.panel6.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

  }

}

