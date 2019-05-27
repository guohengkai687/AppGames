namespace FilterToolForFiles
{
    partial class BackgroundWorkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.bakg_worker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbl_totalFiles = new System.Windows.Forms.Label();
            this.lbl_completedFiles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bakg_worker
            // 
            this.bakg_worker.WorkerReportsProgress = true;
            this.bakg_worker.WorkerSupportsCancellation = true;
            this.bakg_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Filter_DoWork);
            this.bakg_worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Filter_ProcessChanged);
            this.bakg_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Filter_RunWorkCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(25, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(558, 33);
            this.progressBar.TabIndex = 0;
            // 
            // lbl_totalFiles
            // 
            this.lbl_totalFiles.AutoSize = true;
            this.lbl_totalFiles.Location = new System.Drawing.Point(22, 70);
            this.lbl_totalFiles.Name = "lbl_totalFiles";
            this.lbl_totalFiles.Size = new System.Drawing.Size(71, 18);
            this.lbl_totalFiles.TabIndex = 1;
            this.lbl_totalFiles.Text = "共计N条";
            // 
            // lbl_completedFiles
            // 
            this.lbl_completedFiles.AutoSize = true;
            this.lbl_completedFiles.Location = new System.Drawing.Point(443, 70);
            this.lbl_completedFiles.Name = "lbl_completedFiles";
            this.lbl_completedFiles.Size = new System.Drawing.Size(89, 18);
            this.lbl_completedFiles.TabIndex = 2;
            this.lbl_completedFiles.Text = "已完成N条";
            // 
            // BackgroundWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 101);
            this.Controls.Add(this.lbl_completedFiles);
            this.Controls.Add(this.lbl_totalFiles);
            this.Controls.Add(this.progressBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackgroundWorkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进度显示界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bakg_worker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbl_totalFiles;
        private System.Windows.Forms.Label lbl_completedFiles;
    }
}