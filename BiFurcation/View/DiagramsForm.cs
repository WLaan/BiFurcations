using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BiFurcation {

  public partial class DiagramsForm : Form, IDiagramView {

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
          instance = new DiagramsForm();
        }
      }
    }
    private static DiagramsForm instance = null;
    public static DiagramsForm Instance {
      get {
        if (DiagramsForm.instance == null)
          DiagramsForm.instance = new DiagramsForm();
        instance.Visible = true;
        return DiagramsForm.instance;
      }
    }

    public static void setNull() {
      instance = null;
    }

    public static DiagramsForm GetInvisible {
      get {
        if (DiagramsForm.instance == null) {
          DiagramsForm.instance = new DiagramsForm();
          instance.Visible = false;
        }
        return DiagramsForm.instance;
      }
    }
    public static void setInvisible() {
      if (DiagramsForm.instance != null)
        DiagramsForm.instance.Visible = false;
    }
    #endregion

    private int mouseX = 0;
    private int mouseY = 0;
    private bool m_DrawingBox;

    private Control4FunctionsView control4FunctionsView;
    public Control4FunctionsView Control4FunctionsView {
      get {
        return control4FunctionsView;
      }
      set {
        control4FunctionsView = value;
        control4DiagramView.CurrentFunction = control4FunctionsView.CurrentFunction.clone();// control4FunctionsView.CurrentFunction;
        params2Form();
      }
    }

    public Control4DiagramView control4DiagramView {
      get {
        return control4FunctionsView.Control4DiagramView;
      }
    }
    private Control4AllViews control4AllViews {
      get {
        return control4DiagramView.control4AllViews;
      }
    }

    protected DiagramsForm() {
      InitializeComponent();
      this.Cursor = Cursors.Default;
      pictureBox.Cursor = Cursors.Cross;
      BifurcationDiagram_Resize(null, null);
    }

    #region events
    private void buttonDefineColors_Click(System.Object sender, System.EventArgs e) {
      control4AllViews.openColorDefView();
    }
    private void BifurcationDiagram_Resize(System.Object sender, System.EventArgs e) {
      labelShoozClicker.Width = (int)(9.0f * pictureBox.Width / 10.0f);
      labelShoozClicker.Left = panelImage.Left + labelShoozClicker.Width / 18;
      progressBar.Width = labelShoozClicker.Width;
      progressBar.Left = labelShoozClicker.Left;
    }
    private void pictureBox_MouseDown(System.Object sender, MouseEventArgs e) {
      mouseX = e.X;
      mouseY = e.Y;
      if (e.Button == MouseButtons.Left) {
        m_DrawingBox = true;
        control4DiagramView.mouseDown(e.X, e.Y, pictureBox.Width, pictureBox.Height);
        this.Cursor = Cursors.Default;
        pictureBox.Cursor = Cursors.Cross;
        labelShoozClicker.Cursor = Cursors.Cross;
      }
    }
    private void pictureBox_MouseMove(System.Object sender, MouseEventArgs e) {
      if (m_DrawingBox)
        control4DiagramView.mouseMove(e.X, e.Y, pictureBox.Width, pictureBox.Height);
      PointD p = control4DiagramView.showMouseCoords(e.X, e.Y, pictureBox.Width, pictureBox.Height);
      labelCurrX.Text = p.X.ToString("0.000");
      labelCurrY.Text = p.Y.ToString("0.000");
    }
    private void pictureBox_MouseUp(System.Object sender, MouseEventArgs e) {
      if (m_DrawingBox) {
        m_DrawingBox = false;
        control4DiagramView.mouseUp(e.X, e.Y, pictureBox.Width, pictureBox.Height);
        this.Cursor = Cursors.WaitCursor;
        Application.DoEvents();
        this.Cursor = Cursors.Default;
        pictureBox.Cursor = Cursors.Cross;
      }
    }
    private void buttonReset_Click(System.Object sender, System.EventArgs e) {
      control4DiagramView.reset();
    }
    private void choozClicker_MouseClick(System.Object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left)
        control4DiagramView.diagramParamShoice(e.X, labelShoozClicker.Size);
    }
    private void listBoxFeigenbaum_SelectedIndexChanged(System.Object sender, System.EventArgs e) {
      control4DiagramView.feigenbaumChoice(listBoxFeigenbaum.SelectedItem.ToString());
    }
    private void textBox_KeyDown(object sender, KeyEventArgs e){
      if (e.KeyCode == Keys.Enter) {
        control4DiagramView.createDiagram(false);
      }
    }
    private void textBoxStartParameter_TextChanged(System.Object sender, System.EventArgs e) {
      control4DiagramView.DiagramStartParameter = control4AllViews.text2Float(textBoxStartParameter.Text);
    }
    private void textBoxStopParamater_TextChanged(System.Object sender, System.EventArgs e) {
      control4DiagramView.DiagramStopParameter = control4AllViews.text2Float(textBoxStopParamater.Text);
    }
    private void textBoxMaxIterations_TextChanged(System.Object sender, System.EventArgs e) {
      control4DiagramView.MaxFunctionIterations = (int)control4AllViews.text2Float(textBoxMaxIterations.Text);
    }
    private void buttonCreateDiagram_Click(System.Object sender, System.EventArgs e) {
      control4DiagramView.createDiagram(false);
    }
    private void textBoxMaxGifImages_TextChanged(System.Object sender, System.EventArgs e) {
      control4DiagramView.MaxGIFIterations = (int)control4AllViews.text2Float(textBoxMaxGifImages.Text);
    }
    private void createGIFOverIterationsMenuItem_Click(System.Object sender, System.EventArgs e) {
      control4DiagramView.createDiagram(true);
    }
    private void textBoxDiagramGifName_TextChanged(System.Object sender, System.EventArgs e) {
      control4DiagramView.DiagramGifFileName = textBoxDiagramGifName.Text;
    }
    private void imageToEditorToolStripMenuItem_Click(System.Object sender, System.EventArgs e) {
      if (pictureBox.Image != null)
        control4AllViews.startImageEditor(pictureBox.Image);
    }
    private void pictureBoxFunction_DoubleClick(System.Object sender, System.EventArgs e) {
      if (pictureBoxFunction.Image != null)
        control4AllViews.startImageEditor(pictureBoxFunction.Image);
    }
    private void buttonStop_Click(System.Object sender, System.EventArgs e) {
      control4DiagramView.stopThread();
      endGenerate();
    }
    private void textBoxSkipHenion150_TextChanged(System.Object sender, System.EventArgs e) {
      control4DiagramView.setHenonSkipIterations(textBoxSkipHenion150.Text);
    }
    private void checkBoxPlotFeigenbaum_CheckedChanged(System.Object sender, System.EventArgs e) {
      control4DiagramView.PlotFeigenbaum = checkBoxPlotFeigenbaum.Checked;
      control4DiagramView.plotDiagram();
      endGenerate();
    }
    private void comboBoxChoozenFunction_SelectedIndexChanged(System.Object sender, System.EventArgs e) {
      control4FunctionsView.CurrFunctionType = (FunctionType)comboBoxChoozenFunction.SelectedIndex;
    }
    #endregion

    #region Interface
    private void setimage(Image im) {
      try {
         if (this.InvokeRequired) {
          this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
            this.setimage(im);
          })));
        }
        else {
          pictureBox.Image = im;
        }
      }
      catch { }
    }
    private Bitmap formImage;
    public Bitmap FormImage {
      set {
        formImage = value;
        setimage(value);
      }
      get {
        return formImage;
      }
    }

    public Bitmap setFunctionImage {
      set {
        pictureBoxFunction.Image = value;
      }
      get {
        return (Bitmap)pictureBoxFunction.Image;
      }
    }
    public string Parameter {
      set {
        labelParameter.Text = value;
        textBoxMaxIterations.Text = Control4FunctionsView.MaxFunctionIterations.ToString();
      }
    }
    public string FunctionText {
      set {
        labelFunction.Text = value;
      }
    }
    public void showNumber(int index, decimal Par, List<DiagramSet> diagram) {
      listBoxFurcationGroup.Items.Clear();
      for (int i = 0; i < diagram[index].setPoints.Count; i++)
        listBoxFurcationGroup.Items.Add(diagram[index].setPoints[i].X.ToString());
      int c = diagram[index].setPoints.Count;
      labelNumFurcations.Text = "Number of converging points: " + c.ToString() + " at " + labelParameter.Text + " = " + Par.ToString("0.000000000"); 
    }
    public void setCurrentIteration(int t) {
      try {
        if (this.InvokeRequired) {
          this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
            this.setCurrentIteration(t);
          })));
        }
        else {
          labelCurrentIteration.Text = t.ToString();
          Refresh();
        }
      }
      catch { }
    }
    public void setEnabled(bool e) {
      panel2.Enabled = e;
      panel3.Enabled = e;
      labelShoozClicker.Enabled = e;
    }
    public void params2Form() {
      textBoxStartParameter.Text = control4DiagramView.Xmin.ToString("0.00");
      textBoxStopParamater.Text = control4DiagramView.Xmax.ToString("0.00");
      textBoxXStart.Text = control4DiagramView.Ymin.ToString("0.00");
      textBoxXStop.Text = control4DiagramView.Ymax.ToString("0.00");
      textBoxMaxIterations.Text = control4DiagramView.MaxFunctionIterations.ToString();
      textBoxSkipHenion150.Text = control4DiagramView.SkipFirst.ToString();
      textBoxSkipHenion150.Visible = control4DiagramView.CurrentFunction is HenonFunction;
      labelSkipFirst.Visible = control4DiagramView.CurrentFunction is HenonFunction;

      FunctionText = control4DiagramView.CurrentFunction.FunctionStr;
      Parameter = control4DiagramView.DiagramLabelParameter;
      control4DiagramView.DiagramDrawer.LineWidth = 3;
    }

    #region IProgressbar
    public void setProgressBar(int max) {
      if (this.InvokeRequired) {
        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
          this.setProgressBar(max);
        })));
      }
      else {
        progressBar.Value = 0;
        progressBar.Maximum = max;
        progressBar.Visible = true;
        progressBar.BringToFront();
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
      progressBar.Visible = false;
      setEnabled(true);
      Refresh();
    }
    public int GIFProgress {
      set {
       // labelGIFProgress.Text = value.ToString();
      }
    }
    #endregion
    #endregion

  }
}
