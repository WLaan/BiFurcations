namespace BiFurcation {

  public class JuliaRationalPlot:JuliaPlot {

    private Complex one = new Complex(1, 0);
    public override string Formula {
      get {
        return " julia set Z' = Z^2 + 1/(10Z^2), with Z0 = (1,0) and C = Current pixel";
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
        return "Julia Rational ";
      }
    }

    public JuliaRationalPlot(Control4NonLineairSystems c, int dt) : base(c, dt) {
      ThisType = FractalType.JuliaRationalPlot;
    }
    public JuliaRationalPlot(Control4NonLineairSystems c, int dt, DirectBitmap m) : this(c, dt) {
      UseOwnBitmap = true;
      map = m;
      resetMaxSquared();
    }

    protected override Complex Zn(Complex Z, Complex C) {
      return Z * Z * Z + one / (10*Z * Z);
    }
    public override BasePlotter clone(DirectBitmap m) {
      return new JuliaRationalPlot(combinedControl, definedTYype, m);
    }
  }

}
