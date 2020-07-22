using System;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;

namespace Updater {
  public partial class Updater : Form {

    public Updater() {
      InitializeComponent();
    }

    private void setDownProgress(DownloadProgressChangedEventArgs e) {
      if (this.InvokeRequired) {
        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate {
          this.setDownProgress(e);
        })));
      }
      else {
        labelBusyExporting.Visible = true;
        labelBusyExporting.Text = "Gedownload " + e.BytesReceived / 1000 + " van " + e.TotalBytesToReceive / 1000 + " Kbytes. " + (2 * e.ProgressPercentage) + " % compleet...";
        labelBusyExporting.Invalidate();
      }
    }
    private void endImport(bool succes) {
      labelBusyExporting.Visible = false;
      labelBusyExporting.Text = "";
      if (succes) {
        MessageBox.Show("Oude versie opgeslagen als BiFurcation-1.exe", "Import gelukt");
        System.Diagnostics.Process.Start("BiFurcation.exe");
        Dispose();
      }
      else
        MessageBox.Show("Fout bij importeren van BiFurcation.exe: ");
    }
    private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
      setDownProgress(e);
    }
    private void WebClientDownloadCompletedAsync(object sender, AsyncCompletedEventArgs args) {
      endImport(true);
    }
    private void buttonDownload_Click(Object sender, EventArgs e) {
      FileInfo file = new FileInfo(Assembly.GetExecutingAssembly().Location);

      if (File.Exists(file.DirectoryName + Path.DirectorySeparatorChar + "BiFurcation-1.exe"))//file.Name.Replace(file.Extension, "") + "-1" + file.Extension))
        File.Delete(file.DirectoryName + Path.DirectorySeparatorChar + "BiFurcation-1.exe");// file.Name.Replace(file.Extension, "") + "-1" + file.Extension);
      if (File.Exists(file.DirectoryName + Path.DirectorySeparatorChar + "BiFurcation.exe"))
        File.Move(file.DirectoryName + Path.DirectorySeparatorChar + "BiFurcation.exe", file.DirectoryName + Path.DirectorySeparatorChar + "BiFurcation-1.exe");

      try {
        using (WebClient client = new WebClient()) {
          var ur = new Uri(UpdateSetting.RemoteFolder + "/BiFurcation.exe");
          string authInfo = UpdateSetting.AuthInfo;
          authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
          client.Headers["Authorization"] = "Basic " + authInfo;
          client.Credentials = UpdateSetting.Credentials;
          client.DownloadProgressChanged += WebClientDownloadProgressChanged;
          client.DownloadFileCompleted += WebClientDownloadCompletedAsync;

          client.DownloadFileAsync(ur, System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar + "BiFurcation.exe");
        }
      }
      catch { endImport(false); }
    }

  }
}
