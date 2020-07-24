using System;
using System.Drawing;

namespace BiFurcation {

  public class BolSpiralLinePlotter : LinePlot {

    public override string Title {
      get {
        return "Sphere lineplot";
      }
    }
    public override string Formula {
      get {
        return "Sphere, With x = (1/sqrt(2))cos(Lambda)cos(Phi), y = sin(Lambda)cos(Phi), z = sin(Phi) where Phi = arctan(sinh(A.Lambda)";
      }
    }
    public override string SpreadText {
      get {
        return "Exact at poles";
      }
    }

    public BolSpiralLinePlotter(Control4NonLineairSystems c) : base(c) {
      parameters[0] = 0.1;
      parameters[6] = 0.96;
      maxMouseIterations = 14000;
      minMouseIterations = 1000;
      maxIterations = 10000;
      specificLineType = SpecificLineType.Bolspiral;
      saveValues();
    }
    public BolSpiralLinePlotter(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
    }

    protected void calcExtremas() {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      double P = 1 / Math.Sqrt(2);
      double Q = P * Math.Sqrt(1 - B * B);
      extremas = new Extremas();

      // Calculate the values.
      for (long N = -maxIterations / 2; N < maxIterations / 2; N++) {
        double S = N * Math.PI / 50;
        double T = Math.Atan(A * S);
        double X = Math.Cos(S) * Math.Cos(T);
        double Y = Math.Sin(S) * Math.Cos(T);
        double Z = Math.Sin(T);
        double U = P * (Y - X);
        double V = B * Z - Q * (X + Y);
        setExtrema(U, V);
      }
      deltaX = (1.0 * extremas.xmax - extremas.xmin);
      deltaY = (1.0 * extremas.ymax - extremas.ymin);
    }
    protected void calcPoints(Color c) {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      DirectBitmap map = Map;
      //bol spiraal van Esscher: 2 schepen piraat <--> koopvaart

      double halfRoot2 = 1 / Math.Sqrt(2);
      double Q = halfRoot2 * Math.Sqrt(1 - B * B);

      // Calculate the values.
      double deltaAlpha = Math.PI / 50;
      double xr0 = 0;
      double yr0 = 0;
      for (long N = -maxIterations / 2; N < maxIterations / 2; N++) {
        double S = N * deltaAlpha;
        double Phi = Math.Atan(Math.Sinh(A * S));
        if (!spreadA)
          Phi = Math.Atan(A * S);
        double X = Math.Cos(S) * Math.Cos(Phi);
        double Y = Math.Sin(S) * Math.Cos(Phi);
        double Z = Math.Sin(Phi);
        double U = halfRoot2 * (Y - X);
        double V = -Q * (Y + X) + B * Z;

        double Xr = (int)(10 + (Map.Width - 20) * (U - extremas.xmin) / deltaX);
        double Yr = (int)(10 + (Map.Height - 20) * (V - extremas.ymin) / deltaY);
        if (Yr < 0) Yr = 0;
        if (Yr >= Map.Height)
          Yr = Map.Height - 1;
        if (N == -maxIterations / 2)
          map.SetPixel((int)Xr, (int)Yr, Color.Black);
        else {
          map.SetPixel((int)Xr, (int)Yr, Color.Black);
          map.SetLine(Xr, Yr, xr0, yr0, Color.Black);
        }
        xr0 = Xr;
        yr0 = Yr;
      }
    }
    protected override void calcTypePoints() {
      calcExtremas();
      calcPoints(Color.Black);
    }

    public override BasePlotter Clone(DirectBitmap m) {
      return new BolSpiralLinePlotter(combinedControl, m);
    }

  }

}
