using System;
using System.Linq;
using System.Drawing;

namespace BiFurcation {

  public class BaseFor2DimensionalPlot:BasePlotter {

    private int minimumCLR = 1000;
    private int maximumCLR = -1000;
    private double maxMagnitudeZ = 0;
    private double minMagnitude = 1000;

    #region protected
    protected double dx;
    protected double dy;
    protected double ReaC = 0;
    protected double ImaC = 0;
    #endregion

    #region properties

    protected double[] parameters = new double[12];
    private readonly string[] parXY = new string[] { "", "x", "x^2", "xy", "y", "y^2" };
    public double[] Parameters {
      get {
        return parameters;
      }
    }

    public virtual Complex Initial_C {
      get;
    }

    protected virtual Complex Initial_Z{
      get;
    }

    public virtual string Formula {
      get;
    }
    public string Area {
      get {
        return " (" + XMin.ToString("0.00") + " < x < " + XMax.ToString("0.00") + " , " + YMin.ToString("0.00") + " < y < " + YMax.ToString("0.00") + ")";
      }
    }

    protected virtual Complex Zn(Complex Z, Complex C) {
      return Z * Z + C;
    }
    #endregion

    public BaseFor2DimensionalPlot(Control4NonLineairSystems c):base(c) {
      combinedControl = c;
      MaxIterations = combinedControl.MaxIterations;
      MAX_MAG_SQUARED = combinedControl.MAX_MAG_SQUARED;
      Init();
    }
    public BaseFor2DimensionalPlot(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
      ResetMaxSquared();
    }

    private void scanSubExstremes() {
      Complex C = Initial_C;
      Complex Z = Initial_Z;
      int clr = 1;
      clr = 1;
      while ((clr < maxIterations) && (Z.MagnitudeSquared < max_MAG_SQUARED)) {
        Z = Zn(Z, C);
        clr++;
      }
      if (minimumCLR > clr)
        minimumCLR = clr;
      if (maximumCLR < clr)
        maximumCLR = clr;
      if (maxMagnitudeZ < Z.Magnitude && Z.Magnitude < 16)
        maxMagnitudeZ = Z.Magnitude;
      if (minMagnitude > Z.Magnitude)
        minMagnitude = Z.Magnitude;
    }

    #region protected
    protected string UserFunctionXStr() {
      string X = "";
      for (int i = 0; i < 6; i++)
        if (parameters[i] != 0) {
          string sign = "+";
          if (parameters[i] < 0)
            sign = "-";
          if (Math.Abs(parameters[i]) != 1)
            X += sign + Math.Abs(parameters[i]) + parXY[i];
          else
            X += sign + parXY[i];
        }
      if (!String.IsNullOrEmpty(X) && X.Substring(0, 1).Equals("+"))
        X = X.Substring(1);
      return X;
    }
    protected string UserFunctionYStr() {
      string Y = "";
      for (int i = 0; i < 6; i++)
        if (parameters[6 + i] != 0) {
          string sign = "+";
          if (parameters[6 + i] < 0)
            sign = "-";
          if (Math.Abs(parameters[i]) != 1)
            Y += sign + Math.Abs(parameters[6 + i]) + parXY[i];
          else
            Y += sign + parXY[i];
        }
      if (!String.IsNullOrEmpty(Y) && Y.Substring(0, 1).Equals("+"))
        Y = Y.Substring(1);
      return Y;
    }

