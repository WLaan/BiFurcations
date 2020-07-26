using System.IO;
using System.Drawing;
using System.Xml.Serialization;   // Does XML serializing for a class.
using System.Collections.Generic;

namespace BiFurcation {

  public class Constants {

    public static bool Initalising = true;
    public static Color[] pens = new Color[] { Color.Red,         Color.Blue, Color.DodgerBlue, Color.Purple,        Color.Magenta,
                                               Color.LightYellow, Color.Lime, Color.Maroon,     Color.DarkTurquoise, Color.Black};
    public static int MaxF = 10;

    public static int NumColors = 48;
    public static SmoozedColor[] SmoozedColorTags = new SmoozedColor[NumColors];
    public static int[] DefinedColors = new int[] { -1       ,-16192   ,-8000   ,-64      ,-4128832 ,-4128769 ,-4144897 ,-16129   ,-2039584 ,-32640   ,-16256   ,-128    ,
                                                    -8323200 ,-8323073 ,-8355585,-32513   ,-4144960 ,-65536   ,-32768   ,-256     ,-16728064,-16711681,-16776961,-65281  ,
                                                    -12566464,-4194304 ,-4177920 ,-4145152,-16744448,-16727872,-16777024,-4194112 ,-12566464,-8388608 ,-8372224 ,-8355840,
                                                    -16744448,-16744320,-16777088,-8388480,-16777216,-12582912,-8372160 ,-12566528,-16760832,-16760768,-16777152,-12582848};
    public static double ContrastValue = 20;

    public static Type3Color Type3Color = Type3Color.Blue;
    public static Color[] type3Colors = new Color[] {Color.Red, Color.Green, Color.Blue };

    public static Color FurcationColor = Color.Black;
    public static Color DiagramColor = Color.Black;
    public static Color OneColor = Color.Black;

    public static int FunctionsLineWidth = 1;
    public static int FurcationsLineWidth = 1;
    public static int DiagramLineWidth = 1;


    public static FunctionType currentFunctionType = FunctionType.FixedPolynomial;
    public static double MinimumMU = 1000;
    public static double MaximumMU = -1000;
    public static double MaxMagnitude = 0;
    public static double MinMagnitude = 10000;
    public static bool LineairInterpolation = true;
    private static int InterpolationSteps = 16;
    public static List<SmoozedColor> smoozedColors = new List<SmoozedColor>();
    public static List<Color> smoozedColors1024 = new List<Color>();
    public static int UsedFontSize = 15;
    public static int UsedBSize = 1000;
    private static float P(int j) {
      if (LineairInterpolation) {
        return j;
      }
      else
        return (j - InterpolationSteps) * (j - InterpolationSteps) / (InterpolationSteps * InterpolationSteps);
    }
    private static bool Initialized = false;

    public Constants() {
      if (Initialized) return;//a call to settingsFromXML did the job
      Initialize();
    }

    public static void Initialize() {
      smoozedColors.Clear();
      for (int c = 0; c < 48; c++) {
        SmoozedColorTags[c] = new SmoozedColor(c, -1, 100f / 48);
        SmoozedColorTags[c].color = Color.FromArgb(Constants.DefinedColors[c]);
       // sortedColors[c] = -1;
      }
      SmoozedColorTags[40].index = 0;
      SmoozedColorTags[17].index = 1;
      SmoozedColorTags[20].index = 2;
      SmoozedColorTags[22].index = 3;
      smoozedColors.Add(SmoozedColorTags[40]);//black
      smoozedColors.Add(SmoozedColorTags[17]);//red
      smoozedColors.Add(SmoozedColorTags[20]);//green
      smoozedColors.Add(SmoozedColorTags[22]);//blue

      SortSmoozedColors();
      Initialized = true;
    }

