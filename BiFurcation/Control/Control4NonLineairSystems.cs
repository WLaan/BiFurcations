using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

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
    private readonly List<Task> tasks = new List<Task>();
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

    private Progress<ProgressReportModel> progressHandlerGif = null;
    private IProgress<ProgressReportModel> progressGif;
    private CancellationTokenSource ctsGif = new CancellationTokenSource();
    private CancellationToken tokenGif;
    private ProgressReportModel reportGif;

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
    private int colorMouseX2 = 0;

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
        colorSpread = new Bitmap(colorForm.GetSpreadImageSize.Width, colorForm.GetSpreadImageSize.Height);
        Constants.SetColorRange(colorSpread);
        colorForm.SetSpreadImage(colorSpread);
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
        fractalPlotter.Reset(); 
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
        fractalPlotter.Reset();
        if (PlotForm != null && PlotForm.FormImage != null) {
          PlotForm.FormImage.Dispose();
          PlotForm.FormImage = null;
        }
        SimulateTask();
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
        fractalPlotter.Reset();
        fractalPlotter.UsedColorIndices = new ColorIndex[BSize, BSize];
      }
    }

    private SmoozeType smoozeType = SmoozeType.Type2;
    public SmoozeType SmoozeType {
      set {
        smoozeType = value;
        if (fractalPlotter != null) {
          fractalPlotter.SmoozeType = value;
          Simulate(false);
        }
      }
      get {
        return smoozeType;
      }
    }

    public PointF JuliaXoffset {
      get {
        if (fractalPlotter is JuliaPlot plot) {
          return plot.definedOffset;
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
        if (fractalPlotter is LinePlot plot) {
          return (int)(1000 * plot.Parameters[0]);
        }
        else
          return 100;
      }
    }
    public int LineplotBValue {
      get {
        if (fractalPlotter is LinePlot plot) {
          return (int)(1000 * plot.Parameters[6]);
        }
        else
          return 100;
      }
    }
    public int MaxAval {
      get {
        if (fractalPlotter is LinePlot plot) {
          return (int)(1000 * plot.MaxAval);
        }
        else
          return 1000;
      }
    }
    public int MinAval {
      get {
        if (fractalPlotter is LinePlot plot) {
          return (int)(1000 * plot.MinAval);
        }
        else
          return -1000;
      }
    }
    public string LambdaOrMandelbrotA {
      set {
        if (fractalPlotter is LambdaPlot || fractalPlotter is MandelbrotPlot) {
          MandelbrotPlot p = (MandelbrotPlot)fractalPlotter;
          fractalPlotter.Reset();
          float.TryParse(value, out float a);
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
        if (fractalPlotter is LinePlot plot) 
          plot.SpecificLineType = value;
        if (PlotForm != null)
          PlotForm.FormImage = MainImage;
      }
      get {
        if (fractalPlotter is LinePlot plot)
           return plot.SpecificLineType;
        else
          return SpecificLineType.None;
      }
    }
    public void SetMiraAB(int A, int B) {
      if (fractalPlotter is LinePlot plot)
        plot.SetABval(A, B);
      if (PlotForm != null)
        PlotForm.FormImage = PointsImage.Bitmap; 
    }
    public void SetMiraAB(string A, string B) {
      if (fractalPlotter is LinePlot plot)
        plot.SetABval(A, B);
      if (PlotForm != null)
        PlotForm.FormImage = PointsImage.Bitmap; 
    }
    public bool SpreadMiraA {
      set {
        if (fractalPlotter is LinePlot plot) {
          plot.SpreadA = value;
          if (PlotForm != null)
            PlotForm.FormImage = PointsImage.Bitmap;
        }
      }
    }
    public int SetIterationsLinPlot {
      set {
        if (fractalPlotter is LinePlot plot) {
          plot.Iterations = value;
          if (PlotForm != null)
            PlotForm.FormImage = PointsImage.Bitmap; 
        }
      }
      get {
        if (fractalPlotter is LinePlot plot) {
         return plot.Iterations;
        }
        else
          return 0;
      }
    }
    public int MinMouseIterationVal {
      get {
        if (fractalPlotter is LinePlot plot) {
          return plot.MinMouseIterations;
        }
        else
          return 0;
      }
    }
    public int MaxMouseIterationVal {
      get {
        if (fractalPlotter is LinePlot plot) {
          return plot.MaxMouseIterations;
        }
        else
          return 1000;
      }
    }
    public int MaxABMouse {
      get {
        if (fractalPlotter is LinePlot plot) {
          return plot.MaxABMouse;
        }
        else
          return 0;
      }
    }
    public double LinplotStartX {
      get {
        if (fractalPlotter is LinePlot plot) {
          return plot.StartPoint.X;
        }
        else
          return 0;
      }
    }
    public double LinplotStartY {
      get {
        if (fractalPlotter is LinePlot plot) {
          return plot.StartPoint.Y;
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
        MiraLinePlotter miraExample = (MiraLinePlotter)miraLinePlotter.Clone(new DirectBitmap(100, 100));
        miraExample.ExampleNumber = i;
        miraLineplotExamples.Add(miraExample);
      }
      Xmin = (decimal)fractalPlotter.XMin;
      Xmax = (decimal)fractalPlotter.XMax;
      Ymin = (decimal)fractalPlotter.YMin;
      Ymax = (decimal)fractalPlotter.YMax;

      InterpolateColorPalette();

      foreach (BasePlotter p in generalPlotters) {
        BasePlotter pp = p.Clone(new DirectBitmap(100, 100));
        examplePlottersGeneral.Add(pp);
      }
      for (int jp = 0; jp < JuliaPlot.Initials.Length; jp++) {
        JuliaPlot jpp = new JuliaPlot(this, jp, new DirectBitmap(100, 100));
        examplePlottersJulia.Add(jpp);
      }
      for (int mp = 0; mp < linePlotters.Count;mp++) {// Enum.GetNames(typeof(SpecificLineType)).Length - 1; mp++) {
        BasePlotter mpp = linePlotters[mp].Clone(new DirectBitmap(100, 100, true)); 
        examplePlottersMira.Add(mpp);
      }
    }

    #region private helpers
    private void InitFractal() {
      if (fractalPlotter != null) {

        Xmin = (decimal)fractalPlotter.XMini;
        Xmax = (decimal)fractalPlotter.XMaxi;
        Ymin = (decimal)fractalPlotter.YMini;
        Ymax = (decimal)fractalPlotter.YMaxi;

        fractalPlotter.MAX_MAG_SQUARED = max_MAG_SQUARED.ToString();
        fractalPlotter.SmoozeType = SmoozeType;
        fractalPlotter.Reset();
        PlotForm.Params2Form();
        if (fractalPlotter.ThisType == FractalType.LinePlot) {
          fractalPlotter.DoCalculation();
          if (PlotForm != null)
            PlotForm.FormImage = PointsImage.Bitmap;
        }
        else
          SimulateTask();
      }  
    }
    private void CalcCombinedFractal() {

      fractalPlotter.InitImages(MainImage, PointsImage.Bitmap, BSize);
      fractalPlotter.DoCalculation();

      if (fractalType == FractalType.Julia && mandelbrotInsetBitmap != null && smoozeType == SmoozeType.Single) {
        using Graphics g = Graphics.FromImage(PointsImage.Bitmap);
        //  AdjustAspect();
        mandelbrotPlotInset.SmoozeType = SmoozeType.Single;
        mandelbrotPlotInset.XMini = -2;
        mandelbrotPlotInset.XMaxi = 0.7;
        mandelbrotPlotInset.YMini = -1.5;
        mandelbrotPlotInset.YMaxi = 1.5;
        mandelbrotPlotInset.DoCalculation();
        JuliaPlot p = (JuliaPlot)fractalPlotter;
        mandelbrotPlotInset.AddRedDot(p.Initial_C);
        Rectangle source = new Rectangle(0, 0,
                                         mandelbrotInsetBitmap.Width, mandelbrotInsetBitmap.Height);
        Rectangle dest = new Rectangle(0, PointsImage.Height - mandelbrotPlotInset.Map.Height, mandelbrotPlotInset.Map.Width, mandelbrotPlotInset.Map.Height);
        g.DrawImage(mandelbrotInsetBitmap.Bitmap, dest, source, GraphicsUnit.Pixel);
      }
      int cSize = BSize / 50;
      Rectangle destRect = DestRect;
      try {
        using Graphics g = Graphics.FromImage(MainImage);
        string text = fractalPlotter.Title + ", Escape radius:" + max_MAG_SQUARED + ", Iterations:" + maxIterations;
        g.Clear(Color.LightGray);
        using Pen pen0 = new Pen(Color.Black, 4);
        g.DrawRectangle(pen0, new Rectangle(destRect.X - 1, destRect.Y - 1, destRect.Width + 2, destRect.Height + 2));
        using Pen pen = new Pen(Color.White, 4);
        g.DrawLine(pen, destRect.X - 4, destRect.Y - 1, destRect.Width + destRect.X, destRect.Y - 1);
        g.DrawLine(pen, destRect.X - 1, destRect.Y - 1, destRect.X - 1, destRect.Height + destRect.Y);
        g.DrawString(text, new Font("Calibri", cSize), Brushes.Blue, pictBoxSize.Height / 20, BSize / 70);
        g.DrawString(yMax.ToString("0.00"), new Font("Calibri", 2 * cSize / 3), Brushes.Blue, 5, destRect.Y);
        g.DrawString(yMin.ToString("0.00"), new Font("Calibri", 2 * cSize / 3), Brushes.Blue, 5, destRect.Y + destRect.Height - cSize);
        g.DrawString(xMin.ToString("0.00"), new Font("Calibri", 2 * cSize / 3), Brushes.Blue, destRect.X - cSize, destRect.Y + destRect.Height + cSize / 4);
        g.DrawString(xMax.ToString("0.00"), new Font("Calibri", 2 * cSize / 3), Brushes.Blue, destRect.X + destRect.Width - cSize, destRect.Y + destRect.Height + cSize / 4);

        g.DrawImage(PointsImage.Bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
      }
      catch { }

      fractalPlotter.Copy2GIF(MainImage, BSize, sourceRect);

      if (PlotForm != null)
        PlotForm.FormImage = MainImage;
    }
    private void InterpolateColorPalette() {
      Constants.Interpolate();
      if (fractalPlotter != null)
        fractalPlotter.Map.CalculatedTypes.Clear();
    }

    private void InitTaskHandlesGif() {
      progressHandlerGif = new Progress<ProgressReportModel>();
      progressHandlerGif.ProgressChanged += ((ICombined)plotForm).ReportProgressGif;
      reportGif = new ProgressReportModel();
      ctsGif = new CancellationTokenSource();
      tokenGif = ctsGif.Token;
      progressGif = progressHandlerGif;
    }
    private void FractalCompletedGIF() {
      fractalPlotter.CreateGif = false;
      gifCreater.Create(1, gifFilename);
      xMin = currXmin;
      xMax = currXmax;
      yMin = currYmin;
      yMax = currYmax;
      PlotForm.SetEnabled(true);
      PlotForm.EndGenerate();
      Reset();//includes  SimulateTask();
    }
    private void DoGif() {
      for (int i = 0; i < nGif && Xmin < centerX && yMin < centerY ; i++) {
        //calc image
        fractalPlotter.Reset();
        InitTaskHandles();
        CalcCombinedFractal();
        xMin -= dx;
        Xmax += dx;
        Ymin -= dy;
        yMax += dy;
        if (i > 0)
          gifCreater.images.Add(fractalPlotter.Copy4GIF);
        // Let the user know we're not dead.
        reportGif.PercentageComplete = i;
        if (progressGif != null)
          progressGif.Report(reportGif);
        if (tokenGif.IsCancellationRequested) break;

        plotForm.Params2Form();
      }
    }
    #endregion

    #region public

    #region virtual
    public override void StopThread() {
      base.StopThread();
      ctsGif.Cancel();
    }
    public override void SimulateTask() {
      DoTaskWork = CalcCombinedFractal;
      base.SimulateTask();
    }
    #endregion

    #region NonlinearSystemsForm
    public void Simulate(bool reset) {
      if (reset) {
        fractalPlotter.Reset();
      }
      SimulateTask();
    }
    public void PresetParameter(int index, string value) {
      double.TryParse(value, out fractalPlotter.Parameters[index]);
      fractalPlotter.Reset();
    }
    public void SetUserdefined(string x, string y) {
      if (fractalPlotter is JuliaPlot plot) {
        fractalPlotter.Reset();
        float.TryParse(x, out float xf);
        float.TryParse(y, out float yf);
        plot.SetUserDefined(xf, yf);
      }
    }
    public void StartImageEditor(Image image) {
      control4AllViews.StartImageEditor(image);
    }
    public async void CreateGif(PointD current, string numGif, string fName) {
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

      plotForm.Params2Form();

      PlotForm.SetProgressBar(pictBoxSize.Width);
      PlotForm.SetEnabled(false);
      InitTaskHandlesGif();
      await Task.Run(() => { DoGif(); });
      FractalCompletedGIF();
    }
    public void JuliaMouseMove(double x, double y, DirectBitmap map) {
      if (fractalType == FractalType.Mandelbrot) {
        if (juliaPlotInset == null)
          juliaPlotInset = new JuliaPlot(this, JuliaPlot.Initials.Length - 1, map);
        juliaPlotInset.SetUserDefined((float)x, (float)y);
        juliaPlotInset.Reset();
        juliaPlotInset.SmoozeType = this.smoozeType;
        juliaPlotInset.DoCalculation();
      }
    }
    public void GetImage(DirectBitmap m, SmoozeType type) {
      if (fractalPlotter == null) return;
      demoType = fractalPlotter.Clone(m);
      demoType.SmoozeType = type;
      demoType.Reset();
      demoType.MaxIterations = 32;
      demoType.DoCalculation();
    }
    public void Index2GeneralType(int index) {
      fractalPlotter = generalPlotters[index];
      fractalType = fractalPlotter.ThisType;
      InitFractal();
    }
    public void Index2JuliaType(int index) {
      fractalPlotter = JuliaPlotters[index];
      fractalType = fractalPlotter.ThisType;
      InitFractal();
    }
    public void Index2LineType(int index) {
      fractalPlotter = linePlotters[index];
      fractalType = fractalPlotter.ThisType;
      InitFractal();
    }
    public void CollectSmoozedColors(Image map, bool rescanSamples) {
      if (Constants.SelectedBoxes > 0) {
        Constants.AddSmoozedColorList(true);

        if (fractalPlotter != null)
          InterpolateColorPalette();
        else
          Constants.Interpolate();
        if (map != null)
          Constants.SetColorRange(map);
        if (rescanSamples)
          RescanExampleParallelAsync(true);
      }
    }
    public void SetStartPointLinePlot(string A, string B) {
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
      trackedSmoozedColor = Constants.Tracker4Cursor(x, size);
    }
    public void MouseMoveColorDef(int x, int y, Size size) {
      colorMouseX2 = x;
      if (colorMouseX2 < colorSpread.Height / 20)
        colorMouseX2 = colorSpread.Height / 20;
      if (trackedSmoozedColor != null) {
        trackedSmoozedColor.TrackerPositionPercentage = 100f * colorMouseX2 / size.Width;
        Constants.SortSmoozedColors();
        Constants.SetColorRange(colorSpread);
        colorForm.SetSpreadImage(colorSpread);
      }
    }
    public void MouseUpColorDef(int x, int y) {
      colorMouseX2 = x;
      if (fractalPlotter != null && false) {
        fractalPlotter.SetColorsFromNewSmoozedColors(smoozeType);
        Rectangle destRect = DestRect;
        using (Graphics g = Graphics.FromImage(MainImage)) {
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
    public void PresetPlotter(FractalType type) {
      if (fractalPlotter != null) {
        fractalType = type;
        InitFractal();
      }
    }
    #endregion

    public void RescanExampleParallelAsync(bool colorChanged) {
      tasks.Clear();
      foreach (BasePlotter p in examplePlottersGeneral) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        tasks.Add(Task.Run(() => p.DoCalculation()));
      }
      foreach (BasePlotter p in examplePlottersJulia) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        tasks.Add(Task.Run(() => p.DoCalculation()));
      }
      foreach (BasePlotter p in examplePlottersMira) {
        p.SmoozeType = smoozeType;
        if (colorChanged)
          p.Map.CalculatedTypes.Clear();
        tasks.Add(Task.Run(() => p.DoCalculation()));
      }
      foreach (MiraLinePlotter m in miraLineplotExamples) {
        tasks.Add(Task.Run(() => m.setFavorite(m.ExampleNumber)));
      }
      var results = Task.WhenAll(tasks);
      for (int i = 0; i < examplePlottersGeneral.Count; i++)
        PlotForm.AddExampleImage(i, examplePlottersGeneral[i].map.Bitmap, examplePlottersGeneral[i].Title, ExampleGroups.General);
      for (int i = 0; i < examplePlottersJulia.Count; i++)
        PlotForm.AddExampleImage(i, examplePlottersJulia[i].map.Bitmap, examplePlottersJulia[i].Title, ExampleGroups.Julia);
      for (int i = 0; i < examplePlottersMira.Count; i++)
        PlotForm.AddExampleImage(i, examplePlottersMira[i].map.Bitmap, examplePlottersMira[i].Title, ExampleGroups.Line);
      foreach (MiraLinePlotter miraLineplot in  miraLineplotExamples) {
        ((ICombined)PlotForm).AddExampleImage(miraLineplot.ExampleNumber, miraLineplot.map.Bitmap,
          miraLineplot.StartPoint.X.ToString("00.0") + " - " + miraLineplot.StartPoint.Y.ToString("00.0") + Environment.NewLine +
          miraLineplot.Parameters[0].ToString("0.00") + " - " + miraLineplot.Parameters[6].ToString("0.00"), ExampleGroups.MiraLine);
      }
    }
    public void ResetLinePlot() {
      if (fractalPlotter is LinePlot plotter) {
        plotter.Reset();
        if (PlotForm != null)
          PlotForm.FormImage = PointsImage.Bitmap;
      }
    }
    public void SetMiratypePlot(string tag) {
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