    protected int Type1(int clr, Complex Z) {
      if (Z.Magnitude == 0)
        return 0;
      else {
        double mu = (clr + 1 - Math.Log(Math.Log((double)Z.Magnitude) / Math.Log(2)));
        if (mu < Constants.MinimumMU)
          mu = Constants.MinimumMU;
        if (mu > Constants.MaximumMU)
          mu = Constants.MaximumMU;
        mu =  Constants.smoozedColors1024.Count * (mu - Constants.MinimumMU) / (Constants.MaximumMU - Constants.MinimumMU);
        int index = (Constants.smoozedColors1024.Count + (int)(mu)) % Constants.smoozedColors1024.Count;
        return index;
      }
    }
    private readonly object type2Lock = new object();
    protected int Type2(int clr, Complex Z) {
      if (Z.Magnitude == 0 || clr > maxIterations)
        return 0;
      else {
        int index = 0;
        try {
          lock (type2Lock) {
            double zn = Z.Magnitude / Constants.MaxMagnitude;
            double escape = Math.Sqrt(1.0 * clr / maxIterations);
            double mu = zn * escape;
            if (mu > Constants.smoozedColors1024.Count && Constants.smoozedColors1024.Count > 0)
              mu = (int)mu % Constants.smoozedColors1024.Count;
            else
              if (mu < 1 && Constants.smoozedColors1024.Count != 0)
              mu *= Constants.smoozedColors1024.Count;
            if (Constants.smoozedColors1024.Count != 0)
              index = (Constants.smoozedColors1024.Count + (int)mu) % Constants.smoozedColors1024.Count;
          }
        }
        catch { }
        return index;
      }
    }
    protected Color Type3(double value) {
      const double MaxColor = 255;
      int val = (int)(MaxColor * Math.Pow(value, Constants.ContrastValue / 100.0));
      switch (Constants.Type3Color) {
        case Type3Color.Red:
          if (value < 0.75)
            return Color.FromArgb(val, 0, 0);
          else
            return Color.FromArgb(0, val, 0);
        case Type3Color.Green:
          if (value < 0.75)
            return Color.FromArgb(0, val, 0);
          else
            return Color.FromArgb(val, val, 0);
        case Type3Color.Blue:
          if (value < 0.75)
            return Color.FromArgb(0, 0, val);
          else
            return Color.FromArgb(0, val, 0);
        default:
          return Color.FromArgb(val, val, val);
      }

    }

