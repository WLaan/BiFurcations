using System;
using System.Drawing;
using System.Collections.Generic;

namespace BiFurcation {

  public class DiagramDrawer: BaseFunctionDrawer {

    private decimal[] feigenbaumPoints = new decimal[] { 3M, 3.4494M, 3.544M, 3.5644M, 3.5687M, 3.5696M, 3.5698M, 3.5699M };
    #region properties
    private List<DiagramSet> diagramPoints = new List<DiagramSet>();
    public List<DiagramSet> DiagramPoints {
      set {
        diagramPoints = value;
      }
    }

    public override string title {
      get {
        return "Attractor diagram of " + control4FunctionsView.Control4DiagramView.CurrentFunction.FunctionStrWithPar;
      }
    }
    public override string xLow {
      get {
        return Function.DiagramStart.ToString();
      }
    }
    public override string xHigh {
      get {
        return Function.DiagramStop.ToString();
      }
    }
    public override string xType {
      get {
        return control4FunctionsView.Control4DiagramView.DiagramLabelParameter;
      }
    }
    public override string yLow {
      get {
        return Function.XMax.ToString("0.00");
      }
    }
    public override string yHigh {
      get {
        return Function.XMin.ToString("0.00");
      }
    }
    public override string yType {
      get {
        return "x" ;
      }
    }
    #endregion

    public DiagramDrawer(IView f, Control4FunctionsView c, bool cg) :base(f, c, cg) {
    }

    protected override void plotPoints() {
      int count1 = 0;
      using (Graphics g = Graphics.FromImage(PointsImage.Bitmap)) {
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        if (diagramPoints.Count > 0) {
          int max = -1;
          decimal minDistance = 1000;
          decimal maxDistance = 0;
          for (int i = diagramPoints.Count - 1; i >= 0; i--) {
            if (diagramPoints[i].setPoints[0].Y > maxDistance)
              maxDistance = diagramPoints[i].setPoints[0].Y;
            if (diagramPoints[i].setPoints[0].Y < minDistance)
              minDistance = diagramPoints[i].setPoints[0].Y;
            if (diagramPoints[i].setPoints.Count > max)
              max = diagramPoints[i].setPoints.Count;
          }
          form.setProgressBar(diagramPoints.Count);
          double factor = 1.0 * Constants.smoozedColors.Count / max;
          using (Pen pen = new Pen(Constants.DiagramColor, Constants.DiagramLineWidth)) {        
            for (int i = diagramPoints.Count - 1; i > 0; i--) {
              if ((i + 1) % 100 == 0)
                form.worker_ProgressChanged(diagramPoints.Count - i);
              decimal currentX = diagramPoints[i].X;
              int cIndex = (int)(10.0 * (1.0 * diagramPoints[i].setPoints.Count) / (1.0 * max));

              if (diagramPoints[i].setPoints.Count == 1) {
                float y = (float)(BSize * (1 - (diagramPoints[i].setPoints[0].X - Function.XMin) / (Function.XMax - Function.XMin)));
                PointF p2 = new PointF((float)currentX, y);
                pen.Color = Color.Black;
                if (!Single.IsInfinity(p2.Y))
                  g.DrawEllipse(pen, p2.X, p2.Y, 1, 1);
                count1++;
              }
              else
                for (int s = 0; s < diagramPoints[i].setPoints.Count; s++) {
                  PointF p2 = new PointF((float)currentX, (float)(diagramPoints[i].setPoints[s].Y) * BSize);
                  int xx = (int)(Math.Floor(factor * diagramPoints[i].setPoints.Count)) - 1;
                  if (xx < 0) xx = 0;
                  pen.Color = Color.DarkGray;
                  g.DrawEllipse(pen, p2.X, p2.Y, 1, 1);
                }
            }
          }
          if (control4FunctionsView.Control4DiagramView.PlotFeigenbaum) {
            dx = 1.0M * PointsImage.Bitmap.Width / (Function.DiagramStop - Function.DiagramStart);
            for (int f = 0; f < feigenbaumPoints.Length; f++)
              if (feigenbaumPoints[f] > Function.DiagramStart) {
                float xValF1 = (float)((feigenbaumPoints[f] - Function.DiagramStart) * dx);
                float deltaY = (float)diagramPoints[(int)xValF1].Y;
                g.DrawLine(Pens.Red, xValF1, BSize, xValF1, BSize * (deltaY));// BSize / 10);
              }
          }
        }
      }
    }
    public override void DrawAxes(Graphics g) {
      string xl = xLow;
      string xh = xHigh;
      if (Function.DiagramStart > Function.DiagramStop) {
        xl = xHigh;
        xh = xLow;
      }
      int cSize = fontSize;
      g.DrawString(title, new Font("Calibri", cSize), Brushes.Blue, BSize / 20, 20);

 //     g.DrawString(xl, new Font("Calibri", cSize), Brushes.Blue, BSize / 20, BSize - BSize / 30);
      g.DrawString(xType, new Font("Calibri", cSize), Brushes.Blue, BSize / 2, BSize - BSize / 30);
 //     g.DrawString(xh, new Font("Calibri", cSize), Brushes.Blue, BSize - BSize / 15, BSize - BSize / 30);//

      g.DrawString(yLow, new Font("Calibri", cSize), Brushes.Blue, 5, BSize / 20);
      g.DrawString(yType, new Font("Calibri", cSize), Brushes.Blue, 5, BSize / 2);
      g.DrawString(yHigh, new Font("Calibri", cSize), Brushes.Blue, 5, BSize - BSize / 14);

      dx = (9 * BSize / 10) / (Function.DiagramStop - Function.DiagramStart);
      decimal firstValue = (decimal)Math.Round(Function.DiagramStart + (Function.DiagramStop- Function.DiagramStart)/4);
      decimal deltaValue = ((decimal)Math.Round(Function.DiagramStop + 0.5M) - firstValue) / 4;
      if (deltaValue > 0)
        for (decimal x = firstValue; x < Function.DiagramStop + 1; x += deltaValue) {
          float xVal = (float)(BSize / 20 + (x - Function.DiagramStart) * dx);
          g.DrawString(x.ToString("0.00"), new Font("Calibri", fontSize), Brushes.Blue, xVal, BSize - BSize / 20);
          g.DrawLine(Pens.Black, xVal, BSize - BSize / 25, xVal, BSize - BSize / 20);
        }
    }

  }

}
