using System.Drawing;

namespace BiFurcation {

  public class JuliaPlot3:JuliaPlot {

    private Complex min1 = new Complex(-1, 0);

    public override string Formula {
      get {
        return " Iterating Z'= -1 - Z + Z*Z*Z + C, with Z0 = (1,0) and C = Current pixel";
      }
    }
    public override Complex Initial_C {
      get {
        return new Complex(0, 0);
      }
    }
    protected override Complex Initial_Z {
      get {
        return new Complex(ReaC, ImaC);
      }
    }
    public override string Title {
      get {
        return "Julia Cubic";
      }
    }

    public JuliaPlot3(Control4NonLineairSystems c, int dt) : base(c, dt) {
      XMini = -2;
      XMaxi = 2;
      YMini = -2;
      YMaxi = 2;
      ThisType = FractalType.JuliaPol3;
    }
    public JuliaPlot3(Control4NonLineairSystems c, int dt, DirectBitmap m) : this(c, dt) {
      UseOwnBitmap = true;
      map = m;
      resetMaxSquared();
    }

    protected override Complex Zn(Complex Z, Complex C) {
      return min1 - Z + Z * Z * Z + C;
    }
    public override BasePlotter clone(DirectBitmap m) {
      return new JuliaPlot3(combinedControl, definedTYype, m);
    }
  }

}
