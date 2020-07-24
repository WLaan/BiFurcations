using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiFurcation {

  public enum SmoozeType {
    Single,
    Type1,
    Type2,
    Type3,
    None
  }
  public enum Type3Color {
    Red,
    Green,
    Blue
  }
  public enum ExampleGroups {
    General,
    Julia,
    Line,
    MiraLine
  }
  public enum FractalType {
    None = -1,
    Userdefined = 0,
    Mandelbrot,
    JuliaPol3,
    JuliaRationalPlot,
    Henon,
    Lambda,
    Multibrot,
    Mandelbar,
    Julia,
    LinePlot
  }
  public enum FractalQuality {
    Low,
    Normal,
    High
  }
  public class Control4NonLineairSystems : ImageControl{

    #region private fields
    private List<Task> tasks = new List<Task>();
    protected const decimal MIN_X = -2;
    protected const decimal MAX_X = 2;
    protected const decimal MIN_Y = -2;
    protected const decimal MAX_Y = 2;
    private SmoozedColor trackedSmoozedColor = null;
    public Bitmap colorSpread;

    private FractalType fractalType = FractalType.Mandelbrot;

    private List<BaseFor2DimensionalPlot> generalPlotters = new List<BaseFor2DimensionalPlot>();
    private List<BaseFor2DimensionalPlot> JuliaPlotters = new List<BaseFor2DimensionalPlot>();
    private List<BaseFor2DimensionalPlot> linePlotters = new List<BaseFor2DimensionalPlot>();
    private List<BasePlotter> examplePlottersGeneral = new List<BasePlotter>();
    private List<BasePlotter> examplePlottersJulia = new List<BasePlotter>();
    private List<BasePlotter> examplePlottersMira = new List<BasePlotter>();

    private BasePlotter demoType;
    private JuliaPlot juliaPlotInset;
    private MandelbrotPlot mandelbrotPlotInset;
    private DirectBitmap mandelbrotInsetBitmap;
    private List<MiraLinePlotter> miraLineplotExamples = new List<MiraLinePlotter>();

    private BackgroundWorker worker4GIF;
    private string gifFilename = "";
    private decimal currXmin;
    private decimal currXmax;
    private decimal currYmin;
    private decimal currYmax;
    private decimal dx;
    private decimal dy;
    private decimal centerX = 0;
    private decimal centerY = 0;
    private int nGif = 10;

    private int colorMouseX1 = 0;
    private int colorMouseY1 = 0;
    private int colorMouseX2 = 0;
    private int colorMouseY2 = 0;
    private int colorMouseRange = 0;

    #endregion

    #region properties
    public new ICombined PlotForm {
      get {
        return (ICombined)base.plotForm;
      }
      set {
        plotForm = value;
        RescanExampleParallelAsync(false);
      }
    }
    private IDefineColors colorForm;
    public IDefineColors ColorForm {
      set {
        colorForm = value;
        colorSpread = new Bitmap(colorForm.getSpreadImageSize.Width, colorForm.getSpreadImageSize.Height);
        Constants.setColorRange(colorSpread);
        colorForm.setSpreadImage(colorSpread);
      }
    }
    private int maxIterations = 32;
    public override int MaxIterations {
      set {
        maxIterations = value;
        fractalPlotter.MaxIterations = maxIterations;
        mandelbrotPlotInset.MaxIterations = maxIterations;
      }
      get {
        return maxIterations;
      }
    }
    public string MaxIterationsStr {
      set {
        Int32.TryParse(value, out maxIterations);
        fractalPlotter.MaxIterations = maxIterations;
        fractalPlotter.reset(); 
        mandelbrotPlotInset.MaxIterations = maxIterations;
      }
      get {
        return maxIterations.ToString();
      }
    }
    private FractalQuality imageQuality = FractalQuality.Normal;
    public FractalQuality ImageQuality {
      set {
        imageQuality = value;
        switch (imageQuality) {
          case FractalQuality.Low:
            Constants.UsedBSize = 500;
            break;
          case FractalQuality.Normal:
            Constants.UsedBSize = 1000;
            break;
          case FractalQuality.High:
            Constants.UsedBSize = 2000;
            break;
        }
        BSize = Constants.UsedBSize;
        fractalPlotter.reset();
        if (PlotForm != null && PlotForm.FormImage != null) {
          PlotForm.FormImage.Dispose();
          PlotForm.FormImage = null;
        }
        simulate();
      }
      get {
        return imageQuality;
      }
    }

    public bool ReverseGif {
      set {
        gifCreater.AddReverse = value;
      }
    }

    private int max_MAG_SQUARED = 4;
    public string MAX_MAG_SQUARED {
      get {
        return max_MAG_SQUARED.ToString();
      }
      set {
        Int32.TryParse(value, out max_MAG_SQUARED);
        fractalPlotter.reset();
        fractalPlotter.UsedColorIndices = new ColorIndex[BSize, BSize];
      }
    }

    private SmoozeType smoozeType = SmoozeType.Type2;
    public SmoozeType SmoozeType {
      set {
        smoozeType = value;
        if (fractalPlotter != null) {
          fractalPlotter.SmoozeType = value;
          simulate(false);
        }
      //((ICombined)PlotForm).rescanExamples();
      //  rescanExamples(false);
      }
      get {
        return smoozeType;
      }
    }

    public PointF JuliaXoffset {
      get {
        if (fractalPlotter is JuliaPlot) {
          JuliaPlot jp = (JuliaPlot)fractalPlotter;
          return jp.definedOffset;
        }
        else
          return new PointF(0,0);
      }
    }
    public double[] Parameters {
      get {
        if (fractalPlotter != null)
          return fractalPlotter.Parameters;
        else
          return new double[12];
      }
    }
    public int LineplotAValue {
      get {
        if (fractalPlotter is LinePlot) {
          LinePlot lp = (LinePlot)fractalPlotter;
          return (int)(1000 * lp.Parameters[0]);
        }
        else
          return 100;
      }
    }
    public int LineplotBValue {
      get {
        if (fractalPlotter is LinePlot) {
          LinePlot lp = (LinePlot)fractalPlotter;
          return (int)(1000 * lp.Parameters[6]);
        }
        else
          return 100;
      }
    }
    public int MaxAval {
      get {
        if (fractalPlotter is LinePlot) {
          LinePlot lp = (LinePlot)fractalPlotter;
          return (int)(1000 * lp.MaxAval);
        }
        else
          return 1000;
      }
    }
    public int MinAval {
      get {
        if (fractalPlotter is LinePlot) {
          LinePlot lp = (LinePlot)fractalPlotter;
          return (int)(1000 * lp.MinAval);
        }
        else
          return -1000;
      }
    }
    public string LambdaOrMandelbrotA {
      set {
        if (fractalPlotter is LambdaPlot || fractalPlotter is MandelbrotPlot) {
          MandelbrotPlot p = (MandelbrotPlot)fractalPlotter;
          fractalPlotter.reset();
          float a;
          float.TryParse(value, out a);
          p.A = a;
        }
      }
      get {
        if (fractalPlotter is LambdaPlot || fractalPlotter is MandelbrotPlot) {
          return ((MandelbrotPlot)fractalPlotter).A.ToString("0.00");
        }
        else
          return "";
      }
    }
    public SpecificLineType SpecificLineType {
      set {
        if (fractalPlotter is LinePlot) 
          ((LinePlot)fractalPlotter).SpecificLineType = value;
        if (PlotForm != null)
          PlotForm.FormImage = MainImage;
      }
      get {
        if (fractalPlotter is LinePlot)
           return ((LinePlot)fractalPlotter).SpecificLineType;
        else
          return SpecificLineType.None;
      }
    }
    public void setMiraAB(int A, int B) {
      if (fractalPlotter is LinePlot)
        ((LinePlot)fractalPlotter).setABval(A, B);
      if (PlotForm != null)
        PlotForm.FormImage = PointsImage.Bitmap; 
    }
    public void setMiraAB(string A, string B) {
      if (fractalPlotter is LinePlot)
        ((LinePlot)fractalPlotter).setABval(A, B);
      if (PlotForm != null)
        PlotForm.FormImage = PointsImage.Bitmap; 
    }
    public bool SpreadMiraA {
      set {
        if (fractalPlotter is LinePlot) {
          ((LinePlot)fractalPlotter).SpreadA = value;
          if (PlotForm != null)
            PlotForm.FormImage = PointsImage.Bitmap;
        }
      }
    }
    public int setIterationsLinPlot {
      set {
        if (fractalPlotter is LinePlot) {
          ((LinePlot)fractalPlotter).Iterations = value;
          if (PlotForm != null)
            PlotForm.FormImage = PointsImage.Bitmap; 
        }
      }
      get {
        if (fractalPlotter is LinePlot) {
         return ((LinePlot)fractalPlotter).Iterations;
        }
        else
          return 0;
      }
    }
    public int MinMouseIterationVal {
      get {
        if (fractalPlotter is LinePlot) {
          return ((LinePlot)fractalPlotter).MinMouseIterations;
        }
        else
          return 0;
      }
    }
    public int MaxMouseIterationVal {
      get {
        if (fractalPlotter is LinePlot) {
          return ((LinePlot)fractalPlotter).MaxMouseIterations;
        }
        else
          return 1000;
      }
    }
    public int MaxABMouse {
      get {
        if (fractalPlotter is LinePlot) {
          return ((LinePlot)fractalPlotter).MaxABMouse;
        }
        else
          return 0;
      }
    }
    public double LinplotStartX {
      get {
        if (fractalPlotter is LinePlot) {
          LinePlot lp = (LinePlot)fractalPlotter;
          return lp.StartPoint.X;
        }
        else
          return 0;
      }
    }
    public double LinplotStartY {
      get {
        if (fractalPlotter is LinePlot) {
          LinePlot lp = (LinePlot)fractalPlotter;
          return lp.StartPoint.Y;
        }
        else
          return 0;
      }
    }
    #endregion

    public Control4NonLineairSystems(IFunctionsView f):base(f) {
    }
    public Control4NonLineairSystems(ICombined f, Control4AllViews bf):base(f,bf) {
      pictBoxSize = new Size(BSize, BSize);

      mandelbrotInsetBitmap = new DirectBitmap(pictBoxSize.Width / 5, pictBoxSize.Height / 5);
      mandelbrotPlotInset = new MandelbrotPlot(this, mandelbrotInsetBitmap);

      generalPlotters.Add(new UserdefinedPlot(this));
      generalPlotters.Add(new MandelbrotPlot(this));
      generalPlotters.Add(new JuliaPlot3(this, 0));
      generalPlotters.Add(new JuliaRationalPlot(this, 0));
      generalPlotters.Add(new HenonPlot(this));
      generalPlotters.Add(new LambdaPlot(this));
      generalPlotters.Add(new MultibrotReciprokePlot(this));
      generalPlotters.Add(new MandelbarPlot(this));

      fractalPlotter = generalPlotters[1];

      for (int jp = 0; jp < JuliaPlot.Initials.Length; jp++) {
        JuliaPlot jpp = new JuliaPlot(this, jp);
        JuliaPlotters.Add(jpp);
      }
      MiraLinePlotter miraLinePlotter = new MiraLinePlotter(this);
      linePlotters.Add(miraLinePlotter);
      linePlotters.Add(new BolSpiralLinePlotter(this));
      linePlotters.Add(new HenonLinePlotter(this));
      linePlotters.Add(new DustLinePlotter(this));
      linePlotters.Add(new CloudLinePlotter(this, CloudType.Type0));
      linePlotters.Add(new CloudLinePlotter(this, CloudType.Type1));
   //   linePlotters.Add(new CloudLinePlotter(this, CloudType.Type2));
      linePlotters.Add(new DendriteLinePlotter(this));
      linePlotters.Add(new StarLinePlotter(this));
      linePlotters.Add(new JuliaLinePlotter(this));

      for (int i = 0; i < miraLinePlotter.Favorites.Length; i++) {
        MiraLinePlotter miraExample = (MiraLinePlotter)miraLinePlotter.clone(new DirectBitmap(100, 100));
        miraExample.ExampleNumber = i;
        miraLineplotExamples.Add(miraExample);
      }
      Xmin = (decimal)fractalPlotter.XMin;
      Xmax = (decimal)fractalPlotter.XMax;
      Ymin = (decimal)fractalPlotter.YMin;
      Ymax = (decimal)fractalPlotter.YMax;

      interpolateColorPalette();

      foreach (BasePlotter p in generalPlotters) {
        BasePlotter pp = p.clone(new DirectBitmap(100, 100));
        examplePlottersGeneral.Add(pp);
      }
      for (int jp = 0; jp < JuliaPlot.Initials.Length; jp++) {
        JuliaPlot jpp = new JuliaPlot(this, jp, new DirectBitmap(100, 100));
        examplePlottersJulia.Add(jpp);
      }
      for (int mp = 0; mp < linePlotters.Count;mp++) {// Enum.GetNames(typeof(SpecificLineType)).Length - 1; mp++) {
        BasePlotter mpp = linePlotters[mp].clone(new DirectBitmap(100, 100, true)); 
        examplePlottersMira.Add(mpp);
      }
    }

    #region private helpers
    private void initFractal() {
      if (fractalPlotter != null) {

        Xmin = (decimal)fractalPlotter.XMini;
        Xmax = (decimal)fractalPlotter.XMaxi;
        Ymin = (decimal)fractalPlotter.YMini;
        Ymax = (decimal)fractalPlotter.YMaxi;

        fractalPlotter.MAX_MAG_SQUARED = max_MAG_SQUARED.ToString();
        fractalPlotter.Worker = worker;
        fractalPlotter.SmoozeType = SmoozeType;
        fractalPlotter.reset();//.Map.reset();
        PlotForm.params2Form();
        if (fractalPlotter.ThisType == FractalType.LinePlot) {
          fractalPlotter.doCalculation();
          if (PlotForm != null)
            PlotForm.FormImage = PointsImage.Bitmap;
        }
        else
          simulate();

      }  
    }
    private void CalcCombinedFractal(object sender, DoWorkEventArgs e) {

      fractalPlotter.Worker = worker;
      fractalPlotter.initImages(MainImage, PointsImage.Bitmap, BSize);
      fractalPlotter.doCalculation();

      if (fractalType == FractalType.Julia && mandelbrotInsetBitmap != null && smoozeType == SmoozeType.Single) {
        using (Graphics g = Graphics.FromImage(PointsImage.Bitmap)) {
          //  AdjustAspect();
          mandelbrotPlotInset.SmoozeType = SmoozeType.Single;
          mandelbrotPlotInset.XMini = -2;
          mandelbrotPlotInset.XMaxi = 0.7;
          mandelbrotPlotInset.YMini = -1.5;
          mandelbrotPlotInset.YMaxi = 1.5;
          mandelbrotPlotInset.doCalculation();
          JuliaPlot p = (JuliaPlot)fractalPlotter;
          mandelbrotPlotInset.addRedDot(p.Initial_C);
          Rectangle source = new Rectangle(0,0,
                                           mandelbrotInsetBitmap.Width, mandelbrotInsetBitmap.Height);
          Rectangle dest = new Rectangle(0, PointsImage.Height- mandelbrotPlotInset.Map.Height, mandelbrotPlotInset.Map.Width, mandelbrotPlotInset.Map.Height);
          g.DrawImage(mandelbrotInsetBitmap.Bitmap, dest, source, GraphicsUnit.Pixel);
        }
      }
      int cSize = BSize / 50;
      Rectangle destRect = DestRect;
      try {
        using (Graphics g = Graphics.FromImage(MainImage)) {
          string text = fractalPlotter.Title + ", Escape radius:" + max_MAG_SQUARED + ", Iterations:" + maxIterations;
          g.Clear(Color.LightGray);
          using (Pen pen = new Pen(Color.Black, 4))
            g.DrawRectangle(pen, new Rectangle(destRect.X - 1, destRect.Y - 1, destRect.Width + 2, destRect.Height + 2));
          using (Pen pen = new Pen(Color.White, 4)) {
            g.DrawLine(pen, destRect.X - 4, destRect.Y - 1, destRect.Width + destRect.X, destRect.Y - 1);
            g.DrawLine(pen, destRect.X - 1, destRect.Y - 1, destRect.X - 1, destRect.Height + destRect.Y);
          }
          g.DrawString(text, new Font("Calibri", cSize), Brushes.Blue, pictBoxSize.Height / 20, BSize / 70);
          g.DrawString(yMax.ToString("0.00"), new Font("Calibri", 2 * cSize / 3), Brushes.Blue, 5, destRect.Y);
          g.DrawString(yMin.ToString("0.00"), new Font("Calibri", 2 * cSize / 3), Brushes.Blue, 5, destRect.Y + destRect.Height - cSize);
          g.DrawString(xMin.ToString("0.00"), new Font("Calibri", 2 * cSize / 3), Brushes.Blue, destRect.X - cSize, destRect.Y + destRect.Height + cSize/4);
          g.DrawString(xMax.ToString("0.00"), new Font("Calibri", 2 * cSize / 3), Brushes.Blue, destRect.X + destRect.Width - cSize, destRect.Y + destRect.Height + cSize/4);

          g.DrawImage(PointsImage.Bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
        }
      }
      catch { }

      fractalPlotter.copy2GIF(MainImage, BSize, sourceRect);

      if (PlotForm != null)
        PlotForm.FormImage = MainImage;
      PointsImage.Bitmap.Save("testt.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    protected void fractalProgressGIF(object sender, ProgressChangedEventArgs e) {
      PlotForm.GIFProgress = e.ProgressPercentage;
    }
    protected void fractalCompletedGIF(object sender, RunWorkerCompletedEventArgs e) {
      fractalPlotter.CreateGif = false;
      gifCreater.create(1, gifFilename);
      xMin = currXmin;
      xMax = currXmax;
      yMin = currYmin;
      yMax = currYmax;
      worker = null;
      PlotForm.setEnabled(true);
      PlotForm.endGenerate();
      worker4GIF = null;
      reset();
      simulate(true);
    }
    private void doGif(object sender, DoWorkEventArgs e) {
      worker = new BackgroundWorker();
      worker.ProgressChanged += new ProgressChangedEventHandler(fractalProgress);
      worker.WorkerReportsProgress = true;
      worker.WorkerSupportsCancellation = true;
      for (int i = 0; i < nGif && !worker4GIF.CancellationPending && Xmin < centerX && yMin < centerY ; i++) {
        //calc image
        PlotForm.setProgressBar(pictBoxSize.Width);
        fractalPlotter.reset();
        CalcCombinedFractal(null, null);
        xMin -= dx;
        decimal dd = centerX - Xmin;
        Xmax += dx;// centerX + dd;
        // xMax -= dx;
        Ymin -= dy;
        //  yMax -= dy;
        yMax += dy;// centerY + centerY - Ymin;
     //   dx = 2 * (xMax - xMin) / nGif;
      //  dy = 2 * (yMax - yMin) / nGif;
        if (i > 0)
          gifCreater.images.Add(fractalPlotter.Copy4GIF);
        worker4GIF.ReportProgress(i);
        plotForm.params2Form();
      }
    }
    private void interpolateColorPalette() {
      Constants.interpolate();
      if (fractalPlotter != null)
        fractalPlotter.Map.CalculatedTypes.Clear();
    }
    #endregion

    #region public

    #region virtual
    public override void stopThread() {
      try {
        if (fractalPlotter != null && fractalPlotter.Worker != null)
          fractalPlotter.Worker.CancelAsync();
      }
      catch { }
      try {
        if (worker != null)
          worker.CancelAsync();
      }
      catch { }
      try {
        if (worker4GIF != null)
          worker4GIF.CancelAsync();
      }
      catch { }
    }
    public override void simulate() {
      if (worker != null) {
        worker.CancelAsync();
        worker = null;
      }
      plotForm.setEnabled(false);
      doFractalWork = CalcCombinedFractal;
      base.simulate();
    }
    #endregion

    #region NonlinearSystemsForm
    public void simulate(bool reset) {
      if (reset) {
        fractalPlotter.reset();
      }
      simulate();
    }
    public void presetParameter(int index, string value) {
      double.TryParse(value, out fractalPlotter.Parameters[index]);
      fractalPlotter.reset();
    }
    public void setUserdefined(string x, string y) {
      if (fractalPlotter is JuliaPlot) {
        fractalPlotter.reset();
        float xf;
        float.TryParse(x, out xf);
        float yf;
        float.TryParse(y, out yf);
        ((JuliaPlot)fractalPlotter).setUserDefined(xf, yf);
      }
    }
    public void startImageEditor(Image image) {
      control4AllViews.startImageEditor(image);
    }
    public void createGif(PointD current, string numGif, string fName) {
      m_StartX = (float)current.X;
      m_StartY = (float)current.Y;
      gifFilename = fractalPlotter.Title + fName + numGif;
      Int32.TryParse(numGif, out nGif);
      gifFilename = string.Concat(gifFilename.Split(Path.GetInvalidFileNameChars()));

      gifFilename = gifFilename.Replace("^", "");
      gifFilename = gifFilename.Replace("/", "");
      currXmin = xMin;
      currXmax = xMax;
      currYmin = yMin;
      currYmax = yMax;
      fractalPlotter.CreateGif = true;
      gifCreater.images.Clear();
      //zoom in to the largest square around current x,y
      if (Math.Abs(m_StartY) < 0.05)
        m_StartY = 0;
      if (Math.Abs(m_StartX) < 0.05)
        m_StartX = 0;
      double minX = Math.Min(Math.Abs((float)xMax - m_StartX), Math.Abs((float)xMin - m_StartX));
      double minY = Math.Min(Math.Abs((float)yMax - m_StartY), Math.Abs((float)yMin - m_StartY));
      double delta = Math.Min(minX, minY);

      xMin = (decimal)(m_StartX - delta);
      xMax = (decimal)(m_StartX + delta);
      yMin = (decimal)(m_StartY - delta);
      yMax = (decimal)(m_StartY + delta);

      centerX = xMin + (xMax - xMin) / 2;
      centerY = yMin + (yMax - yMin) / 2;
      dx = (xMax - xMin) / (2*nGif);
      dy = (yMax - yMin) / (2*nGif);
      xMax -= dx * (nGif - 1);
      xMin += dx * (nGif - 1);
      yMax -= dy * (nGif - 1);
      yMin += dy * (nGif - 1);
      fractalPlotter.Map.reset();
      fractalPlotter.reset();
      plotForm.params2Form();

  //    CalcCombinedFractal(null, null);
      worker4GIF = new BackgroundWorker();
      worker4GIF.WorkerSupportsCancellation = true;
      worker4GIF.WorkerReportsProgress = true;
      worker4GIF.DoWork += new DoWorkEventHandler(doGif);
      worker4GIF.ProgressChanged += new ProgressChangedEventHandler(fractalProgressGIF);
      worker4GIF.RunWorkerCompleted += new RunWorkerCompletedEventHandler(fractalCompletedGIF);
      worker4GIF.RunWorkerAsync();
    }
    public void juliaMouseMove(double x, double y, DirectBitmap map) {
      if (fractalType == FractalType.Mandelbrot) {
        if (juliaPlotInset == null)
          juliaPlotInset = new JuliaPlot(this, JuliaPlot.Initials.Length - 1, map);
        juliaPlotInset.setUserDefined((float)x, (float)y);
        juliaPlotInset.reset();
        juliaPlotInset.SmoozeType = this.smoozeType;
        juliaPlotInset.doCalculation();
      }
    }
    public void getImage(DirectBitmap m, SmoozeType type) {
      if (fractalPlotter == null) return;
      demoType = fractalPlotter.clone(m);
      demoType.SmoozeType = type;
      demoType.reset();
      demoType.MaxIterations = 32;
      demoType.doCalculation();
    }
    public void index2GeneralType(int index) {
      fractalPlotter = generalPlotters[index];
      fractalType = fractalPlotter.ThisType;
      initFractal();
    }
    public void index2JuliaType(int index) {
      fractalPlotter = JuliaPlotters[index];
      fractalType = fractalPlotter.ThisType;
      initFractal();
    }
    public void index2LineType(int index) {
      fractalPlotter = linePlotters[index];
      fractalType = fractalPlotter.ThisType;
      initFractal();
    }
    public void collectSmoozedColors(Image map, bool rescanSamples) {
      if (Constants.SelectedBoxes > 0) {
        Constants.AddSmoozedColorList(true);

        if (fractalPlotter != null)
          interpolateColorPalette();
        else
          Constants.interpolate();
        if (map != null)
          Constants.setColorRange(map);
        if (rescanSamples)
          RescanExampleParallelAsync(true);
      }
    }
    public void setStartPointLinePlot(string A, string B) {
      if (fractalPlotter is LinePlot && !String.IsNullOrEmpty(A) && !String.IsNullOrEmpty(B)) {
        LinePlot lp = (LinePlot)fractalPlotter;
        float x = float.Parse(A);
        float y = float.Parse(B);
        lp.StartPoint = new PointF(x, y);
        if (PlotForm != null)
          PlotForm.FormImage = PointsImage.Bitmap; 
      }
    }
    #endregion

    #region ColorsForm
    public void MouseDownColorDef(int x, int y, Size size) {
      colorMouseX1 = x;
      colorMouseY1 = y;
      colorMouseRange = size.Width;
      trackedSmoozedColor = Constants.tracker4Cursor(x, size);
    }
    public void MouseMoveColorDef(int x, int y, Size size) {
      colorMouseX2 = x;
      colorMouseY2 = y;
      if (colorMouseX2 < colorSpread.Height / 20)
        colorMouseX2 = colorSpread.Height / 20;
      if (trackedSmoozedColor != null) {
        trackedSmoozedColor.TrackerPositionPercentage = 100f * colorMouseX2 / size.Width;
        Constants.sortSmoozedColors();
        Constants.setColorRange(colorSpread);
        colorForm.setSpreadImage(colorSpread);
      }
    }
    public void MouseUpColorDef(int x, int y) {
      colorMouseX2 = x;
      colorMouseY2 = y;
      if (fractalPlotter != null && false) {
        fractalPlotter.setColorsFromNewSmoozedColors(smoozeType);
        using (Graphics g = Graphics.FromImage(MainImage)) {
          Rectangle destRect = DestRect;
          g.DrawImage(PointsImage.Bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
        }
        if (PlotForm != null) {
          PlotForm.FormImage = MainImage;
        }
        RescanExampleParallelAsync(true);
        if (juliaPlotInset != null)
          juliaPlotInset.Map.CalculatedTypes.Clear();
      }
      trackedSmoozedColor = null;
    }
    #endregion

    #region control4AllViews
    public void presetPlotter(FractalType type) {
      if (fractalPlotter != null) {
        fractalType = type;
        initFractal();
      }
    }
    #endregion

    public void RescanExampleParallelAsync(bool colorChanged) {
      tasks.Clear();
      foreach (BasePlotter p in examplePlottersGeneral) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        tasks.Add(Task.Run(() => p.doCalculation()));
      }
      foreach (BasePlotter p in examplePlottersJulia) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        tasks.Add(Task.Run(() => p.doCalculation()));
      }
      foreach (BasePlotter p in examplePlottersMira) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        tasks.Add(Task.Run(() => p.doCalculation()));
      }
      var results = Task.WhenAll(tasks);
      for (int i = 0; i < examplePlottersGeneral.Count; i++)
        PlotForm.addExampleImage(i, examplePlottersGeneral[i].map.Bitmap, examplePlottersGeneral[i].Title, ExampleGroups.General);
      for (int i = 0; i < examplePlottersJulia.Count; i++)
        PlotForm.addExampleImage(i, examplePlottersJulia[i].map.Bitmap, examplePlottersJulia[i].Title, ExampleGroups.Julia);
      for (int i = 0; i < examplePlottersMira.Count; i++)
        PlotForm.addExampleImage(i, examplePlottersMira[i].map.Bitmap, examplePlottersMira[i].Title, ExampleGroups.Line);

    }
    public void rescanExamples(bool colorChanged) {
      foreach (BasePlotter p in examplePlottersGeneral) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        p.doCalculation();
      }
      foreach (BasePlotter p in examplePlottersJulia) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        p.doCalculation();
      }
      foreach (BasePlotter p in examplePlottersMira) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        p.doCalculation();
      }
      for (int i = 0; i < examplePlottersGeneral.Count; i++)
        PlotForm.addExampleImage(i, examplePlottersGeneral[i].map.Bitmap, examplePlottersGeneral[i].Title, ExampleGroups.General);
      for (int i = 0; i < examplePlottersJulia.Count; i++)
        PlotForm.addExampleImage(i, examplePlottersJulia[i].map.Bitmap, examplePlottersJulia[i].Title, ExampleGroups.Julia);
      for (int i = 0; i < examplePlottersMira.Count; i++)
        PlotForm.addExampleImage(i, examplePlottersMira[i].map.Bitmap, examplePlottersMira[i].Title, ExampleGroups.Line);

      if (!colorChanged) {
        MiraLinePlotter miraLineplot = null;
        foreach (LinePlot p in linePlotters)
          if (p.SpecificLineType == SpecificLineType.Mira) {
            miraLineplot = (MiraLinePlotter)p.clone(new DirectBitmap(100, 100));
            break;
          }
        if (miraLineplot != null) {
          for (int i = 0; i < miraLineplot.Favorites.Length; i++) {
            miraLineplot.map = new DirectBitmap(100, 100, true);
            miraLineplot.setFavorite(i);
            ((ICombined)PlotForm).addExampleImage(i, miraLineplot.map.Bitmap,
              miraLineplot.StartPoint.X.ToString("00.0") + " - " + miraLineplot.StartPoint.Y.ToString("00.0") + Environment.NewLine +
              miraLineplot.Parameters[0].ToString("0.00") + " - " + miraLineplot.Parameters[6].ToString("0.00"), ExampleGroups.MiraLine);
          }
        }
      }

      ((ICombined)PlotForm).rescanExamples();
    }
    public void resetLinePlot() {
      if (fractalPlotter is LinePlot) {
        LinePlot plotter = (LinePlot)fractalPlotter;
        plotter.reset();
        if (PlotForm != null)
          PlotForm.FormImage = PointsImage.Bitmap;
      }
    }
    public void setMiratypePlot(string tag) {
      foreach (LinePlot p in linePlotters)
        if (p.SpecificLineType == SpecificLineType.Mira) {
          fractalPlotter = p;
          break;
        }
      if (fractalPlotter is LinePlot) {
        fractalType = fractalPlotter.ThisType;
        MiraLinePlotter plotter = (MiraLinePlotter)fractalPlotter;
        string[] favorites = plotter.Favorites;
        if (favorites.Length > 0) {
          Int32.TryParse(tag, out int miraType);
          if (miraType >= 0) {
            plotter.setFavorite(miraType);
            if (PlotForm != null)
              PlotForm.FormImage = PointsImage.Bitmap;
          }
        }
      }
    }
    #endregion

  }

}
