using System.Drawing;

namespace BiFurcation {

 public class SmoozedColor {

    public int Tag;
    public int index;
    public Color color;
    public SmoozedColor left = null;
    public SmoozedColor right = null;
    public float WidthPercentageLeft {
      get {
        if (left != null)
          return (TrackerPositionPercentage - left.TrackerPositionPercentage) / 2;
        else
          return TrackerPositionPercentage;
      }
    }
    public float WidthPercentageRight {
      get {
        if (right != null)
          return (right.TrackerPositionPercentage - TrackerPositionPercentage) / 2;
        else
          return 100 - TrackerPositionPercentage;
      }
    }

    public float TrackerPositionPercentage { get; set; } = 0;

    public SmoozedColor(int t, int i, float f) {//
      Tag = t;
      index = i;
      TrackerPositionPercentage = f;
    }

    public bool CursorInTracker(int x, Size size) {
      Rectangle rect = TrackerRectangle(size);
      return rect.Contains(x, size.Height / 2);
    }
    public int LinePosInImage(Size size) {
      return (int)(TrackerPositionPercentage * size.Width / 100f);
    }
    public Rectangle TrackerRectangle(Size size) {
      int s = size.Height / 20;
      return  new Rectangle(LinePosInImage(size) - s, size.Height / 2 - s, 2 * s, 2 * s);
    }

  }

}
