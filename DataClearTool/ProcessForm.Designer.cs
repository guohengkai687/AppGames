namespace DataClearTool
{
    partial class ProcessForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bakg_work = new System.ComponentModel.BackgroundWorker();
            this.lbl_currentItem = new System.Windows.Forms.Label();
            this.lbl_totalItems = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(34, 31);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(490, 23);
            this.progressBar.TabIndex = 0;
            // 
            // bakg_work
            // 
            this.bakg_work.WorkerReportsProgress = true;
            this.bakg_work.WorkerSupportsCancellation = true;
            this.bakg_work.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bakg_workDoWork);
            this.bakg_work.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bakg_workProgressChanged);
            this.bakg_work.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bakg_eorkRunWorkerCompleted);
            // 
            // lbl_currentItem
            // 
            this.lbl_currentItem.AutoSize = true;
            this.lbl_currentItem.Location = new System.Drawing.Point(31, 67);
            this.lbl_currentItem.Name = "lbl_currentItem";
            this.lbl_currentItem.Size = new System.Drawing.Size(125, 18);
            this.lbl_currentItem.TabIndex = 1;
            this.lbl_currentItem.Text = "正在删除第N条";
            // 
            // lbl_totalItems
            // 
            this.lbl_totalItems.AutoSize = true;
            this.lbl_totalItems.Location = new System.Drawing.Point(462, 66);
            this.lbl_totalItems.Name = "lbl_totalItems";
            this.lbl_totalItems.Size = new System.Drawing.Size(71, 18);
            this.lbl_totalItems.TabIndex = 2;
            this.lbl_totalItems.Text = "总计N条";
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 94);
            this.Controls.Add(this.lbl_totalItems);
            this.Controls.Add(this.lbl_currentItem);
            this.Controls.Add(this.progressBar);
            this.Name = "ProcessForm";
            this.Text = "删除进度";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker bakg_work;
        private System.Windows.Forms.Label lbl_currentItem;
        private System.Windows.Forms.Label lbl_totalItems;
    }
}