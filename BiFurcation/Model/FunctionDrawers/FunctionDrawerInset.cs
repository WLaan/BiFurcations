using System.Drawing;

namespace BiFurcation {

  public class FunctionDrawerInset: FunctionDrawer {

    private DirectBitmap pointsImage;
    public override DirectBitmap PointsImage {
      get {
        if (pointsImage != null)
          return pointsImage;
        else
          return new DirectBitmap(1, 1);
      }
    }

    private Bitmap mainImage;
    public override Bitmap MainImage {
      get {
        if (mainImage != null)
          return mainImage;
        else
          return new Bitmap(1, 1);
      }
    }

    public FunctionDrawerInset(IView f, Control4FunctionsView c, bool cg):base (f, c, cg) {
      pointsImage = new DirectBitmap(BSize, BSize);
      mainImage = new Bitmap(BSize, BSize);
    }

  }

}
