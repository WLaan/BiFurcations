namespace BiFurcation {

  public class LambdaPlot : MandelbrotPlot {

    protected override Complex Initial_Z {
      get {
        return new Complex(0.5, 0);
      }
    }
    public override Complex Initial_C {
      get {
        return new Complex(ReaC, ImaC);
      }
    }
    protected override Complex Zn(Complex Z, Complex C) {
      return Initial_C * Z * (1 - Z);
    }
    public override string Title {
      get {
        return "Lambda ";
      }
    }
    public override string Formula {
      get {
        return " Iterating Z' = C * Z * (1 - Z), C = (x,y), Z0 = (0.5,0)";
      }
    }

    public LambdaPlot(Control4NonLineairSystems c) : base(c) {
      XMini = -3;
      XMaxi = 5;
      YMini = -3;
      YMaxi = 3;
      ThisType = FractalType.Lambda;
    }
    public LambdaPlot(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
      ResetMaxSquared();
    }

    public override BasePlotter Clone(DirectBitmap m) {
      return new LambdaPlot(combinedControl, m);
    }

  }

}
