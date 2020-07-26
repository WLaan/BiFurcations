using System;
using System.Drawing;
using System.Threading;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;

namespace BiFurcation {

  public class Control4DiagramView : ImageControl {

    #region private
    private List<DiagramSet> diagramPoints = new List<DiagramSet>();
    private FunctionDrawer diagramFunctionPlotter;
    #endregion

    #region override
    public override decimal Xmin {
      get {
        if (diagramDrawer.Function.DiagramStart > diagramDrawer.Function.DiagramStop) {
          decimal max = diagramDrawer.Function.DiagramStop;
          decimal min = diagramDrawer.Function.DiagramStart;
          diagramDrawer.Function.DiagramStop = max;
          diagramDrawer.Function.DiagramStart = min;
        }
        return diagramDrawer.Function.DiagramStart;
      }
      set {
        diagramDrawer.Function.DiagramStart = value;
      }
    }
    public override decimal Xmax {
      get {
        if (diagramDrawer.Function.DiagramStart > diagramDrawer.Function.DiagramStop) {
          decimal max = diagramDrawer.Function.DiagramStop;
          decimal min = diagramDrawer.Function.DiagramStart;
          diagramDrawer.Function.DiagramStop = max;
          diagramDrawer.Function.DiagramStart = min;
        }
        return diagramDrawer.Function.DiagramStop;
      }
      set {
        diagramDrawer.Function.DiagramStop = value;
      }
    }
    public override decimal Ymin {
      get {
        return diagramDrawer.Function.XMin;
      }
      set {
        diagramDrawer.Function.XMin = value;
      }
    }
    public override decimal Ymax {
      get {
        return diagramDrawer.Function.XMax;
      }
      set {
        diagramDrawer.Function.XMax = value;
      }
    }
    public new IDiagramView PlotForm {
      get {
        return (IDiagramView)plotForm;
      }
      set {
        plotForm = value;
      }
    }
    public override Bitmap MainImage {
      get {
        if (diagramDrawer?.MainImage != null)
          return diagramDrawer.MainImage;
        else
          return new Bitmap(1, 1);
      }
      set {
        diagramDrawer.MainImage = value;
      }
    }
    public override DirectBitmap PointsImage {
      get {
        if (diagramDrawer?.PointsImage != null)
          return diagramDrawer.PointsImage;
        else
          return new DirectBitmap(1, 1);
      }
      set {
        diagramDrawer.PointsImage = value;
      }
    }

    #endregion

    #region properties
    private bool plotFeigenbaum = false;
    public bool PlotFeigenbaum {
      set {
        plotFeigenbaum = value;
      }
      get {
        return plotFeigenbaum;
      }
    }
    public BaseFunction CurrentFunction {
      get {
        return diagramDrawer.Function;
      }
      set {
        diagramDrawer.Function = value;
        boarderStack.Clear();
      }
    }

