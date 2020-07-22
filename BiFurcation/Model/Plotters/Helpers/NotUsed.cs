/*
//  unsafe Bitmap ReplaceColor(Bitmap source, Color toReplace, Color replacement) {
//    const int pixelSize = 4; // 32 bits per pixel

//    Bitmap target = new Bitmap(
//      source.Width,
//      source.Height,
//      PixelFormat.Format32bppArgb);

//    BitmapData sourceData = null, targetData = null;

//    try {
//      sourceData = source.LockBits(
//        new Rectangle(0, 0, source.Width, source.Height),
//        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

//      targetData = target.LockBits(
//        new Rectangle(0, 0, target.Width, target.Height),
//        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

//      for (int y = 0; y < source.Height; ++y) {
//        byte* sourceRow = (byte*)sourceData.Scan0 + (y * sourceData.Stride);
//        byte* targetRow = (byte*)targetData.Scan0 + (y * targetData.Stride);

//        for (int x = 0; x < source.Width; ++x) {
//          byte b = sourceRow[x * pixelSize + 0];
//          byte g = sourceRow[x * pixelSize + 1];
//          byte r = sourceRow[x * pixelSize + 2];
//          byte a = sourceRow[x * pixelSize + 3];

//          if (toReplace.R == r && toReplace.G == g && toReplace.B == b) {
//            r = replacement.R;
//            g = replacement.G;
//            b = replacement.B;
//          }

//          targetRow[x * pixelSize + 0] = b;
//          targetRow[x * pixelSize + 1] = g;
//          targetRow[x * pixelSize + 2] = r;
//          targetRow[x * pixelSize + 3] = a;
//        }
//      }
//    }
//    finally {
//      if (sourceData != null)
//        source.UnlockBits(sourceData);

//      if (targetData != null)
//        target.UnlockBits(targetData);
//    }

//    return target;
//  }
*/

/*static void MultiThreaded() {
//  const int w = 800;
//  const int h = 600;
//  const int zoom = 1;
//  const int maxiter = 255;
//  const int moveX = 0;
//  const int moveY = 0;
//  const double cX = -0.7;
//  const double cY = 0.27015;

//  // Precalculate a pallette of 256 colors
//  var colors = (from c in Enumerable.Range(0, 256)
//                select Color.FromArgb((c >> 5) * 36, (c >> 3 & 7) * 36, (c & 3) * 85)).ToArray();

//  // The "AsParallel" below invokes PLINQ, making evaluation parallel using as many cores as
//  // are available.
//  var calculatedPoints = Enumerable.Range(0, w * h).AsParallel().Select(xy =>
//  {
//    double zx, zy, tmp;
//    int x, y;
//    int i = maxiter;
//    y = xy / w;
//    x = xy % w;
//    zx = 1.5 * (x - w / 2) / (0.5 * zoom * w) + moveX;
//    zy = 1.0 * (y - h / 2) / (0.5 * zoom * h) + moveY;
//    while (zx * zx + zy * zy < 4 && i > 1) {
//      tmp = zx * zx - zy * zy + cX;
//      zy = 2.0 * zx * zy + cY;
//      zx = tmp;
//      i -= 1;
//    }
//    return new CalculatedPoint { x = x, y = y, i = i };
//  });

//  // Bitmap is not multi-threaded, so main thread needs to read in the results as they
//  // come in and plot the pixels.
//  var bitmap = new Bitmap(w, h);
//  foreach (CalculatedPoint cp in calculatedPoints)
//    bitmap.SetPixel(cp.x, cp.y, colors[cp.i]);
//  bitmap.Save("julia-set-multi.png");
//}
*/