    public static void AddSmoozedColor(int tag, int ind, float f) {
      smoozedColors.Add(new SmoozedColor(tag, ind, f));
    }
    public static void AddSmoozedColorList(bool doInit) {
      Constants.smoozedColors.Clear();
      foreach (SmoozedColor pic in SmoozedColorTags)
        if (pic.index >= 0) 
          Constants.smoozedColors.Add(pic);
      bool switched = true;
      while (switched) {
        switched = false;
        for (int t = 0; t < smoozedColors.Count - 1; t++)
          if (smoozedColors[t].index > smoozedColors[t + 1].index) {
            switched = true;
            SmoozedColor temp = smoozedColors[t];
            smoozedColors[t] = smoozedColors[t + 1];
            smoozedColors[t + 1] = temp;
          }
      }
      if (doInit)
        for (int t = 0; t < Constants.smoozedColors.Count; t++)
          Constants.smoozedColors[t].TrackerPositionPercentage = t * 100f / Constants.smoozedColors.Count + 50f / Constants.smoozedColors.Count;
    }
    public static int SelectedBoxes {
      get {
        int count = 0;
        for (int b = 0; b < SmoozedColorTags.Length; b++)
          if (SmoozedColorTags[b].index >= 0)
            count++;
        return count;
      }
    }
    public static SmoozedColor Tracker4Cursor(int x, Size size) {
      foreach (SmoozedColor s in smoozedColors)
        if (s.CursorInTracker(x, size))
          return s;
      return null;
    }
    public static void SortSmoozedColors() {
      bool switched = true;
      while (switched) {
        switched = false;
        for (int t = 0; t < Constants.smoozedColors.Count - 1; t++)
          if (Constants.smoozedColors[t].TrackerPositionPercentage > Constants.smoozedColors[t + 1].TrackerPositionPercentage) {
            switched = true;
            SmoozedColor temp = Constants.smoozedColors[t];
            Constants.smoozedColors[t] = Constants.smoozedColors[t + 1];
            Constants.smoozedColors[t + 1] = temp;
          }
      }
      for (int t = 0; t < Constants.smoozedColors.Count; t++) {
        Constants.smoozedColors[t].index = t;
        if (t > 0)
          Constants.smoozedColors[t].left = Constants.smoozedColors[t - 1];
        else
          Constants.smoozedColors[t].left = null;
        if (t < Constants.smoozedColors.Count - 1)
          Constants.smoozedColors[t].right = Constants.smoozedColors[t + 1];
        else
          Constants.smoozedColors[t].right = null;
      }
      Interpolate();
    }
    private static void DoInterpolate(Color a, Color b, int start, int stop) {
      float steps = (float)stop;// InterpolationSteps;
      float stepA = (float)(((b.A - a.A) / (steps - 1)));
      float stepR = (float)(((b.R - a.R) / (steps - 1)));
      float stepG = (float)(((b.G - a.G) / (steps - 1)));
      float stepB = (float)(((b.B - a.B) / (steps - 1)));

      for (int j = start; j < stop; j++) {
        float pj = P(j);
        Color cc = Color.FromArgb((int)(a.A + (stepA * pj)),
                                  (int)(a.R + (stepR * pj)),
                                  (int)(a.G + (stepG * pj)),
                                  (int)(a.B + (stepB * pj)));
        smoozedColors1024.Add(cc);
      }
    }
    public static void Interpolate() {
      smoozedColors1024.Clear();
      if (smoozedColors.Count <= 1) {
        if (smoozedColors.Count == 0)
          smoozedColors1024.Add(Color.Black);
        else
          smoozedColors1024.Add(Color.FromArgb(Constants.DefinedColors[0]));
        return;
      }
      int numColors = 1024;
      InterpolationSteps = numColors / (smoozedColors.Count - 1) + 1;
      if (InterpolationSteps == 1)
        InterpolationSteps = 2;

      int steps0 = numColors * (int)(smoozedColors[0].TrackerPositionPercentage) / 100;
      for (int i = 0; i < steps0; i++)
        smoozedColors1024.Add(smoozedColors[0].color);
      for (int i = 0; i < smoozedColors.Count - 1; i++) {
        int steps = numColors * (int)(smoozedColors[i + 1].TrackerPositionPercentage - smoozedColors[i].TrackerPositionPercentage) / 100;
        DoInterpolate(smoozedColors[i].color, smoozedColors[i + 1].color, 0, steps);// Color.FromArgb(Constants.DefinedColors[index1]), Color.FromArgb(Constants.DefinedColors[index2]), 0, steps);
      }
      int steps1 = numColors * (int)(100 - smoozedColors[smoozedColors.Count - 1].TrackerPositionPercentage) / 100;
      for (int i = 0; i < steps1; i++)
        smoozedColors1024.Add(smoozedColors[smoozedColors.Count - 1].color);
    }
    public static void SetColorRange(Image im) {
      int width = im.Width;
      int selectedColors = SelectedBoxes;
      int colorsUsed = Constants.smoozedColors1024.Count;
      if (colorsUsed == 0)
        colorsUsed = 1;
      if (colorsUsed < selectedColors)
        colorsUsed = selectedColors;
      if (colorsUsed > Constants.smoozedColors1024.Count)
        colorsUsed = Constants.smoozedColors1024.Count;
      float delta = (float)(1.0f * width / colorsUsed);
      if (delta == 0) delta = 1;
      float x = 0;
      using Graphics g = Graphics.FromImage(im);
      for (int i = 0; i < colorsUsed; i++) {
        g.FillRectangle(new SolidBrush(Constants.smoozedColors1024[i]), new RectangleF(x, 0, delta, im.Height));
        x += delta;
      }
      float currentX = 0;
      for (int i = 0; i < smoozedColors.Count; i++) {
        SmoozedColor c = smoozedColors[i];
        int x1 = c.LinePosInImage(im.Size);

        if (smoozedColors[i].Tag != 40) {// smoozedColors[i].color != Color.Black) {
          g.DrawLine(Pens.Black, x1, 0, x1, im.Height);
          g.DrawRectangle(Pens.Black, c.TrackerRectangle(im.Size));
        }
        else {
          g.DrawLine(Pens.White, x1, 0, x1, im.Height);
          g.DrawRectangle(Pens.White, c.TrackerRectangle(im.Size));
        }
        currentX += c.WidthPercentageLeft + c.WidthPercentageRight;
      }
    }

