namespace BiFurcation {

  public class JuliaPlotInset: JuliaPlot {

    public double x = 0;
    public double y = 0;

    public override double XMin {
      get {
        return XMini;
      }
    }
    public override double XMax {
      get {
        return XMaxi;
      }
    }
    public override double YMin {
      get {
        return YMini;
      }
    }
    public override double YMax {
      get {
        return YMaxi;
      }
    }

    public override Complex Initial_C {
      get {
        return new Complex(x, y);
      }
    }

    public JuliaPlotInset(Control4NonLineairSystems c, double ix, double iy, DirectBitmap m) : base(c, 0) {
      UseOwnBitmap = true;
      map = m;
      x = ix;
      y = iy;
      XMini = -2;
      XMaxi = 2;
      YMini = -2;
      YMaxi = 2;
      maxIterations = 32;
      max_MAG_SQUARED = 4;
    }
    public override BasePlotter Clone(DirectBitmap m) {
      return new JuliaPlotInset(combinedControl, x, y, m);
    }

  }

}