/*
 * 
 * if w >= 380 and w < 440:
    R = -(w - 440.) / (440. - 380.)
    G = 0.0
    B = 1.0
elif w >= 440 and w < 490:
    R = 0.0
    G = (w - 440.) / (490. - 440.)
    B = 1.0
elif w >= 490 and w < 510:
    R = 0.0
    G = 1.0
    B = -(w - 510.) / (510. - 490.)
elif w >= 510 and w < 580:
    R = (w - 510.) / (580. - 510.)
    G = 1.0
    B = 0.0
elif w >= 580 and w < 645:
    R = 1.0
    G = -(w - 645.) / (645. - 580.)
    B = 0.0
elif w >= 645 and w <= 780:
    R = 1.0
    G = 0.0
    B = 0.0
else:
    R = 0.0
    G = 0.0
    B = 0.0
*/

/*string text = "voorbeeld tekst";
   //Rectangle ZoomTgtArea = new Rectangle(300, 500, 200, 200);
   //// Point zoomOrigin = Point.Empty;   // updated in MouseMove when button is pressed
   //float zoomFactor = 2f;
   //private void DrawStuff(Graphics g, Point z) {
   //  bool isZoomed = g.Transform.Elements[0] != 1
   //              || g.Transform.OffsetX != 0 | g.Transform.OffsetY != 0;
   //  if (isZoomed)
   //    g.Clear(Color.Gainsboro);   // pick your back color

//  // all your drawing here!
//  Rectangle r = new Rectangle(10, 10, 500, 800);  // some size
//  using (Font f = new Font("Tahoma", 11f))
//    g.DrawString(text + z.X + "-" + z.Y, f, Brushes.DarkSlateBlue, r);
//}
//public void doZoomedPainting(Graphics g, Point zoomCenter, bool fixedZoom) {
//  //zoomCenter or zoomOrigin = e.Location 
//  // normal drawing
//  DrawStuff(g, zoomCenter);

//  // for the movable zoom we want a small correction
//  Rectangle cr = pictureBox.ClientRectangle;
//  float pcw = cr.Width / (cr.Width - ZoomTgtArea.Width / 2f);
//  float pch = cr.Height / (cr.Height - ZoomTgtArea.Height / 2f);

//  // now we prepare the graphics object; note: order matters!
//  g.SetClip(ZoomTgtArea);
//  // we can either follow the mouse or keep the output area fixed:
//  if (fixedZoom)
//    g.TranslateTransform(ZoomTgtArea.X - zoomCenter.X * zoomFactor,
//                                    ZoomTgtArea.Y - zoomCenter.Y * zoomFactor);
//  else
//    g.TranslateTransform(-zoomCenter.X * zoomFactor * pcw,
//                                    -zoomCenter.Y * zoomFactor * pch);
//  // finally zoom
//  g.ScaleTransform(zoomFactor, zoomFactor);

//  // and display zoomed
//  DrawStuff(g, zoomCenter);
//}
//class CustomProgressBar : ProgressBar {
//  //Property to set to decide whether to print a % or Text
//  public ProgressBarDisplayText DisplayStyle { get; set; }

//  //Property to hold the custom text
//  public String CustomText { get; set; }

//  public CustomProgressBar() {
//    // Modify the ControlStyles flags
//    //http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
//    SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
//  }

//  protected override void OnPaint(PaintEventArgs e) {
//    Rectangle rect = ClientRectangle;
//    Graphics g = e.Graphics;

//    ProgressBarRenderer.DrawHorizontalBar(g, rect);
//    rect.Inflate(-3, -3);
//    if (Value > 0) {
//      // As we doing this ourselves we need to draw the chunks on the progress bar
//      Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
//      ProgressBarRenderer.DrawHorizontalChunks(g, clip);
//    }

//    // Set the Display text (Either a % amount or our custom text
//    string text = DisplayStyle == ProgressBarDisplayText.Percentage ? Value.ToString() + '%' : CustomText;


//    using (Font f = new Font(FontFamily.GenericSerif, 10)) {

//      SizeF len = g.MeasureString(text, f);
//      // Calculate the location of the text (the middle of progress bar)
//      // Point location = new Point(Convert.ToInt32((rect.Width / 2) - (len.Width / 2)), Convert.ToInt32((rect.Height / 2) - (len.Height / 2)));
//      Point location = new Point(Convert.ToInt32((Width / 2) - len.Width / 2), Convert.ToInt32((Height / 2) - len.Height / 2));
//      // The commented-out code will centre the text into the highlighted area only. This will centre the text regardless of the highlighted area.
//      // Draw the custom text
//      g.DrawString(text, f, Brushes.Red, location);
//    }
//  }
//}
//}
//Sample WinForms Application
//  using System;
//using System.Linq;
//using System.Windows.Forms;
//using System.Collections.Generic;

//namespace ProgressBarSample {
//  public partial class Form1 : Form {
//    public Form1() {
//      InitializeComponent();
//      // Set our custom Style (% or text)
//      customProgressBar1.DisplayStyle = ProgressBarDisplayText.CustomText;
//      customProgressBar1.CustomText = "Initialising";
//    }

//    private void btnReset_Click(object sender, EventArgs e) {
//      customProgressBar1.Value = 0;
//      btnStart.Enabled = true;
//    }

//    private void btnStart_Click(object sender, EventArgs e) {
//      btnReset.Enabled = false;
//      btnStart.Enabled = false;

//      for (int i = 0; i < 101; i++) {

//        customProgressBar1.Value = i;
//        // Demo purposes only
//        System.Threading.Thread.Sleep(100);

//        // Set the custom text at different intervals for demo purposes
//        if (i > 30 && i < 50) {
//          customProgressBar1.CustomText = "Registering Account";
//        }

//        if (i > 80) {
//          customProgressBar1.CustomText = "Processing almost complete!";
//        }

//        if (i >= 99) {
//          customProgressBar1.CustomText = "Complete";
//        }
//      }

//      btnReset.Enabled = true;


//    }


//  }
//}
*/

