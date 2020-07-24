using System.Drawing;

namespace BiFurcation {

  public class BaseFunctionDrawer:BasePlotter {

    #region fields
    protected IView form;
    public IView Form2Plot {
      get {
        return form;
      }
      set {
        form = value;
      }
    }
    protected Control4FunctionsView control4FunctionsView;

    protected int lineWidth = 1;
    public virtual int LineWidth {
      set {
        lineWidth = value;
      }
      get {
        return lineWidth;
      }
    }

    protected int fontSize = Constants.UsedFontSize;
    public System.Int32 FontSize {
      get {
        return fontSize;
      }

      set {
        fontSize = value;
      }
    }
    protected Pen blackPen = new Pen(Color.Black, 2);
    protected Pen dashed_pen = new Pen(Color.Black, 1);
    public PointF center;
    protected decimal dx = 0;
    protected decimal dy = 0;

    #region properties
    protected int BSize {
      get {
        return control4FunctionsView.BSize;
      }
    }
    public Size ImageSize {
      get {
        return control4FunctionsView.ImageSize;
      }
    }

    public Rectangle SourceRect {
      get {
        return control4FunctionsView.sourceRect;
      }
    }
    public Rectangle DestRect {
      get {
        return control4FunctionsView.DestRect;
      }
    }

    private DirectBitmap pointsImage;
    public virtual DirectBitmap PointsImage {
      get {
        return pointsImage;
      }
      set {
        pointsImage = value;
      }
    }
    private Bitmap mainImage;
    public virtual Bitmap MainImage {
      get {
        return mainImage;
      }
      set {
        mainImage = value;
      }
    }

    protected BaseFunction baseFunction = null;
    public BaseFunction Function {
      get {
        return baseFunction;
      }
      set {
        baseFunction = value;
      }
    }

    public virtual string Title {
      get {
        return "";
      }
    }
    public virtual string XLow {
      get {
        return "";
      }
    }
    public virtual string XHigh {
      get {
        return "";
      }
    }
    public virtual string XType {
      get {
        return "";
      }
    }
    public virtual string YLow {
      get {
        return "";
      }
    }
    public virtual string YHigh {
      get {
        return "";
      }
    }
    public virtual string YType {
      get {
        return "";
      }
    }

    #endregion
    #endregion

    public BaseFunctionDrawer(IView f, Control4FunctionsView c, bool cg) {
      form = f;
      control4FunctionsView = c;
      baseFunction = control4FunctionsView.CurrentFunction;
      createGIF = cg;
      float[] dashValues = { 2, 4, 2, 4 };
      dashed_pen.DashPattern = dashValues;
      center = new PointF(BSize / 2, BSize / 2);
      mainImage = new Bitmap(BSize, BSize);
      if (MainImage != null)
        using (Graphics g = Graphics.FromImage(MainImage)) 
          g.Clear(Color.LightGray);
      PointsImage = new DirectBitmap(BSize, BSize);
      if (PointsImage != null)
        using (Graphics g = Graphics.FromImage(PointsImage.Bitmap)) 
          g.Clear(Color.White);
    }

    protected virtual void PlotPoints() {
    }
    protected virtual void DrawLines() {
    }
    protected virtual void DrawBoarders() {
      using (Graphics g = Graphics.FromImage(MainImage)) {
        //hor top
        g.DrawLine(Pens.Black, BSize / 20, BSize / 20, BSize - BSize / 20, BSize / 20);
        //hor bottom
        g.DrawLine(Pens.Black, BSize / 20, BSize - BSize / 20, BSize - BSize / 20, BSize - BSize / 20);
        //vert left
        g.DrawLine(Pens.Black, BSize / 20, BSize / 20, BSize / 20, BSize - BSize / 20);
        //vert right
        g.DrawLine(Pens.Black, BSize - BSize / 20, BSize / 20, BSize - BSize / 20, BSize - BSize / 20);

        DrawAxes(g);
      }
    }
    public void DrawPicture() {
      InitImages(MainImage, PointsImage.Bitmap, BSize);

      PlotPoints();
      DrawLines();
      DrawBoarders();
      Rectangle destRect = DestRect;

      using (Graphics g = Graphics.FromImage(MainImage)) {
        g.DrawImage(PointsImage.Bitmap, destRect, SourceRect, GraphicsUnit.Pixel);
     //   PointsImage.Bitmap.Save("testt.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        using (Pen pen = new Pen(Color.Black, 4))
          g.DrawRectangle(pen, new Rectangle(destRect.X - 1, destRect.Y - 1, destRect.Width + 2, destRect.Height + 2));
        using (Pen pen = new Pen(Color.White, 4)) {
          g.DrawLine(pen, destRect.X - 3, destRect.Y - 1, destRect.Width + destRect.X + 1, destRect.Y - 1);
          g.DrawLine(pen, destRect.X - 1, destRect.Y - 1, destRect.X - 1, destRect.Height + destRect.Y);
        }
      }

      Copy2GIF(mainImage, BSize, SourceRect);

      if (form != null)
        form.FormImage = MainImage;
    }

  }

}
