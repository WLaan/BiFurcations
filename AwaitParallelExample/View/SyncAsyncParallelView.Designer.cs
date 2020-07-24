namespace AwaitParallelExample {

  partial class SyncAsyncParallelForm {

    #region  Required designer variable.
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button buttonNormal;
    private System.Windows.Forms.Button buttonAsinc;
    #endregion

    #region Windows Form Designer generated code
    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }



    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.label1 = new System.Windows.Forms.Label();
      this.buttonNormal = new System.Windows.Forms.Button();
      this.buttonAsinc = new System.Windows.Forms.Button();
      this.buttonParallel = new System.Windows.Forms.Button();
      this.buttonParallelAsync = new System.Windows.Forms.Button();
      this.buttonCancelOperation = new System.Windows.Forms.Button();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.textBoxResults = new System.Windows.Forms.TextBox();
      this.buttonParallelSync = new System.Windows.Forms.Button();
      this.buttonParallelAsyncV2 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Calibri", 14.25743F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(29, 9);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(689, 26);
      this.label1.TabIndex = 0;
      this.label1.Text = "Await and Parallel example: Use of  ASYNC, AWAIT, TASK and Parallel.ForEach";
      // 
      // buttonNormal
      // 
      this.buttonNormal.Location = new System.Drawing.Point(29, 50);
      this.buttonNormal.Margin = new System.Windows.Forms.Padding(4);
      this.buttonNormal.Name = "buttonNormal";
      this.buttonNormal.Size = new System.Drawing.Size(1170, 59);
      this.buttonNormal.TabIndex = 1;
      this.buttonNormal.Text = "Normal execution";
      this.buttonNormal.UseVisualStyleBackColor = true;
      this.buttonNormal.Click += new System.EventHandler(this.buttonNormal_Click);
      // 
      // buttonAsinc
      // 
      this.buttonAsinc.Location = new System.Drawing.Point(29, 124);
      this.buttonAsinc.Margin = new System.Windows.Forms.Padding(4);
      this.buttonAsinc.Name = "buttonAsinc";
      this.buttonAsinc.Size = new System.Drawing.Size(1170, 59);
      this.buttonAsinc.TabIndex = 1;
      this.buttonAsinc.Text = "Async execution";
      this.buttonAsinc.UseVisualStyleBackColor = true;
      this.buttonAsinc.Click += new System.EventHandler(this.buttonAsinc_Click);
      // 
      // buttonParallel
      // 
      this.buttonParallel.Location = new System.Drawing.Point(324, 195);
      this.buttonParallel.Margin = new System.Windows.Forms.Padding(4);
      this.buttonParallel.Name = "buttonParallel";
      this.buttonParallel.Size = new System.Drawing.Size(282, 59);
      this.buttonParallel.TabIndex = 1;
      this.buttonParallel.Text = "Parallel native async execution";
      this.buttonParallel.UseVisualStyleBackColor = true;
      this.buttonParallel.Click += new System.EventHandler(this.buttonParallelNativeAsync_Click);
      // 
      // buttonParallelAsync
      // 
      this.buttonParallelAsync.Location = new System.Drawing.Point(620, 195);
      this.buttonParallelAsync.Margin = new System.Windows.Forms.Padding(4);
      this.buttonParallelAsync.Name = "buttonParallelAsync";
      this.buttonParallelAsync.Size = new System.Drawing.Size(282, 59);
      this.buttonParallelAsync.TabIndex = 1;
      this.buttonParallelAsync.Text = "Parallel own async execution";
      this.buttonParallelAsync.UseVisualStyleBackColor = true;
      this.buttonParallelAsync.Click += new System.EventHandler(this.buttonParallelAsync_Click);
      // 
      // buttonCancelOperation
      // 
      this.buttonCancelOperation.Location = new System.Drawing.Point(29, 295);
      this.buttonCancelOperation.Margin = new System.Windows.Forms.Padding(4);
      this.buttonCancelOperation.Name = "buttonCancelOperation";
      this.buttonCancelOperation.Size = new System.Drawing.Size(1170, 59);
      this.buttonCancelOperation.TabIndex = 1;
      this.buttonCancelOperation.Text = "Cancel opperation";
      this.buttonCancelOperation.UseVisualStyleBackColor = true;
      this.buttonCancelOperation.Click += new System.EventHandler(this.buttonCancelOperationc_Click);
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(29, 362);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(1166, 23);
      this.progressBar.TabIndex = 3;
      // 
      // textBoxResults
      // 
      this.textBoxResults.Location = new System.Drawing.Point(29, 399);
      this.textBoxResults.Multiline = true;
      this.textBoxResults.Name = "textBoxResults";
      this.textBoxResults.Size = new System.Drawing.Size(1166, 353);
      this.textBoxResults.TabIndex = 4;
      // 
      // buttonParallelSync
      // 
      this.buttonParallelSync.Location = new System.Drawing.Point(29, 195);
      this.buttonParallelSync.Margin = new System.Windows.Forms.Padding(4);
      this.buttonParallelSync.Name = "buttonParallelSync";
      this.buttonParallelSync.Size = new System.Drawing.Size(282, 59);
      this.buttonParallelSync.TabIndex = 1;
      this.buttonParallelSync.Text = "Parallel Sync execution (frozen form)";
      this.buttonParallelSync.UseVisualStyleBackColor = true;
      this.buttonParallelSync.Click += new System.EventHandler(this.buttonParallelSync_Click);
      // 
      // buttonParallelAsyncV2
      // 
      this.buttonParallelAsyncV2.Location = new System.Drawing.Point(917, 195);
      this.buttonParallelAsyncV2.Margin = new System.Windows.Forms.Padding(4);
      this.buttonParallelAsyncV2.Name = "buttonParallelAsyncV2";
      this.buttonParallelAsyncV2.Size = new System.Drawing.Size(282, 59);
      this.buttonParallelAsyncV2.TabIndex = 1;
      this.buttonParallelAsyncV2.Text = "Parallel own async execution V2 with progress";
      this.buttonParallelAsyncV2.UseVisualStyleBackColor = true;
      this.buttonParallelAsyncV2.Click += new System.EventHandler(this.buttonParallelAsyncV2_Click);
      // 
      // SyncAsyncParallelForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1238, 791);
      this.Controls.Add(this.buttonParallelAsyncV2);
      this.Controls.Add(this.buttonParallelSync);
      this.Controls.Add(this.textBoxResults);
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.buttonCancelOperation);
      this.Controls.Add(this.buttonParallelAsync);
      this.Controls.Add(this.buttonParallel);
      this.Controls.Add(this.buttonAsinc);
      this.Controls.Add(this.buttonNormal);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Calibri", 12.11881F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "SyncAsyncParallelForm";
      this.Text = "Asinc & Parallel examples";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonParallel;
    private System.Windows.Forms.Button buttonParallelAsync;
    private System.Windows.Forms.Button buttonCancelOperation;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.TextBox textBoxResults;
    private System.Windows.Forms.Button buttonParallelSync;
    private System.Windows.Forms.Button buttonParallelAsyncV2;
  }
}

