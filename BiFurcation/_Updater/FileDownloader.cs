using System;
using System.IO;
using System.Net;
using System.ComponentModel;

namespace BiFurcation {
  public class FileDownloader {

    private readonly string _url;
    private readonly string _fullPathWhereToSave;
    private DownloadType dType = null;

    public FileDownloader(DownloadType dl) {
   //   form = f;
      dType = dl;
      if (string.IsNullOrEmpty(dl.file2Download)) throw new ArgumentNullException("url");
      if (string.IsNullOrEmpty(dl.PC_Destination)) throw new ArgumentNullException("fullPathWhereToSave");

      this._url = dl.file2Download;
      this._fullPathWhereToSave = dl.PC_Destination;
    }

    private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
   //   if (form != null)
   //     form.setDownProgress(e);
    }
    private void WebClientDownloadCompletedAsync(object sender, AsyncCompletedEventArgs args) {
   //   if (form != null)
   //     form.endImport(dType);
    }

    public bool StartDownload() {
      try {
        if (File.Exists(_fullPathWhereToSave))
          File.Delete(_fullPathWhereToSave);
        using WebClient client = new WebClient();
        var ur = new Uri(_url);
        client.Headers["Authorization"] = UpdateSetting.AuthInfo;
        client.Credentials = UpdateSetting.Credentials;
        client.DownloadProgressChanged += WebClientDownloadProgressChanged;
        client.DownloadFileCompleted += WebClientDownloadCompletedAsync;

        client.DownloadFileAsync(ur, _fullPathWhereToSave);
      }
      catch {
        dType.succes = false;
        dType.reportSucces = true;
        return false;
      }
      finally {
      }
      return true;
    }
    public static bool DownloadFile(DownloadType dl) {
      FileDownloader fdl = new FileDownloader(dl);
      return fdl.StartDownload();
    }

    public static bool DownloadSimpelFile(string remoteFilePath, string localDestPath) {
      if (File.Exists(localDestPath))
        File.Delete(localDestPath);
      try {
        using (WebClient client = new WebClient()) {
          var ur = new Uri(remoteFilePath);
          client.Headers["Authorization"] = UpdateSetting.AuthInfo;
          client.Credentials = UpdateSetting.Credentials;
          client.DownloadFile(ur, localDestPath);
          return true;
        }
      }
      catch {
        return false;
      }
    }

  }
  public enum DownloadFileType {
    APP_DLL,
    LockedON,
    BIN,
    Media,
    Infotext,
    None
  }
  public class DownloadType {

    public DownloadFileType type = DownloadFileType.None;
    public string file2Download = "";
    public string PC_Destination = "";
    public int timeout = 1000;
    public bool succes = true;
    public bool reportSucces = false;

    public DownloadType(DownloadFileType t, string remote, string pc_dest) {
      type = t;
      file2Download = remote;
      PC_Destination = pc_dest;
    }

  }

}
