using System;
using System.Drawing;
using System.Collections.Generic;

namespace BiFurcation {

  public enum SpecificLineType {
    Mira,
    Bolspiral,
    Henon,
    Dust,
    Cloud,
    Dendrite,
    Star,
    Julia,
    None
  }

  public class Extremas {

    public double xmin;
    public double xmax;
    public double ymin;
    public double ymax;

    public Extremas() {
      xmin = 1000;
      xmax = -1000;
      ymin = 1000;
      ymax = -1000;
    }

  }

  public class LinePlot : UserdefinedPlot {

    protected Extremas extremas = new Extremas();
    protected double deltaX = 0;
    protected double deltaY = 0;
    protected List<PointF> calcedPoints = new List<PointF>();
    protected int disposedCount = 50;
    protected double A = 0;
    protected double B = 0;
    protected PointF start = new PointF(0, 0);
    protected int MaxIter = 1;

    #region properties
    protected SpecificLineType specificLineType = SpecificLineType.None;
    public SpecificLineType SpecificLineType {
      set {
        specificLineType = value;
        DoCalculation();
      }
      get{
        return specificLineType;
      }
    }

    public override string Title {
      get;
    }
    public override string Formula {
      get;
    }
    public virtual bool UseIterations {
      get {
        return true;
      }
    }
    public virtual bool UseStartPoint {
      get {
        return false;
      }
    }
    public virtual bool UseBVal {
      get {
        return true;
      }
    }
    public virtual string SpreadText {
      get {
        return "";
      }
    }

    public override DirectBitmap Map {
      get {
        if (UseOwnBitmap)
          return map;
        else    
          return combinedControl.PointsImage;// combinedControl.MainImage;
      }
    }
    public void SetABval(int A, int B) {
      parameters[0] = A / 1000f;
      if (specificLineType != SpecificLineType.Henon)
        parameters[6] = B / 1000f;
      else
        parameters[6] = Math.Sqrt(1 - parameters[0] * parameters[0]);
      DoCalculation();
    }
    public virtual void SetABval(string A, string B) {
      float a = 0;
      float.TryParse(A, out a);
      float b = 0;
      float.TryParse(B, out b);
      parameters[0] = a;
      parameters[6] = b;
      DoCalculation();
    }
    protected float minAval = -1;
    public float MinAval {
      get {
        return minAval;
      }
    }
    protected float maxAval = 1;
    public float MaxAval {
      get {
        return maxAval;
      }
    }

    protected PointF startPoint = new PointF(0, 0);
    public PointF StartPoint {
      set {
        startPoint = value;
        DoCalculation();
      }
      get {
        return startPoint;
      }
    }

    protected bool spreadA = false;
    public bool SpreadA {
      set {
        spreadA = value;
        DoCalculation();
      }
    }

    public override int MaxIterations {
      get {
        return maxIterations;
      }
      set {
        maxIterations = value;
      }
    }
    public int Iterations {
      set {
        maxIterations = value;
        DoCalculation();
      }
      get {
        return maxIterations;
      }
    }

    protected int minMouseIterations = 100;
    public int MinMouseIterations {
      set {
        minMouseIterations = value;
      }
      get {
        return minMouseIterations;
      }
    }

    protected int maxMouseIterations = 10000;
    public int MaxMouseIterations {
      set {
        maxMouseIterations = value;
      }
      get {
        return maxMouseIterations;
      }
    }

    protected int maxABmouse = 1000;
    public int MaxABMouse {
      get {
        return maxABmouse;
      }
    }
    public virtual bool ShowFavorites {
      get {
        return false;
      }
    }
    public string[] Favorites = new string[0]; 
    #endregion

