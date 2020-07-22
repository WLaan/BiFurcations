namespace BiFurcation {

  public class MandelbarPlot : MandelbrotPlot {

    protected override Complex Initial_Z {
      get {
        return new Complex(0, 0);
      }
    }
    public override string Title {
      get {
        return "Mandelbar Conj. ";
      }
    }
    public override string Formula {
      get {
        return " Iterating Z' = (Zcon * Zcon) + C, C = (0,0)";
      }
    }
    protected override Complex Zn(Complex Z, Complex C) {
      Complex Zcon = new Complex(Z.Re, -Z.Im);
      return (Zcon * Zcon) + C;
    }

    public MandelbarPlot(Control4NonLineairSystems c) : base(c) {
      XMini = -2;
      XMaxi = 2;
      YMini = -2;
      YMaxi = 2;
      ThisType = FractalType.Mandelbar;
    }
    public MandelbarPlot(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
      resetMaxSquared();
    }
    public override BasePlotter clone(DirectBitmap m) {
      return new MandelbarPlot(combinedControl, m);
    }

  }

}
