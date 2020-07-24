using System;
using System.Drawing;

namespace BiFurcation {

 public class JuliaLinePlotter : LinePlot {

    public override string Title {
      get {
        return "Julia lineplot";
      }
    }
    public override string Formula {
      get {
        return "Julia, With x' = x^2 - y^2 + A, y'= 2xy + B)";
      }
    }

    public JuliaLinePlotter(Control4NonLineairSystems c) : base(c) {
      parameters[0] = 0.275;
      parameters[6] = 0.47;
      maxMouseIterations = 1000;
      minMouseIterations = 100;
      maxIterations = 300;
      specificLineType = SpecificLineType.Julia;
      SaveValues();
    }
    public JuliaLinePlotter(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
    }

    protected void CalcExtremas() {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      extremas = new Extremas();
      calcedPoints.Clear();
      float DELH = 1.6f;
      float DELV = 1.2f;
      int N1 = maxIterations;
      int N2 = (int)Math.Floor(N1 * DELV / DELH);
      int N3 = 0;
      if (B != 0)
        N3 = -N2;
      int XM = 320;
      int YM = 240;
      float S = 0;
      for (int i = 0; i < N1; i++)
        for (int j = N3; j < N2; j++) {
          int i1 = XM + i;
          int i2 = XM - i;
          float X = 1.0f * i * DELH / N1;
          int j1 = YM - j;
          int j2 = YM + j;
          float Y = 1.0f * j * DELV / N2;
          for (int k = 1; k <= 800; k++) {
            float X1 = X * X - Y * Y + A;
            float Y1 = 2 * X * Y + B;
            S = X * X + Y * Y;
            float S1 = (X - X1) * (X - X1) + (Y - Y1) * (Y - Y1);
            if (S > 1000)
              break;//break k-loop
            if (S1 < 0.001) {
              SetExtrema(i1, j1);
              SetExtrema(i2, j2);
              if (B == 0) {
                SetExtrema(i1, j2);
                SetExtrema(i2, j1);
              }
              break;//break k-loop
            }
            else {
              X = X1;
              Y = Y1;
            }
          }
        }
    }
    protected void CalcPoints(Color c) {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      deltaX = (1.0 * extremas.xmax - extremas.xmin);
      deltaY = (1.0 * extremas.ymax - extremas.ymin);
      DirectBitmap map = Map;

      float DELH = 1.6f;
      float DELV = 1.2f;
      int N1 = 300;
      int N2 = (int)Math.Floor(N1 * DELV / DELH);
      int N3 = 0;
      if (B != 0)
        N3 = -N2;
      int XM = 320;
      int YM = 240;
      float S = 0;
      for (int i = 0; i < N1; i++)
        for (int j = N3; j < N2; j++) {
          int i1 = XM + i;
          int i2 = XM - i;
          float X = 1.0f * i * DELH / N1;
          int j1 = YM - j;
          int j2 = YM + j;
          float Y = 1.0f * j * DELV / N2;
          for (int k = 1; k <= 800; k++) {
            float X1 = X * X - Y * Y + A;
            float Y1 = 2 * X * Y + B;
            S = X * X + Y * Y;
            float S1 = (X - X1) * (X - X1) + (Y - Y1) * (Y - Y1);
            if (S > 1000)
              break;//break k-loop
            if (S1 < 0.001) {
              int color = (i + k % 14) % Constants.smoozedColors.Count;
              c = Constants.smoozedColors[color].color;
              double Xr = (int)(10 + (map.Width - 20) * (i1 - extremas.xmin) / deltaX);
              double Yr = (int)(10 + (map.Height - 20) * (j1 - extremas.ymin) / deltaY);
              double Xr2 = (int)(10 + (map.Width - 20) * (i2 - extremas.xmin) / deltaX);
              double Yr2 = (int)(10 + (map.Height - 20) * (j2 - extremas.ymin) / deltaY);
              map.SetPixel((int)Xr, (int)Yr, c);
              map.SetPixel((int)Xr2, (int)Yr2, c);
              if (B == 0) {
                map.SetPixel((int)Xr, (int)Yr2, c);
                map.SetPixel((int)Xr2, (int)Yr, c);
              }
              break;//break k-loop
            }
            else {
              X = X1;
              Y = Y1;
            }
          }
        }
    }
    protected override void CalcTypePoints() {
      CalcExtremas();
      CalcPoints(Color.Black);
    }

    public override BasePlotter Clone(DirectBitmap m) {
      return new JuliaLinePlotter(combinedControl, m);
    }

  }

}
