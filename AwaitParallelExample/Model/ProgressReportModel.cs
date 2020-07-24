using System;
using System.Collections.Generic;

namespace AwaitParallelExample {

  public class ProgressReportModel {
    public List<WebsiteDataModel> SitesDownloaded { get; set; } = new List<WebsiteDataModel>();
    public int PercentageComplete { get; set; } = 0;
    public string GetLastAdded {
      get {
        if (SitesDownloaded.Count > 0) {
          WebsiteDataModel data = SitesDownloaded[^1];
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
