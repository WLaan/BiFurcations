using System;
using System.Drawing;

namespace BiFurcation {

  public class HenonLinePlotter : LinePlot {

    public override string Title {
      get {
        return "Henon lineplot";
      }
    }
    public override string Formula {
      get {
        return "Henon, With x' = -Ax - B(y - x^2) and y' = Bx - A(y - x^2) where B = Sqrt(1 - A*A)";
      }
    }
    public override void setABval(string A, string B) {
      float a = 0;
      float.TryParse(A, out a);
      float b = 0;
      float.TryParse(B, out b);
      parameters[0] = a;
      parameters[6] = Math.Sqrt(1 - parameters[0] * parameters[0]);
      DoCalculation();
    }
    public override bool UseBVal {
      get {
        return false;
      }
    }

    public HenonLinePlotter(Control4NonLineairSystems c) : base(c) {
      parameters[0] = -0.406;
      parameters[6] = Math.Sqrt(1 - parameters[0] * parameters[0]);
      maxMouseIterations = 20000;
      minMouseIterations = 500;
      maxIterations = 10000;
      specificLineType = SpecificLineType.Henon;
      SaveValues();
    }
    public HenonLinePlotter(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
    }

    protected void CalcExtremas() {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      Random rnd = new Random(1);
      calcedPoints.Clear();
      for (int i = 0; i < 64; i++) {
        double X1 = -0.4 + rnd.NextDouble();
        double Y1 = -0.4 + rnd.NextDouble();

        for (int N = 1; N < maxIterations; N++) {
          calcedPoints.Add(new PointF((float)X1, (float)Y1));
          SetExtrema(X1, Y1);
          double X2 = X1 * A - B * (Y1 - X1 * X1);
          double Y2 = X1 * B + A * (Y1 - X1 * X1);
          X1 = X2;
          Y1 = Y2;
          if (Math.Abs(X1) + Math.Abs(Y1) > 2)
            break;
        }
      }
    }
    protected override void CalcTypePoints() {
      CalcExtremas();
      CalcLinePoints();
    }

    public override BasePlotter Clone(DirectBitmap m) {
      return new HenonLinePlotter(combinedControl, m);
    }

  }

}
