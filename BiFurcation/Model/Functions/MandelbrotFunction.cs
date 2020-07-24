using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace BiFurcation {

  public class MandelbrotFunction:HenonFunction {

    public override string FunctionStr {
      get {
        return "X = X^2 - Y^2  and Y = 2*X*Y";
      }
    }
    public override string FunctionStrWithPar {
      get {
        string signA = " + " + Math.Abs(parameters[2]).ToString("0.00");
        if (parameters[2] < 0)
          signA = " - " + Math.Abs(parameters[2]).ToString("0.00");
        return "Mandelbrot function :  " + "X = X^2 -Y^2 and Y = 2*X*Y";
      }
    }

    public MandelbrotFunction(IFunctionsView f):base(f) {
    }

    public override List<PointD> trajectory(PointD p) {
      Traject.Clear();
      decimal startX = p.X;
      decimal startY = p.Y;
      for (int h = 0; h < multStepPoints && (startX * startX + startY * startY < max_MAG_SQUARED); h++) {
        decimal stX = startX;
        startX = startX * startX - startY * startY;
        startY = 2 * stX * startY;
        Traject.Add(new PointD(startX, startY));
      }
      return Traject;
    }
    public override void CalcFunctionPoints() {
      allPoints[0].Clear();
      parNum = 2;
      //  SkipIterations = 0;
      decimal minX = 1000;
      decimal maxX = -1000;
      decimal minY = 1000;
      decimal maxY = -1000;
      decimal a = parameters[2];
      decimal b = parameters[1];
      decimal startX = 0.5M;
      decimal startY = 0.1M;
      for (int h = 0; h < MaxIterations; h++) {
        decimal stX = startX;
        startX = startX * startX - startY * startY;// startY;//Z*Z+C=(a+bi)(a+bi)+(1, 1i)=a^2-b^2+2abi+1+i
        startY = 2 * stX * startY;
        if (h > SkipIterations) {
          if ((startX * startX + startY * startY) < max_MAG_SQUARED) {
            int c = allPoints[0].Count;
            if (c == 0 || (allPoints[0][c - 1].X != startX || allPoints[0][c - 1].Y != startY)) {
              allPoints[0].Add(new PointD(startX, startY));
              if (minX > startX)
                minX = startX;
              if (maxX < startX)
                maxX = startX;
              if (minY > startY)
                minY = startY;
              if (maxY < startY)
                maxY = startY;
            }
          }
        }
      }
    }
  }

}
