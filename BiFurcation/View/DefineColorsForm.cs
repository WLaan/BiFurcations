using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BiFurcation {

  public partial class DefineColorsForm : Form, IDefineColors {

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
          instance = new DefineColorsForm();
        }
      }
    }
    private static DefineColorsForm instance = null;
    public static DefineColorsForm Instance {
      get {
        if (DefineColorsForm.instance == null)
          DefineColorsForm.instance = new DefineColorsForm();
        instance.Visible = true;
        return DefineColorsForm.instance;
      }
    }

    public static void setNull() {
      instance = null;
    }

    public static DefineColorsForm GetInvisible {
      get {
        if (DefineColorsForm.instance == null) {
          DefineColorsForm.instance = new DefineColorsForm();
          instance.Visible = false;
        }
        return DefineColorsForm.instance;
      }
    }
    public static void setInvisible() {
      if (DefineColorsForm.instance != null)
        DefineColorsForm.instance.Visible = false;
    }
    #endregion

    private PictureBox[] boxes = new PictureBox[48];
    private MandelbrotPlot mandelbrotPlotInset;
    private DirectBitmap map;
    private SmoozeType smoozeType = SmoozeType.Type2;

    #region properties
    private Control4NonLineairSystems combinedControl;
    public Control4NonLineairSystems CombinedControl {
      get {
        return combinedControl;
      }
      set {
        combinedControl = value;
        combinedControl.ColorForm = this;
        //   mandelbrotPlotInset.XMax = combinedControl.fractalPlotter.XMax;
        mandelbrotPlotInset = new MandelbrotPlot(combinedControl, map);
        mandelbrotPlotInset.XMini = combinedControl.fractalPlotter.XMin;
        mandelbrotPlotInset.XMaxi = combinedControl.fractalPlotter.XMax;
        mandelbrotPlotInset.YMini = combinedControl.fractalPlotter.YMin;
        mandelbrotPlotInset.YMaxi = combinedControl.fractalPlotter.YMax;
        if (Constants.smoozedColors.Count == 4 && Constants.smoozedColors[3].TrackerPositionPercentage < 10) 
          defaultColors(false);
        combinedControlSettings2MandelBrot();
        var t = new Thread(() => mandelbrotPlotInset.doCalculation());
        t.Start();
      }
    }
    private void defaultColors(bool rescanSamples){
      SmoozedColor tag = (SmoozedColor)picColor_40.Tag;
      int numSelected = Constants.SelectedBoxes;
      if (tag.index < 0)
        tag.index = numSelected;
      picColor_40.BorderStyle = BorderStyle.Fixed3D;
      for (int b = 17; b < 24; b++) {
        tag = (SmoozedColor)boxes[b].Tag;
        numSelected = Constants.SelectedBoxes;
        if (tag.index < 0)
          tag.index = numSelected;
        boxes[b].BorderStyle = BorderStyle.Fixed3D;
      }

      combinedControl.collectSmoozedColors(pictureBoxColors.Image, rescanSamples);

    }
    private Control4FunctionsView control4FunctionsView;
    public Control4FunctionsView Control4FunctionsView {
      get {
        return control4FunctionsView;
      }
      set {
        control4FunctionsView = value;
      }
    }

    private Control4DiagramView control4DiagramView;
    public Control4DiagramView Control4DiagramView {
      get {
        return control4DiagramView;
      }
      set {
        control4DiagramView = value;
      }
    }
    #endregion

    protected DefineColorsForm() {

      InitializeComponent();

      //add SmoozedColor's to Tag's of pictureBoxes
      foreach (Control ctl in panelColorPictures.Controls) {
        if (ctl is PictureBox && ctl.Tag != null) {
          try {
            int b = 0;
            int.TryParse(ctl.Tag.ToString(), out b);
            if (b < 48) {
              boxes[b] = (PictureBox)ctl;
              ctl.BackColor = Constants.SmoozedColorTags[b].color;
              ctl.Tag = Constants.SmoozedColorTags[b];
              if (Constants.SmoozedColorTags[b].index >= 0) 
                boxes[b].BorderStyle = BorderStyle.Fixed3D;
              else
                boxes[b].BorderStyle = BorderStyle.None;
            }
          }
          catch {
          }
        }
      }

      //set colors for function Buttons
      buttonFunctionColor0.BackColor = Constants.pens[0];
      buttonFunctionColor1.BackColor = Constants.pens[1];
      buttonFunctionColor2.BackColor = Constants.pens[2];
      buttonFunctionColor3.BackColor = Constants.pens[3];
      buttonFunctionColor4.BackColor = Constants.pens[4];
      buttonFunctionColor5.BackColor = Constants.pens[5];
      buttonFunctionColor6.BackColor = Constants.pens[6];
      buttonFunctionColor7.BackColor = Constants.pens[7];
      buttonFunctionColor8.BackColor = Constants.pens[8];
      buttonFunctionColor9.BackColor = Constants.pens[9];

      buttonLinesColor.BackColor = Constants.OneColor;
      map = new DirectBitmap(Constants.UsedBSize, Constants.UsedBSize);
      pictureBoxExampleMandelbrot.Image = map.Bitmap;

    }

    private void setPictureSelected(PictureBox pic) {
      SmoozedColor tag = (SmoozedColor)pic.Tag;
      int numSelected = Constants.SelectedBoxes;
      if (tag.index < 0) 
        tag.index = numSelected;     
      pic.BorderStyle = BorderStyle.Fixed3D;
    }
    private void switchPictureSelected(PictureBox pic) {
      SmoozedColor tag = (SmoozedColor)pic.Tag;   
      if (tag.index < 0) {
        int numSelected = Constants.SelectedBoxes;
        tag.index = numSelected;
        pic.BorderStyle = BorderStyle.Fixed3D;
      }
      else {
        tag.index = -1;
        pic.BorderStyle = BorderStyle.None;
      }
      combinedControl.collectSmoozedColors(pictureBoxColors.Image, true);
      Refresh();
    }
    private void combinedControlSettings2MandelBrot() {
      if (mandelbrotPlotInset.XMini != combinedControl.fractalPlotter.XMin ||
          mandelbrotPlotInset.XMaxi != combinedControl.fractalPlotter.XMax ||
          mandelbrotPlotInset.YMini != combinedControl.fractalPlotter.YMin ||
          mandelbrotPlotInset.YMaxi != combinedControl.fractalPlotter.YMax ||
          mandelbrotPlotInset.MaxIterations != combinedControl.fractalPlotter.MaxIterations ||
          mandelbrotPlotInset.MAX_MAG_SQUARED != combinedControl.MAX_MAG_SQUARED) {
        mandelbrotPlotInset.XMini = combinedControl.fractalPlotter.XMin;
        mandelbrotPlotInset.XMaxi = combinedControl.fractalPlotter.XMax;
        mandelbrotPlotInset.YMini = combinedControl.fractalPlotter.YMin;
        mandelbrotPlotInset.YMaxi = combinedControl.fractalPlotter.YMax;
        mandelbrotPlotInset.MaxIterations = combinedControl.fractalPlotter.MaxIterations;
        mandelbrotPlotInset.MAX_MAG_SQUARED = combinedControl.MAX_MAG_SQUARED;
        mandelbrotPlotInset.reset();
      }
    }
    #region events  
    private void radioButtonCheckedChanged(Object sender, EventArgs e) {
      if (radioButtonSingle.Checked)
        smoozeType = SmoozeType.Single;
      if (radioButtonType1.Checked)
        smoozeType = SmoozeType.Type1;
      if (radioButtonType2.Checked)
        smoozeType = SmoozeType.Type2;
      if (radioButtonType3.Checked)
        smoozeType = SmoozeType.Type3;
      mandelbrotPlotInset.SmoozeType = smoozeType;
      combinedControlSettings2MandelBrot();
      
      mandelbrotPlotInset.doCalculation();
      Refresh();
    }
    private void btnColumn_Click(Object sender, EventArgs e) {
      if (CombinedControl == null || CombinedControl.SmoozeType == SmoozeType.Single) return;

      Button btn = sender as Button;
      int col = int.Parse(btn.Tag.ToString());
      for (int i = 0; i <= 5; i++) 
        setPictureSelected(boxes[i * 8 + col]);
      combinedControl.collectSmoozedColors(pictureBoxColors.Image, true);
      Refresh();
    }
    private void btnRow_Click(Object sender, EventArgs e) {
      if (CombinedControl == null || CombinedControl.SmoozeType == SmoozeType.Single) return;

      Button btn = sender as Button;
      int row = int.Parse(btn.Tag.ToString());
      int first_number = row * 8;
      int numSelected = Constants.SelectedBoxes;
      for (int i = 0; i <= 7; i++) 
        setPictureSelected(boxes[first_number + i]);
      combinedControl.collectSmoozedColors(pictureBoxColors.Image, true);
      Refresh();
    }
    private void picColor_Click(Object sender, EventArgs e) {
      if (CombinedControl == null || CombinedControl.SmoozeType == SmoozeType.Single) btnNone_Click(null, null);

      PictureBox pic = sender as PictureBox;
      switchPictureSelected(pic);
    }
    private void btnDefault_Click(Object sender, EventArgs e) {
      if (CombinedControl == null || CombinedControl.SmoozeType == SmoozeType.Single) return;

      // Deselect all colors.
      btnNone_Click(null, null);
      defaultColors(true);
      Refresh();
    }
    private void btnAll_Click(Object sender, EventArgs e) {
      if (CombinedControl == null || CombinedControl.SmoozeType == SmoozeType.Single) return;

      for (int b = 0; b < boxes.Length; b++) {
        SmoozedColor tag = (SmoozedColor)boxes[b].Tag;
        tag.index = b;
        boxes[b].BorderStyle = BorderStyle.Fixed3D;
      }
      combinedControl.collectSmoozedColors(pictureBoxColors.Image, true);
      Refresh();
    }
    private void btnNone_Click(Object sender, EventArgs e) {
      if (CombinedControl == null || CombinedControl.SmoozeType == SmoozeType.Single) return;

      for (int b = 0; b < boxes.Length; b++) {
        SmoozedColor tag = (SmoozedColor)boxes[b].Tag;
        tag.index = -1;
        boxes[b].BorderStyle = BorderStyle.None;
      }
      combinedControl.collectSmoozedColors(pictureBoxColors.Image, true);
      Refresh();
    }
    private void checkBoxLineairInterpolation_CheckedChanged(Object sender, EventArgs e) {
      Constants.LineairInterpolation = checkBoxLineairInterpolation.Checked;
      combinedControl.collectSmoozedColors(pictureBoxColors.Image, true);
      Refresh();
    }
    private void buttonFunctionColor_Click(Object sender, EventArgs e) {
      Button b = (Button)sender;
      DialogResult r = colorDialog.ShowDialog();
      if (r != DialogResult.Cancel) {
        int c = Int32.Parse(b.Tag.ToString());
        Constants.pens[c] = colorDialog.Color;
        b.BackColor = colorDialog.Color;
      }
    }
    private void checkBoxf_CheckedChanged(Object sender, EventArgs e) {
      CheckBox c = (CheckBox)sender;
      int n = Int32.Parse(c.Tag.ToString());
      Control4FunctionsView.setFInclude(n, c.Checked);
    }
    private void buttonLinesColor_Click(Object sender, EventArgs e) {
      DialogResult r = colorDialog.ShowDialog();
      if (r != DialogResult.Cancel) {
        Constants.FurcationColor = colorDialog.Color;
        buttonLinesColor.BackColor = colorDialog.Color;
      }
    }
    private void buttonDiagramLineColor_Click(Object sender, EventArgs e) {
      DialogResult r = colorDialog.ShowDialog();
      if (r != DialogResult.Cancel) {
        Constants.DiagramColor = colorDialog.Color;
        buttonDiagramLineColor.BackColor = colorDialog.Color;
      }
    }
    private void buttonOneColor_Click(Object sender, EventArgs e) {
      DialogResult r = colorDialog.ShowDialog();
      if (r != DialogResult.Cancel) {
        buttonOneColor.BackColor = colorDialog.Color;
        Constants.OneColor = colorDialog.Color;
        Constants.settings2XML();
        if (NonLineairSystemsForm.Instance.Visible) 
          combinedControl.RescanExampleParallelAsync(false);
        Refresh();
      }
    }
    private void comboBoxColorType3_SelectedIndexChanged(Object sender, EventArgs e) {
      Constants.Type3Color = (Type3Color)comboBoxColorType3.SelectedIndex;
      mandelbrotPlotInset.setColorsFromNewSmoozedColors(smoozeType);
      if (NonLineairSystemsForm.Instance.Visible)
        combinedControl.RescanExampleParallelAsync(false);
      Refresh();
    }
    private void numericUpDownContrast_ValueChanged(Object sender, EventArgs e) {
      Constants.ContrastValue = (int)numericUpDownContrast.Value;
      mandelbrotPlotInset.setColorsFromNewSmoozedColors(smoozeType);
      if (NonLineairSystemsForm.Instance.Visible)
        combinedControl.RescanExampleParallelAsync(false);
      Refresh();
    }
    private void numericUpDownFunctionLineWidth_ValueChanged(Object sender, EventArgs e) {
      Constants.FunctionsLineWidth = (int)numericUpDownFunctionLineWidth.Value;
      Constants.settings2XML();
    }
    private void numericUpDownLineWidthFurcation_ValueChanged(Object sender, EventArgs e) {
      Constants.FurcationsLineWidth = (int)numericUpDownLineWidthFurcation.Value;
      Constants.settings2XML();
    }
    private void numericUpDownLineWidth_ValueChanged(Object sender, EventArgs e) {
      Constants.DiagramLineWidth = (int)numericUpDownLineWidth.Value;
      Constants.settings2XML();
    }
    private void buttonDone_Click(Object sender, EventArgs e) {
      combinedControl.RescanExampleParallelAsync(true);
  //    var t = new Thread(() => combinedControl.RescanExamples(true));
  //    t.Start();
   //   combinedControl.rescanExamples(false);
   //   combinedControl.rescanExamples(true);
      Constants.settings2XML();
      Hide();
    }
    private void pictureBoxColors_MouseDown(Object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left)
        combinedControl.MouseDownColorDef(e.X, e.Y, pictureBoxColors.Size);
    }
    private void pictureBoxColors_MouseMove(Object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        combinedControl.MouseMoveColorDef(e.X, e.Y, pictureBoxColors.Size);
        mandelbrotPlotInset.setColorsFromNewSmoozedColors(smoozeType);
        Refresh();
      }   
    }
    private void pictureBoxColors_MouseUp(Object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        combinedControl.MouseUpColorDef(e.X, e.Y);
      }
    }
    #endregion

    public Size getSpreadImageSize {
      get {
        return pictureBoxColors.Size;
      }
    }
    public void setSpreadImage(Bitmap im) {
      pictureBoxColors.Image = im;
    }

  }

}
