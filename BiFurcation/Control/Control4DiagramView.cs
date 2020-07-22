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
        plotDiagram();
        PlotForm.endGenerate();
        PlotForm.setEnabled(true);
      }
    }

    private string diagramGifFileName = "Diagram.GIF";
    public String DiagramGifFileName {
      get {
        return diagramGifFileName;
      }

      set {
        diagramGifFileName = value;
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
    private void paramChoice2Form(decimal Par) {
      decimal currentPar = CurrentFunction.Parameter;
      CurrentFunction.Parameter = Par;
      CurrentFunction.calcFunctionPoints();
      diagramFunctionPlotter.Function = CurrentFunction;

      diagramFunctionPlotter.Form2Plot = null;//just to be sure
      diagramFunctionPlotter.drawPicture();
      PlotForm.setFunctionImage = diagramFunctionPlotter.MainImage;
      CurrentFunction.Parameter = currentPar;
    }
    private void calcDiagram(object sender, DoWorkEventArgs e) {
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");
      gifCreater.images.Clear();

      int deltaIterMax = MaxFunctionIterations / maxGIFIterations;
      int startIter = maxGIFIterations - 1;
      if (diagramDrawer.CreateGif) {
        startIter = 1;
      }
      int[] iters = new int[] { 2, 10, 50, 100, 200, 400, 600, 800, 1000, 1200 };
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
        for (int i = 0; i < BSize && (worker!=null &&!worker.CancellationPending); i++) {
          worker.ReportProgress(i);
          decimal p = start + i * delta;
          BaseFunction diagramFunction = CurrentFunction;
          diagramFunction.Parameter = p;
        
          if (diagramDrawer.CreateGif)
            diagramFunction.MaxIterations = s;
          else
            diagramFunction.MaxIterations = MaxFunctionIterations;
          diagramFunction.setFurcationPoints();
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
        plotDiagram();
        if (diagramDrawer.CreateGif) {
          gifCreater.images.Add(diagramDrawer.Copy4GIF);
         // diagramDrawer.Copy4GIF.Save("temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
          Thread.Sleep(1);
        }
        PlotForm.setCurrentIteration(m);
        if (s < 100)
          s += 10;
        else
          if (s < 1000)
          s += 100;
        else
          s += d;
      }
      int mSec = 20 / maxGIFIterations;
      if (mSec == 0) mSec = 1;
      if (diagramDrawer.CreateGif)
        gifCreater.create(mSec, diagramGifFileName);
      paramChoice2Form(DiagramStopParameter);
    }
    private void diagramProgress(object sender, ProgressChangedEventArgs e) {
      plotForm.worker_ProgressChanged(e.ProgressPercentage);
    }
    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
      plotForm.endGenerate();
      plotForm.setEnabled(true);
      worker = null;
      diagramDrawer.CreateGif = false;
    }
    #endregion

    public void setHenonSkipIterations(string num) {
      if (CurrentFunction is HenonFunction) {
        HenonFunction f = (HenonFunction)CurrentFunction;
        Int32.TryParse(num, out f.SkipIterations);
      }
    }
    public override void simulate() {
      PlotForm.params2Form();
      createDiagram(false);
    }
    public void setDiagram(IDiagramView diagram) {//, int parnum) {// bool Ap, bool Bp, bool Cp) {
      PlotForm = diagram;
      if (plotForm.FormImage != null)
        try {
          using (Graphics g = Graphics.FromImage(plotForm.FormImage))
            g.Clear(Color.White);
        }
        catch { }
      if (PlotForm.setFunctionImage != null)
        try {
          using (Graphics g = Graphics.FromImage(PlotForm.setFunctionImage))
            g.Clear(Color.White);
        }
        catch { }
      GC.Collect();
    }
    public void plotDiagram() {
      if (diagramDrawer.Form2Plot == null)
        diagramDrawer.Form2Plot = plotForm;
      diagramDrawer.DiagramPoints = diagramPoints;
      diagramDrawer.drawPicture();
    }
    public void createDiagram(bool cGIF) {
      plotForm.setEnabled(false);
      if (DiagramStartParameter != DiagramStopParameter && worker == null) {
        plotForm.setProgressBar(BSize);
        diagramDrawer.CreateGif = cGIF;
        worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = true;
        worker.WorkerReportsProgress = true;
        worker.DoWork += new DoWorkEventHandler(calcDiagram);
        worker.ProgressChanged += new ProgressChangedEventHandler(diagramProgress);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        worker.RunWorkerAsync();
      }
      else
        plotForm.setEnabled(true);
    }
    public void diagramParamShoice(int x, Size size) {
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
          PlotForm.showNumber(index, Par, diagramPoints);
        paramChoice2Form(Par);
      }
    }
    public void feigenbaumChoice(string val) {
      if (diagramPoints.Count > 0) {
        decimal Par = 0;
        decimal.TryParse(val, out Par);
        paramChoice2Form(Par);
      }
    }

  }

}
