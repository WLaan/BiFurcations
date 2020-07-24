using System;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace BiFurcation {

  public class Control4AllViews {

    protected CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
    public Control4FunctionsView control4FunctionsView;
    private Control4NonLineairSystems control4NonLineairSystems;
    public Control4NonLineairSystems Control4NonLineairSystems {
      get {
        return control4NonLineairSystems;
      }
      set {
        if (control4NonLineairSystems == null)
          control4NonLineairSystems = value;
        else {
          control4NonLineairSystems = value;
          var t = new Thread(() => control4NonLineairSystems.PresetPlotter(FractalType.Mandelbrot));
          t.Start();
        }
      }
    }

    public DefineColorsForm defColorForm;
    private Control4DiagramView control4DiagramView;
    public Control4DiagramView Control4DiagramView {
      get {
        return control4DiagramView;
      }
      set {
        control4DiagramView = value;
      }
    }

    public Control4AllViews(IFunctionsView i) {
      defColorForm = DefineColorsForm.GetInvisible;
      control4FunctionsView = new Control4FunctionsView(i);
      Control4NonLineairSystems = new Control4NonLineairSystems(i);
      Control4DiagramView = new Control4DiagramView(i);

      NonLineairSystemsForm m = NonLineairSystemsForm.GetInvisible;
      control4NonLineairSystems = new Control4NonLineairSystems(m, this);
      m.Control4NonLineairSystems = control4NonLineairSystems;
      control4NonLineairSystems.PlotForm = m;//needed to define colors when this form is not yet opened
      ((ICombined)Control4NonLineairSystems.PlotForm).presetType();
      Control4NonLineairSystems.PlotForm.params2Form();

      defColorForm.Control4DiagramView = Control4DiagramView;
      defColorForm.Control4FunctionsView = control4FunctionsView;
    }

    public void StartImageEditor(Image image) {
      if (image == null) return;
      try {
        //Create temporary file name
        string TMP_IMAGE = "temp.jpg";

        //get the folder of application
        string PATH_APP = System.IO.Path.GetDirectoryName(StaticFormsCalls.StartupPath) + @"\tempImage\";

        //Create a subFolder tempImage
        System.IO.Directory.CreateDirectory(PATH_APP);

        //Save a new path in a variable
        String NEW_PATH = PATH_APP + TMP_IMAGE;

        //Save the image in the pictureBox in the new path and file name
        image.Save(NEW_PATH, System.Drawing.Imaging.ImageFormat.Jpeg);

        //Lunch the process with defaoul image editor in the comouter
        ProcessStartInfo startInfo = new ProcessStartInfo(NEW_PATH);
        Process.Start(startInfo);

        //image.Save("temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //ProcessStartInfo startInfo = new ProcessStartInfo("temp.jpg");
        //startInfo.Verb = "edit";
        //Process.Start(startInfo);
      }
      catch { }
    }
    public decimal Text2Float(string text) {
      if (String.IsNullOrEmpty(text.Trim()))
        return 0;
      int komma = text.IndexOf(",");
      if (komma >= 0)
        text = text.Substring(0, komma) + "." + text.Substring(komma + 1);
      decimal d = 0;
      try {
        d = decimal.Parse(text, culture);
      }
      catch { }
      return d;
    }

    public void OpenColorDefView() {
      defColorForm.Control4FunctionsView = control4FunctionsView;
      defColorForm.BringToFront();
      defColorForm.Show();
      defColorForm.Refresh();
    }
    public void OpenSystem2Form() {
      NonLineairSystemsForm m = NonLineairSystemsForm.Instance;
      m.Control4NonLineairSystems = Control4NonLineairSystems;
      ((ICombined)Control4NonLineairSystems.PlotForm).presetType();
      m.Show();
      m.BringToFront();
    }

  }

}
