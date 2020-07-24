using System.Collections.Generic;

namespace BiFurcation {

  public class DiagramSet {

    public List<PointD> setPoints = new List<PointD>();

    public decimal X { get; set; }

    public decimal Y { get; set; }

    public DiagramSet(decimal px, decimal py) {
      X = px;
      Y = py;
      setPoints.Add(new PointD(X, Y));
    }
    public DiagramSet(decimal px, DiagramSet set) {
      X = px;
      Y = set.setPoints[0].Y;
      setPoints.AddRange(set.setPoints);
    }

  }

}
