using System.Drawing;

namespace BiFurcation {

  public interface IView {

    Bitmap FormImage {
      set;
      get;
    }
    void SetProgressBar(int max);
    void SetEnabled(bool en);
    void EndGenerate();
    void Params2Form();
    void ReportProgress(object sender, ProgressReportModel e);

  }
}
