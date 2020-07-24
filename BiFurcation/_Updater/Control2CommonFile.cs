using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace BiFurcation {

  public class Control2CommonFile {

    public static string FileName(string path) {
      if (String.IsNullOrEmpty(path))
        return "";
      if (path.StartsWith("/"))
        path = path.Substring(1);
      int dot = path.LastIndexOf(Path.DirectorySeparatorChar);
      string result = path.Substring(dot + 1);
      return result;
    }
    public static DateTime FileTimeStamp(string uri) {
      Uri serverUri = new Uri(uri);
      DateTime stamp = new DateTime();
      try {
        FtpWebRequest Request = (FtpWebRequest)WebRequest.Create(serverUri);
        Request.Credentials = UpdateSetting.Credentials;
        Request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
        Request.UseBinary = false;
        Request.Timeout = 20000;
        try {
          using FtpWebResponse Response = (FtpWebResponse)Request.GetResponse();
          stamp = Response.LastModified;
        }
        catch (Exception e) {
          if (e.Message.Contains("Remote name could not be resolved"))
            stamp = new DateTime(1, 1, 1);
          else
            stamp = new DateTime(1, 5, 31);
        }
      }
      catch { }
      return stamp;
    }
    public static bool CheckAndDownloadApp(DownloadType dlt) {
      if (UpdateSetting.ServerDown)
        return false;
      try {
        DateTime lastUpdateDate = FileTimeStamp(dlt.file2Download);// response1.LastModified;
        DateTime currentVersionDate = System.IO.File.GetLastWriteTime(dlt.PC_Destination);
        TimeSpan span = lastUpdateDate.Subtract(currentVersionDate);

        if (span.Days > 0 || span.Hours * 3600 + span.Minutes * 60 + span.Seconds > 100) {//min 5 min 
          DialogsResult res = DialogsResult.Yes;
          FileInfo file = new FileInfo(Assembly.GetExecutingAssembly().Location);
          res = StaticFormsCalls.DoResult("Nieuwe versie " + FileName(dlt.PC_Destination) + " downloaden?", "Nieuwe versie aanwezig", false);
          if (res == DialogsResult.Yes) {
          //  writeDownloadInfo();
            return true;
          }
        }
      }
      catch (Exception err) {
        StaticFormsCalls.ShowMessage("Update check van " + FileName(dlt.file2Download) + err.Message);
      }
      return false;
    }

  }

}
