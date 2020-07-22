namespace BiFurcation {

  public class HenonPlot : UserdefinedPlot {

    public override string Title {
      get {
        return "Henon";
      }
    }
    public override string Formula {
      get {
        return " Iterating Z'= -1 - Z + Z*Z*Z ";
      }
    }

    public HenonPlot(Control4NonLineairSystems c) : base(c){
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
      maxIterations = 255;
      XMini = -3;
      XMaxi = 3;
      YMini = -4;
      YMaxi = 6;
      ThisType = FractalType.Henon;
    }
    public HenonPlot(Control4NonLineairSystems c, DirectBitmap m) : this(c) {
      UseOwnBitmap = true;
      map = m;
      resetMaxSquared();
    }

    public override void doCalculation() {
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
      // Calculate the values.
      init();
      ReaC = XMin;
      for (int X = 0; X < Map.Width; X++) {
        ImaC = YMin;
        for (int Y = 0; Y < Map.Height; Y++) {
          double a = ReaC + 0.1;
          double b = ImaC;

          int clr = 1;
          while ((clr < maxIterations) ) {
            // Calculate Z(clr).
            double aa = a * a;
            double bb = b * b;

            double ta = a;
            a = 1 - 1.4 * a * a + b;
            b = 0.3 * ta;
            if (a*a + b*b > max_MAG_SQUARED) {
              break; // Bail
            }
            clr++;
          }
          Complex Z = new Complex(a, b);
          Map.usedColorIndices[X, Y] = new ColorIndex(X, Y, clr, Z);
          color2UsedColorIndices(Map.usedColorIndices[X, Y]);
          ImaC += dy;
        }
        ReaC += dx;
        // Let the user know we're not dead.
        if (worker != null)
          worker.ReportProgress(X);
      }
      Map.Calced_CLR_Z = true;
      usedColorIndices = new ColorIndex[Map.Width, Map.Height];
      if (!Map.CalculatedTypes.Contains(smoozeType))
        Map.CalculatedTypes.Add(smoozeType);
      usedColorIndicesCalced = true;
      setColorsFromNewSmoozedColors(combinedControl.SmoozeType);
      //   map.Save("testt.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    public override BasePlotter clone(DirectBitmap m) {
      return new HenonPlot(combinedControl, m);
    }

  }

}
