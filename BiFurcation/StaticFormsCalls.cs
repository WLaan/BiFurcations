namespace BiFurcation {

  public enum DialogsResult {
    Yes,
    No,
    Cancel,
    None
  }
  public class StaticFormsCalls {

#if Forms
    public static string StartupPath = System.Windows.Forms.Application.StartupPath;
    public static DialogsResult DoResult(string text1, string text2, bool withCancel) {
#if Forms
      System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.YesNo;
      if (withCancel)
        buttons = System.Windows.Forms.MessageBoxButtons.YesNoCancel;
      System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(text1, text2, buttons);
      switch (res) {
        case System.Windows.Forms.DialogResult.Yes:
          return DialogsResult.Yes;
        case System.Windows.Forms.DialogResult.No:
          return DialogsResult.No;
        case System.Windows.Forms.DialogResult.Cancel:
          return DialogsResult.Cancel;
      }
#else
      var res = System.Windows.MessageBox.Show(text1, text2, MessageBoxButton.YesNoCancel);
      switch (res) {
        case MessageBoxResult.Yes:
          return VTreeDialogResult.Yes;
        case MessageBoxResult.Cancel:
          return VTreeDialogResult.Cancel;
        case MessageBoxResult.No:
          return VTreeDialogResult.No;
      }
#endif
      return DialogsResult.None;
    }
    public static void ShowMessage(string text) {
#if Forms
      System.Windows.Forms.MessageBox.Show(new System.Windows.Forms.Form { TopMost = true },text);
#endif
    }
#endif
  }

}
