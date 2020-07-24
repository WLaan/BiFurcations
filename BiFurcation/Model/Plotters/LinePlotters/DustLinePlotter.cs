using System.Drawing;

namespace BiFurcation {

 public  class DustLinePlotter : LinePlot {

    public override string Title {
      get {
        return "Dust lineplot";
      }
    }
    public override string Formula {
      get {
        return "Dust, With x' = Ax - By - 1 - A and y' = Bx + Ay + B";
      }
    }

    public DustLinePlotter(Control4NonLineairSystems c) : base(c) {
      parameters[0] = 0.696;
      parameters[6] = 0.076;
      maxMouseIterations = 25;
      minMouseIterations = 14;
      maxIterations = 17;
      specificLineType = SpecificLineType.Dust;
      saveValues();
    }
    public DustLinePlotter(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
    }
    protected void calcExtremas() {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      calcedPoints.Clear();
      if (maxIterations > 20)
        maxIterations = 20;
      int max = maxIterations;
      double[] Xs = new double[max];
      double[] Ys = new double[max];
      double[] Ss = new double[max];
      float C = 0.5f;
      float D = -0.5f;
      double X = 2 * A - 1;
      double Y = 2 * B;
      calcedPoints.Add(new PointF(-1f, 0));
      calcedPoints.Add(new PointF(1f, 0));
      calcedPoints.Add(new PointF((float)X, (float)Y));
      extremas.xmin = -1;
      extremas.xmax = 1;
      extremas.ymin = 0;
      setExtrema(X, Y);
      int M = 0;
      double G = 0;
      do {
        if (G < max - 1) {
          M++;
          G++;
          double Xl = A * X - B * Y - 1 + A;
          double Yl = B * X + A * Y + B;
          double X2 = C * X - D * Y + 1 - C;
          double Y2 = D * X + C * Y - D;
          calcedPoints.Add(new PointF((float)Xl, (float)Yl));
          calcedPoints.Add(new PointF((float)X2, (float)Y2));
          setExtrema(Xl, Yl);
          setExtrema(X2, Y2);
          X = Xl;
          Y = Yl;
          Xs[M] = X2;
          Ys[M] = Y2;
          Ss[M] = G;
        }
        else {
          X = Xs[M];
          Y = Ys[M];
          G = Ss[M];
          M--;
        }
      } while (M >= 0);
    }
    protected override void calcTypePoints() {
      calcExtremas();
      calcLinePoints();
    }

    public override BasePlotter Clone(DirectBitmap m) {
      return new DustLinePlotter(combinedControl, m);
    }

  }

}
