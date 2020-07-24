using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace BifurcationCore {
  static class Program {

    //const int Size = 1;
    //public static void InstanceOverheadTest() {
    //  object[] array = new object[Size];
    //  long initialMemory = GC.GetTotalMemory(true);
    //  for (int i = 0; i < Size; i++) {
    //    array[i] = new BiFurcation.DirectBitmap(1000, 1000);
    //  }
    //  long finalMemory = GC.GetTotalMemory(true);
    //  GC.KeepAlive(array);
    //  long total = finalMemory - initialMemory;
    //  Console.WriteLine("Measured size of each element: {0:0.000} bytes",
    //                    ((double)total) / Size);
    //}
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    public static Form MainForm = null;
    [STAThread]
    static void Main() {
     // InstanceOverheadTest();
      AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) => {
        Debug.WriteLine(eventArgs.Exception.ToString());
      };

      System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

      if (!BiFurcation.UpdateSetting.InternetFileName.StartsWith("/")) {
        BiFurcation.UpdateSetting.InternetFileName = "/" + BiFurcation.UpdateSetting.InternetFileName;
      }


      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      bool wait4Update = false;
      if (!String.IsNullOrEmpty(BiFurcation.UpdateSetting.AppIPAddress) && !BiFurcation.UpdateSetting.ServerDown) {

        if (!BiFurcation.UpdateSetting.ServerDown) {
          BiFurcation.DownloadType dlt = new BiFurcation.DownloadType(BiFurcation.DownloadFileType.APP_DLL,
                                              BiFurcation.UpdateSetting.AppIPAddress + BiFurcation.UpdateSetting.AppRemoteFolder + "/BiFurcation.exe",
                                              BiFurcation.StaticFormsCalls.StartupPath + Path.DirectorySeparatorChar + "BiFurcation.exe");
          wait4Update = BiFurcation.Control2CommonFile.CheckAndDownloadApp(dlt);
        }
      }
      if (!wait4Update) {
        BiFurcation.Constants.Initialize();
        BiFurcation.Constants.SettingsFromXML();
        MainForm = new BiFurcation.FunctionsForm();
        try {
          Application.Run(MainForm);
        }
        catch { }
      }
      else {
        System.Diagnostics.Process.Start("Updater.exe");
      }
    }
  }
}
