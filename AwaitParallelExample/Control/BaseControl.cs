using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AwaitParallelExample {

  public class BaseControl {

    public IView form;
    protected readonly Model model;
    public static CancellationTokenSource cts = new CancellationTokenSource();

    public BaseControl(IView f) {
      form = f;
      model = new Model();
    }

    protected void ReportWebsiteInfo(WebsiteDataModel data) {
      form.add2ListBox(data.WebsiteData.Length.ToString("0000000") + " characters long.  Downloaded: " + data.WebsiteUrl + Environment.NewLine);
    }
    protected WebsiteDataModel DownloadWebsite(string websiteUrl) {
      WebsiteDataModel output = new WebsiteDataModel();
      WebClient client = new WebClient();

      output.WebsiteUrl = websiteUrl;
      output.WebsiteData = client.DownloadString(websiteUrl);

      return output;
    }
    protected async Task<WebsiteDataModel> DownloadWebsiteNativeAsync(string websiteUrl) {
      WebsiteDataModel output = new WebsiteDataModel();
      WebClient client = new WebClient();

      output.WebsiteUrl = websiteUrl;
      output.WebsiteData = await client.DownloadStringTaskAsync(websiteUrl);

      return output;
    }
    protected void PrintResults(List<WebsiteDataModel> results) {
      form.clearTextBox();
      foreach (var item in results)
        ReportWebsiteInfo(item);
    }

  }

}
