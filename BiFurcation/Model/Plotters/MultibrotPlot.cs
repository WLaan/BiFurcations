namespace BiFurcation {

  public class MultibrotPlot : MandelbrotPlot {

    protected override Complex Initial_Z {
      get {
        return new Complex(ReaC, ImaC);
      }
    }
    protected override Complex Zn(Complex Z, Complex C) {
      return  Z * Z * Z * Z * Z * Z + C;
    }
    public override string Title {
      get {
        return "Multibrot Z^6 ";
      }
    }
    public override string Formula {
      get {
        return " Iterating Z' = Z * Z * Z * Z * Z * Z + C, C = Z0 = (0,0)";
      }
    }

    public MultibrotPlot(Control4NonLineairSystems c) : base(c) {
      XMini = -1.5;
      XMaxi = 1.5;
      YMini = -1.5;
      YMaxi = 1.5;
    }
    public override BasePlotter clone(DirectBitmap m) {
      return new MultibrotPlot(combinedControl);
    }

  }
}
