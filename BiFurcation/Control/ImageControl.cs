using System;
using System.Drawing;
using System.Threading;
using System.Globalization;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BiFurcation {

  public struct Boarders {

    public decimal MIN_X;
    public decimal MAX_X;
    public decimal MIN_Y;
    public decimal MAX_Y;
    public int MaxIterations;

    public Boarders(decimal mix, decimal max, decimal miy, decimal may, int mi) {
      MIN_X = mix;
      MAX_X = max;
      MIN_Y = miy;
      MAX_Y = may;
      MaxIterations = mi;
    }

  }

  public delegate void DoWork(object sender, DoWorkEventArgs e);
  public delegate void DoTask();

  public class ImageControl {

    #region protected
    protected CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
    protected Size pictBoxSize;
    protected int screenX = 0;
    protected int screenY = 0;
    protected float m_StartX;
    protected float m_StartY;
    protected float m_CurX;
    protected float m_CurY;
    protected List<Boarders> boarderStack = new List<Boarders>();
    protected GifCreater gifCreater = new GifCreater();
    #endregion

    #region properties
    protected int bSize = 1000;
    public virtual int BSize {
      get {
        return bSize;
      }
      set {
        bSize = value;
        try {
          if (mainImage != null)
            mainImage.Dispose();
          mainImage = new Bitmap(bSize, bSize);
          if (pointsImage != null)
            pointsImage.Dispose();
          pointsImage = new DirectBitmap(bSize, bSize);
          GC.Collect();
        }
        catch { }
        finally {
          pictBoxSize = new Size(BSize, BSize);
          ImageSize = new Size(bSize, bSize);
          sourceRect = new Rectangle(0, 0, bSize, bSize);
        }
      }
    }
    private DirectBitmap pointsImage;
    public virtual DirectBitmap PointsImage {
      get {
        return pointsImage;
      }
      set {
        pointsImage = value;
      }
    }
    private Bitmap mainImage;
    public virtual Bitmap MainImage {
      get {
        return mainImage;
      }
      set {
        mainImage = value;
      }
    }
    public Rectangle sourceRect;
    public Rectangle DestRect {
      get {
        Rectangle destRect = new Rectangle(sourceRect.Width / 20 + 1, sourceRect.Height / 20 + 1, 9 * sourceRect.Width / 10 - 2, 9 * sourceRect.Height / 10 - 2);
        return destRect;
      }
    }
    protected IView plotForm;
    public virtual IView PlotForm {
      get {
        return plotForm;
      }
    }
    public virtual int MaxIterations {
      get;
      set;
    }

    protected decimal xMin = -1;
    public virtual decimal Xmin {
      set {
        xMin = value;
      }
      get {
        return xMin;
      }
    }
    public string XminStr {
      set {
        decimal.TryParse(value, out decimal temp);
        fractalPlotter.Reset();
        xMin = temp;
      }
    }

    protected decimal xMax = 1;
    public virtual decimal Xmax {
      set {
        xMax = value;
      }
      get {
        return xMax;
      }
    }
    public string XmaxStr {
      set {
        decimal.TryParse(value, out decimal temp);
        fractalPlotter.Reset(); 
        fractalPlotter.UsedColorIndices = new ColorIndex[BSize, BSize];
        Xmax = temp;
      }
    }

    protected decimal yMin = -1;
    public virtual decimal Ymin {
      set {
        yMin = value;
      }
      get {
        return yMin;
      }
    }
    public string YminStr {
      set {
        decimal.TryParse(value, out decimal temp);
        Ymin = temp;
        fractalPlotter.Reset();
      }
    }

    protected decimal yMax = 1;
    public virtual decimal Ymax {
      set {
        yMax = value;
      }
      get {
        return yMax;
      }
    }
    public string YmaxStr {
      set {
        decimal.TryParse(value, out decimal temp);
        fractalPlotter.Reset();
        Ymax = temp;
      }
    }
    #endregion

    #region public
    public Control4AllViews control4AllViews;
    public Size ImageSize;

    protected Progress<ProgressReportModel> progressHandler = null;
    public IProgress<ProgressReportModel> progress;
    public CancellationTokenSource cts = new CancellationTokenSource();
    public CancellationToken token;
    public ProgressReportModel report;

    private DoTask doTaskWork;
    public DoTask DoTaskWork {
      set {
        doTaskWork = value;
      }
    }
    #endregion

    public ImageControl(IView f) {
      plotForm = f;
    }
    public ImageControl(IView f, Control4AllViews cav):this(f) {
      plotForm = f;
      control4AllViews = cav;
      BSize = Constants.UsedBSize;
    }

    public BaseFor2DimensionalPlot fractalPlotter;

    #region virtual
    public void InitTaskHandles() {
      progressHandler = new Progress<ProgressReportModel>();
      progressHandler.ProgressChanged += plotForm.ReportProgress;
      report = new ProgressReportModel();
      cts = new CancellationTokenSource();
      token = cts.Token;
      progress = progressHandler;// as IProgress<ProgressReportModel>;
    }
    public virtual async void SimulateTask() {
      PlotForm.SetProgressBar(pictBoxSize.Width);
      PlotForm.SetEnabled(false);
      InitTaskHandles();
      await Task.Run(() => { doTaskWork(); });
      PlotForm.SetEnabled(true);
      PlotForm.EndGenerate();
    } 
    public virtual void StopThread() {
      cts.Cancel();
    }

    public virtual void MouseMove(int x, int y, int w, int h) {
      if (fractalPlotter != null && fractalPlotter.ThisType == FractalType.LinePlot) return;

      Bitmap map = MainImage;
      if (map != null && w != 0 && h != 0) {
        try {
          x = (int)(x * pictBoxSize.Width / w);
          y = (int)(y * pictBoxSize.Height / h);
          Bitmap bm = new Bitmap(MainImage.Width, MainImage.Height);
          try {
            if (PlotForm.FormImage != MainImage && PlotForm.FormImage != null)
              PlotForm.FormImage.Dispose();
          }
          catch { }

          if (bm != null) {
            Rectangle destRect = DestRect;
            using (Graphics gr = Graphics.FromImage(bm)) {
              gr.DrawImage(PointsImage.Bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
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
    public virtual void MouseUp(int x, int y, int w, int h) {
      if (fractalPlotter == null || fractalPlotter.ThisType != FractalType.LinePlot) {
        GC.Collect();
        PlotForm.FormImage = MainImage;
        PointD pXY = ShowMouseCoords(x, y, w, h);
        if (Math.Abs(m_CurX - (float)pXY.X) < 0.01 && Math.Abs(m_CurY - (float)pXY.Y) < 0.01)
          return;
        boarderStack.Add(new Boarders(Xmin, Xmax, Ymin, Ymax, MaxIterations));

        m_CurX = (float)pXY.X;
        m_CurY = (float)pXY.Y;

        // Put the coordinates in proper order.
        double x1 = Math.Min(m_StartX, m_CurX);
        double x2 = Math.Max(m_StartX, m_CurX);
        if (x1 == x2)
          x2 = x1 + 1;

        double y1 = Math.Min(m_StartY, m_CurY);
        double y2 = Math.Max(m_StartY, m_CurY);
        if (y1 == y2)
          y2 = y1 + 1;

        Xmax = (decimal)x2;
        Xmin = (decimal)x1;
        Ymax = (decimal)y2;
        Ymin = (decimal)y1;
        if (fractalPlotter != null)
          fractalPlotter.Reset();
        SimulateTask();
      }
    }
    public virtual void Reset() {
      if (boarderStack.Count > 0) {
        Boarders b = boarderStack[boarderStack.Count - 1];
        Xmin = b.MIN_X;
        Xmax = b.MAX_X;
        Ymin = b.MIN_Y;
        Ymax = b.MAX_Y;
        MaxIterations = b.MaxIterations;
        boarderStack.RemoveAt(boarderStack.Count - 1);
      }
      if (fractalPlotter != null) {
        fractalPlotter.Reset();
      }
      SimulateTask();
    }
    #endregion

    public PointD ShowMouseCoords(int x, int y, int w, int h) {
      //bitmap is square but picturebox is not
      //The image is supposed to be STRETCHED about the picturebox
      //first copy values, so old values can be used again
      decimal realW = w;
      decimal realH = h;
      decimal realX = x;
      decimal realY = y;
      // now make the area square
      decimal factor = 1.0m;
      if (w > h) {
        factor = 1.0m * w / h;
        realW = w / factor;
        realX = x / factor;
      }
      else {
        factor = 1.0m * h / w;
        realH = h / factor;
        realY = y / factor;
      }
      //resize the square to the sourceRect
      factor = 0.5m * sourceRect.Width / realW;
      realW = realW * factor;
      realX = realX * factor;
      realH = realH * factor;
      realY = realY * factor;
      //translate the cursor to destrect
      RectangleF destRect = new RectangleF(sourceRect.Width / 40.0f + 1, sourceRect.Height / 40.0f + 1, 9.0f * sourceRect.Width / 10.0f - 2, 9.0f * sourceRect.Height / 10.0f - 2);
      realX = realX - (decimal)destRect.X + 3;
      realY = realY - (decimal)destRect.Y + 3;
      //resize the area to Constants.destRect
      realW = (realW - 2 * (decimal)destRect.X);
      realH = (realH - 2 * (decimal)destRect.Y);
      //now calc the relative offset in Constants.destRect
      decimal mX = (decimal)(Xmin + (1.0m * realX / realW) * (Xmax - Xmin));
      decimal mY = (decimal)(Ymax - (1.0m * realY / realH) * (Ymax - Ymin));
      return new PointD(mX, mY);
    }
    public bool MouseDown(int x, int y, int w, int h) {
      if (fractalPlotter == null || fractalPlotter.ThisType != FractalType.LinePlot) {
        screenX = (int)(x * pictBoxSize.Width / w);
        screenY = (int)(y * pictBoxSize.Height / h);
        PointD pXY = ShowMouseCoords(x, y, w, h);

        m_StartX = (float)pXY.X;
        m_StartY = (float)pXY.Y;
        m_CurX = m_StartX;
        m_CurY = m_StartY;
        return true;
      }
      else return false;
    }

  }

}