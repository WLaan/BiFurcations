using System;
using System.Drawing;

namespace BiFurcation {

  public enum CloudType {
    Type0,
    Type1,
    Type2
  }
  public class CloudLinePlotter : LinePlot {

    private CloudType cloudType = CloudType.Type0;
    public CloudType CloudType {
      set {
        cloudType = value;
        switch (cloudType) {
          case CloudType.Type0:
            startPoint = new PointF(3.21f, 6.54f);
            parameters[0] = 3.5;
            parameters[6] = -3;
            maxAval = 4;
            minAval = 2.5f;
            break;
          case CloudType.Type1:
            startPoint = new PointF(0, 0);
            parameters[0] = -0.5;
            parameters[6] = 2;
            maxAval = 0;
            minAval = -1;
            break;
          case CloudType.Type2:
            startPoint = new PointF(4f, 1f);
            parameters[0] = 0.51;
            parameters[6] = -0.49;
            maxAval = 1;
            minAval = 0;
            break;
        }
      }
      get {
        return cloudType;
      }
    }
    private double[] Xs = new double[] { 2, 4, 8, 10, 12, 14, 16 };
    private double[] Ys = new double[] { 0, 0, 0, 0 , 0,  0,  0 };
    private double[] Ps = new double[] { 400, 800, 1600, 2000, 2400, 2800, 3200 };

    public override string Title {
      get {
        return "Cloud lineplot";
      }
    }
    public override string Formula {
      get {
        switch (cloudType) {
          case CloudType.Type0:
            return "Cloud, With x' = y + F(x), y'= -x + F(x') where F(x) = A*X or A*X + B*(X +/- 1)";
          case CloudType.Type1:
            return "Cloud, With x' = y + F(x), y'= -x + F(x') where F(x) = X*(A+B)/(1+abs(X)";
          default:
            return "Cloud, With x' = y + F(x), y'= -x + F(x') where F(x) = A*X (X>0) or B*X (X<0)";
        }
      }
    }
    public override bool UseStartPoint {
      get {
        return true;
      }
    }

    public CloudLinePlotter(Control4NonLineairSystems c, CloudType t) : base(c) {
      maxMouseIterations = 50000;
      minMouseIterations = 1000;
      maxIterations = 30000;
      maxABmouse = 1000;
      CloudType = t;
      specificLineType = SpecificLineType.Cloud;
      saveValues();
    }
    public CloudLinePlotter(Control4NonLineairSystems c, DirectBitmap m, CloudType t) : this(c, t) {
      UseOwnBitmap = true;
      map = m;
    }


    private double cloudFunc0(double x, double A, double B) {
      if (x > 1)
        return A * x + B * (x - 1);
      else
        if (x < -1)
        return A * x + B * (x + 1);
      else
        return A * x;
    }
    private double cloudFunc1(double x, double A, double B) {
      return x * (A + B) / (1 + Math.Abs(x));
    }
    private double cloudFunc2(double x, double A, double B) {
      if (x > 0)
        return A * x;
      else
        return B * x;
    }
    protected void calcExtremas0() {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      extremas = new Extremas();
      calcedPoints.Clear();
      double X = startPoint.X;
      double Y = startPoint.Y;
      for (int N = 0; N < maxIterations; N++) {
        if (Math.Abs(X) + Math.Abs(Y) > 200000)
          break;
        setExtrema(X, Y);
        calcedPoints.Add(new PointF((float)X, (float)Y));
        double Z = X;
        X = Y + cloudFunc0(X, A, B);
        Y = -Z + cloudFunc0(X, A, B);
      }
    }
    protected void calcExtremas1() {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      extremas = new Extremas();
      calcedPoints.Clear();
      for (int k = 0; k < 7; k++) {
        double X = Xs[k];
        double Y = Ys[k];
        double P = Ps[k];
        for (int n = 0; n < P; n++) {
          setExtrema(X, Y);
          calcedPoints.Add(new PointF((float)X, (float)Y));
          double Z = X;
          X = Y + cloudFunc1(X, A, B);
          Y = -Z + cloudFunc1(X, A, B);
        }
      }
    }
    protected void calcExtremas2() {
      float A = (float)parameters[0];
      float B = (float)parameters[6];
      extremas = new Extremas();
      calcedPoints.Clear();
      double C = 0.9;
      double X = StartPoint.X;
      double Y = StartPoint.Y;
      for (int n = 0; n < maxIterations; n++) {
        setExtrema(X, Y);
        calcedPoints.Add(new PointF((float)X, (float)Y));
        double Z = X;
        X = C * Y + cloudFunc2(X, A, B);
        Y = -Z + cloudFunc2(X, A, B);
      }
    }
    protected override void calcTypePoints() {
      switch (cloudType) {
        case CloudType.Type0:
          calcExtremas0();
          break;
        case CloudType.Type1:
          calcExtremas1();
          break;
        case CloudType.Type2:
          calcExtremas2();
          break;
      }
      calcLinePoints();
    }

    public override BasePlotter clone(DirectBitmap m) {
      return new CloudLinePlotter(combinedControl, m, this.cloudType);
    }

  }

}
