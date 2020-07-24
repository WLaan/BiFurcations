using System;
using System.Drawing;

namespace BiFurcation {

  public class StarLinePlotter : LinePlot {

    public override string Title {
      get {
        return "Star lineplot";
      }
    }
    public override string Formula {
      get {
        return "Star, With x' = x + F(A,B)*cos(N*A), y'= y + F(A,B)*sin(N*A) where F(A,B) = ...";
      }
    }
    public override bool UseStartPoint {
      get {
        return true;
      }
    }
    public override bool UseBVal {
      get {
        return false;
      }
    }

    public StarLinePlotter(Control4NonLineairSystems c) : base(c) {
      parameters[0] = 0.217;
      parameters[6] = 1;
      maxMouseIterations = 10;
      minMouseIterations = 1;
      maxIterations = 5;
      startPoint = new PointF(4f, 0.35f);
      specificLineType = SpecificLineType.Star;
      SaveValues();
    }
    public StarLinePlotter(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
    }

    protected void CalcExtremas() {
      float A0 = (float)parameters[0];
      float B0 = (float)parameters[6];
      extremas = new Extremas();
      calcedPoints.Clear();
      double V = startPoint.X;
      double R = startPoint.Y;
      int P = maxIterations;
      double A = 1000 * A0;
      A = A * (float)Math.PI / 180f;
      double X = 0;
      double Y = 0;
      SetExtrema(X, X);
      calcedPoints.Add(new PointF((float)X, (float)X));
      double powMax = Math.Pow(V, P - 1);
      for (int N = 0; N < (V + 1) * powMax - 1; N++) {
        int M = N;
        double B = N * A;
        int F = 0;
        if ((M % V) == 0 && F < P - 1) {
          M = (int)Math.Floor((double)M / (double)V);
          while ((M % V) == 0 && F < P - 1) 
            F++;
        }
        double pow = Math.Pow(R, P - F - 1);
        double X2 = X + pow * Math.Cos(B);
        double Y2 = Y + pow * Math.Sin(B);
        X = X2;
        Y = Y2;
        SetExtrema(X, Y);
        calcedPoints.Add(new PointF((float)X, (float)Y));
      }
    }
    protected void CalcPoints(Color c) {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      DirectBitmap map = Map;
      deltaX = (1.0 * extremas.xmax - extremas.xmin);
      deltaY = (1.0 * extremas.ymax - extremas.ymin);
      PointF p0 = calcedPoints[0];
      double Xr0 = (int)(10 + (Map.Width - 20) * (p0.X - extremas.xmin) / deltaX);
      double Yr0 = (int)(10 + (Map.Height - 20) * (p0.Y - extremas.ymin) / deltaY);
      for (int i = 1; i < calcedPoints.Count; i++) {
        PointF p = calcedPoints[i];
        double Xr = (int)(10 + (Map.Width - 20) * (p.X - extremas.xmin) / deltaX);
        double Yr = (int)(10 + (Map.Height - 20) * (p.Y - extremas.ymin) / deltaY);
        if (Yr < 0) Yr = 0;
        if (Yr >= Map.Height)
          Yr = Map.Height - 1;
        if (Math.Abs(Xr) >= Map.Width)
          Xr = Map.Width - 1;
        map.SetLine((int)Xr0, (int)Yr0, (int)Xr, (int)Yr, Color.Black);
        Xr0 = Xr;
        Yr0 = Yr;
      }
    }
    protected override void CalcTypePoints() {
      if (Math.Abs(startPoint.X) > 10) return;

      CalcExtremas();
      CalcPoints(Color.Black);
    }

    public override BasePlotter Clone(DirectBitmap m) {
      return new StarLinePlotter(combinedControl, m);
    }

  }

}
