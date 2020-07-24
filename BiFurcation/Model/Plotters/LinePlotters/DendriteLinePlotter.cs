using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace BiFurcation {

  public class DendriteLinePlotter : LinePlot {

    public override string Title {
      get {
        return "Dendrite lineplot";
      }
    }
    public override string Formula {
      get {
        return "Dendrite, With x' = Ax +/- By, y'= Bx -/+ Ay where B = Sqrt(1 - A*A) and +/- random";
      }
    }
    public override bool UseBVal {
      get {
        return false;
      }
    }

    public DendriteLinePlotter(Control4NonLineairSystems c) : base(c) {
      parameters[0] = 0.6;
      parameters[6] = 0.8;
      maxMouseIterations = 200000;
      minMouseIterations = 1000;
      maxIterations = 10000;
      specificLineType = SpecificLineType.Dendrite;
      SaveValues();
    }
    public DendriteLinePlotter(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
    }

    protected void CalcExtremas() {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      extremas = new Extremas();
      calcedPoints.Clear();
      Random rand = new Random();
      B = (float)Math.Sqrt(1 - A * A);
      double X = A;
      double Y = B;
      double C = A;
      double D = -B;
      for (int i = 0; i < maxIterations; i++) {
        double r = rand.NextDouble();
        if (r < 0.5) {
          double Z = X;
          X = A * X - B * Y;
          Y = B * Z + A * Y;
          SetExtrema(X, Y);
          calcedPoints.Add(new PointF((float)X, (float)Y));
        }
        else {
          double Z = X;
          X = C * X - D * Y + 1 - C;
          Y = D * Z + A * Y - D;
          SetExtrema(X, Y);
          calcedPoints.Add(new PointF((float)X, (float)Y));
        }
      }
    }
    protected override void CalcTypePoints() {
      CalcExtremas();
      CalcLinePoints();
    }

    public override BasePlotter Clone(DirectBitmap m) {
      return new DendriteLinePlotter(combinedControl, m);
    }

  }

}
