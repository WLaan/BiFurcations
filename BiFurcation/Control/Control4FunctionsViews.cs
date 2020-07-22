using System;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

namespace BiFurcation {

  public enum FunctionType {
    FixedPolynomial,
    Polynomial,
    Henon,
    Base
  }

  public class Control4FunctionsView: ImageControl {

    public override int BSize {
      get {
        return bSize;
      }
      set {
        base.BSize = value;
        if (henonFunction != null) {
          henonFunction.BSize = bSize;
          functionDrawer.FontSize = bSize / 50;
        }
      }
    }

    public new IFunctionsView PlotForm {
      get {
        return (IFunctionsView)plotForm;
      }
      set {
        plotForm = value;
      }
    }

    #region private
    private PolynomialFunction polynominalFunction = new PolynomialFunction();
    private FixedPolynomialFunction fixedPolynominalFunction = new FixedPolynomialFunction();
    private SinFunction sinFunction = new SinFunction();
    private HenonFunction henonFunction;
    private MandelbrotFunction mandelbrotFunction;
    private GeneralMappingFunction generalMappingFunction = new GeneralMappingFunction();

    private bool doFillXvalues = true;
    private bool[] FIncludes = new bool[Constants.MaxF];
    private bool drawingHenonMousePoints = false;

    private FunctionDrawer functionDrawer;
    #endregion

    #region override
    public override decimal Xmin {
      get {
        return currentFunction.XMin;
      }
      set {
        currentFunction.XMin = value;
      }
    }
    public override decimal Xmax {
      get {
        return currentFunction.XMax;
      }
      set {
        currentFunction.XMax = value;
      }
    }
    public override decimal Ymin {
      get {
        return currentFunction.YMin;
      }
      set {
        currentFunction.YMin = value;
      }
    }
    public override decimal Ymax {
      get {
        return currentFunction.YMax;
      }
      set {
        currentFunction.YMax = value;
      }
    }
    #endregion

