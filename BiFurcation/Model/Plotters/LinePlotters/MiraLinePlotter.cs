using System;
using System.Drawing;

namespace BiFurcation {

  public class MiraLinePlotter:LinePlot {

    public int ExampleNumber = 0;
    public override string Title {
      get {
        return "Mira lineplot";
      }
    }
    public override string Formula {
      get {
        return "Mira, With x' = B*y + F(x) and y' = -x + F(x') where F(x) = Ax + (1-A)2x^2/(1 + x^2)";
      }
    }
    public override bool UseStartPoint {
      get {
        return true;
      }
    }
    public override string SpreadText {
      get {
        return "Spread A (+4 times +/-0.1)";
      }
    }
    public override bool ShowFavorites {
      get {
        return true;
      }
    }

    public MiraLinePlotter(Control4NonLineairSystems c) : base(c) {
      parameters[0] = -0.48;
      parameters[6] = 0.93;
      maxMouseIterations = 100000;
      minMouseIterations = 10000;
      maxIterations = 40000;
      startPoint = new PointF(4f, 0);
      specificLineType = SpecificLineType.Mira;
      disposedCount = 16;
      saveValues();
      #region favorites
      Favorites = new string[] {//"A    B      X0  Y0",
                                 "-0.4  1      4   0",
                                 "-0.4  1     20   0",
                                 "-0.2  1     10   0",
                                 " 0.3  1      2   0",
                                 " 0.31 1     12   0",
                                 " 0.32 1     -5   0",
                                 " 0.30 1      7   0",
                                 " 0.30 1    -12   0",
                                 " 0.30 1    -21   0",
                                 "-0.05 1      2   0",
                                 "-0.05 1      7.5 0",
                                 "-0.05 1      9.8 0",
                                 "-0.05 1     15   0",
                                 "-0.05 1     18   0",
                                 "-0.05 1     20   0",
                                 "-0.05 1     25   0",
                                 " 0.18 1      5.3 0",
                                 " 0.18 1      8   0",
                                 " 0.18 1      9   0",
                                 " 0.18 1     15   0",
                                 " 0.18 1     20   0",
                                 " 0.21 1     20   0",
                                 "-0.48 0.93   4   0",
                                 "-0.4  0.99   4   0",
                                 "-0.25 0.998  3   0",
                                 " 0.01 0.96   3   0",
                                 " 0.1  0.99   3   0",
                                 " 0.7  0.9998 0   12",
      };
      #endregion
    }
    public MiraLinePlotter(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
    }

    private double F(double x, float A) {
      double result = 0;
      double C = 2 - 2 * A;
      double xx = x * x;
      result = A * x + C * xx / (1 + xx);
      return result;
    }
    protected void calcExtremas(float A, float B) {
      double X = startPoint.X;
      double Y = startPoint.Y;

      setExtrema(X, Y);
      calcedPoints.Add(new PointF((float)X, (float)Y));
      for (int m = 0; m < maxIterations; m++) {
        double Z = X;
        X = B * Y + F(X, A);
        Y = -Z + F(X, A);
        if (m > disposedCount) {
          setExtrema(X, Y);
          calcedPoints.Add(new PointF((float)X, (float)Y));
        }
      }
      deltaX = (1.0 * extremas.xmax - extremas.xmin);
      deltaY = (1.0 * extremas.ymax - extremas.ymin);
    }
    protected void calcPoints(float A, float B, Color c) {
      DirectBitmap map = Map;
      deltaX = (1.0 * extremas.xmax - extremas.xmin);
      deltaY = (1.0 * extremas.ymax - extremas.ymin);
      for (int i = 0; i < calcedPoints.Count; i++) {
        PointF p = calcedPoints[i];
        double Xr = 10 + (map.Width - 20) * (p.X - extremas.xmin) / deltaX;
        double Yr = 10 + (map.Height - 20) * (p.Y - extremas.ymin) / deltaY;
        if (Yr < 0) Yr = 0;
        if (Yr >= Map.Height)
          Yr = map.Height - 1;
        if (Math.Abs(Xr) >= Map.Width)
          Xr = map.Width - 1;
        map.SetPixel((int)Xr, (int)Yr, c);

      }
    }
    protected override void calcTypePoints() {
      calcedPoints.Clear();
      extremas = new Extremas();

      calcExtremas((float)parameters[0], (float)parameters[6]);
      if (spreadA) {
        for (float i = 1; i < 5; i++) {
          calcExtremas((float)parameters[0] - i * 0.001f, (float)parameters[6]);
          calcExtremas((float)parameters[0] + i * 0.001f, (float)parameters[6]);
        }
      }
      if (spreadA) {
        for (float i = 1; i < 5; i++) {
          calcedPoints.Clear();
          calcExtremas((float)parameters[0] - i * 0.01f, (float)parameters[6]);
          calcPoints((float)parameters[0] - i * 0.001f, (float)parameters[6], Constants.smoozedColors[(int)i % Constants.smoozedColors.Count].color);

          calcedPoints.Clear();
          calcExtremas((float)parameters[0] + i * 0.01f, (float)parameters[6]);
          calcPoints((float)parameters[0] + i * 0.001f, (float)parameters[6], Constants.smoozedColors[((int)i + 5) % Constants.smoozedColors.Count].color);
        }
      }
      calcedPoints.Clear();
      calcExtremas((float)parameters[0], (float)parameters[6]);
      if (Constants.smoozedColors.Count > 0)
        calcPoints((float)parameters[0], (float)parameters[6], Constants.smoozedColors[0].color);
      else
        calcPoints((float)parameters[0], (float)parameters[6], Color.Black);
    }
    public override BasePlotter Clone(DirectBitmap m) {
      MiraLinePlotter plotter = new MiraLinePlotter(combinedControl, m);
      plotter.Favorites = this.Favorites;
      return plotter;
    }

  }

}
