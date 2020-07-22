using System.Drawing;

namespace BiFurcation {

  public struct CalculatedPoint {
    public int x;
    public int y;
    public int i;
    public Complex z;
  }

  public class ColorIndex {

    public int x;
    public int y;
    public int Clr;
    public Complex Z;
    public int[] index;
    public Color[] color;

    public ColorIndex(int xi, int yi) {
      x = xi;
      y = yi;
      index = new int[4];
      color = new Color[4];
    }
    public ColorIndex(int xi, int yi, int c, Complex z) {
      x = xi;
      y = yi;
      Clr = c;
      Z = z;
      index = new int[4];
      color = new Color[4];
    }

  }

}
