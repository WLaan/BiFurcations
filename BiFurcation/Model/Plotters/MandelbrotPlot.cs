using System.Drawing;

namespace BiFurcation {

  public class MandelbrotPlot : BaseFor2DimensionalPlot {

    #region properties
    protected float a = 2;
    public float A {
      set {
        a = value;
      }
      get {
        return a;
      }
    }
    protected override Complex Initial_Z {
      get {
        return new Complex(-0, 0);
      }
    }
    public override Complex Initial_C {
      get {
        return new Complex(ReaC, ImaC);
      }
    }
    public override string Title {
      get {
        return "Mandelbrot ";
      }
    }
    public override string Formula {
      get {
        return " Iterating Z' = Z^A + C, with Z0 = (0,0) and C = Current pixel";
      }
    }
    protected override Complex Zn(Complex Z, Complex C) {
      Complex powerZ = Z;
      for (int i = 0; i < a - 1; i++)
        powerZ = powerZ * Z;
      powerZ = powerZ + C;
      return powerZ;
    }
    #endregion

    public MandelbrotPlot(Control4NonLineairSystems c) : base(c) {
      XMini = -2;
      XMaxi = 0.7;
      YMini = -1.5;
      YMaxi = 1.5;
      maxIterations = 50;// 255;
      ThisType = FractalType.Mandelbrot;
    }
    public MandelbrotPlot(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
      resetMaxSquared();
      maxIterations = 20;
    }

    public override void doCalculation() {
      if (Map == null) return;
      
      calc_Clr_Z();
      colors2UsedColorIndices();
      setColorsFromNewSmoozedColors(smoozeType);
    }

    public void addRedDot(Complex dot) {
      int x = (int)(1.0 * Map.Width * ((dot.Re - XMin) / (XMax - XMin)));
      int y = (int)(1.0 * Map.Height * (1-(dot.Im - YMin) / (YMax - YMin)));
      using (Graphics g = Graphics.FromImage(Map.Bitmap))
        g.FillEllipse(Brushes.Red, x, y, 8, 8);
    }
    public override BasePlotter clone(DirectBitmap m) {
      return new MandelbrotPlot(combinedControl, m);
    }

  }

}