    protected void Init() {
      if (Map != null) {
        if (Map.Width > 1)
          dx = 1.0 * (XMax - XMin) / (Map.Width - 1);
        else
          dx = 0;
        if (Map.Height > 1)
          dy = 1.0 * (YMax - YMin) / (Map.Height - 1);
        else
          dy = 0;
      }
      if (Constants.smoozedColors1024.Count == 0)
        Constants.smoozedColors1024.Add(Color.Black);
      if (Constants.smoozedColors1024[0] == Color.White)
        Constants.smoozedColors1024[0] = Color.Black;
      minimumCLR = 1000;
      maximumCLR = -1000;
      maxMagnitudeZ = 0;
      minMagnitude = 1000;

      ReaC = XMin;
      ImaC = YMin;
      scanSubExstremes();
      ReaC = XMax;
      ImaC = YMax;
      scanSubExstremes();
      // Calculate the values. 
      ReaC = (XMin + XMax) / 2;
      ImaC = YMax;
      for (int Y = 0; Y < Map.Height; Y++) {
        scanSubExstremes();
        if (ImaC > dy)
          ImaC -= dy;
      }
      ReaC = XMax;
      ImaC = (YMin + YMax) / 2;
      for (int X0 = 0; X0 < Map.Width; X0++) {
        scanSubExstremes();
        if (ReaC > dx)
          ReaC -= dx;
      }
      ReaC = XMax;
      ImaC = YMax;
      for (int X0 = 0; X0 < Map.Width; X0++) {
        scanSubExstremes();
        ReaC -= dx;
        ImaC -= dy;
      }
      Constants.MaximumMU = maximumCLR;
      Constants.MinimumMU = minimumCLR;
      Constants.MaxMagnitude = maxMagnitudeZ;
      Constants.MinMagnitude = minMagnitude;
    }
    protected void Calc_Clr_Z() {
      DirectBitmap map = Map;
      if (map.Calced_CLR_Z)
        return;
      if (usedColorIndicesCalced) {
        for (int X = 0; X < Map.Width; X++)
          for (int Y = 0; Y < Map.Height; Y++)
            if (usedColorIndices[X, Y] != null)
              map.usedColorIndices[X, Y] = usedColorIndices[X, Y];
        map.Calced_CLR_Z = true;
        return;
      }
      Init();
      //var calculatedPoints = Enumerable.Range(0, map.Width * map.Height).AsParallel().Select(xy => {
      //  int X, Y;
      //  Y = xy / map.Width;
      //  X = xy % map.Width;
      //  ReaC = XMin + X * dx;
      //  ImaC = YMax - Y * dy;
      //  Complex C = Initial_C;
      //  Complex Z = Initial_Z;
      //  int clr = 1;
      //  while ((clr < maxIterations) && (Z.MagnitudeSquared < max_MAG_SQUARED)) {
      //    // Calculate Z(clr).
      //    Z = Zn(Z, C);
      //    clr++;
      //  }
      //  try {
      //    map.usedColorIndices[X, Y] = new ColorIndex(X, Y, clr, Z);
      //    if (map.usedColorIndices[X, Y] == null) {
      //      X = 0;//Start over again. did happen sometimes, not anymore (??)
      //    }
      //  }
      //  catch {
      //  }
      //  return new CalculatedPoint { x = X, y = Y, i = 0 };
      //});
      ReaC = XMin;
      try {
        for (int X = 0; X < map.Width && (worker == null || !worker.CancellationPending); X++) {
          try {
            if (worker != null)
              worker.ReportProgress(X);
          }
          catch {
          }
          ImaC = YMax;
          for (int Y = 0; Y < map.Height; Y++) {
            Complex C = Initial_C;
            Complex Z = Initial_Z;
            int clr = 1;
            while ((clr < maxIterations) && (Z.MagnitudeSquared < max_MAG_SQUARED)) {
              // Calculate Z(clr).
              Z = Zn(Z, C);
              clr++;
            }
            try {
              map.usedColorIndices[X, Y] = new ColorIndex(X, Y, clr, Z);
              if (map.usedColorIndices[X, Y] == null) {
                X = 0;//Start over again. did happen sometimes, not anymore (??)
              }
            }
            catch {
            }
            ImaC -= dy;
          }
          ReaC += dx;
        }
      }
      catch {
      }
      map.Calced_CLR_Z = true;
      if (usedColorIndices == null)
        usedColorIndices = new ColorIndex[map.Width, map.Height];
      for (int X = 0; X < map.Width; X++)
        for (int Y = 0; Y < map.Height; Y++) 
          usedColorIndices[X, Y] = map.usedColorIndices[X, Y];
      usedColorIndicesCalced = true;
    }
    protected void Color2UsedColorIndices(ColorIndex ci) {
      if (ci == null) return;
      if (ci.Clr < maxIterations) {
        switch (smoozeType) {
          case SmoozeType.Type1:
            ci.index[(int)SmoozeType.Type1] = Type1(ci.Clr, ci.Z);
            break;
          case SmoozeType.Type2:
            ci.index[(int)SmoozeType.Type2] = Type2(ci.Clr, ci.Z);
            break;
          default:
            ci.color[(int)SmoozeType.Type3] = Type3(1.0 * ci.Clr / maxIterations);
            break;
        }
        ci.color[(int)SmoozeType.Single] = Color.White;
      }
      else
        ci.color[(int)SmoozeType.Single] = Constants.OneColor;
    }
    protected void Colors2UsedColorIndices() {
      if (Map.CalculatedTypes.Contains(smoozeType))
        return;
      DirectBitmap map = Map;
      for (int X = 0; X < Map.Width && (worker == null || !worker.CancellationPending); X++) {
        try {
          if (worker != null)
            worker.ReportProgress(X);
        }
        catch {
        }
        for (int Y = 0; Y < Map.Height; Y++) {
          try {
            if (map.usedColorIndices[X, Y] != null)
              Color2UsedColorIndices(map.usedColorIndices[X, Y]);
          }
          catch {
          }
        }
      }
      if (!map.CalculatedTypes.Contains(smoozeType))
        map.CalculatedTypes.Add(smoozeType);
    }
    #endregion
    public void SetColorsFromNewSmoozedColors(SmoozeType type) {
      DirectBitmap map = Map;
      if (map.CalculatedTypes.Contains(type)) {
        for (int x = 0; x < map.Width; x++) {
          for (int y = 0; y < map.Height; y++) {
            try {
              if (map.usedColorIndices[x, y] != null) {
                if (type == SmoozeType.Single || type == SmoozeType.Type3)
                  map.SetPixel(x, y, Map.usedColorIndices[x, y].color[(int)type]);
                else
                 if (map.usedColorIndices[x, y] != null) {
                  map.SetPixel(x, y, Constants.smoozedColors1024[Map.usedColorIndices[x, y].index[(int)type] % Constants.smoozedColors1024.Count]);
                  if (map.usedColorIndices[x, y] == null || map.usedColorIndices[x, y].index[(int)type] > Constants.smoozedColors1024.Count) {
                  }
                }
              }
            }
            catch {
            }
          }
        }
      }
    }
    public override void DrawAxes(Graphics g) {
    }
    public override BasePlotter Clone(DirectBitmap m) {
      return new BaseFor2DimensionalPlot(combinedControl, m);
    }

  }

}


