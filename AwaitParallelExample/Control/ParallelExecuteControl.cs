using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AwaitParallelExample {

  //you can move the form aound while executing AND fast executed
  public class ParallelExecuteControl:BaseControl {

    public ParallelExecuteControl(IView f):base(f) {     
    }

    private List<WebsiteDataModel> RunDownloadParallelSync() {
      List<string> websites = model.Websites;
      List<WebsiteDataModel> output = new List<WebsiteDataModel>();
      Parallel.ForEach<string>(websites, (site) => {
        WebsiteDataModel results = DownloadWebsite(site);
        output.Add(results);
      });
      return output;
    }
    private async Task RunDownloadParallelNativeAsync() {
      List<string> websites = model.Websites;
      List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>(); 
      foreach (string site in websites) {
        tasks.Add(DownloadWebsiteNativeAsync(site));
      }
      var results = await Task.WhenAll(tasks);
      foreach (var item in results)
        ReportWebsiteInfo(item);
    }
    private async Task<List<WebsiteDataModel>> RunDownloadParallelAsync() {
      List<string> websites = model.Websites;
      List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();
      foreach (string site in websites) {
        tasks.Add(Task.Run(() => DownloadWebsite(site)));
      }
      var results = await Task.WhenAll(tasks);
      return new List<WebsiteDataModel>(results);
    }
    private async Task<List<WebsiteDataModel>> RunDownloadParallelASyncV2(IProgress<ProgressReportModel> progress) {
      List<string> websites = model.Websites;
      List<WebsiteDataModel> output = new List<WebsiteDataModel>();
      ProgressReportModel report = new ProgressReportModel();

      await Task.Run(() => {
        Parallel.ForEach<string>(websites, (site) => {
          WebsiteDataModel results = DownloadWebsite(site);
          output.Add(results);

          report.SitesDownloaded = output;
          report.PercentageComplete = (output.Count * 100) / websites.Count;
          progress.Report(report);
        });
      });
      return output;
    }

    public void ExecuteParallelSync() {
      form.clearTextBox();
      var watch = System.Diagnostics.Stopwatch.StartNew();
      var results = RunDownloadParallelSync();
      PrintResults(results);
      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      form.add2ListBox("Total execution time: " + elapsedMs);
    }
    public async void ExecuteParallelNativeAsync() {
      form.clearTextBox();
      var watch = System.Diagnostics.Stopwatch.StartNew();
      await RunDownloadParallelNativeAsync();
      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      form.add2ListBox("Total execution time: " + elapsedMs);
    }
    public async void ExecuteParallelAsync() {
      form.clearTextBox();
      var watch = System.Diagnostics.Stopwatch.StartNew();
      var results = await RunDownloadParallelAsync();
      PrintResults(results);
      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      form.add2ListBox("Total execution time: " + elapsedMs);
    }
    public async void ExecuteParallelAsyncV2() {
      form.clearTextBox();
      Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
      progress.ProgressChanged += form.ReportProgress;
      var watch = System.Diagnostics.Stopwatch.StartNew();
      var results = await RunDownloadParallelASyncV2(progress);
      PrintResults(results);
      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      form.add2ListBox("Total execution time: " + elapsedMs);
    }

  }

}
