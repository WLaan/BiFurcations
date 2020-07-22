using System.Drawing;

namespace BiFurcation {

  public class FunctionDrawer: BaseFunctionDrawer {

    private Pen attractorLinePen;
    private Color attractorLineColor = Color.Blue;

    #region properties
    public override string title {
      get {
        if (Function is HenonFunction)
          return Function.FunctionStrWithPar;
        else
          return Function.FunctionStrWithPar + " with Seed: " + Function.Seed.ToString("0.0000");
      }
    }

    public bool DrawFurcations {
      set {
        Function.DrawFurcations =  value;
        drawPicture();
      }
      get {
        return Function.DrawFurcations;
      }
    }
    #endregion

    public FunctionDrawer(IView f, Control4FunctionsView c, bool cg) : base(f, c, cg) {
      attractorLinePen = new Pen(attractorLineColor, lineWidth);
      if (Function != null) {
        dy = (Function.YMax - Function.YMin) / 10;
        dx = (Function.XMax - Function.XMin) / 10;
      }
      center= new PointF(BSize / 2, BSize / 2);
    }

    protected override void plotPoints() {
      using (Graphics g = Graphics.FromImage(PointsImage.Bitmap)) {
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        for (int f = 0; f < Constants.MaxF; f++)
          if (Function.FunctionGenerations[f])
            using (Pen cPen = new Pen(Constants.pens[f], lineWidth/2f))
              Function.drawFunctionLines(g, f, cPen);
      }
    }
    protected override void drawLines() {
      dy = (Function.YMax - Function.YMin) / 10;
      dx = (Function.XMax - Function.XMin) / 10;
      using (Graphics g = Graphics.FromImage(PointsImage.Bitmap)) {
        try {
          g.DrawLine(blackPen, 0, (float)(BSize / 2 - Function.y0), (float)(BSize), (float)(BSize / 2 - Function.y0));
          g.DrawLine(blackPen, (float)(BSize / 2 + Function.x0), 0, (float)(BSize / 2 + Function.x0), BSize);

          if (!(Function is HenonFunction)) {
            PointF centerxy = new PointF((float)(BSize / 2 + Function.x0), (float)(BSize / 2 - Function.y0));
            decimal slope = dy / dx;
            PointF LeftBottom = new PointF(0, (float)(centerxy.Y + (float)centerxy.X / (float)slope));
            PointF RightTop = new PointF(BSize, (float)(centerxy.Y - (BSize - centerxy.X) / (float)slope));
            g.DrawLine(attractorLinePen, LeftBottom, centerxy);
            g.DrawLine(attractorLinePen, centerxy, RightTop);
          }

          for (int xy = 1; xy < 10; xy++) {
            g.DrawLine(dashed_pen, 0, xy * BSize / 10, BSize, xy * BSize / 10);
            g.DrawLine(dashed_pen, xy * BSize / 10, 0, xy * BSize / 10, BSize);
          }
          if (DrawFurcations) {
            Function.setFurcationPoints();
            Function.drawFurcationLines(g);
          }
        }
        catch { }
      }
    }
    public override void drawAxes(Graphics g) {
      dy = (Function.YMax - Function.YMin) / 10;
      dx = (Function.XMax - Function.XMin) / 10;
      for (int xy = 0; xy <= 10; xy++) {
        decimal yVal = (Function.YMax - xy * dy);
        g.DrawString(yVal.ToString("0.00"), new Font("Calibri", 2 * fontSize / 3), Brushes.Blue, BSize / 200, BSize / 20 - BSize / 100 + xy * (9 * BSize / 10) / 10);
        decimal xVal = (Function.XMin + xy * dx);
        g.DrawString(xVal.ToString("0.00"), new Font("Calibri", 2 * fontSize / 3), Brushes.Blue, BSize / 20 - BSize / 100 + xy * (9*BSize/10) / 10, BSize - BSize / 20+FontSize);
      }

      g.DrawString(title, new Font("Calibri", fontSize), Brushes.Blue, BSize/20, FontSize/2);

      g.DrawString("f(x)", new Font("Calibri", fontSize), Brushes.Red, 0, BSize / 10 - 3 * BSize / 60 + 20);
      g.DrawString("^", new Font("Calibri", fontSize), Brushes.Red, 15, BSize / 10 - 2 * BSize / 60 + 25);
      g.DrawString("|", new Font("Calibri", fontSize), Brushes.Red, 15, BSize / 10 - BSize / 60);

      g.DrawString("-", new Font("Calibri", fontSize), Brushes.Red, BSize - BSize / 10-20, BSize -BSize/30);
      g.DrawString("-", new Font("Calibri", fontSize), Brushes.Red, BSize - BSize / 10-10, BSize - BSize / 30);
      g.DrawString("> x", new Font("Calibri", fontSize), Brushes.Red, BSize - BSize / 10 , BSize - BSize / 30);
    }
    public void initTrajectory(PointD trajectStart) {
      if (Function is HenonFunction) {
        HenonFunction f = (HenonFunction)Function;
        f.initTrajectory(trajectStart);
        drawPicture();
        using (Graphics g = Graphics.FromImage(PointsImage.Bitmap))
          f.drawTrajectoryLines(g);

        Rectangle destRect = DestRect;
        using (Graphics g = Graphics.FromImage(MainImage))
          g.DrawImage(PointsImage.Bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
        if (form != null)
          form.FormImage = MainImage;
      }
    }
    public void drawNextTrajectory() {
      if (Function is HenonFunction) {
        drawPicture();
        HenonFunction f = (HenonFunction)Function;
        f.calcNextTrajectory();
        drawPicture();
        using (Graphics g = Graphics.FromImage(PointsImage.Bitmap))
          f.drawTrajectoryLines(g);

        Rectangle destRect = DestRect;
        using (Graphics g = Graphics.FromImage(MainImage))
          g.DrawImage(PointsImage.Bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
        if (form != null)
          form.FormImage = MainImage;
      }
    }

  }

}
