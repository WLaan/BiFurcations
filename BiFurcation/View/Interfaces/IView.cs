using System.Drawing;

namespace BiFurcation {

  public interface IView {

    Bitmap FormImage {
      set;
      get;
    }
    void setProgressBar(int max);
    void worker_ProgressChanged(int perc);
    void setEnabled(bool en);
    void endGenerate();
    int GIFProgress {
      set;
    }
    void params2Form();

  }
}
