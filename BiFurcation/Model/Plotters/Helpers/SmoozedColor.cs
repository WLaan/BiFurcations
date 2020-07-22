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
          return (trackerPositionPercentage - left.trackerPositionPercentage) / 2;
        else
          return trackerPositionPercentage;
      }
    }
    public float WidthPercentageRight {
      get {
        if (right != null)
          return (right.trackerPositionPercentage - trackerPositionPercentage) / 2;
        else
          return 100 - trackerPositionPercentage;
      }
    }
    private float trackerPositionPercentage = 0;
    public float TrackerPositionPercentage {
      get {
        return trackerPositionPercentage;
      }
      set {
        trackerPositionPercentage = value;
      }
    }

    public SmoozedColor(int t, int i, float f) {//
      Tag = t;
      index = i;
      trackerPositionPercentage = f;
    }

    public bool cursorInTracker(int x, Size size) {
      Rectangle rect = trackerRectangle(size);
      return rect.Contains(x, size.Height / 2);
    }
    public int linePosInImage(Size size) {
      return (int)(trackerPositionPercentage * size.Width / 100f);
    }
    public Rectangle trackerRectangle(Size size) {
      int s = size.Height / 20;
      return  new Rectangle(linePosInImage(size) - s, size.Height / 2 - s, 2 * s, 2 * s);
    }

  }

}
