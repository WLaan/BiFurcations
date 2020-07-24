using System.Collections.Generic;

namespace AwaitParallelExample {

  //you can't move the form aound while executing: it is frozen
  public class NormalExecuteControl:BaseControl {

    public NormalExecuteControl(IView f):base(f) {
    }

    private List<WebsiteDataModel> RunDownload() {
      List<string> websites = model.Websites;
      List<WebsiteDataModel> output = new List<WebsiteDataModel>();
      foreach (string site in websites) {
        WebsiteDataModel results = DownloadWebsite(site);
        output.Add(results);
      }
      return output;
    }

    public void ExecuteSinc() {
      var watch = System.Diagnostics.Stopwatch.StartNew();
      var results = RunDownload();//RunDownloadSync
      PrintResults(results);
      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      form.add2ListBox("Total execution time: " + elapsedMs);
    }

  }

}
