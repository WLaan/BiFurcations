using System;
using System.Drawing;
using System.Collections.Generic;

namespace BiFurcation {

  public class HenonFunction : FixedPolynomialFunction {

    protected decimal max_MAG_SQUARED = 4;
    protected IFunctionsView mainForm;
    private List<PointD> traject = new List<PointD>();
    public List<PointD> Traject {
      get {
        return traject;
      }

      set {
        traject = value;
      }
    }

    public override string FunctionStr {
      get {
        return "X = 1 + Y - A*X^2  and Y = B*X";
      }
    }
    public override string FunctionStrWithPar {
      get {
        string signA = " + " + Math.Abs(parameters[2]).ToString("0.00");
        if (parameters[2] < 0)
          signA = " - " + Math.Abs(parameters[2]).ToString("0.00");
        return "Henon function :  " + "X = 1 + Y " + signA + "X^2 and Y = " + parameters[1].ToString("0.00")+"X";
      }
    }
    public override decimal[] Parameters {
      get {
        return parameters;
      }
      set {
        parameters = value;
      }
    }
    public int HenonDotsize = 2;
    public int SkipIterations = 100;
    public bool checkBoarders = true;
    protected int multStepPoints = 2;
    public int MultStepPoints {
      get{
        return multStepPoints;
      }
      set {
        multStepPoints = value;
      }
    }
    private int initionalDots = 16;
    public int InitionalDots {
      set {
        initionalDots = value;
      }
    }

    public HenonFunction() {
      parNum = 2;
      parameters[1] = 0.3M;
      parameters[2] = 1.4M;
      diagramStop = 1.05M;
      XMin = -1.5M;
      XMax = 1.5M;
      YMin = -0.5M;
      YMax = 0.5M;
      CalcFunctionPoints();
      checkBoarders = false;
    }
    public HenonFunction(IFunctionsView f):this() {
      mainForm = f;
      DrawFurcations = false;
      maxIterations = 20000;
    }

    public virtual List<PointD> trajectory(PointD p) {
      Traject.Clear();
      decimal startX = p.X;
      decimal startY = p.Y;
      for (int h = 0; h < multStepPoints && (startX * startX + startY * startY < max_MAG_SQUARED); h++) {
        decimal stX = startX;
        startX = 1 - parameters[2] * startX * startX + startY;
        startY = parameters[1] * stX;
        Traject.Add(new PointD(startX, startY));
      }
      return Traject;
    }

    protected override PointD Point2Window(decimal x, decimal y) {
      //multiply the point to a squared window x:0 - width /y:width - 0
      //x from 0 to 4000  == x from -2000 to 2000
      return new PointD(XVal(x), YVal(y));
    }

    public override void SetFurcationPoints() {
      furcationPoints.Clear();
      CalcFunctionPoints();
      foreach (PointD p in allPoints[0]) {
        furcationPoints.Add(new DiagramSet(p.X, p.Y));
      }
    }
    public override void CalcFunctionPoints() {
      allPoints[0].Clear();
      parNum = 2;

      decimal minX = 1000;
      decimal maxX = -1000;
      decimal minY = 1000;
      decimal maxY = -1000;
      decimal a = parameters[2];
      decimal b = parameters[1];
      decimal startX = 0;
      decimal startY = 0;
      for (int h = 0; h < MaxIterations; h++) {
        decimal stX = startX;
        startX = 1 - a * startX * startX + startY;
        startY = b*stX;
        if (h > SkipIterations && (startX * startX + startY * startY) < max_MAG_SQUARED) {
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
    public override void DrawFunctionLines(Graphics gg, int pList, Pen pen) {
      if (allPoints[pList].Count > 0) {
        gg.Clear(Color.White);
        if (YMax - YMin == 0 || XMax - XMin == 0) return;
        decimal factorY =BSize / (YMax - YMin);
        decimal factorX =BSize / (XMax - XMin);
        for (int i = 0; i < allPoints[pList].Count && allPoints[pList][i] != null; i++) {
          try {
            gg.FillEllipse(Brushes.Black, ((float)factorX * ((float)allPoints[pList][i].X - (float)XMin)), 
                                          ((float)factorY * ((float)YMax - (float)allPoints[pList][i].Y)), 
                                          HenonDotsize, HenonDotsize);
          }
          catch { }
        }
      }
    }
    public void initTrajectory(PointD p) {
      Traject.Clear();
      decimal radiusX = (xMax - XMin) / 200;
      decimal radiusY = (YMax - yMin) / 100;
      double alpha = 0;
      int totalPoints = initionalDots;
      for (int c = 0; c < totalPoints; c++) {
        decimal dx = radiusX * (decimal)Math.Sin(alpha);
        decimal dy = radiusY * (decimal)Math.Cos(alpha);
        decimal x = p.X - dx;
        decimal y = p.Y - dy;
        PointD newP = new PointD(x, y);
        Traject.Add(newP);
        alpha += 2 * Math.PI / totalPoints;
      }
    }
    public void calcNextTrajectory() {
      List<PointD> current = new List<PointD>(Traject);
      List<PointD> newList = new List<PointD>();
      Traject.Clear();
      foreach (PointD p in current) {
        Traject = trajectory(p);
        newList.AddRange(Traject);
      }
      Traject = newList;
    }
    public void drawTrajectoryLines(Graphics gg) {
      if (YMax - YMin == 0 || XMax - XMin == 0) return;
      float factorY = (float)(BSize / (YMax - YMin));
      float factorX = (float)(BSize / (XMax - XMin));
      using (Pen pen = new Pen(Color.Red, HenonDotsize * 2)) {
        for (int i = 0; i < Traject.Count; i++) {
          try {
            PointD pI = Traject[i];
            float xI = (float)(factorX * ((float)pI.X - (float)XMin));
            float yI = (float)(factorY * ((float)YMax - (float)pI.Y));
            gg.FillEllipse(Brushes.Red, xI, yI, 10, 10);
          }
          catch { }
        }
      }
    }
    public override BaseFunction Clone() {
      HenonFunction h = new HenonFunction();
      CopyFields(h);
      h.mainForm = mainForm;
      h.checkBoarders = checkBoarders;
      h.MaxIterations = MaxIterations;
      h.HenonDotsize = HenonDotsize;
      h.SkipIterations = SkipIterations;
      h.DrawFurcations = false;
      h.HenonDotsize = 20;
      return h;
    }

  }

}