    #region properties
    public void setHenonDotsize(string num) {
      if (currentFunction is HenonFunction) {
        HenonFunction f = (HenonFunction)currentFunction;
        Int32.TryParse(num, out f.HenonDotsize);
        plotFunction();
      }
    }
    public bool OmitFirst {
      set {
        currentFunction.OmitFirst = value;
        setPoints();
      }
    }
    public int ParNum {
      set {
        currentFunction.ParNum = value;
        if (control4DiagramView != null)
          control4DiagramView.ParNum = value;
      }
      get {
        return currentFunction.ParNum;
      }
    }
    public decimal A {
      get {
        return currentFunction.Parameters[2]; 
      }
      set {
        currentFunction.Parameters[2] = value;
        if (ParNum == 2)
          currentFunction.DiagramStart = value;
      }
    }
    public decimal B {
      get {
        return currentFunction.Parameters[1];
      }
      set {
        currentFunction.Parameters[1] = value;
        if (ParNum == 1)
          currentFunction.DiagramStart = value;
      }
    }
    public decimal C {
      get {
        return currentFunction.Parameters[0];
      }
      set {
        currentFunction.Parameters[0] = value;
        if (ParNum == 0)
          currentFunction.DiagramStart = value;
      }
    }
    public decimal Seed {
      get {
        return currentFunction.Seed;
      }
      set {
        currentFunction.Seed = value;
      }
    }
    private bool seedWithMouse = false;
    public bool SeedWithMouse {
      set {
        seedWithMouse = value;
      }
      get {
        return seedWithMouse;
      }
    }
    public override int MaxIterations {
      get {
        if (currentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)currentFunction;
          return f.MaxIterations;
        }
        else
          return MaxFunctionIterations;
      }
      set {
        if (currentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)currentFunction;
          f.MaxIterations = value;
        }
        else
          MaxFunctionIterations = value;
      }
    }
    public int MaxFunctionIterations {
      set {
      //  if (currentFunction is HenonFunction || true) {
          //  HenonFunction f = (HenonFunction)currentFunction;
          currentFunction.MaxIterations = value;
       // }
      }
      get {
        return currentFunction.MaxIterations;// maxFunctionIterations;
      }
    }
    private int maxGIFIterations = 100;
    public int MaxGIFIterations {
      set {
        maxGIFIterations = value;
      }
    }
    private FunctionType currentFunctionType = FunctionType.FixedPolynomial;
    public FunctionType CurrFunctionType {
      set {
        boarderStack.Clear();
        currentFunctionType = value;
        doFillXvalues = true;
        switch (currentFunctionType) {
          case FunctionType.Polynomial:
            currentFunction = polynominalFunction;
            break;
          case FunctionType.FixedPolynomial:
            currentFunction = fixedPolynominalFunction;
            break;
          //case FunctionType.SinFunction:
          //  currentFunction = sinFunction;
          //  break;
          case FunctionType.Henon:
            currentFunction = henonFunction;
            doFillXvalues = false;
            break;
          default:
            currentFunction = new BaseFunction();
            break;
        }
        if (!doFillXvalues)
          PlotForm.fillXValues(new List<decimal>());
        currentFunction.XMax = currentFunction.XMax;
        currentFunction.YMax = currentFunction.YMax;
        functionDrawer = new FunctionDrawer(PlotForm, this, createGIF);
        setPoints();
        Constants.currentFunctionType = value;
       // Constants.settings2XML();
      }
      get {
        return currentFunctionType;
      }
    }

    private BaseFunction currentFunction;
    public BaseFunction CurrentFunction{
      get {
        return currentFunction;
      }
    }

    public bool DrawFurcations {
      set {
        functionDrawer.DrawFurcations = value;
      }
      get {
        if (functionDrawer != null)
          return functionDrawer.DrawFurcations;
        else
          return false;
      }
    }

    private bool createGIF = false;
    public bool CreateGIF {
      set {
        createGIF = value;
        if (functionDrawer != null)
          functionDrawer.CreateGif = value;
      }
      get {
        return createGIF;
      }
    }

    private string functionGifFileName = "GIF_filename.GIF";
    public String FunctionGifFileName {
      get {
        return functionGifFileName;
      }

      set {
        functionGifFileName = value;
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
    public decimal DiagramStopParameter {
      get {
        return currentFunction.DiagramStop;
      }
      set {
        currentFunction.DiagramStop = value;
      }
    }
    #endregion
    public int MultStepPoints {
      set {
        if (currentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)currentFunction;
          f.MultStepPoints = value;
        }
      }
      get {
        if (currentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)currentFunction;
          return f.MultStepPoints;
        }
        else return 0;
      }
    }
    public int InitionalDots {
      set {
        if (currentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)currentFunction;
          f.InitionalDots = value;
        }
      }
    }
    public int NoPoints {
      get {
        if (currentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)currentFunction;
          return f.Traject.Count;
        }
        else return 0;
      }
    }

    public Control4FunctionsView(IView f):base (f) {
    }
    public Control4FunctionsView(IView f, Control4AllViews cav) : base(f, cav) {
      Constants constants = new Constants();
      Constants.settingsFromXML();
      PlotForm = (IFunctionsView) f;
     // BSize = 2000; done in base!!!!!!
      currentFunction = new BaseFunction();
      functionDrawer = new FunctionDrawer(PlotForm, this, createGIF);
      henonFunction = new HenonFunction(PlotForm);
      mandelbrotFunction = new MandelbrotFunction(PlotForm);

      CurrFunctionType = Constants.currentFunctionType;

      Constants.Initalising = false;
      PlotForm.Control4FunctionsView = this;
      PlotForm.params2Form();
    }

    #region private
    private void calcSim(object sender, DoWorkEventArgs e) {
      doFillXvalues = false;
      int m = MaxFunctionIterations;
      currentFunction.MaxIterations = 1;
      plotFunction();
      gifCreater.images.Clear();
      for (int i = 1; i < m && !currentFunction.ReachedConvergence; i++) {
        MaxFunctionIterations = i;
        currentFunction.MaxIterations = i;
        plotFunction();
        if (CreateGIF)
          gifCreater.images.Add(functionDrawer.Copy4GIF);
        Thread.Sleep(5);
      }
      gifCreater.create(1, functionGifFileName);
      bool b = currentFunction.ReachedConvergence;
      MaxFunctionIterations = m;
      doFillXvalues = true;
    }
    private void calcSimPar(object sender, DoWorkEventArgs e) {
      doFillXvalues = false;
      decimal t = currentFunction.Parameter;
      decimal start = t;
      if (t > currentFunction.DiagramStop) {
        start = currentFunction.DiagramStop;
      }
      int m = MaxFunctionIterations;
      decimal delta = Math.Abs((currentFunction.DiagramStop - t)) * 300 / 100;
      gifCreater.images.Clear();
      PlotForm.setProgressBar((int)(Math.Abs((currentFunction.DiagramStop - t)) * 300 / delta)+ 10);
      for (decimal i = 0; i <= Math.Abs((currentFunction.DiagramStop - t)) * 300 && !worker.CancellationPending; i += delta) {
        currentFunction.Parameter = start + i / 300;
        worker.ReportProgress((int)i);
        plotFunction();
        if (CreateGIF)
          gifCreater.images.Add(functionDrawer.Copy4GIF);
        Thread.Sleep(5);
      }
      gifCreater.create(1, functionGifFileName);
      currentFunction.Parameter = t;
      plotFunction();
      MaxFunctionIterations = m;
      doFillXvalues = true;
    }
    private void diagramProgress(object sender, ProgressChangedEventArgs e) {
      plotForm.worker_ProgressChanged(e.ProgressPercentage);
    }
    private void worker_RunWorkerCompletedSim(object sender, RunWorkerCompletedEventArgs e) {
      worker = null;
      PlotForm.setEnabled(true);
      plotForm.endGenerate();
      CreateGIF = false;
    }
    #endregion

    public void setHenonSkipIterations(string num) {
      if (currentFunction is HenonFunction) {
        HenonFunction f = (HenonFunction)currentFunction;
        Int32.TryParse(num, out f.SkipIterations);
      }
    }
    public override void simulate() {
      setPoints();
      PlotForm.params2Form();
    }

    public void setFInclude(int f, bool v) {
      FIncludes[f] = v;
      currentFunction.FunctionGenerations[f] = v;
      if (v) {
        currentFunction.calcFunctionPoints();
        plotFunction();
      }
    }
    public void setXYBoarders(string xmin, string xmax, string ymin, string ymax) {
      currentFunction.XMin = control4AllViews.text2Float(xmin);
      currentFunction.XMax = control4AllViews.text2Float(xmax);
      currentFunction.YMin = control4AllViews.text2Float(ymin);
      currentFunction.YMax = control4AllViews.text2Float(ymax);
    }
    public void plotFunction() {
      currentFunction.calcFunctionPoints();
      if (functionDrawer != null) {
        if (currentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)currentFunction;
          try {
            if (f.MaxIterations > 1000000 && functionDrawer.MainImage.Height == Constants.UsedBSize) {
              BSize = 2* Constants.UsedBSize;
            }
            else {
              if (f.MaxIterations <= 1000000 && functionDrawer.MainImage.Height == 2* Constants.UsedBSize) {
                BSize = Constants.UsedBSize;
              }
            }
          }
          catch { }
        }
        else {
          try {
            if (functionDrawer.MainImage.Height > Constants.UsedBSize) {
              BSize = Constants.UsedBSize;
            }
          }
          catch { }
        }
        functionDrawer.drawPicture();
      }
    }
    public override void mouseMove(int x, int y, int w, int h) {
      Bitmap map = MainImage;
      if (map != null && w != 0 && h != 0) {
        try {
          x = (int)(x * pictBoxSize.Width / w);
          y = (int)(y * pictBoxSize.Height / h);
          Bitmap bm = new Bitmap(map.Width, map.Height);
          //try {
          //  //NIET doen!!!!
          //  if (PlotForm.FormImage != MainImage && PlotForm.FormImage != null)
          //    PlotForm.FormImage.Dispose();
          //}
          //catch { }

          if (bm != null) {
            Rectangle destRect = DestRect;
            plotFunction();
            using (Graphics gr = Graphics.FromImage(bm)) {
              gr.DrawImage(functionDrawer.PointsImage.Bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
              //     PointsImage.Bitmap.Save("testt.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
              using (Pen p = new Pen(Color.Red, 1)) {
                Rectangle rect = new Rectangle((int)(Math.Min(screenX, x)), (int)(Math.Min(screenY, y)),
                                               (int)(Math.Abs(screenX - x)), (int)(Math.Abs(screenY - y)));
                gr.DrawRectangle(p, rect);
                PlotForm.FormImage = bm;
              }
            }
          }
        }
        catch { }
      }
    }
    public void setPoints() {
      if (Constants.Initalising) return;
      PlotForm.setEnabled(false);
      plotFunction();

      if (doFillXvalues) {
        List<decimal> furcationPoints = new List<decimal>();
        foreach (DiagramSet p in currentFunction.furcationPoints)
          furcationPoints.Add(p.X);
        List<PointD> setpoints = currentFunction.furcationPoints[currentFunction.furcationPoints.Count - 1].setPoints;
        if (setpoints.Count > 1)
          for (int i = setpoints.Count - 1; i >= 0; i--) {
            PointD p = setpoints[i];
            furcationPoints.Add(p.X);
          }
        PlotForm.fillXValues(furcationPoints);
      }
      PlotForm.setEnabled(true);
    }
    public string getNewFunctionString() {
      return currentFunction.FunctionStr;
    }
    public void simulate(bool cGIF) {
      if (worker == null) {
        CreateGIF = cGIF;
        PlotForm.setEnabled(false);
        worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = true;
        worker.WorkerReportsProgress = true;
        worker.DoWork += new DoWorkEventHandler(calcSim);
        worker.ProgressChanged += new ProgressChangedEventHandler(diagramProgress);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompletedSim);
        worker.RunWorkerAsync();
      }
    }
    public void simulatePar(bool cGIF) {
      if (worker == null) {
        CreateGIF = cGIF;
        PlotForm.setEnabled(false);
        worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = true;
        worker.WorkerReportsProgress = true;
        worker.DoWork += new DoWorkEventHandler(calcSimPar);
        worker.ProgressChanged += new ProgressChangedEventHandler(diagramProgress);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompletedSim);
        worker.RunWorkerAsync();
      }
    }
    public override void mouseUp(int x, int y, int w, int h) {
      if (!drawingHenonMousePoints)
        base.mouseUp(x, y, w, h);
    }
    public void initDrawTrajectory(int x, int y, int w, int h) {
      if (currentFunction is HenonFunction) {
        drawingHenonMousePoints = true;
        PointD p = showMouseCoords(x, y, w, h);
        functionDrawer.initTrajectory(p);
      }
    }
    public void nextTrajectory() {
      if (currentFunction is HenonFunction) {
        functionDrawer.drawNextTrajectory();
      }
    }
    public void stopTrajectory() {
      drawingHenonMousePoints = false;
      plotFunction();
    }
    public void setDiagramParameters(bool Ap, bool Bp, bool Cp) {
      if (Ap) 
        ParNum = 2;
      else
        if (Bp) 
        ParNum = 1;
      else 
        ParNum = 0;
    }
    public void setDiagram(IDiagramView diagram) {//, bool Ap, bool Bp, bool Cp) {
      if (control4DiagramView != null) {
        control4DiagramView.ParNum = 0;// ParNum;
        control4DiagramView.CurrentFunction = currentFunction.clone();
        if (control4DiagramView.CurrentFunction is HenonFunction)
          control4DiagramView.DiagramStopParameter = 0;
        else
          control4DiagramView.DiagramStopParameter = currentFunction.DiagramStop;
        control4DiagramView.DiagramStartParameter = currentFunction.DiagramStart;
        control4DiagramView.setDiagram(diagram);
      }
    }

  }

}
