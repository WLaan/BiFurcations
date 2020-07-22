using System;
using System.Net;
using System.Text;

namespace BiFurcation {
  public class UpdateSetting {

    public static bool ServerDown = false;
    public static string AppUsername = "willaan";
    public static string AppPassword = "tW[sihQDp8-f";
    public static string AppIPAddress = "ftp://willaan.nl/";
    public static string AppRemoteFolder = "httpdocs/bifurcation";

    public static string InternetFileName = "";

    public static string AuthInfo {
      get {
        return "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(UpdateSetting.AppUsername + ":" + UpdateSetting.AppPassword));
      }
    }
    public static string RemoteFolder {
      get {
        return UpdateSetting.AppIPAddress + UpdateSetting.AppRemoteFolder;
      }
    }
    public static string RemoteFTPPath {
      get {
        return UpdateSetting.RemoteFolder + UpdateSetting.InternetFileName;
      }
    }
    public static NetworkCredential Credentials {
      get {
        return new NetworkCredential(UpdateSetting.AppUsername, UpdateSetting.AppPassword);
      }
    }

  }
}