    public LinePlot(Control4NonLineairSystems c) : base(c) {
      MaxIterations = 200;
      maxABmouse = 1000;

      parameters[1] = 0;
      parameters[2] = 0;
      parameters[3] = 0;
      parameters[4] = 0;
      parameters[5] = 0;

      parameters[7] = 0;
      parameters[8] = 0;
      parameters[9] = 0;
      parameters[10] = 0;
      parameters[11] = 0;

      XMini = -4;
      XMaxi = 4;
      YMini = -3;
      YMaxi = 3;
      ThisType = FractalType.LinePlot;
      SaveValues();
    }
    public LinePlot(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
    }

    protected void SaveValues() {
      A = parameters[0];
      B = parameters[6];
      start = new PointF(startPoint.X, startPoint.Y);
      MaxIter = maxIterations;
    }

    #region private function calculations
    private void InitMap(DirectBitmap map) {
      for (int x = 0; x < Map.Width; x++)
        for (int y = 0; y < Map.Height; y++) {
          try {
            map.SetPixel(x, y, Color.White);
          }
          catch { }
        }
    }
    protected void SetExtrema(double X1, double Y1) {
      if (extremas.xmin > X1) extremas.xmin = X1;
      if (extremas.xmax < X1) extremas.xmax = X1;
      if (extremas.ymin > Y1) extremas.ymin = Y1;
      if (extremas.ymax < Y1) extremas.ymax = Y1;
    }
    protected void CalcLinePoints() {
      DirectBitmap map = Map;
      deltaX = (1.0 * extremas.xmax - extremas.xmin);
      deltaY = (1.0 * extremas.ymax - extremas.ymin);
      for (int i = 0; i < calcedPoints.Count; i++) {
        PointF p = calcedPoints[i];
        double Xr = (int)(10 + (map.Width - 20) * (p.X - extremas.xmin) / deltaX);
        double Yr = (int)(10 + (map.Height - 20) * (p.Y - extremas.ymin) / deltaY);
        if (Yr < 0) Yr = 0;
        if (Yr >= Map.Height)
          Yr = map.Height - 1;
        if (Math.Abs(Xr) >= Map.Width)
          Xr = map.Width - 1;
        map.SetPixel((int)Xr, (int)Yr, Color.Black);
      }
    }
    protected virtual void CalcTypePoints() {
    }
    #endregion

    public override void DoCalculation() {
      DirectBitmap map = Map;
      if (map == null) return;

      extremas = new Extremas();
      InitMap(map);
      CalcTypePoints();
  
      if (!map.CalculatedTypes.Contains(smoozeType))
        map.CalculatedTypes.Add(smoozeType);
      map.Calced_CLR_Z = true;
    }
    public void setFavorite(int index) {
      if (index >= Favorites.Length) return;
      string selected = Favorites[index].Trim();
      int space = selected.IndexOf(" ");
      string A = selected.Substring(0, space);
      double a = 0;
      double.TryParse(A, out a);
      Parameters[0] = a;

      selected = selected.Substring(space).Trim();
      space = selected.IndexOf(" ");
      string B = selected.Substring(0, space);
      double b = 0;
      double.TryParse(B, out b);
      Parameters[6] = b;

      selected = selected.Substring(space).Trim();
      space = selected.IndexOf(" ");
      string X = selected.Substring(0, space).Trim();
      float x = 0;
      float.TryParse(X, out x);
      selected = selected.Substring(space).Trim();
      string Y = selected;
      float y = 0;
      float.TryParse(Y, out y);
      StartPoint = new PointF(x, y);
      DoCalculation();
      SaveValues();
    }
    public override BasePlotter Clone(DirectBitmap m) {
      LinePlot plotter = new LinePlot(combinedControl, m);
      plotter.Favorites = this.Favorites;
      return plotter;
    }
    public override void Reset() {
      Map.Reset();
      usedColorIndices = new ColorIndex[Map.Width, Map.Height];
      usedColorIndicesCalced = false;
      parameters[0] = A;
      parameters[6] = B;
      startPoint.X = start.X;
      startPoint.Y = start.Y;
      maxIterations = MaxIter;
      DoCalculation();
    }

  }

}
