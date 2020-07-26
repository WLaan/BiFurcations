using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AwaitParallelExample {

  //you can move the form aound while executing
  public class AsyncExecuteControl : BaseControl {

    public AsyncExecuteControl(IView f) : base(f) {
    }

    //Don't return a void with async method!!!
    //Convention: Always add Async to method name that is async
    //if returning a string : async Task<string> RunDownloadASync()
    private async Task<List<WebsiteDataModel>> RunDownloadAsync(IProgress<ProgressReportModel> progress, 
                                                                CancellationToken cancellationToken) {
      List<string> websites = model.Websites;
      List<WebsiteDataModel> output = new List<WebsiteDataModel>();
      ProgressReportModel report = new ProgressReportModel();
      foreach (string site in websites) {
        WebsiteDataModel results = await Task.Run(() => DownloadWebsite(site));
        output.Add(results);

        // if (cancellationToken.IsCancellationRequested){break;}
        cancellationToken.ThrowIfCancellationRequested();

        report.SitesDownloaded = output;
        report.PercentageComplete = (output.Count * 100) / websites.Count;
        progress.Report(report);
        // ReportWebsiteInfo(results);
      }
      return output;
      //if returning a string : 
      //return "Yep";
    }

    public async void ExecuteAsinc() {
      Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
      progress.ProgressChanged += form.ReportProgress;
      cts = new CancellationTokenSource();
      form.clearTextBox();
      var watch = System.Diagnostics.Stopwatch.StartNew();
      try {
        var results = await RunDownloadAsync(progress, cts.Token);
        PrintResults(results);
      }
      catch (OperationCanceledException){
        form.add2ListBox("The async method was cancelled: " + Environment.NewLine);
      }

      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      form.add2ListBox("Total execution time: " + elapsedMs + Environment.NewLine);
    }

  }

}
