using System;
using System.Windows.Forms;

namespace AwaitParallelExample {

  public partial class SyncAsyncParallelForm : Form, IView {

    private NormalExecuteControl NormalExecutions;
    private AsyncExecuteControl AsyncExecutions;
    private ParallelExecuteControl ParallelExecutions;

    public SyncAsyncParallelForm() {
      InitializeComponent();
      NormalExecutions = new NormalExecuteControl(this);
      AsyncExecutions = new  AsyncExecuteControl(this);
      ParallelExecutions = new ParallelExecuteControl(this);
    }

    private void buttonNormal_Click(object sender, EventArgs e) {
      NormalExecutions.ExecuteSinc();
    }
    private void buttonAsinc_Click(object sender, EventArgs e) {
      AsyncExecutions.ExecuteAsinc();
    }

    private void buttonParallelSync_Click(object sender, EventArgs e) {
      ParallelExecutions.ExecuteParallelSync();
    }
    private void buttonParallelNativeAsync_Click(object sender, EventArgs e) {
      ParallelExecutions.ExecuteParallelNativeAsync();
    }
    private void buttonParallelAsync_Click(object sender, EventArgs e) {
      ParallelExecutions.ExecuteParallelAsync();
    }
    private void buttonParallelAsyncV2_Click(object sender, EventArgs e) {
      ParallelExecutions.ExecuteParallelAsyncV2();
    }
    private void buttonCancelOperationc_Click(object sender, EventArgs e) {
      BaseControl.cts.Cancel();
    }

    #region interface
    public void clearTextBox() {
      textBoxResults.Clear();
      textBoxResults.Refresh();
    }
    public void add2ListBox(string list) {
      textBoxResults.Text += list;
      textBoxResults.Refresh();
    }
    public void ReportProgress(object sender, ProgressReportModel e) {
      progressBar.Value = e.PercentageComplete;
      add2ListBox(e.GetLastAdded);
      textBoxResults.Refresh();
    }
    #endregion

  }

}
