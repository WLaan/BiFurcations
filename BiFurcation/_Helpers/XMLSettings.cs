using System.Xml.Serialization;

namespace BiFurcation {

  public class XMLSettings {

    #region fields
    [XmlElement]
    public string DefaultLanguage;
    [XmlElement]
    public int backColor0 = 0;
    [XmlElement]
    public int backColor1 = 0;
    [XmlElement]
    public int backColor2 = 0;
    [XmlElement]
    public int backColor3 = 0;
    [XmlElement]
    public int backColor4 = 0;
    [XmlElement]
    public int backColor5 = 0;
    [XmlElement]
    public int backColor6 = 0;
    [XmlElement]
    public int backColor7 = 0;
    [XmlElement]
    public int backColor8 = 0;
    [XmlElement]
    public int backColor9 = 0;

    [XmlElement]
    public int FurcationColor = 40;
    [XmlElement]
    public int OneColor = 40;
    [XmlElement]
    public int DiagramColor = 40;

    [XmlElement]
    public int FunctionsLineWidth = 1;
    [XmlElement]
    public int FurcationsLineWidth = 1;
    [XmlElement]
    public int DiagramLineWidth = 1;

    [XmlElement]
    public int[] sortedColors = new int[48];
    [XmlElement]
    public float[] TrackerPositionPercentages = new float[48];
    [XmlElement]
    public int UsedFontSize = Constants.UsedFontSize;
    [XmlElement]
    public FunctionType functionType = FunctionType.FixedPolynomial;
    [XmlElement]
    public Type3Color Type3Color = Type3Color.Blue;
    #endregion

    public XMLSettings() {
      backColor0 = Constants.pens[0].ToArgb();
      backColor1 = Constants.pens[1].ToArgb(); 
      backColor2 = Constants.pens[2].ToArgb();
      backColor3 = Constants.pens[3].ToArgb();
      backColor4 = Constants.pens[4].ToArgb();
      backColor5 = Constants.pens[5].ToArgb();
      backColor6 = Constants.pens[6].ToArgb();
      backColor7 = Constants.pens[7].ToArgb();
      backColor8 = Constants.pens[8].ToArgb();
      backColor9 = Constants.pens[9].ToArgb();

      FurcationColor = Constants.FurcationColor.ToArgb();
      OneColor = Constants.OneColor.ToArgb();
      DiagramColor = Constants.DiagramColor.ToArgb();

      FunctionsLineWidth = Constants.FunctionsLineWidth;
      FurcationsLineWidth = Constants.FurcationsLineWidth;
      DiagramLineWidth = Constants.DiagramLineWidth;

      for (int s = 0; s < Constants.SmoozedColorTags.Length; s++) {
        SmoozedColor c = Constants.SmoozedColorTags[s];

        if (c != null) {
          TrackerPositionPercentages[c.Tag] = c.TrackerPositionPercentage;
          sortedColors[c.Tag] = c.index;
        }
        else {
          sortedColors[s] = -1;
          TrackerPositionPercentages[s] = 0;
        }
      }
      UsedFontSize = Constants.UsedFontSize;
      functionType = Constants.currentFunctionType;
      Type3Color = Constants.Type3Color;
    }
  }
}
