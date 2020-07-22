using System.Drawing;

namespace BiFurcation {

  public class JuliaPlot : MandelbrotPlot {

    private static float[] initialXs = new float[] { -0.70176f, -0.745430f, -0.40f, -0.79f,-0.162f, 0.3f, -0.75f, -1.476f, - 0.12f, 0.28f,  -0.7f };//-1.476f
    private static float[] initialYs = new float[] { -0.3842f,   0.11301f,   0.65f,  0.15f, 1.04f, -0.01f, 0f,     0.01f,  - 0.77f, 0.008f, 0.27015f };

    public static PointF[] Initials {
      get {
        PointF[] points = new PointF[initialXs.Length];
        for (int p0 = 0; p0 < initialXs.Length; p0++)
          points[p0] = new PointF(initialXs[p0], initialYs[p0]);
        return points;
      }
    }
    protected int definedTYype = initialXs.Length - 1;
    public int DefinedType {
      set {
        if (value < initialXs.Length)
          definedTYype = value;
      }
      get {
        return definedTYype;
      }
    }

    public override Complex Initial_C {
      get {
        return new Complex(initialXs[definedTYype], initialYs[definedTYype]);
      }
    }
    protected override Complex Initial_Z {
      get {
        return new Complex(ReaC, ImaC);
      }
    }
    public override string Title {
      get {
        return "Julia (" + initialXs[definedTYype].ToString("0.0") + " + " + initialYs[definedTYype].ToString("0.0") + "j";
      }
    }
    public override string Formula {
      get {
        return " Iterating Z'= Z^A + C, with Z = current pixel and C = (" + Initial_C.Re.ToString("0.0") + "," + Initial_C.Im.ToString("0.0") + ")";
      }
    }
    public PointF definedOffset {
      get {
        return new PointF(initialXs[definedTYype], initialYs[definedTYype]);
      }
    }

    public JuliaPlot(Control4NonLineairSystems c, int dt) : base(c){
      if (dt < initialXs.Length)
        definedTYype = dt;
      XMini = -2;
      XMaxi = 2;
      YMini = -2;
      YMaxi = 2;
      maxIterations = 255;
      MAX_MAG_SQUARED = "2";
      ThisType = FractalType.Julia;
    }
    public JuliaPlot(Control4NonLineairSystems c, int dt, DirectBitmap m) : this(c, dt) {
      UseOwnBitmap = true;
      map = m;
      resetMaxSquared();
    }

    public void setUserDefined(float valx, float valy) {
      if (definedTYype == initialXs.Length - 1) {
        initialXs[initialXs.Length - 1] = valx;
        initialYs[initialYs.Length - 1] = valy;
      }
    }
    public override BasePlotter clone(DirectBitmap m) {
      return new JuliaPlot(combinedControl, definedTYype, m);
    }

  }

}
