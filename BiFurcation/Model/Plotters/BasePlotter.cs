using System.Drawing;
using System.ComponentModel;

namespace BiFurcation {

  public class BasePlotter {

    protected bool usedColorIndicesCalced = false;
    protected ColorIndex[,] usedColorIndices;// = new ColorIndex[Constants.UsedBSize, Constants.UsedBSize];
    public ColorIndex[,] UsedColorIndices {
      set {
        usedColorIndices = value;
      }
      get {
        return usedColorIndices;
      }
    }

    protected bool createGIF = false;
    public bool CreateGif {
      get {
        return createGIF;
      }
      set {
        createGIF = value;
      }
    }

    protected Bitmap copy4GIF;
    public Bitmap Copy4GIF {
      get {
        return copy4GIF;
      }
      set {
        copy4GIF = value;
      }
    }
    public Control4NonLineairSystems combinedControl = null;
    public double XMini = -2;
    public double XMaxi = 2;
    public double YMini = -2;
    public double YMaxi = 2;
    public virtual double XMin {
      get {
        if (useOwnBitmap)
          return XMini;
        else
          return (double)combinedControl.Xmin;
      }
    }
    public virtual double XMax {
      get {
        if (useOwnBitmap)
          return XMaxi;
        else
          return (double)combinedControl.Xmax;
      }
    }
    public virtual double YMin {
      get {
        if (useOwnBitmap)
          return YMini;
        else
          return (double)combinedControl.Ymin;
      }
    }
    public virtual double YMax {
      get {
        if (useOwnBitmap)
          return YMaxi;
        else
          return (double)combinedControl.Ymax;
      }
    }

    private bool useOwnBitmap = false;
    public bool UseOwnBitmap {
      set {
        useOwnBitmap = value;
        if (useOwnBitmap) {
          max_MAG_SQUARED = 8;
        }
      }
      get {
        return useOwnBitmap;
      }
    }
    protected double max_MAG_SQUARED = 4;
    public string MAX_MAG_SQUARED {
      get {
        return max_MAG_SQUARED.ToString();
      }
      set {
        double.TryParse(value, out max_MAG_SQUARED);
      }
    }

    protected int maxIterations = 32;
    public virtual int MaxIterations {
      get {
        return maxIterations;
      }
      set {
        maxIterations = value;
      }
    }
    public DirectBitmap map = null;
    public virtual DirectBitmap Map {
      get {
        if (UseOwnBitmap)
          return map;
        else
          return combinedControl.PointsImage;
      }
    }
    public virtual string Title {
      get;
    }
    protected SmoozeType smoozeType = SmoozeType.Type2;
    public SmoozeType SmoozeType {
      set {
        smoozeType = value;
      }
      get {
        return smoozeType;
      }
    }
    protected BackgroundWorker worker = null;
    public BackgroundWorker Worker {
      get {
        return worker;
      }
      set {
        worker = value;
      }
    }
    public FractalType ThisType = FractalType.None;

    public BasePlotter() {
    }
    public BasePlotter(Control4NonLineairSystems c) {
      combinedControl = c;
    }
    public BasePlotter(Control4NonLineairSystems c, DirectBitmap m):this(c) {
      UseOwnBitmap = true;
      map = m;
      ResetMaxSquared();     
    }

    public virtual void DoCalculation() {}
    public void InitImages(Bitmap MainImage, Bitmap PointsImage, int BSize) {
      try {
        using (Graphics g = Graphics.FromImage(PointsImage))
          g.Clear(Color.White);
        try {
          using (Graphics g = Graphics.FromImage(MainImage))
            g.Clear(Color.LightGray);
        }
        catch {
          MainImage = new Bitmap(BSize, BSize);
          using (Graphics g = Graphics.FromImage(MainImage))
            g.Clear(Color.LightGray);
        }
      }
      catch { }
    }
    public virtual void DrawAxes(Graphics g) {}
    public void Copy2GIF(Bitmap MainImage, int BSize, Rectangle sourceRect) {
      if (createGIF) {
        copy4GIF = new Bitmap(BSize / 2, BSize / 2);
        using (Graphics gh = Graphics.FromImage(copy4GIF)) {
          gh.DrawImage(MainImage, new Rectangle(0, 0, BSize / 2, BSize / 2), sourceRect, GraphicsUnit.Pixel);
        }
      }
    }
    protected void ResetMaxSquared() {
      max_MAG_SQUARED = max_MAG_SQUARED / 2;
      MaxIterations = 40;
    }
    public virtual BasePlotter Clone(DirectBitmap m) {
      return new BasePlotter(combinedControl, m);
    }
    public virtual void Reset() {
      Map.reset();
      if (Map.usedColorIndices != null)
        usedColorIndices = new ColorIndex[Map.Width, Map.Height];
      usedColorIndicesCalced = false;
    }

  }

}
