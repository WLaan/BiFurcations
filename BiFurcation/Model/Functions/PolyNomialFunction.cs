using System;
using System.Drawing;

namespace BiFurcation {

  public class PolynomialFunction : BaseFunction {

    private string[] parnames = new string[] {"C","B","A" };
    public override string FunctionStr {
      get {
        string text = coefficent(2, true, "X^2") + coefficent(1, true, "X") + coefficent(0, true, "");// A + B + C;
        text = text.Trim();
        if (text.Length > 0 && text[0] == '+')
          text = text.Substring(1);
        return text;
      }
    }
    public override string FunctionStrWithPar {
      get {
        string text = coefficent(2, false,"X") + coefficent(1, false, "X") + coefficent(0, false, "");// A + B + C;
        text = text.Trim();
        if (text.Length > 0 && text[0] == '+')
          text = text.Substring(1);
        return "Function : f(x) = " + text;
      }
    }

    public PolynomialFunction() {
      parameters[2] = 1;
      parameters[1] = 0;
      parameters[0] = -2M;
      ParNum = 0;
      diagramStart = -2;
      diagramStop = 0.25M;
      XMin = -2;
      XMax = 2;
      YMin = -2;
      YMax = 2;
    }

    protected string coefficent(int p, bool withPar, string xy) {
      string sign = " + ";
      string power = xy;
      if (parameters[p] < 0)
        sign = " - ";
      if (parameters[p] != 0) {
        if (parNum == p && withPar)
          return " + " + parnames[p] + power;
        else {
          if (Math.Abs(parameters[p]) != 1) {
            return sign + Math.Abs(parameters[p]) + power;
          }
          else
            return sign + power;
        }
      }
      else
        if (parNum == p && withPar)
        return " + " + parnames[p] + xy + "^" + p;
      else
        return "";
    }

    protected override decimal FValue(decimal p0) {
      return parameters[2] * p0 * p0 + parameters[1] * p0 + parameters[0];
    }
    public override BaseFunction clone() {
      PolynomialFunction p = new PolynomialFunction();
      copyFields(p);
      return p;
    }

  }

}
