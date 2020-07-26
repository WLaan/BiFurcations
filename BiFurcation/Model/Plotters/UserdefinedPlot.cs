namespace BiFurcation {

  public class UserdefinedPlot : BaseFor2DimensionalPlot {

    protected override Complex Initial_Z {
      get {
        return new Complex(ReaC, ImaC);
      }
    }
    public override Complex Initial_C {
      get {
        return new Complex(0,0);
      }
    }
    public override string Title {
      get {
        return "User defined";
      }
    }
    public override string Formula {
      get{
        return " With x' = " + UserFunctionXStr() + " and y' = " + UserFunctionYStr();
      }
    }

    public UserdefinedPlot(Control4NonLineairSystems c)  : base(c) {
      parameters[0] = 1;
      parameters[1] = 0;
      parameters[2] = -1.4;
      parameters[3] = 0;
      parameters[4] = 1;
      parameters[5] = 0;

      parameters[6] = 0;
      parameters[7] = 0.3;
      parameters[8] = 0;
      parameters[9] = 0;
      parameters[10] = 0;
      parameters[11] = 0;

      XMini = -2;
      XMaxi = 2;
      YMini = -3;
      YMaxi = 4;
      ThisType = FractalType.Userdefined;
    }
    public UserdefinedPlot(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
      ResetMaxSquared();
    }

    public override void DoCalculation() {
      if (Map == null) return;
      if (Map.Calced_CLR_Z)
        return;
      if (usedColorIndicesCalced) {
        for (int X = 0; X < Map.Width; X++)
          for (int Y = 0; Y < Map.Height; Y++)
            Map.usedColorIndices[X, Y] = usedColorIndices[X, Y];
        Map.Calced_CLR_Z = true;
        return;
      }
      Init();
      Reset();
      // Calculate the values.
      ReaC = XMin;
      try {
        for (int X = 0; X < Map.Width; X++) {//143

          // Let the user know we're not dead.
          if (ReportProgressBreak(X)) break;

          ImaC = YMin;
          for (int Y = 0; Y < Map.Height; Y++) {
            double a = ReaC + 0.1;
            double b = ImaC;
            int clr = 1;
            while ((clr < maxIterations)) {
              // Calculate Z(clr).
              double aa = a * a;
              double bb = b * b;
              double ab = a * b;
              double newX = parameters[0] + parameters[1] * a + parameters[2] * aa + parameters[3] * ab + parameters[4] * b + parameters[5] * bb;
              double newY = parameters[6] + parameters[7] * a + parameters[8] * aa + parameters[9] * ab + parameters[10] * b + parameters[11] * bb;
              if (newX * newX + newY * newY > max_MAG_SQUARED) {
                break; // Bail
              }
              double ta = a;
              a = newX;
              b = newY;

              clr++;
            }
            // Set the pixel's value.
            Complex Z = new Complex(a, b);
            Map.usedColorIndices[X, Y] = new ColorIndex(X, Y, clr, Z);
            Color2UsedColorIndices(Map.usedColorIndices[X, Y]);
            ImaC += dy;
          }
          ReaC += dx;
        }
      }
      catch { }
      Map.Calced_CLR_Z = true;
      if (!Map.CalculatedTypes.Contains(smoozeType))
        Map.CalculatedTypes.Add(smoozeType);
      SetColorsFromNewSmoozedColors(smoozeType);
      usedColorIndicesCalced = true;
    }
    public override BasePlotter Clone(DirectBitmap m) {
      return new UserdefinedPlot(combinedControl, m);
    }

  }

}
