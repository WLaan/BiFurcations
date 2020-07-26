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
        return CurrentFunction.XMin;
      }
      set {
        CurrentFunction.XMin = value;
      }
    }
    public override decimal Xmax {
      get {
        return CurrentFunction.XMax;
      }
      set {
        CurrentFunction.XMax = value;
      }
    }
    public override decimal Ymin {
      get {
        return CurrentFunction.YMin;
      }
      set {
        CurrentFunction.YMin = value;
      }
    }
    public override decimal Ymax {
      get {
        return CurrentFunction.YMax;
      }
      set {
        CurrentFunction.YMax = value;
      }
    }
    #endregion

    #region properties
    public void SetHenonDotsize(string num) {
      if (CurrentFunction is HenonFunction curr) {
        Int32.TryParse(num, out curr.HenonDotsize);
        PlotFunction();
      }
    }
    public bool OmitFirst {
      set {
        CurrentFunction.OmitFirst = value;
        SetPoints();
      }
    }
    public int ParNum {
      set {
        CurrentFunction.ParNum = value;
        if (Control4DiagramView != null)
          Control4DiagramView.ParNum = value;
      }
      get {
        return CurrentFunction.ParNum;
      }
    }
    public decimal A {
      get {
        return CurrentFunction.Parameters[2]; 
      }
      set {
        CurrentFunction.Parameters[2] = value;
        if (ParNum == 2)
          CurrentFunction.DiagramStart = value;
      }
    }
    public decimal B {
      get {
        return CurrentFunction.Parameters[1];
      }
      set {
        CurrentFunction.Parameters[1] = value;
        if (ParNum == 1)
          CurrentFunction.DiagramStart = value;
      }
    }
    public decimal C {
      get {
        return CurrentFunction.Parameters[0];
      }
      set {
        CurrentFunction.Parameters[0] = value;
        if (ParNum == 0)
          CurrentFunction.DiagramStart = value;
      }
    }
    public decimal Seed {
      get {
        return CurrentFunction.Seed;
      }
      set {
        CurrentFunction.Seed = value;
      }
    }

    public bool SeedWithMouse { set; get; } = false;
    public override int MaxIterations {
      get {
        if (CurrentFunction is HenonFunction curr) {
          return curr.MaxIterations;
        }
        else
          return MaxFunctionIterations;
      }
      set {
        if (CurrentFunction is HenonFunction curr) {
          curr.MaxIterations = value;
        }
        else
          MaxFunctionIterations = value;
      }
    }
    public int MaxFunctionIterations {
      set {
        CurrentFunction.MaxIterations = value;
      }
      get {
        return CurrentFunction.MaxIterations;
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
            CurrentFunction = polynominalFunction;
            break;
          case FunctionType.FixedPolynomial:
            CurrentFunction = fixedPolynominalFunction;
            break;
          //case FunctionType.SinFunction:
          //  currentFunction = sinFunction;
          //  break;
          case FunctionType.Henon:
            CurrentFunction = henonFunction;
            doFillXvalues = false;
            break;
          default:
            CurrentFunction = new BaseFunction();
            break;
        }
        if (!doFillXvalues)
          PlotForm.FillXValues(new List<decimal>());
        CurrentFunction.XMax = CurrentFunction.XMax;
        CurrentFunction.YMax = CurrentFunction.YMax;
        functionDrawer = new FunctionDrawer(PlotForm, this, createGIF);
        SetPoints();
        Constants.currentFunctionType = value;
       // Constants.settings2XML();
      }
      get {
        return currentFunctionType;
      }
    }

    public BaseFunction CurrentFunction { get; private set; }

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

    public String FunctionGifFileName { get; set; } = "GIF_filename.GIF";

    public Control4DiagramView Control4DiagramView { get; set; }
    public decimal DiagramStopParameter {
      get {
        return CurrentFunction.DiagramStop;
      }
      set {
        CurrentFunction.DiagramStop = value;
      }
    }
    #endregion
    public int MultStepPoints {
      set {
        if (CurrentFunction is HenonFunction curr) {
          curr.MultStepPoints = value;
        }
      }
      get {
        if (CurrentFunction is HenonFunction curr) {
          return curr.MultStepPoints;
        }
        else return 0;
      }
    }
    public int InitionalDots {
      set {
        if (CurrentFunction is HenonFunction curr) {
          curr.InitionalDots = value;
        }
      }
    }
    public int NoPoints {
      get {
        if (CurrentFunction is HenonFunction curr) {
          return curr.Traject.Count;
        }
        else return 0;
      }
    }
    public string NewFunctionString {
      get {
        return CurrentFunction.FunctionStr;
      }
    }

    public Control4FunctionsView(IView f):base (f) {
    }
    public Control4FunctionsView(IView f, Control4AllViews cav) : base(f, cav) {
      Constants constants = new Constants();
      Constants.SettingsFromXML();
      PlotForm = (IFunctionsView) f;
     // BSize = 2000; done in base!!!!!!
      CurrentFunction = new BaseFunction();
      functionDrawer = new FunctionDrawer(PlotForm, this, createGIF);
      henonFunction = new HenonFunction(PlotForm);
      mandelbrotFunction = new MandelbrotFunction(PlotForm);

      CurrFunctionType = Constants.currentFunctionType;

      Constants.Initalising = false;
      PlotForm.Control4FunctionsView = this;
      PlotForm.Params2Form();
    }

    #region private
    private void CalcSim() {
      doFillXvalues = false;
      int m = MaxFunctionIterations;
      CurrentFunction.MaxIterations = 1;
      PlotFunction();
      gifCreater.images.Clear();
      int deltaI = m / 10;
      if (m == 0) m = 1;
      for (int i = 1; i < m && !CurrentFunction.ReachedConvergence; i+=deltaI) {//
        MaxFunctionIterations = i;
        CurrentFunction.MaxIterations = i;
        PlotFunction();
        if (CreateGIF)
          gifCreater.images.Add(functionDrawer.Copy4GIF);
        Thread.Sleep(1);
      }
      gifCreater.Create(1, FunctionGifFileName);
      MaxFunctionIterations = m;
      doFillXvalues = true;
      CreateGIF = false;
    }
    private void CalcSimPar() {
      doFillXvalues = false;
      decimal t = CurrentFunction.Parameter;
      decimal start = t;
      if (t > CurrentFunction.DiagramStop) {
        start = CurrentFunction.DiagramStop;
      }
      int m = MaxFunctionIterations;
     
      gifCreater.images.Clear();

      decimal range2Fill = Math.Abs(CurrentFunction.DiagramStop - t);
      int numSteps = 50;
      decimal delta = range2Fill / numSteps;
      int max = (int)(Math.Abs(CurrentFunction.DiagramStop - t) * 100);
      PlotForm.SetProgressBar(numSteps + 1);
      try {
        for (decimal i = 0; i <numSteps; i++) {
          report.PercentageComplete = (int)i;
          if (progressHandler is IProgress<ProgressReportModel> progress)
            progress.Report(report);
          if (token.IsCancellationRequested) break;
          CurrentFunction.Parameter = start + i*delta;
          PlotFunction();
          if (CreateGIF)
            gifCreater.images.Add(functionDrawer.Copy4GIF);
          Thread.Sleep(5);
        }
      }
      catch { }
      gifCreater.Create(1, FunctionGifFileName);
      CurrentFunction.Parameter = t;
      PlotFunction();
      MaxFunctionIterations = m;
      doFillXvalues = true;
    }
    #endregion

    public void SetHenonSkipIterations(string num) {
      if (CurrentFunction is HenonFunction curr) {
        Int32.TryParse(num, out curr.SkipIterations);
      }
    }
    public override void SimulateTask() {
      SetPoints();
      PlotForm.Params2Form();
    }

    public void SetFInclude(int f, bool v) {
      FIncludes[f] = v;
      CurrentFunction.FunctionGenerations[f] = v;
      if (v) {
        CurrentFunction.CalcFunctionPoints();
        PlotFunction();
      }
    }
    public void SetXYBoarders(string xmin, string xmax, string ymin, string ymax) {
      CurrentFunction.XMin = control4AllViews.Text2Float(xmin);
      CurrentFunction.XMax = control4AllViews.Text2Float(xmax);
      CurrentFunction.YMin = control4AllViews.Text2Float(ymin);
      CurrentFunction.YMax = control4AllViews.Text2Float(ymax);
    }
    public void PlotFunction() {
      CurrentFunction.CalcFunctionPoints();
      if (functionDrawer != null) {
        if (CurrentFunction is HenonFunction curr) {
          try {
            if (curr.MaxIterations > 1000000 && functionDrawer.MainImage.Height == Constants.UsedBSize) {
              BSize = 2* Constants.UsedBSize;
            }
            else {
              if (curr.MaxIterations <= 1000000 && functionDrawer.MainImage.Height == 2* Constants.UsedBSize) {
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
        functionDrawer.DrawPicture();
      }
    }
    public override void MouseMove(int x, int y, int w, int h) {
      Bitmap map = MainImage;
      if (map != null && w != 0 && h != 0) {
        try {
          x = (int)(x * pictBoxSize.Width / w);
          y = (int)(y * pictBoxSize.Height / h);
          Bitmap bm = new Bitmap(map.Width, map.Height);
          if (bm != null) {
            Rectangle destRect = DestRect;
            PlotFunction();
            using Graphics gr = Graphics.FromImage(bm);
            gr.DrawImage(functionDrawer.PointsImage.Bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
            using Pen p = new Pen(Color.Red, 1);
            Rectangle rect = new Rectangle((int)(Math.Min(screenX, x)), (int)(Math.Min(screenY, y)),
                                           (int)(Math.Abs(screenX - x)), (int)(Math.Abs(screenY - y)));
            gr.DrawRectangle(p, rect);
            PlotForm.FormImage = bm;
          }
        }
        catch { }
      }
    }
    public void SetPoints() {
      if (Constants.Initalising) return;
      PlotForm.SetEnabled(false);
      PlotFunction();

      if (doFillXvalues) {
        List<decimal> furcationPoints = new List<decimal>();
        foreach (DiagramSet p in CurrentFunction.furcationPoints)
          furcationPoints.Add(p.X);
        List<PointD> setpoints = CurrentFunction.furcationPoints[CurrentFunction.furcationPoints.Count - 1].setPoints;
        if (setpoints.Count > 1)
          for (int i = setpoints.Count - 1; i >= 0; i--) {
            PointD p = setpoints[i];
            furcationPoints.Add(p.X);
          }
        PlotForm.FillXValues(furcationPoints);
      }
      PlotForm.SetEnabled(true);
    }
    public void Simulate(bool cGIF) {
      CreateGIF = cGIF;
      DoTaskWork = CalcSim;
      base.SimulateTask();
    }
    public void SimulatePar(bool cGIF) {
      CreateGIF = cGIF;
      DoTaskWork = CalcSimPar;
      base.SimulateTask();
    }
    public override void MouseUp(int x, int y, int w, int h) {
      if (!drawingHenonMousePoints)
        base.MouseUp(x, y, w, h);
    }
    public void InitDrawTrajectory(int x, int y, int w, int h) {
      if (CurrentFunction is HenonFunction) {
        drawingHenonMousePoints = true;
        PointD p = ShowMouseCoords(x, y, w, h);
        functionDrawer.InitTrajectory(p);
      }
    }
    public void NextTrajectory() {
      if (CurrentFunction is HenonFunction) {
        functionDrawer.DrawNextTrajectory();
      }
    }
    public void StopTrajectory() {
      drawingHenonMousePoints = false;
      PlotFunction();
    }
    public void SetDiagramParameters(bool Ap, bool Bp, bool Cp) {
      if (Ap) 
        ParNum = 2;
      else
        if (Bp) 
        ParNum = 1;
      else 
        ParNum = 0;
    }
    public void SetDiagram(IDiagramView diagram) {//, bool Ap, bool Bp, bool Cp) {
      if (Control4DiagramView != null) {
        Control4DiagramView.ParNum = 0;// ParNum;
        Control4DiagramView.CurrentFunction = CurrentFunction.Clone();
        if (Control4DiagramView.CurrentFunction is HenonFunction)
          Control4DiagramView.DiagramStopParameter = 0;
        else
          Control4DiagramView.DiagramStopParameter = CurrentFunction.DiagramStop;
        Control4DiagramView.DiagramStartParameter = CurrentFunction.DiagramStart;
        Control4DiagramView.SetDiagram(diagram);
      }
    }

  }

}
