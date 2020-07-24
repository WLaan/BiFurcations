using System.Collections.Generic;

namespace AwaitParallelExample {

  public interface IView {

    void clearTextBox();
    void add2ListBox(string list);
    void ReportProgress(object sender, ProgressReportModel e);

  }

}
