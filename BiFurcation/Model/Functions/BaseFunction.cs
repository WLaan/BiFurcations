using System;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BiFurcation {

  public class BaseFunction {

    public int BSize = Constants.UsedBSize;
    public int MaxAxis;
    public int setCount = 0;

    #region properties
    protected virtual bool MathematicalEquilibrium {
      get {
        return false;
      }
    }
    protected decimal[] parameters = new decimal[12];
    public virtual decimal[] Parameters {
      get {
        return parameters;
      }
      set {
        parameters = value;
      }
    }

    protected int parNum = 0;
    public int ParNum {
      set {
        parNum = value;
      }
      get {
        return parNum;
      }
    }
    public decimal Parameter {
      get {
        return parameters[parNum];
      }
      set {
        parameters[parNum] = value;
      }
    }

    public virtual string FunctionStr {
      get {
        string text = "";
        return text;
      }
    }

    public virtual string FunctionStrWithPar {
      get {
        string text = "";
        return text;
      }
    }

    protected int maxIterations = 300;
    public int MaxIterations {
      set {
        maxIterations = value;
      }
      get {
        return maxIterations;
      }
    }

    protected decimal seed = 0.3M;
    public decimal Seed {
      set {
        seed = value;
      }
      get {
        return seed;
      }
    }

    protected double maxFunctionValue = 2.0f;

    public bool[] FunctionGenerations = new bool[Constants.MaxF];
    public List<PointD>[] allPoints = new List<PointD>[200];

    public List<DiagramSet> furcationPoints = new List<DiagramSet>();
    private decimal[] Xs;

    protected decimal diagramStart = 0;
    public decimal DiagramStart {
      get {
        return diagramStart;
      }
      set {
        diagramStart = value;
      }
    }

    protected decimal diagramStop = 0;
    public decimal DiagramStop {
      get {
        return diagramStop;
      }
      set {
        diagramStop = value;
      }
    }

    private decimal xMin = 0;
    public decimal XMin {
      get {
        return xMin;
      }
      set {
        xMin = value;
        if (xMax == xMin)
          xMax = xMin + 1;
        deltaX = BSize / (xMax - xMin);
        x0 = -xMin * deltaX - BSize / 2;
      }
    }

    protected decimal xMax = 1;
    public decimal XMax {
      get {
        return xMax;
      }
      set {
        xMax = value;
        if (xMax == xMin)
          xMin = xMax - 1;
        deltaX = BSize / (xMax - xMin);
        x0 = -xMin * deltaX - BSize / 2;
      }
    }

    protected decimal yMin = 0;
    public decimal YMin {
      get {
        return yMin;
      }
      set {
        yMin = value;
        if (yMax == yMin)
          yMin = YMax - 1;
        deltaY = BSize / (yMax - yMin);
        y0 = -yMin * deltaY - BSize / 2;
      }
    }

    protected decimal yMax = 1;
    public decimal YMax {
      get {
        return yMax;
      }
      set {
        yMax = value;
        if (yMax == yMin)
          yMin = YMax - 1;
        deltaY = BSize / (yMax - yMin);
        y0 = -yMin * deltaY - BSize / 2;
      }
    }
    private bool drawFurcations = true;
    public bool DrawFurcations {
      set {
        drawFurcations = value;
      }
      get {
        return drawFurcations;
      }
    }
    private bool omitFirst = false;
    public bool OmitFirst {
      set {
        omitFirst = value;
      }
    }
    #endregion

    public decimal x0 = 0;
    public decimal y0 = 0;
    public decimal deltaY;
    public decimal deltaX;
s
    public BaseFunction() {
      MaxAxis = BSize / 2;
      deltaY = BSize / 4;
      deltaX = BSize / 4;

      FunctionGenerations[0] = true;
      for (int f = 0; f < Constants.MaxF; f++)
        allPoints[f] = new List<PointD>();
      if (xMax - xMin != 0)
        deltaX = BSize / (xMax - xMin);
      else
        deltaX = 1;
      x0 = -xMin * deltaX - BSize / 2;
      if (yMax - yMin != 0)
        deltaY = BSize / (yMax - yMin);
      else
        deltaY = 1;
      y0 = -yMin * deltaY - BSize / 2;
    }
    public BaseFunction(int pn):this() {
      ParNum = pn;
    }
    public BaseFunction(decimal s, int pn):this(pn) {
      seed = s;
    }

    protected void checkSet() {
      decimal last = furcationPoints[furcationPoints.Count - 1].X;
      int foundIndex = -1;
      //CancellationTokenSource cts = new CancellationTokenSource();

      //// Use ParallelOptions instance to store the CancellationToken
      //ParallelOptions po = new ParallelOptions();
      //po.CancellationToken = cts.Token;
      //po.MaxDegreeOfParallelism = 2;// System.Environment.ProcessorCount - 1;
      //try {
      //  Parallel.For(0, furcationPoints.Count - 1, index => {
      //    if (Xs[index] == last) {
      //      foundIndex = index;
      //      po.CancellationToken.ThrowIfCancellationRequested();
      //      cts.Cancel();
      //    }
      //  });

      //}
      //catch (OperationCanceledException e) {

      //}
      //finally {
      //  cts.Dispose();
      //}
      //var calculatedPoints = Enumerable.Range(0, furcationPoints.Count).AsParallel().Select(index => {
      //  if (Xs[index] == last)
      //    return index;
      //  else
      //    return -1;
      //});
      //foreach (int ii in calculatedPoints)
      //  if (ii > 0)
      //    foundIndex = ii;

      //  Parallel.ForEach(0, Xs.Length, index => { });
      //if (foundIndex != -1) {
      //}

      int i = Array.LastIndexOf(Xs, last);
      if (i > 0) {
        setCount = (furcationPoints.Count - i - 1);
        PointD temp = furcationPoints[i].setPoints[0];
        furcationPoints[i].setPoints.Clear();
        furcationPoints[i].setPoints.Add(temp);
        for (int s = 0; s < setCount; s++)
          furcationPoints[i].setPoints.Add(furcationPoints[furcationPoints.Count - 1 - s].setPoints[0]);
        while (furcationPoints[i].setPoints.Count > 1 && furcationPoints[i].setPoints[0].X == furcationPoints[i].setPoints[1].X)
          furcationPoints[i].setPoints.RemoveAt(0);
      }
    }
    protected virtual decimal FValue(decimal p0) {
      return 0M;
    }
    protected virtual PointD FValue(PointD p0) {
      return new PointD(0M, 0M);
    }

    protected decimal yVal(decimal y) {
      decimal deltaY = BSize / (YMax - yMin);
      return MaxAxis - deltaY * y - y0;
    }
    protected decimal xVal(decimal x) {
      decimal deltaX = BSize / (XMax - xMin);
      return MaxAxis - deltaX * x - x0;
    }
    protected virtual PointD point2Window(decimal x, decimal y) {//  List<PointF> points) {
      //multiply the point to a squared window x:0 - width /y:width - 0
      //x from 0 to 4000  == x from -2000 to 2000
      return new PointD(x, yVal(y));// yVal(points[x].Y));
    }

    public virtual void calcFunctionPoints() {
      for (int f = 0; f < Constants.MaxF; f++)
        allPoints[f].Clear();
      decimal deltaX = 1.0m * (xMax - XMin) / BSize;
      for (int f = 0; f < Constants.MaxF; f++) {
        if (FunctionGenerations[f])
          for (int ip = 0; ip < BSize; ip++) {
            decimal x = (XMin + ip * deltaX);
            decimal yn = FValue(x);
            allPoints[f].Add(new PointD(x, yn));
            yn = FValue(yn);
          }
      }
    }
    public virtual void drawFunctionLines(Graphics gg, int pList, Pen pen) {
      if (allPoints[pList].Count > 0) {
        int start = 0;
        PointD p1 = point2Window(start, (decimal)allPoints[pList][start].Y);
        for (decimal i = 1; i < allPoints[pList].Count && allPoints[pList][(int)i] != null; i++) {
          try {
            PointD p2 = point2Window(i, (decimal)allPoints[pList][(int)i].Y);
            if (Math.Abs(p1.Y) <= 1.1M * BSize && Math.Abs(p2.Y) <= 1.1M * BSize)
              gg.DrawLine(pen, (float)p1.X, (float)p1.Y, (float)p2.X, (float)p2.Y);
            p1 = p2;
          }
          catch { }
        }
      }
    }
    public virtual BaseFunction clone() {
      return new BaseFunction(seed, parNum);
    }
    public virtual void copyFields(BaseFunction h) {
      h.ParNum = ParNum;
      h.Parameter = Parameter;
      h.parameters[1] = parameters[1];
      h.parameters[2] = parameters[2];
      h.XMin = xMin;
      h.XMax = xMax;
      h.YMin = yMin;
      h.YMax = yMax;
      h.allPoints[0].AddRange(allPoints[0]);
      h.maxFunctionValue = maxFunctionValue;
      if (diagramStart > diagramStop) {
        h.diagramStart = diagramStop;
        h.diagramStop = diagramStart;
      }
      else {
        h.diagramStart = diagramStart;
        h.diagramStop = diagramStop;
      }
    }

    #region furcations
    public bool ReachedConvergence {
      get {
        if (furcationPoints.Count > 0) {
          bool convergent = furcationPoints[furcationPoints.Count - 1].setPoints.Count > 1;
          if (furcationPoints.Count == 1)
            return convergent;
          else
            return convergent || Math.Abs((furcationPoints[furcationPoints.Count - 2].X - furcationPoints[furcationPoints.Count - 1].X) * BSize) < 1;
        }
        else
          return false;
      }
    }
    public virtual void setFurcationPoints() {
      furcationPoints.Clear();
      decimal fy = seed;
      decimal x = seed;
      setCount = 0;
      Xs = new decimal[maxIterations];
    //  Parallel.For(0,maxIterations)

      for (int it = 0; it < maxIterations; it++) {
        x = fy;
        fy = FValue(fy);
        if (Math.Abs(fy) <= 256) {
          decimal normY = (xMax - fy) / (xMax - XMin);
          furcationPoints.Add(new DiagramSet(x, normY));
          checkSet();
          Xs[it] = x;
          if (setCount > 0) {
            for (int s = 0; s < setCount; s++)
              furcationPoints.RemoveAt(furcationPoints.Count - 1);
            break;
          }
        }
        else
          break;
      }
    }
    public void drawFurcationLines(Graphics g) {
      if (furcationPoints.Count > 1) {
        decimal maxAxis = yMax * BSize / (yMax - yMin) ;
        float furY = (float)maxAxis;
        decimal furX0 = -XMin * deltaX;
        try {
          int start = 1;
          if (omitFirst && furcationPoints.Count > 0 ) {
            using (Pen furcationsPen = new Pen(Constants.FurcationColor, Constants.FurcationsLineWidth)) {
              int last = furcationPoints.Count - 1;
              for (int it = 0; it < setCount; it++) {
                PointD p10 = furcationPoints[last].setPoints[it];
                //point on function
                float x1 = (float)(p10.X * deltaX + furX0);
                float y1 = (float)(p10.Y) * furY;
                //point on y=x
                float x2 = (float)(deltaX) - y1;
                float y2 = y1;

                PointF p1 = new PointF(x1, y1);
                PointF pxy = new PointF(x2, y2);
                //horizontal line
                g.DrawLine(furcationsPen, p1, pxy);
                //again vertical to function
                decimal fy = FValue(1 - (decimal)p10.Y);
                PointF p2 = new PointF(pxy.X, (float)(yVal(fy)));
                g.DrawLine(furcationsPen, p2, pxy);
              }
            }
          }
          else {
            using (Pen furcationsPen = new Pen(Constants.FurcationColor, Constants.FurcationsLineWidth)) {
              for (int it = start; it < furcationPoints.Count; it++) {
                //vertical lines
                PointF p1 = new PointF((float)(furcationPoints[it - 1].X * deltaX + furX0), (float)furY);
                PointF p2 = new PointF((float)(furcationPoints[it - 1].X * deltaX + furX0), (float)yVal(furcationPoints[it].X));
                if (it > start || !omitFirst)
                  g.DrawLine(furcationsPen, p1, p2);

                furY = p2.Y;
                //horizontal lines
                p1 = p2;
                p2 = new PointF((float)(furcationPoints[it].X * deltaX + furX0), p1.Y);
                g.DrawLine(furcationsPen, p1, p2);
              }
            }
          }
        }
        catch { }
      }
    }
    #endregion

  }

}
