using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BiFurcation {

  public partial class NonLineairSystemsForm : Form, ICombined {

    #region instance specific
    public static bool IsNull {
      get {
        return instance == null;
      }
      set {
        if (instance != null && value) {
          instance.components.Dispose();
          instance.Dispose(true);
          instance = null;
        }
        else
          if (!value && instance == null) {
          instance = new NonLineairSystemsForm();
        }
      }
    }
    private static NonLineairSystemsForm instance = null;
    public static NonLineairSystemsForm Instance {
      get {
        if (NonLineairSystemsForm.instance == null)
          NonLineairSystemsForm.instance = new NonLineairSystemsForm();
        instance.Visible = true;
        return NonLineairSystemsForm.instance;
      }
    }

    public static void setNull() {
      instance = null;
    }

    public static NonLineairSystemsForm GetInvisible {
      get {
        if (NonLineairSystemsForm.instance == null) {
          NonLineairSystemsForm.instance = new NonLineairSystemsForm();
          instance.Visible = false;
        }
        return NonLineairSystemsForm.instance;
      }
    }
    public static void setInvisible() {
      if (NonLineairSystemsForm.instance != null)
        NonLineairSystemsForm.instance.Visible = false;
    }
    #endregion

    private Control4NonLineairSystems combinedControl;
    public Control4NonLineairSystems Control4NonLineairSystems {
      set {
        combinedControl = value;
      }
      get {
        return combinedControl;
      }
    }

    #region fields
    private TextBox[] paramBoxes = new TextBox[12];
    private bool m_DrawingBox;
    private int mouseX = 0;
    private int mouseY = 0;
    private Bitmap colorSpread;
    private DirectBitmap juliaMap;
    private DirectBitmap singleColor;
    private DirectBitmap type1;
    private DirectBitmap type2;
    private DirectBitmap type3;
    private FractalType newType = FractalType.Mandelbrot;
    private List<Label> generalTypeLabels = new List<Label>();
    private List<PictureBox> generalTypePictureBoxes = new List<PictureBox>();
    private List<Label> juliaTypeLabels = new List<Label>();
    private List<PictureBox> juliaTypePictureBoxes = new List<PictureBox>();
    private List<Label> lineTypeLabels = new List<Label>();
    private List<PictureBox> lineTypePictureBoxes = new List<PictureBox>();
    private List<Label> lineTypeMiraLabels1 = new List<Label>();
    private List<Label> lineTypeMiraLabels2 = new List<Label>();
    private List<PictureBox> lineTypeMiraPictureBoxes = new List<PictureBox>();
    private PointD movingPosition = new PointD(0, 0);
    #endregion

    protected NonLineairSystemsForm() {

      InitializeComponent();
  
      this.Cursor = Cursors.Default;
      pictureBox.Cursor = Cursors.Cross;

      colorSpread = new Bitmap(pictureBoxColorsSingle.Width, pictureBoxColorsSingle.Height);
      pictureBoxColorsSingle.Image = colorSpread;
      juliaMap = new DirectBitmap(pictureBoxJuliaTypes.Width, pictureBoxJuliaTypes.Height);
      pictureBoxJuliaTypes.Image = juliaMap.Bitmap;
      panelJuliaTypeGraph.Left = 4;

      singleColor = new DirectBitmap(pictureBoxColorsSingle.Width, pictureBoxColorsSingle.Height);
      pictureBoxColorsSingle.Image = singleColor.Bitmap;

      type1 = new DirectBitmap(pictureBoxColors1.Width, pictureBoxColors1.Height);
      pictureBoxColors1.Image = type1.Bitmap;

      type2 = new DirectBitmap(pictureBoxColors2.Width, pictureBoxColors3.Height);
      pictureBoxColors2.Image = type2.Bitmap;

      type3 = new DirectBitmap(pictureBoxColors2.Width, pictureBoxColors3.Height);
      pictureBoxColors3.Image = type3.Bitmap;

      controls2Lists();
 
    }

    private PictureBox spacedPictureBox(int numBoxes, int numPerRow, int boxSize, int i) {
      PictureBox box = new PictureBox();
      int numRows = numBoxes / numPerRow;
      int horSpace = (tabPageGeneral.Width - numPerRow * boxSize) / (1 + numPerRow);
      int vertSpace = (tabPageGeneral.Height - numRows * boxSize) / (1 + numRows);
      int colSpace = horSpace + boxSize;
      int rowSpace = vertSpace + boxSize;
      int colNum = i % numPerRow;
      int rowNum = i / numPerRow;
      box.Location = new Point(horSpace + colNum * colSpace, vertSpace + rowNum * rowSpace);
      return box;
    }
    private Label spacedLabel(int numBoxes, int numPerRow, int boxSize, int i) {
      Label box = new Label();
      int numRows = numBoxes / numPerRow;
      int horSpace = (tabPageGeneral.Width - numPerRow * boxSize) / (1 + numPerRow);
      int vertSpace = (tabPageGeneral.Height - numRows * boxSize) / (1 + numRows);
      int colSpace = horSpace + boxSize;
      int rowSpace = vertSpace + boxSize;
      int colNum = i % numPerRow;
      int rowNum = i / numPerRow;
      box.Location = new Point(horSpace + colNum * colSpace, vertSpace + boxSize + rowNum * rowSpace);
      return box;
    }
    private void controls2Lists() {

      #region parameters
      for (int p = 0; p < 12; p++) {
        TextBox ptxb = new TextBox();
        ptxb.Font = new Font("Calibri", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        ptxb.Location = new Point(37 + (p / 6) * 112, 2 + (p % 6) * 25);//149,2
        ptxb.Name = "ptxb" + p.ToString("00");
        ptxb.Size = new Size(53, 23);
        ptxb.TabIndex = p;
        ptxb.Tag = p;
        ptxb.Text = "0";
        ptxb.TextChanged += new System.EventHandler(this.textBoxAB_TextChanged);
        panelParameters.Controls.Add(ptxb);
        paramBoxes[p] = ptxb;

        Label plbl = new Label();
        plbl.AutoSize = true;
        plbl.Location = new Point(9 + (p / 6) * 112, 5 + (p % 6) * 25);//121,5
        plbl.Name = "plbl" + p.ToString("00");
        plbl.Size = new Size(22, 17);
        if (p < 6)
          plbl.Text = "a" + p.ToString();
        else
          plbl.Text = "b" + (p - 6).ToString();
        panelParameters.Controls.Add(plbl);
      }
      #endregion

      #region General
      int numBoxes = 8;
      int numPerRow = 4;
      int boxSize = 100;
      for (int i = 0; i < numBoxes; i++) {
        int colNum = i % numPerRow;
        int rowNum = i / numPerRow;
        PictureBox box = spacedPictureBox(numBoxes, numPerRow, boxSize, i);
        box.BorderStyle = BorderStyle.Fixed3D;
        box.Name = "pictureBoxG" + i.ToString("00");
        box.Size = new Size(boxSize, boxSize);
        box.SizeMode = PictureBoxSizeMode.StretchImage;
        box.TabStop = false;
        box.Click += new EventHandler(selectCurrentType);
        box.Tag = i;
        tabPageGeneral.Controls.Add(box);
        generalTypePictureBoxes.Add(box);
        Label lbl = spacedLabel(numBoxes, numPerRow, boxSize, i);
        lbl.AutoSize = true;
        lbl.Font = new Font("Calibri", 9.267326F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        lbl.Name = "labelG" + i.ToString("00");
        lbl.AutoSize = true;
        lbl.Text = "0.12 -0.12";
        tabPageGeneral.Controls.Add(lbl);
        generalTypeLabels.Add(lbl);
      }
      #endregion

      #region Julia fractals
      numBoxes = 11;
      numPerRow = 5;
      boxSize = 100;
      for (int i = 0; i < numBoxes; i++) {
        int colNum = i % numPerRow;
        int rowNum = i / numPerRow;
        PictureBox box = spacedPictureBox(numBoxes, numPerRow, boxSize, i);
        box.BorderStyle = BorderStyle.Fixed3D;
        box.Name = "pictureBoxJ" + i.ToString("00");
        box.Size = new Size(100, 100);
        box.SizeMode = PictureBoxSizeMode.StretchImage;
        box.TabStop = false;
        box.Click += new EventHandler(selectCurrentJuliaType);
        box.Tag = i;
        tabPageJulia.Controls.Add(box);
        juliaTypePictureBoxes.Add(box);
        Label lbl = spacedLabel(numBoxes, numPerRow, boxSize, i);
        lbl.AutoSize = true;
        lbl.Font = new Font("Calibri", 9.267326F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        lbl.Name = "labelJ" + i.ToString("00");
        lbl.AutoSize = true;
        lbl.Text = "0.12 -0.12";
        tabPageJulia.Controls.Add(lbl);
        juliaTypeLabels.Add(lbl);
      }
      juliaTypePictureBoxes[10].Left = tabPageJulia.Width / 2 - juliaTypePictureBoxes[10].Width / 2;
      juliaTypeLabels[10].Left = juliaTypePictureBoxes[10].Left;

      #endregion

      #region Linefractals
      numBoxes = 9;
      numPerRow = 3;
      boxSize = 100;
      for (int i = 0; i < numBoxes; i++) {
        int colNum = i % numPerRow;
        int rowNum = i / numPerRow;
        PictureBox box = spacedPictureBox(numBoxes, numPerRow, boxSize, i);
        box.BorderStyle = BorderStyle.Fixed3D;
        box.Name = "pictureBoxLF" + i.ToString("00");
        box.Size = new Size(100, 100);
        box.SizeMode = PictureBoxSizeMode.StretchImage;
        box.TabStop = false;
        box.Click += new EventHandler(selectCurrentLineType);
        box.Tag = i;
        tabPageLinetype.Controls.Add(box);
        lineTypePictureBoxes.Add(box);
        Label lbl = spacedLabel(numBoxes, numPerRow, boxSize, i);
        lbl.AutoSize = true;
        lbl.Font = new Font("Calibri", 9.267326F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        lbl.Name = "labelLF" + i.ToString("00");
        lbl.AutoSize = true;
        lbl.Text = "0.12 -0.12";
        tabPageLinetype.Controls.Add(lbl);
        lineTypeLabels.Add(lbl);
      }
      #endregion

      #region tab MiraLineTypes
      numBoxes = 28;
      numPerRow = 7;
      boxSize = 60;
      for (int i = 0; i < 28; i++) {
        int colNum = i % numPerRow;
        int rowNum = i / numPerRow;
        PictureBox box = spacedPictureBox(numBoxes, numPerRow, boxSize, i);
        box.BorderStyle = BorderStyle.Fixed3D;
        box.Name = "pictureBoxML" + i.ToString("00");
        box.Size = new Size(60, 60);
        box.SizeMode = PictureBoxSizeMode.StretchImage;
        box.TabStop = false;
        box.Click += new EventHandler(pictureBoxMiraType);
        box.Tag = i;
        tabPageMiraLineTypes.Controls.Add(box);
        lineTypeMiraPictureBoxes.Add(box);

        Label lbl = spacedLabel(numBoxes, numPerRow, boxSize, i);
        lbl.Font = new Font("Calibri", 7f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        lbl.Name = "labelMLA" + i.ToString("00");
        lbl.AutoSize = true;
        lbl.Text = "0.12 -0.12 ";
        tabPageMiraLineTypes.Controls.Add(lbl);
        lineTypeMiraLabels1.Add(lbl);

        Label lbl2 = new Label();
        lbl2.Location = new Point(lbl.Left, lbl.Height + lbl.Top);
        lbl2.Font = new Font("Calibri", 7f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        lbl2.ForeColor = Color.Black;
        lbl2.Name = "labelMLB" + i.ToString("00");
        lbl2.AutoSize = true;
        lbl2.Text = "0.12 -0.12 ";
        tabPageMiraLineTypes.Controls.Add(lbl2);
        lineTypeMiraLabels2.Add(lbl2);

        if (i % 7 == 0) {
          Label lblStart = new Label();
          lblStart.Location = new Point(2, lbl.Top);
          lblStart.Font = new Font("Calibri", 7f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
          lblStart.ForeColor = Color.Red;
          lblStart.Name = "labelMLStart" + i.ToString("00");
          lblStart.AutoSize = true;
          lblStart.Text = "Start:";
          tabPageMiraLineTypes.Controls.Add(lblStart);
          Label lblAB = new Label();
          lblAB.Location = new Point(2, lbl2.Top);
          lblAB.Font = new Font("Calibri", 7f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
          lblAB.Name = "labelMLAB" + i.ToString("00");
          lblAB.AutoSize = true;
          lblAB.ForeColor = Color.Red;
          lblAB.Text = "A-B:";
          tabPageMiraLineTypes.Controls.Add(lblAB);
        }
      }
      #endregion

    }

    #region events
    private void buttonDefineColors_Click(Object sender, EventArgs e) {
      DefineColorsForm defColorForm = DefineColorsForm.Instance;
      defColorForm.CombinedControl = combinedControl;
      defColorForm.Show();
      defColorForm.BringToFront();
    }
    private void buttonGenerate_Click(Object sender, EventArgs e) {
      combinedControl.simulate(true);
    }
    private void pictureBox_MouseDown(Object sender, MouseEventArgs e) {
      mouseX = e.X;
      mouseY = e.Y;
      if (e.Button == MouseButtons.Left && combinedControl.mouseDown(e.X, e.Y, pictureBox.Width, pictureBox.Height)) 
        m_DrawingBox = true;
    }
    private void pictureBox_MouseMove(Object sender, MouseEventArgs e) {
      movingPosition = combinedControl.showMouseCoords(e.X, e.Y, pictureBox.Width, pictureBox.Height);
      if (m_DrawingBox)
        combinedControl.mouseMove(e.X, e.Y, pictureBox.Width, pictureBox.Height);
      else {
        combinedControl.juliaMouseMove((double)movingPosition.X, (double)movingPosition.Y, juliaMap);
        pictureBoxJuliaTypes.Refresh();
      }   
      labelCurrX.Text = movingPosition.X.ToString("0.00");
      labelCurrY.Text = movingPosition.Y.ToString("0.00");
    }
    private void pictureBox_MouseUp(Object sender, MouseEventArgs e) {
      if (!m_DrawingBox) return;
      m_DrawingBox = false;
      combinedControl.mouseUp(e.X, e.Y, pictureBox.Width, pictureBox.Height);
      params2Form();
      this.Cursor = Cursors.WaitCursor;
      Application.DoEvents();
      this.Cursor = Cursors.Default;
      pictureBox.Cursor = Cursors.Cross;
    }
    private void buttonReset_Click(Object sender, EventArgs e) {
      combinedControl.reset();
      params2Form();
    }
    private void textBoxXmin_TextChanged(Object sender, EventArgs e) {
      combinedControl.XminStr = textBoxXMin.Text;
    }
    private void textBoxXMax_TextChanged(Object sender, EventArgs e) {
      combinedControl.XmaxStr = textBoxXMax.Text;
    }
    private void textBoxYMin_TextChanged(Object sender, EventArgs e) {
      combinedControl.YminStr = textBoxYMin.Text;
    }
    private void textBoxYMax_TextChanged(Object sender, EventArgs e) {
      combinedControl.YmaxStr = textBoxYMax.Text;
    }
    private void textBoxMaxIterations_TextChanged(Object sender, EventArgs e) {
      combinedControl.MaxIterationsStr = textBoxMaxIterations.Text;
    }
    private void textBoxEscapeRadius_TextChanged(Object sender, EventArgs e) {
      combinedControl.MAX_MAG_SQUARED = textBoxEscapeRadius.Text;
    }
    private void textBoxAB_TextChanged(Object sender, EventArgs e) {
      TextBox box = (TextBox)sender;
      int num = 0;
      Int32.TryParse(box.Tag.ToString(), out num);
      combinedControl.presetParameter(num, box.Text);
    }
    private void imageToEditorMenuItem_Click(Object sender, EventArgs e) {
      if (pictureBox.Image != null)
        combinedControl.startImageEditor(pictureBox.Image);
    }
    private void createGIFMenuItem_Click(Object sender, EventArgs e) {
      combinedControl.createGif(movingPosition, textBoxNumGifImages.Text, textBoxGIFFilename.Text);
      setEnabled(false);
    }
    private void radioButtonCheckedChanged(Object sender, EventArgs e) {
      if (radioButtonSingle.Checked && sender == radioButtonSingle)
        combinedControl.SmoozeType = SmoozeType.Single; 
      if (radioButtonType1.Checked && sender == radioButtonType1)
        combinedControl.SmoozeType = SmoozeType.Type1;
      if (radioButtonType2.Checked && sender == radioButtonType2)
        combinedControl.SmoozeType = SmoozeType.Type2;
      if (radioButtonType3.Checked && sender == radioButtonType3)
        combinedControl.SmoozeType = SmoozeType.Type3;
      Refresh();
    }
    private void pictureBoxColorsSingle_Click(Object sender, EventArgs e) {
      radioButtonSingle.Checked = true;
    }
    private void pictureBoxColors1_Click(Object sender, EventArgs e) {
      radioButtonType1.Checked = true;
    }
    private void pictureBoxColors2_Click(Object sender, EventArgs e) {
      radioButtonType2.Checked = true;
    }
    private void pictureBoxColors3_Click(Object sender, EventArgs e) {
      radioButtonType3.Checked = true;
    }
    private void textBoxJuliaX_KeyDown(Object sender, KeyEventArgs e) {
      if (e.KeyCode== Keys.Enter)
        combinedControl.setUserdefined(textBoxJuliaX.Text, textBoxJuliaY.Text);
    }
    private void textBoxJuliaY_KeyDown(Object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter)
        combinedControl.setUserdefined(textBoxJuliaX.Text, textBoxJuliaY.Text);
    }
    private void textBoxJuliaX_TextChanged(Object sender, EventArgs e) {
      combinedControl.setUserdefined(textBoxJuliaX.Text, textBoxJuliaY.Text);
    }
    private void textBoxJuliaY_TextChanged(Object sender, EventArgs e) {
      combinedControl.setUserdefined(textBoxJuliaX.Text, textBoxJuliaY.Text);
    }
    private void buttonCancelGif_Click(Object sender, EventArgs e) {
      combinedControl.stopThread();
    }
    private void textBoxLambdaA_TextChanged(Object sender, EventArgs e) {
      combinedControl.LambdaOrMandelbrotA = textBoxjuliaMandelPowerA.Text;
    }
    private void radioButtonNormalQuality_CheckedChanged(Object sender, EventArgs e) {
      if (radioButtonNormalQuality.Checked)
        combinedControl.ImageQuality = FractalQuality.Normal;
    }
    private void radioButtonLowQuality_CheckedChanged(Object sender, EventArgs e) {
      if (radioButtonLowQuality.Checked)
        combinedControl.ImageQuality = FractalQuality.Low;
    }
    private void radioButtonHighQuality_CheckedChanged(Object sender, EventArgs e) {
      if (radioButtonHighQuality.Checked)
        combinedControl.ImageQuality = FractalQuality.High;
    }
    private void checkBoxAddReverseGif_CheckedChanged(Object sender, EventArgs e) {
      combinedControl.ReverseGif= checkBoxAddReverseGif.Checked;
    }
    private void buttonDoneExamples_Click(Object sender, EventArgs e) {
      panelExamples.Visible = false;
    }
    private void selectCurrentType(Object sender, EventArgs e) {
      PictureBox box = (PictureBox)sender;
      int tag = Int32.Parse(box.Tag.ToString());
      combinedControl.index2GeneralType(tag);
      newType = FractalType.Mandelbrot;
      presetType();
      panelExamples.Visible = false;
    }
    private void selectCurrentJuliaType(Object sender, EventArgs e) {
      PictureBox box = (PictureBox)sender;
      int tag = Int32.Parse(box.Tag.ToString());
      combinedControl.index2JuliaType(tag);
      newType = FractalType.Julia;
      presetType();
      panelExamples.Visible = false;

      textBoxJuliaX.Enabled = tag == juliaTypePictureBoxes.Count - 1;
      textBoxJuliaY.Enabled = textBoxJuliaX.Enabled;
    }
    private void selectCurrentLineType(Object sender, EventArgs e) {
      PictureBox box = (PictureBox)sender;
      int tag = Int32.Parse(box.Tag.ToString());
      combinedControl.index2LineType(tag);
      newType = FractalType.LinePlot;
      presetType();
      panelExamples.Visible = false;
    }
    private void buttonSelectType_Click(Object sender, EventArgs e) {
      panelExamples.Visible = true;
      panelExamples.BringToFront();
    }
    private void checkBoxSpreadA_CheckedChanged(Object sender, EventArgs e) {
      combinedControl.SpreadMiraA = checkBoxSpreadA.Checked;
    }
    private void hScrollBarMiraA_Scroll(Object sender, ScrollEventArgs e) {
      combinedControl.setMiraAB(hScrollBarMiraA.Value, hScrollBarMiraB.Value);
      textBoxAVal.Text = (hScrollBarMiraA.Value / 1000f).ToString("0.000");
      textBoxBVal.Text = (hScrollBarMiraB.Value / 1000f).ToString("0.000");
    }
    private void hScrollBarIterations_ValueChanged(Object sender, EventArgs e) {
      combinedControl.setIterationsLinPlot = hScrollBarIterations.Value;
      labelIterations.Text = hScrollBarIterations.Value.ToString();
    }
    private void LineplotStartPoint(Object sender, KeyEventArgs e) {
      combinedControl.setStartPointLinePlot(textBoxStartXLineplot.Text, textBoxStartYLineplot.Text);
    }
    private void textBoxABVal_KeyDown(Object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        combinedControl.setMiraAB(textBoxAVal.Text, textBoxBVal.Text);
        if (combinedControl.LineplotAValue < hScrollBarMiraA.Maximum && combinedControl.LineplotAValue > hScrollBarMiraA.Minimum)
          hScrollBarMiraA.Value= combinedControl.LineplotAValue;
        if (combinedControl.LineplotBValue < hScrollBarMiraB.Maximum && combinedControl.LineplotBValue > hScrollBarMiraB.Minimum)
          hScrollBarMiraB.Value = combinedControl.LineplotBValue;
      }
    }
    private void buttonResetLineplot_Click(Object sender, EventArgs e) {
      combinedControl.resetLinePlot();
      params2Form();
    }
    private void pictureBoxMiraType(Object sender, EventArgs e) {
      PictureBox box = (PictureBox)sender;
      string tag = box.Tag.ToString();
      combinedControl.setMiratypePlot(tag);//setFavoriteLinePlot
      newType = FractalType.LinePlot;
      presetType();
      panelExamples.Visible = false;
    }
    #endregion

    #region Interface
    public void rescanExamples() {
      if (this.InvokeRequired) {
        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
          this.rescanExamples();
        })));
      }
      else {
        if (combinedControl != null) {
          combinedControl.getImage(singleColor, SmoozeType.Single);
          combinedControl.getImage(type1, SmoozeType.Type1);
          combinedControl.getImage(type2, SmoozeType.Type2);
          combinedControl.getImage(type3, SmoozeType.Type3);
          panelExamples.Refresh();
          Refresh();
        }
      }
    }
    private void setimage(Image im) {
      try {
        if (InvokeRequired) {
          EndInvoke(BeginInvoke(new MethodInvoker(delegate {
            setimage(im);
          })));
        }
        else {
          pictureBox.Image = im;
          pictureBox.Refresh();
        }
      }
      catch {
      }
    }
    private Bitmap formImage;
    public Bitmap FormImage {
      set {
        formImage = value;
        if (value != null)
          setimage(value);
        else
          setimage(null);
      }
      get {
        return formImage;
      }
    }

    public void setEnabled(bool en) {
      if (this.InvokeRequired) {
        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
          this.setEnabled(en);
        })));
      }
      else {
        buttonSelectType.Enabled = en;
        panelJuliaTypes.Enabled = en;
        panelMiraTypes.Enabled = en;
        panelGeneralSettings.Enabled = en;
        panelColorPictures.Enabled = en;
        panelParameters.Enabled = en;
        panelMiraTypes.Enabled = en;
        if (pictureBox.Image != null)
          pictureBox.Enabled = en;
        createGIFMenuItem.Enabled = en;
      }
    }
    public void setVisibility() {
      newType = combinedControl.fractalPlotter.ThisType;
      panelParameters.Visible = newType == FractalType.Userdefined;

      bool juliaMandelPowerType = newType == FractalType.Julia || newType == FractalType.Mandelbrot || newType == FractalType.Multibrot;//newType == FractalType.Lambda ||
      labeljuliaMandelPowerA.Visible = juliaMandelPowerType;
      textBoxjuliaMandelPowerA.Visible = juliaMandelPowerType;
      panelJuliaTypes.Visible = juliaMandelPowerType;

      labelJuliaType.Visible = newType == FractalType.Julia;
      textBoxJuliaX.Visible = newType == FractalType.Julia;
      textBoxJuliaY.Visible = newType == FractalType.Julia;

      panelJuliaTypeGraph.Visible = newType == FractalType.Mandelbrot;
      panelJuliaTypeGraph.Location = panelParameters.Location;

      bool linePlotType = newType == FractalType.LinePlot;
      panelMiraTypes.Visible = linePlotType;
      if (linePlotType) {
        panelMiraTypes.Location = new Point(panel1.Width / 2 - panelMiraTypes.Width / 2, buttonSelectType.Top + buttonSelectType.Height + 10);// = panelJuliaTypes.Location;

        LinePlot plotter = (LinePlot)combinedControl.fractalPlotter;
        label54.Visible = plotter.UseIterations;
        hScrollBarIterations.Visible = plotter.UseIterations;
        labelIterations.Visible = plotter.UseIterations;

        checkBoxSpreadA.Checked = false;
        checkBoxSpreadA.Text = plotter.SpreadText;
        checkBoxSpreadA.Visible = !String.IsNullOrEmpty(plotter.SpreadText);

        textBoxStartXLineplot.Visible = plotter.UseStartPoint;
        textBoxStartYLineplot.Visible = plotter.UseStartPoint;
        labelStartX.Visible = textBoxStartXLineplot.Visible;
        labelStartY.Visible = textBoxStartYLineplot.Visible;

        labelScrollB.Visible = plotter.UseBVal;
        hScrollBarMiraB.Visible = plotter.UseBVal;
        textBoxBVal.Visible = plotter.UseBVal;

        panelMiraTypes.BringToFront();

      }

      panelGenerateButtons.Visible = !linePlotType;
      panelGeneralSettings.Visible = !linePlotType;
      panelColorPictures.Visible = !linePlotType;

      createGIFMenuItem.Visible = !linePlotType;

    }
    public void params2Form() {
      textBoxXMin.Text = combinedControl.Xmin.ToString("0.000");
      textBoxXMax.Text = combinedControl.Xmax.ToString("0.000");
      textBoxYMin.Text = combinedControl.Ymin.ToString("0.000");
      textBoxYMax.Text = combinedControl.Ymax.ToString("0.0000");
      textBoxMaxIterations.Text = combinedControl.MaxIterationsStr;
      textBoxJuliaX.Text = combinedControl.JuliaXoffset.X.ToString("0.00000");
      textBoxJuliaY.Text = combinedControl.JuliaXoffset.Y.ToString("0.00000");
      if (newType == FractalType.LinePlot) {
        hScrollBarIterations.Minimum = combinedControl.MinMouseIterationVal;
        hScrollBarIterations.Maximum = combinedControl.MaxMouseIterationVal;
        hScrollBarIterations.SmallChange = hScrollBarIterations.Maximum / 100;
        hScrollBarIterations.LargeChange = hScrollBarIterations.Maximum / 10;
        hScrollBarIterations.Value = combinedControl.setIterationsLinPlot;
        try {
          hScrollBarMiraA.Maximum = combinedControl.MaxAval;
          hScrollBarMiraA.Minimum = combinedControl.MinAval;
          hScrollBarMiraA.SmallChange = hScrollBarMiraA.Maximum / 100;
          hScrollBarMiraA.LargeChange = hScrollBarMiraA.Maximum / 10;
          hScrollBarMiraA.Value = combinedControl.LineplotAValue;
          textBoxAVal.Text = (combinedControl.LineplotAValue / 1000.0f).ToString("0.000");
        }
        catch { }
        try {
          hScrollBarMiraB.SmallChange = hScrollBarMiraB.Maximum / 100;
          hScrollBarMiraB.LargeChange = hScrollBarMiraB.Maximum / 10;
          if (combinedControl.LineplotBValue >= hScrollBarMiraB.Minimum && combinedControl.LineplotBValue <= hScrollBarMiraB.Maximum)
            hScrollBarMiraB.Value = combinedControl.LineplotBValue;
          else
            hScrollBarMiraB.Value = hScrollBarMiraB.Minimum;
          textBoxBVal.Text = (combinedControl.LineplotBValue / 1000.0).ToString("0.000");
        }
        catch { }
        //hScrollBarMiraA.Maximum = combinedControl.MaxABMouse + hScrollBarMiraA.LargeChange / 2;
        // hScrollBarMiraA.Minimum = -combinedControl.MaxABMouse - hScrollBarMiraA.LargeChange / 2;
        hScrollBarMiraB.Maximum = combinedControl.MaxABMouse + 3*hScrollBarMiraB.LargeChange/2;
        hScrollBarMiraB.Minimum = -combinedControl.MaxABMouse - 1;// hScrollBarMiraB.LargeChange / 2;
        textBoxStartXLineplot.Text = combinedControl.LinplotStartX.ToString("0.000");
        textBoxStartYLineplot.Text = combinedControl.LinplotStartY.ToString("0.000");
      }
      textBoxjuliaMandelPowerA.Text = combinedControl.LambdaOrMandelbrotA;
      if (combinedControl.Parameters != null && combinedControl.fractalPlotter != null)
        for (int p = 0; p < paramBoxes.Length; p++)
          paramBoxes[p].Text = combinedControl.Parameters[p].ToString();
      setVisibility();
    }
    public void presetType() {
      labelFunctionY.Text = "";
      switch (newType) {
        case FractalType.Userdefined:
          labelFunctionX.Text = "X' = a0 + a1X + a2 X^2 + a3XY + a4Y + a5Y^2";
          labelFunctionY.Text = "Y' = b0 + b1X + b2 X^2 + b3XY + b4Y + b5Y^2";
          break;
        default:
          if (combinedControl.fractalPlotter != null) {
            string text = combinedControl.fractalPlotter.Formula;
            int wh = text.IndexOf("where");
            if (wh > 0) {
              labelFunctionX.Text = text.Substring(0, wh);
              labelFunctionY.Text = text.Substring(wh);
            }
            else
              labelFunctionX.Text = text;
          }
          else
            labelFunctionY.Text = "Mandelbrot fractal. ";
          break;
      }
      params2Form();
    }
    public void addExampleImage(int num, Bitmap map, string name, ExampleGroups group) {
      switch (group) {
        case ExampleGroups.General:
          if (num < generalTypePictureBoxes.Count) {
            generalTypePictureBoxes[num].Image = map;
            generalTypeLabels[num].Text = name;
          }
          break;
        case ExampleGroups.Julia:
          if (num < juliaTypePictureBoxes.Count) {
            juliaTypePictureBoxes[num].Image = map;
            juliaTypeLabels[num].Text = name;
          }
          break;
        case ExampleGroups.Line:
          if (num < lineTypePictureBoxes.Count) {
            lineTypePictureBoxes[num].Image = map;
        //    map.Save(Application.StartupPath + "testt.jpg", System.Drawing.Imaging.ImageFormat.Jpeg); 
            lineTypeLabels[num].Text = name;
          }
          break;
        case ExampleGroups.MiraLine:
          if (num >= 0 && num < lineTypeMiraPictureBoxes.Count) {
            lineTypeMiraPictureBoxes[num].Image = map;
            int newline = name.IndexOf(Environment.NewLine);
            if (newline > 0) {
              lineTypeMiraLabels1[num].Text = name.Substring(0, newline);
              lineTypeMiraLabels2[num].Text = name.Substring(newline + 2);
            }
            else
              lineTypeMiraLabels1[num].Text = name;
          }
          break;
      }  
    }

    #region IProgressbar
    public void setProgressBar(int max) {
      if (this.InvokeRequired) {
        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
          this.setProgressBar(max);
        })));
      }
      else {
        try {
          progressBar.Maximum = max;
          progressBar.Value = 0;
          progressBar.BringToFront();
          progressBar.Visible = true;
         // Refresh();
        }
        catch { }
      }
    }
    public void worker_ProgressChanged(int val) {
      if (this.InvokeRequired) {
        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
          this.worker_ProgressChanged(val);
        })));
      }
      else {
        progressBar.Value = val;
        progressBar.Invalidate();
      }
    }
    public void endGenerate() {
      if (this.InvokeRequired) {
        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
          this.endGenerate();
        })));
      }
      else {
        progressBar.Visible = false;
      }
    }
    public int GIFProgress {
      set {
        labelGIFProgress.Text = "Progress: " + value.ToString();
      }
    }
    #endregion

    #endregion

  }

}