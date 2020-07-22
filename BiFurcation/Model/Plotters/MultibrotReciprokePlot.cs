namespace BiFurcation {

  public class MultibrotReciprokePlot : MandelbrotPlot {

    public new float A {
      set {
        a = value;
      }
      get {
        return a;
      }
    }
    protected override Complex Initial_Z {
      get {
        return new Complex(ReaC, ImaC);
      }
    }
    public override Complex Initial_C {
      get {
        return new Complex(a, 0);
      }
    }
    protected override Complex Zn(Complex Z, Complex C) {
      return 1/(Z * Z) + C;
    }
    public override string Title {
      get {
        return "Multibrot 1/Z^2 + (" + A.ToString("0.00") + ",0)";
      }
    }
    public override string Formula {
      get {
        return " Iterating Z' = 1/(Z * Z) + C, C = (A,0) Z0 = (x,y) A < 1";
      }
    }

    public MultibrotReciprokePlot(Control4NonLineairSystems c) : base(c) {
      XMini = -2;
      XMaxi = 2;
      YMini = -2;
      YMaxi = 2;
      maxIterations = 255;
      a = 0.5f;
      ThisType = FractalType.Multibrot;
    }
    public MultibrotReciprokePlot(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
      resetMaxSquared();
    }
    public override BasePlotter clone(DirectBitmap m) {
      return new MultibrotReciprokePlot(combinedControl, m);
    }

  }
}
