using System;
using System.Collections.Generic;

namespace AwaitParallelExample {

  public class ProgressReportModel {

    private List<WebsiteDataModel> sitesDownloaded = new List<WebsiteDataModel>();
    public List<WebsiteDataModel> SitesDownloaded {
      get {
        return sitesDownloaded;
      }
      set {
        sitesDownloaded = value;
      }
    }
    public int PercentageComplete { get; set; } = 0;
    public string GetLastAdded {
      get {
        if (sitesDownloaded.Count > 0) {
          WebsiteDataModel data = sitesDownloaded[^1];
          return data.WebsiteData.Length.ToString("0000000") + " characters long: " + data.WebsiteUrl + " downloaded:" + Environment.NewLine;
        }
        else
          return "";
      }
    }

    public ProgressReportModel() {
    }

  }

}
