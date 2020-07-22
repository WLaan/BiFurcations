namespace Updater {

  partial class Updater {

    #region fields
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Button buttonDownload;
    private System.Windows.Forms.Label labelBusyExporting;
    #endregion

    #region Windows Form Designer generated code

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
      this.buttonDownload = new System.Windows.Forms.Button();
      this.labelBusyExporting = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // buttonDownload
      // 
      this.buttonDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonDownload.Location = new System.Drawing.Point(30, 30);
      this.buttonDownload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonDownload.Name = "buttonDownload";
      this.buttonDownload.Size = new System.Drawing.Size(226, 37);
      this.buttonDownload.TabIndex = 0;
      this.buttonDownload.Text = "Start Download ..";
      this.buttonDownload.UseVisualStyleBackColor = true;
      this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
      // 
      // labelBusyExporting
      // 
      this.labelBusyExporting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labelBusyExporting.Location = new System.Drawing.Point(30, 73);
      this.labelBusyExporting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelBusyExporting.Name = "labelBusyExporting";
      this.labelBusyExporting.Size = new System.Drawing.Size(226, 19);
      this.labelBusyExporting.TabIndex = 1;
      // 
      // Updater
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SteelBlue;
      this.ClientSize = new System.Drawing.Size(283, 99);
      this.Controls.Add(this.labelBusyExporting);
      this.Controls.Add(this.buttonDownload);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Updater";
      this.Text = "BiFurcation Update downloaden";
      this.ResumeLayout(false);

    }

    #endregion

  }
}