    public override int MaxIterations {
      get {
        if (CurrentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)CurrentFunction;
          return f.MaxIterations;
        }
        else
          return MaxFunctionIterations;
      }
      set {
        if (CurrentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)CurrentFunction;
          f.MaxIterations = value;
        }
        else
          MaxFunctionIterations = value;
      }
    }

    private string[] paramStr = new string[] {"A","B","C" };
    public int ParNum {
      set {
        CurrentFunction.ParNum = value;
        DiagramLabelParameter = paramStr[value];
      }
      get {
        return CurrentFunction.ParNum;
      }
    }

    private DiagramDrawer diagramDrawer;
    public DiagramDrawer DiagramDrawer {
      get {
        return diagramDrawer;
      }
    }

    public string DiagramLabelParameter = "";

    public decimal DiagramStartParameter {
      get {
        return CurrentFunction.DiagramStart;
      }
      set {
        CurrentFunction.DiagramStart = value;
      }
    }

    public decimal DiagramStopParameter {
      get {
        return CurrentFunction.DiagramStop;
      }
      set {
        CurrentFunction.DiagramStop = value;
      }
    }

    public int DiagramLineWidth {
      set {
        diagramDrawer.LineWidth = value;
        PlotDiagram();
        PlotForm.EndGenerate();
        PlotForm.SetEnabled(true);
      }
    }

    public String DiagramGifFileName { get; set; } = "Diagram.GIF";

    public int MaxFunctionIterations {
      set {
        CurrentFunction.MaxIterations = value;
      }
      get {
        return CurrentFunction.MaxIterations;
      }
    }

    private int maxGIFIterations = 20;
    public int MaxGIFIterations {
      set {
        maxGIFIterations = value;
      }
    }
    public Control4FunctionsView Control4FunctionsView {
      get {
        return control4AllViews.control4FunctionsView;
      }
    }
    #endregion

    public Control4DiagramView(IView f):base(f) {
    }
    public Control4DiagramView(IView f, Control4AllViews cav) :base(f, cav) {
      diagramDrawer = new DiagramDrawer(PlotForm, control4AllViews.control4FunctionsView, false);
      diagramFunctionPlotter = new FunctionDrawerInset(PlotForm, Control4FunctionsView, false);
    }

    public int SkipFirst {
      get {
        if (CurrentFunction is HenonFunction) {
          HenonFunction f = (HenonFunction)CurrentFunction;
          return f.SkipIterations;
        }
        else
          return 0;
      }
    }

    #region private helpers
    private void ParamChoice2Form(decimal Par) {
      decimal currentPar = CurrentFunction.Parameter;
      CurrentFunction.Parameter = Par;
      CurrentFunction.CalcFunctionPoints();
      diagramFunctionPlotter.Function = CurrentFunction;

      diagramFunctionPlotter.Form2Plot = null;//just to be sure
      diagramFunctionPlotter.DrawPicture();
      PlotForm.SetFunctionImage = diagramFunctionPlotter.MainImage;
      CurrentFunction.Parameter = currentPar;
    }
    private void CalcDiagram() {
      gifCreater.images.Clear();

      int startIter = maxGIFIterations - 1;
      if (diagramDrawer.CreateGif) {
        startIter = 1;
      }

      int s = 2;
      int d = MaxFunctionIterations / maxGIFIterations;
      if (maxGIFIterations > 2)
        d = MaxFunctionIterations / (maxGIFIterations - 2);

      for (int m = startIter; m < maxGIFIterations; m++) {

        decimal start = DiagramStartParameter;
        decimal stop = DiagramStopParameter;
        if (DiagramStartParameter > DiagramStopParameter) {
          start = DiagramStopParameter;
          stop = DiagramStartParameter;
        }
        int tempMax = CurrentFunction.MaxIterations;
        decimal tempP = CurrentFunction.Parameter;
        decimal delta = 1.0M * (stop - start) / BSize;
        diagramPoints.Clear();
        try {
          for (int i = 0; i < BSize; i++) {
            report.PercentageComplete = i;
            if (progressHandler is IProgress<ProgressReportModel> progress)
              progress.Report(report);
            if (token.IsCancellationRequested) break;

            decimal p = start + i * delta;
            BaseFunction diagramFunction = CurrentFunction;
            diagramFunction.Parameter = p;
            if (diagramDrawer.CreateGif)
              diagramFunction.MaxIterations = s;
            else
              diagramFunction.MaxIterations = MaxFunctionIterations;
            diagramFunction.SetFurcationPoints();
            if (diagramFunction.furcationPoints.Count > 0) {
              if (CurrentFunction is HenonFunction) {
                for (int dp = diagramFunction.furcationPoints.Count - 1; dp > diagramFunction.furcationPoints.Count - 250 && dp >= 0; dp--) {
                  DiagramSet ds = diagramFunction.furcationPoints[dp];
                  diagramPoints.Add(new DiagramSet(i, ds));
                }
              }
              else {
                int last = diagramFunction.furcationPoints.Count - 1;
                diagramPoints.Add(new DiagramSet(i, diagramFunction.furcationPoints[last]));
              }
            }
            else {
              diagramPoints.Add(new DiagramSet(i, 2));
            }
          }
          CurrentFunction.MaxIterations = tempMax;
          CurrentFunction.Parameter = tempP;
          PlotDiagram();
          if (diagramDrawer.CreateGif) {
            gifCreater.images.Add(diagramDrawer.Copy4GIF);
            Thread.Sleep(1);
          }
          PlotForm.SetCurrentIteration(m);
          if (s < 100)
            s += 10;
          else
            if (s < 1000)
            s += 100;
          else
            s += d;
        }
        catch {}
      }
      int mSec = 40 / maxGIFIterations;
      if (mSec == 0) mSec = 1;
      if (diagramDrawer.CreateGif)
        gifCreater.Create(mSec, DiagramGifFileName);
      ParamChoice2Form(DiagramStopParameter);
      diagramDrawer.CreateGif = false;
    }
    #endregion

    public void SetHenonSkipIterations(string num) {
      if (CurrentFunction is HenonFunction) {
        HenonFunction f = (HenonFunction)CurrentFunction;
        Int32.TryParse(num, out f.SkipIterations);
      }
    }
    public override void SimulateTask() {
      PlotForm.Params2Form();
      CreateDiagram(false);
    }
    public void SetDiagram(IDiagramView diagram) {
      PlotForm = diagram;
      if (plotForm.FormImage != null)
        try {
          using Graphics g = Graphics.FromImage(plotForm.FormImage);
          g.Clear(Color.White);
        }
        catch { }
      if (PlotForm.SetFunctionImage != null)
        try {
          using Graphics g = Graphics.FromImage(PlotForm.SetFunctionImage);
          g.Clear(Color.White);
        }
        catch { }
      GC.Collect();
    }
    public void PlotDiagram() {
      if (diagramDrawer.Form2Plot == null)
        diagramDrawer.Form2Plot = plotForm;
      diagramDrawer.DiagramPoints = diagramPoints;
      diagramDrawer.DrawPicture();
    }
    public void CreateDiagram(bool cGIF) {
      diagramDrawer.CreateGif = cGIF;
      DoTaskWork = CalcDiagram;
      base.SimulateTask();
    }
    public void DiagramParamShoice(int x, Size size) {
      if (diagramPoints.Count > 0) {
        decimal dx = 1.0M * x / size.Width;
        int index = (int)(dx * DestRect.Width);
        decimal start = DiagramStartParameter;
        decimal stop = DiagramStopParameter;
        if (stop < start) {
          stop = DiagramStartParameter;
          start = DiagramStopParameter;
        }
        decimal Par = start + (decimal)((stop - start) * dx) ;
        if (index >= 0 && index < BSize && index < diagramPoints.Count)
          PlotForm.ShowNumber(index, Par, diagramPoints);
        ParamChoice2Form(Par);
      }
    }
    public void FeigenbaumChoice(string val) {
      if (diagramPoints.Count > 0) {
        decimal Par = 0;
        decimal.TryParse(val, out Par);
        ParamChoice2Form(Par);
      }
    }

  }

}
