using System;
using System.Drawing;

namespace BiFurcation {

  public class FixedPolynomialFunction:BaseFunction {
    // α = 2.502907875095892822283902873218
    // δ = 4.669201609102990671853203821578
    public override string FunctionStr {
      get {
        return "Ax(1-x)"; 
      }
    }
    public override string FunctionStrWithPar {
      get {
        string sign = "";
        if (Parameter < 0)
          sign = "-";
        if (Math.Abs(Parameter) != 1)
          return Parameter + "x(1-x)";
        else
          return "Logistic function : f(x) = " + sign + "x(1-x)";
      }
    }
    protected override bool MathematicalEquilibrium {
      get {
        return Parameter <= 3;
      }
    }

    public FixedPolynomialFunction():base() {
      ParNum = 2;
      Parameter = 1;
      maxFunctionValue = 2.0f;
      diagramStart = 2;
      diagramStop = 4;
      XMin = 0;
      XMax = 1;
      YMin = 0;
      YMax = 1;
    }

    protected override decimal FValue(decimal p0) {
      decimal x = Parameter * p0 * (1 - p0);
      return x;
    }

    public override BaseFunction Clone() {
      FixedPolynomialFunction f = new FixedPolynomialFunction();
      CopyFields(f);
      return f;
    }

  }
}