    public static void SaveMap(Bitmap map) {
      map.Save("testt.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    #region methods for settings
    public static void SettingsFromXML() {

      XmlSerializer xmlSettingsSerializer = new XmlSerializer(typeof(XMLSettings));
      FileStream ReadFileStream = null;
      try {
        string favName = StaticFormsCalls.StartupPath + Path.DirectorySeparatorChar + "Settings.xml";
        if (!File.Exists(favName))
          Settings2XML();
        ReadFileStream = new FileStream(favName, FileMode.Open, FileAccess.Read, FileShare.Read);
        XMLSettings xmlSettings = (XMLSettings)xmlSettingsSerializer.Deserialize(ReadFileStream);
        ReadFileStream.Close();
        if (xmlSettings != null) {
          pens[0] = Color.FromArgb(xmlSettings.backColor0);
          pens[1] = Color.FromArgb(xmlSettings.backColor1);
          pens[2] = Color.FromArgb(xmlSettings.backColor2);
          pens[3] = Color.FromArgb(xmlSettings.backColor3);
          pens[4] = Color.FromArgb(xmlSettings.backColor4);
          pens[5] = Color.FromArgb(xmlSettings.backColor5);
          pens[6] = Color.FromArgb(xmlSettings.backColor6);
          pens[7] = Color.FromArgb(xmlSettings.backColor7);
          pens[8] = Color.FromArgb(xmlSettings.backColor8);
          pens[9] = Color.FromArgb(xmlSettings.backColor9);

          if (!Initialized) Initialize();

          if (xmlSettings.sortedColors != null) {//first time to use it will be null;
            Constants.smoozedColors.Clear();
            for (int c = 0; c < SmoozedColorTags.Length; c++) {
              SmoozedColorTags[c].index = -1;
              if (xmlSettings.sortedColors[c] >= 0) {
                SmoozedColorTags[c].index = xmlSettings.sortedColors[c];
                SmoozedColorTags[c].TrackerPositionPercentage = xmlSettings.TrackerPositionPercentages[c];
              }
              else {
                SmoozedColorTags[c].index = -1;
                SmoozedColorTags[c].TrackerPositionPercentage = 0;
              }
            }
            AddSmoozedColorList(false);
          }

          Constants.SortSmoozedColors();
          FurcationColor = Color.FromArgb(xmlSettings.FurcationColor);
          OneColor = Color.FromArgb(xmlSettings.OneColor);
          DiagramColor = Color.FromArgb(xmlSettings.DiagramColor);

          FunctionsLineWidth = xmlSettings.FunctionsLineWidth;
          FurcationsLineWidth = xmlSettings.FurcationsLineWidth;
          DiagramLineWidth = xmlSettings.DiagramLineWidth;

         // UsedFontSize = xmlSettings.UsedFontSize;
          currentFunctionType = xmlSettings.functionType;
          Type3Color = xmlSettings.Type3Color;
        }
      }
      catch{ }
      finally {
        if (ReadFileStream != null)
          try {
            ReadFileStream.Close();
            ReadFileStream.Dispose();
          }
          catch { }
      }
    }
    public static void Settings2XML() {
      try {
        string favName = StaticFormsCalls.StartupPath + Path.DirectorySeparatorChar + "Settings.xml";
        XmlSerializer xmlSettingsSerializer = new XmlSerializer(typeof(XMLSettings));
        TextWriter writer = new StreamWriter(favName);
        XMLSettings xmlSettings = new XMLSettings();
        xmlSettingsSerializer.Serialize(writer, xmlSettings);
        writer.Close();
      }
      catch { };
    }
    #endregion

  }
}
