using System.Drawing;

namespace BiFurcation {

  public interface ICombined:IView {

    void RescanExamples();
    void PresetType();
    void AddExampleImage(int num, Bitmap map, string name, ExampleGroups group);
    void ReportProgressGif(object sender, ProgressReportModel e);

  }

}
