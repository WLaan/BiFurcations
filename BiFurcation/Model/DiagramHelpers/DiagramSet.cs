using System.Collections.Generic;

namespace BiFurcation {

  public class DiagramSet {

    public List<PointD> setPoints = new List<PointD>();
    private decimal x;
    public decimal X {
      get {
        return x;
      }
      set {
        x = value;
      }
    }
    private decimal y;
    public decimal Y {
      get {
        return y;
      }
      set {
        y = value;
      }
    }

    public DiagramSet(decimal px, decimal py) {
      x = px;
      y = py;
      setPoints.Add(new PointD(x, y));
    }
    public DiagramSet(decimal px, DiagramSet set) {
      x = px;
      y = set.setPoints[0].Y;
      setPoints.AddRange(set.setPoints);
    }

  }

}
