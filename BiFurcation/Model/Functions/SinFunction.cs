using System;
using System.Drawing;

namespace BiFurcation {

  public class SinFunction : FixedPolynomialFunction {

    public override string FunctionStr {
      get {
        return "A.sin(PI.x)/4";
      }
    }
    public override string FunctionStrWithPar {
      get {
        string sign = "";
        if (Parameter < 0)
          sign = "-";
        if (Math.Abs(Parameter) != 1)
          return Parameter + ".sin(PI.x)/4";
        else
          return "Logistic function : f(x) = " + sign + "sin(PI.x)/4";
      }
    }
    protected override bool MathematicalEquilibrium {
      get {
        return Parameter <= 3;
      }
    }

    public SinFunction() : base() {
    }

    protected override decimal FValue(decimal p0) {
      decimal x = Parameter * (decimal)Math.Sin(Math.PI * (double)p0) / 4;
      return x;
    }

    public override BaseFunction clone() {
      SinFunction f = new SinFunction();
      copyFields(f);
      return f;
    }

  }

}
