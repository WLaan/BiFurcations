using System;
using System.Drawing;

namespace BiFurcation {

  public class GeneralMappingFunction: PolynomialFunction {

    private string[] parnames = new string[] { "a0", "a1", "a2" , "a3", "a4", "a5", "b0", "b1", "b2", "b3", "b4", "b5" };
    public override string FunctionStr {
      get {
        string textX = coefficent(0, true, "") + coefficent(1, true, "X") + coefficent(2, true, "X^2") + coefficent(3, true, "xy") + coefficent(4, true, "y") + coefficent(5, true, "y^2");
        string textY = coefficent(6, true, "") + coefficent(7, true, "X") + coefficent(8, true, "X^2") + coefficent(9, true, "xy") + coefficent(10, true, "y") + coefficent(10, true, "y^2");
        textX = textX.Trim();
        if (textX.Length > 0 && textX[0] == '+')
          textX = textX.Substring(1);
        textY = textY.Trim();
        if (textY.Length > 0 && textY[0] == '+')
          textY = textY.Substring(1);
        return textX + " <-> " + textY; 
      }
    }
    public override string FunctionStrWithPar {
      get {
        string textX = coefficent(0, false, "") + coefficent(1, false, "x") + coefficent(2, false, "x^2") + coefficent(3, false, "xy") + coefficent(4, false, "y") + coefficent(5, false, "y^2");
        string textY = coefficent(6, false, "") + coefficent(7, false, "x") + coefficent(8, false, "x^2") + coefficent(9, false, "xy") + coefficent(10, false, "y") + coefficent(10, false, "y^2");
        textX = textX.Trim();
        if (textX.Length > 0 && textX[0] == '+')
          textX = textX.Substring(1);
        textY = textY.Trim();
        if (textY.Length > 0 && textY[0] == '+')
          textY = textY.Substring(1);
        return textX + " <-> " + textY;
      }
    }

    public GeneralMappingFunction() {
      for (int p = 0; p < 12; p++)
        parameters[p] = 0;
      parameters[0] = (decimal)Math.Cos(Math.PI / 4);
      parameters[1] = (decimal)Math.Cos(Math.PI / 4);
    }

    protected override PointD FValue(PointD p0) {
      decimal x = parameters[0] * p0.X - parameters[1] * (p0.Y - p0.X);// + parameters[2] * p0.X * p0.X + parameters[3] * p0.X * p0.Y + parameters[4] * p0.Y + parameters[5] * p0.Y * p0.Y;
      decimal y = parameters[1] * p0.X + parameters[0] * (p0.Y - p0.X);// parameters[8] * p0.X * p0.X + parameters[9] * p0.X * p0.Y + parameters[10] * p0.Y + parameters[11] * p0.Y * p0.Y;
      return new PointD(x, y);
    }
    protected override PointD Point2Window(decimal x, decimal y) {//  List<PointF> points) {
      //multiply the point to a squared window x:0 - width /y:width - 0
      //x from 0 to 4000  == x from -2000 to 2000
      return new PointD(XVal(x), YVal(y));// yVal(points[x].Y));
    }

    public override void CalcFunctionPoints() {
      allPoints[0].Clear();
      //mandelbrot parameters:
      //xn:
      parameters[0] = 0.3M; //a0
      parameters[1] = 0M;   //a1*x
      parameters[2] = 1M;   //a2*x*x
      parameters[3] = 0M;   //a3*xy
      parameters[4] = 0M;   //a4*y
      parameters[5] = -1M;  //a5*y*y
      //yn:
      parameters[6] = 0.93M;//b0
      parameters[7] = 0M;   //b1*x
      parameters[8] = 0M;   //b2*x*x
      parameters[9] = 2M;   //b3*xy
      parameters[10] = 0M;  //b4*y
      parameters[11] = 0M;  //b5*y*y                    

    }
    public override void DrawFunctionLines(Graphics gg, int pList, Pen pen) {
      if (allPoints[pList].Count > 0) {
        for (int i = 0; i < allPoints[pList].Count; i++) {
          try {
            PointF p = new PointF((float)i / BSize, (float)i % BSize);
            Color c = Color.FromArgb((int)allPoints[pList][i].Y % 256, 255, (int)allPoints[pList][i].X);
            using (Pen pensel = new Pen(c, 1))
              gg.DrawEllipse(pensel, p.X, p.Y, 1, 1);
          }
          catch {
          }
        }
      }
    }
    public override BaseFunction Clone() {
      GeneralMappingFunction g = new GeneralMappingFunction();
      CopyFields(g);
      return g;
    }

  }

}
