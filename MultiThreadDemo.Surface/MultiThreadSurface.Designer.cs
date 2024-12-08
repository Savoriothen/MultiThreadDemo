namespace MultiThreadDemo.Surface;

partial class MultiThreadSurface
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _cancellationTokenSource?.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tbSelectedFolder = new System.Windows.Forms.TextBox();
        btnSelectFolder = new System.Windows.Forms.Button();
        lblSelectedFolder = new System.Windows.Forms.Label();
        btnStart = new System.Windows.Forms.Button();
        btnStop = new System.Windows.Forms.Button();
        lblThreadsNo = new System.Windows.Forms.Label();
        nudThreadNo = new System.Windows.Forms.NumericUpDown();
        tbResult = new System.Windows.Forms.TextBox();
        lblElapsedTime = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)nudThreadNo).BeginInit();
        SuspendLayout();
        // 
        // tbSelectedFolder
        // 
        tbSelectedFolder.Location = new System.Drawing.Point(141, 9);
        tbSelectedFolder.Name = "tbSelectedFolder";
        tbSelectedFolder.ReadOnly = true;
        tbSelectedFolder.Size = new System.Drawing.Size(429, 23);
        tbSelectedFolder.TabIndex = 0;
        // 
        // btnSelectFolder
        // 
        btnSelectFolder.Location = new System.Drawing.Point(576, 9);
        btnSelectFolder.Name = "btnSelectFolder";
        btnSelectFolder.Size = new System.Drawing.Size(110, 23);
        btnSelectFolder.TabIndex = 1;
        btnSelectFolder.Text = "Select folder";
        btnSelectFolder.UseVisualStyleBackColor = true;
        btnSelectFolder.Click += btnSelectFolder_Click;
        // 
        // lblSelectedFolder
        // 
        lblSelectedFolder.Location = new System.Drawing.Point(12, 9);
        lblSelectedFolder.Name = "lblSelectedFolder";
        lblSelectedFolder.Size = new System.Drawing.Size(100, 23);
        lblSelectedFolder.TabIndex = 2;
        lblSelectedFolder.Text = "Selected folder:";
        // 
        // btnStart
        // 
        btnStart.Enabled = false;
        btnStart.Location = new System.Drawing.Point(280, 42);
        btnStart.Name = "btnStart";
        btnStart.Size = new System.Drawing.Size(75, 23);
        btnStart.TabIndex = 3;
        btnStart.Text = "Start";
        btnStart.UseVisualStyleBackColor = true;
        btnStart.Click += btnStart_Click;
        // 
        // btnStop
        // 
        btnStop.Enabled = false;
        btnStop.Location = new System.Drawing.Point(361, 42);
        btnStop.Name = "btnStop";
        btnStop.Size = new System.Drawing.Size(75, 23);
        btnStop.TabIndex = 4;
        btnStop.Text = "Stop";
        btnStop.UseVisualStyleBackColor = true;
        btnStop.Click += btnStop_Click;
        // 
        // lblThreadsNo
        // 
        lblThreadsNo.Location = new System.Drawing.Point(12, 42);
        lblThreadsNo.Name = "lblThreadsNo";
        lblThreadsNo.Size = new System.Drawing.Size(123, 23);
        lblThreadsNo.TabIndex = 5;
        lblThreadsNo.Text = "Number of threads:";
        // 
        // nudThreadNo
        // 
        nudThreadNo.Location = new System.Drawing.Point(141, 42);
        nudThreadNo.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
        nudThreadNo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudThreadNo.Name = "nudThreadNo";
        nudThreadNo.Size = new System.Drawing.Size(120, 23);
        nudThreadNo.TabIndex = 7;
        nudThreadNo.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // tbResult
        // 
        tbResult.Location = new System.Drawing.Point(12, 68);
        tbResult.Multiline = true;
        tbResult.Name = "tbResult";
        tbResult.ReadOnly = true;
        tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        tbResult.Size = new System.Drawing.Size(776, 337);
        tbResult.TabIndex = 8;
        // 
        // lblElapsedTime
        // 
        lblElapsedTime.Location = new System.Drawing.Point(12, 418);
        lblElapsedTime.Name = "lblElapsedTime";
        lblElapsedTime.Size = new System.Drawing.Size(236, 23);
        lblElapsedTime.TabIndex = 9;
        // 
        // MultiThreadSurface
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(lblElapsedTime);
        Controls.Add(tbResult);
        Controls.Add(nudThreadNo);
        Controls.Add(lblThreadsNo);
        Controls.Add(btnStop);
        Controls.Add(btnStart);
        Controls.Add(lblSelectedFolder);
        Controls.Add(btnSelectFolder);
        Controls.Add(tbSelectedFolder);
        Location = new System.Drawing.Point(15, 15);
        ((System.ComponentModel.ISupportInitialize)nudThreadNo).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblElapsedTime;

    private System.Windows.Forms.TextBox tbResult;

    private System.Windows.Forms.NumericUpDown nudThreadNo;

    private System.Windows.Forms.Label lblSelectedFolder;
    private System.Windows.Forms.Button btnSelectFolder;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Label lblThreadsNo;

    private System.Windows.Forms.Button btnStart;

    private System.Windows.Forms.TextBox tbSelectedFolder;

    #endregion
}