/*
* 
* 
* 
* /*----------------------------------------------------------------------+
|   Title:  MandelbrotColorPlane.java                                   |
|                                                                       |
|   Author: David E. Joyce                                              |
|           Department of Mathematics and Computer Science              |
|           Clark University                                            |
|           Worcester, MA 01610-1477                                    |
|           U.S.A.                                                      |                                                                       |
|           http://aleph0.clarku.edu/~djoyce/                           |
|                                                                       |
|   Date:   January, 2003.                                              |
+----------------------------------------------------------------------*/
/*
import java.awt.Color;

public class MandelbrotColorPlane extends ColorPlane {

  private int resolution;
private int parPlane;
private int wrap;
private int escape;
private int pattern;
private double bound, bound2;

public static final double MYERBERG = 1.401155189;

public static final int MU = 0;
public static final int LAMBDA = 1;              //  mu = lambda^2/4 - lambda/2
public static final int RECIPMU = 2;             //   1/mu
public static final int RECIPMUPLUSFOURTH = 3;   //   1/(mu+.25)
public static final int RECIPLAMBDA = 4;         //   1/lambda
public static final int RECIPLAMBDAMINUSONE = 5; //   1/(lambda-1)
public static final int RECIPMUMINUSMYER = 6; //   1/(mu-1.401)

public static final int CIRCLE_ESCAPE = 0;
public static final int SQUARE_ESCAPE = 1;
public static final int STRIP_ESCAPE = 2;
public static final int HALFPLANE_ESCAPE = 3;

public static final int PLAIN_PATTERN = 0;
public static final int FEATHERED_PATTERN = 1;
public static final int BINARY_PATTERN = 2;
public static final int GRAYSCALE_PATTERN = 3;
public static final int ZEBRA_PATTERN = 4;
private static final double[] BOUND_VALUE = { 2.0, 20.0, 5.0, 2.0, 5.0 };

public MandelbrotColorPlane(int resolution, int parPlane, int wrap, int escape, int pattern) {
  setResolution(resolution);
  setParPlane(parPlane);
  setWrap(wrap);
  setEscape(escape);
  setPattern(pattern);
}

public void setResolution(int resolution) { this.resolution = resolution; }

public void setParPlane(int parPlane) { this.parPlane = parPlane; }

public void setWrap(int wrap) { this.wrap = wrap; }

public void setEscape(int escape) { this.escape = escape; }

public void setPattern(int pattern) {
  this.pattern = pattern;
  bound = BOUND_VALUE[pattern];
  bound2 = bound * bound;
}

public static Complex convert(Complex z, int oldPlane, int newPlane) {
  if (oldPlane == newPlane)
    return new Complex(z);
  // first convert from the old plane to either the lambda or the mu plane
  if (oldPlane != MU && oldPlane != LAMBDA) {
    z = z.reciprocal();
    if (oldPlane == RECIPMUPLUSFOURTH)
      z = z.minus(0.25);
    else if (oldPlane == RECIPLAMBDAMINUSONE)
      z = z.plus(1.0);
    else if (oldPlane == RECIPMUMINUSMYER)
      z = z.plus(MYERBERG);
  } // if
    // next, convert to mu or lambda as necessary
  if (oldPlane == LAMBDA || oldPlane == RECIPLAMBDA || oldPlane == RECIPLAMBDAMINUSONE) {
    if (newPlane != LAMBDA && newPlane != RECIPLAMBDA && newPlane != RECIPLAMBDAMINUSONE) {
      // convert lambda to mu.  mu = (lambda/2)^2 - (lambda/2)
      z = z.over(2.0);
      z = z.times(z).minus(z);
    } // if
  }
  else {
    if (newPlane == LAMBDA || newPlane == RECIPLAMBDA || newPlane == RECIPLAMBDAMINUSONE) {
      // convert mu to lambda.  lambda = 1 + sqrt(1+4mu)
      z = z.times(4.0).plus(1.0);
      z = z.sqrt().plus(1.0);
    } // if
  } // if/else
    // finally, convert to the new plane
  switch (newPlane) {
    case MU: return z;
    case LAMBDA: return z;
    case RECIPMU: return z.reciprocal();
    case RECIPMUPLUSFOURTH: return z.plus(0.25).reciprocal();
    case RECIPLAMBDA: return z.reciprocal();
    case RECIPLAMBDAMINUSONE: return z.minus(1.0).reciprocal();
    case RECIPMUMINUSMYER: return z.minus(MYERBERG).reciprocal();
  } // switch
  return z;  // never used, but makes compiler happy
} // convert

private boolean escaped(double s, double t) {
  switch (escape) {
    case CIRCLE_ESCAPE:
      return s * s + t * t >= bound2;
    case SQUARE_ESCAPE:
      return Math.abs(s) >= bound || Math.abs(t) >= bound;
    case STRIP_ESCAPE:
      return Math.abs(s) >= bound;
    case HALFPLANE_ESCAPE:
      return s >= bound;
  } // switch
  return true; // never used, but makes compiler happy
} // escaped

// Determine whether the point z=x+iy lies in the Mandelbrot set or not.
public Color valueAt(double x, double y) {
  Complex z = new Complex(x, y);
  // First, change (x,y) to be a point in the mu-plane, if it isn't in it yet.
  z = convert(z, parPlane, MU);
  x = z.x;
  y = z.y;

  // Next check to see if z + 1/4 lies inside the cardioid
  // given by the polar inequality  r < (1+cos theta)/2.  In rectangular
  // coordinates this becomes  (s^2 + t^2 - s/2)^2 < (s^2 + t^2)/4 where
  // (s,t) is (x + 1/4, y).  If so, z lies inside the set
  double s = x + 0.25;
  double t = y;
  double ss = s * s;
  double tt = y * y;
  double left = (ss + tt - s * 0.5);
  if (left * left < (ss + tt) * 0.25)
    return Color.black;

  // Now see how many iterates of 0 it takes to reach the escape criterion
  // These computations do not use the Complex class for sake of speed
  s = 0.0;
  t = 0.0;
  int k = 0;
  for (k = 0; !escaped(s, t) && k < resolution; k++) {
    ss = s * s - t * t;
    tt = 2.0 * s * t;
    s = ss - x;
    t = tt - y;
  } // for

  if (k == resolution)
    return Color.black;

  if (pattern == ZEBRA_PATTERN)
    return (k % 2 == 0) ? Color.black : Color.white;

  if (pattern == FEATHERED_PATTERN) {
    if (Math.abs(s) < bound || Math.abs(t) < bound)
      return Color.black;
  }

  if (pattern == GRAYSCALE_PATTERN) {
    double bright = (wrap * k % resolution) / (0.0 + resolution);
    if (bright < 0.5)
      bright = 1.0 - 1.2 * bright;
    else
      bright = -0.2 + 1.2 * bright;
    int cidx = Color.HSBtoRGB(0.0f, 0.0f, (float)(bright));
    return new Color(cidx);
  }

  double hue = (wrap * k % resolution) / (0.0 + resolution);
  if (pattern == BINARY_PATTERN && t > 0)
    hue = (hue < 0.8) ? hue + 0.2 : hue - 0.8;
  int cidx = Color.HSBtoRGB((float)(hue), 1.0f, 1.0f);
  return new Color(cidx);
}

public String toString() {
  return "[" + resolution + "," + parPlane + "," + wrap + "," + escape + "," + pattern + "]";
} // toString

} // MandelbrotColorPlane


  
/*----------------------------------------------------------------------+
|   Title:  ColorPlane.java                                             |
|                                                                       |
|   Author: David E. Joyce                                              |
|           Department of Mathematics and Computer Science              |
|           Clark University                                            |
|           Worcester, MA 01610-1477                                    |
|           U.S.A.                                                      |                                                                       |
|           http://aleph0.clarku.edu/~djoyce/                           |
|                                                                       |
|   Date:   January, 2003.                                              |
+----------------------------------------------------------------------*/
/*
import java.awt.Color;

public class ColorPlane {

  public Color valueAt(double x, double y) {
    return null;
  }

} // ColorPlane
  */

 /*
  //public static void ColorToHSV(Color color, out double hue, out double saturation, out double value) {
//  int max = Math.Max(color.R, Math.Max(color.G, color.B));
//  int min = Math.Min(color.R, Math.Min(color.G, color.B));

//  hue = color.GetHue();
//  saturation = (max == 0) ? 0 : 1d - (1d * min / max);
//  value = max / 255d;
//}
//public static Color ColorFromHSV(double hue, double saturation, double value) {
//  int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
//  double f = hue / 60 - Math.Floor(hue / 60);

//  value = value * 255;
//  int v = Convert.ToInt32(value);
//  int p = Convert.ToInt32(value * (1 - saturation));
//  int q = Convert.ToInt32(value * (1 - f * saturation));
//  int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

//  if (hi == 0)
//    return Color.FromArgb(255, v, t, p);
//  else if (hi == 1)
//    return Color.FromArgb(255, q, v, p);
//  else if (hi == 2)
//    return Color.FromArgb(255, p, v, t);
//  else if (hi == 3)
//    return Color.FromArgb(255, p, q, v);
//  else if (hi == 4)
//    return Color.FromArgb(255, t, p, v);
//  else
//    return Color.FromArgb(255, v, p, q);
//}
//private static Color MapColor(int i, double r, double c) {
//  double di = (double)i;
//  double zn;
//  double hue;

//  zn = Math.Sqrt(Math.Abs(r * r + c * c));
//  double logs = Math.Log(Math.Log(Math.Abs(zn)));
//  if (double.IsNaN(logs))
//    logs = 1;
//  hue = di + 1.0 - logs / Math.Log(2.0);  // 2 is escape radius
//  hue = 0.95 + 20.0 * hue; // adjust to make it prettier
//                           // the hsv function expects values from 0 to 360
//  while (hue > 360.0)
//    hue -= 360.0;
//  while (hue < 0.0)
//    hue += 360.0;

//  return ColorFromHSV(hue, 0.8, 1.0);
//}
*/