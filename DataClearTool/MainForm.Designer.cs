namespace DataClearTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_dataPath = new System.Windows.Forms.Label();
            this.txt_dataPath = new System.Windows.Forms.TextBox();
            this.dtPicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_startDate = new System.Windows.Forms.Label();
            this.lbl_endDate = new System.Windows.Forms.Label();
            this.dtPicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.btn_deleteData = new System.Windows.Forms.Button();
            this.lbl_diskSpace = new System.Windows.Forms.Label();
            this.lbl_diskSpaceVale = new System.Windows.Forms.Label();
            this.proBar_diskSpace = new System.Windows.Forms.ProgressBar();
            this.timerDiskInfo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_dataPath
            // 
            this.lbl_dataPath.AutoSize = true;
            this.lbl_dataPath.Location = new System.Drawing.Point(49, 52);
            this.lbl_dataPath.Name = "lbl_dataPath";
            this.lbl_dataPath.Size = new System.Drawing.Size(134, 18);
            this.lbl_dataPath.TabIndex = 0;
            this.lbl_dataPath.Text = "数据存储路径：";
            // 
            // txt_dataPath
            // 
            this.txt_dataPath.Location = new System.Drawing.Point(198, 42);
            this.txt_dataPath.Name = "txt_dataPath";
            this.txt_dataPath.Size = new System.Drawing.Size(293, 28);
            this.txt_dataPath.TabIndex = 1;
            this.txt_dataPath.Text = "E:\\";
            // 
            // dtPicker_startDate
            // 
            this.dtPicker_startDate.CustomFormat = "yyyy-MM-dd";
            this.dtPicker_startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker_startDate.Location = new System.Drawing.Point(198, 105);
            this.dtPicker_startDate.Name = "dtPicker_startDate";
            this.dtPicker_startDate.Size = new System.Drawing.Size(152, 28);
            this.dtPicker_startDate.TabIndex = 2;
            // 
            // lbl_startDate
            // 
            this.lbl_startDate.AutoSize = true;
            this.lbl_startDate.Location = new System.Drawing.Point(49, 115);
            this.lbl_startDate.Name = "lbl_startDate";
            this.lbl_startDate.Size = new System.Drawing.Size(143, 18);
            this.lbl_startDate.TabIndex = 3;
            this.lbl_startDate.Text = "删除-开始日期：";
            // 
            // lbl_endDate
            // 
            this.lbl_endDate.AutoSize = true;
            this.lbl_endDate.Location = new System.Drawing.Point(49, 157);
            this.lbl_endDate.Name = "lbl_endDate";
            this.lbl_endDate.Size = new System.Drawing.Size(143, 18);
            this.lbl_endDate.TabIndex = 4;
            this.lbl_endDate.Text = "删除-结束日期：";
            // 
            // dtPicker_endDate
            // 
            this.dtPicker_endDate.CustomFormat = "yyyy-MM-dd";
            this.dtPicker_endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker_endDate.Location = new System.Drawing.Point(198, 147);
            this.dtPicker_endDate.Name = "dtPicker_endDate";
            this.dtPicker_endDate.Size = new System.Drawing.Size(152, 28);
            this.dtPicker_endDate.TabIndex = 5;
            // 
            // btn_deleteData
            // 
            this.btn_deleteData.Location = new System.Drawing.Point(358, 206);
            this.btn_deleteData.Name = "btn_deleteData";
            this.btn_deleteData.Size = new System.Drawing.Size(133, 41);
            this.btn_deleteData.TabIndex = 6;
            this.btn_deleteData.Text = "删除";
            this.btn_deleteData.UseVisualStyleBackColor = true;
            this.btn_deleteData.Click += new System.EventHandler(this.Btn_deleteData_Click);
            // 
            // lbl_diskSpace
            // 
            this.lbl_diskSpace.AutoSize = true;
            this.lbl_diskSpace.Location = new System.Drawing.Point(49, 293);
            this.lbl_diskSpace.Name = "lbl_diskSpace";
            this.lbl_diskSpace.Size = new System.Drawing.Size(116, 18);
            this.lbl_diskSpace.TabIndex = 7;
            this.lbl_diskSpace.Text = "工作盘空间：";
            // 
            // lbl_diskSpaceVale
            // 
            this.lbl_diskSpaceVale.AutoSize = true;
            this.lbl_diskSpaceVale.Location = new System.Drawing.Point(456, 293);
            this.lbl_diskSpaceVale.Name = "lbl_diskSpaceVale";
            this.lbl_diskSpaceVale.Size = new System.Drawing.Size(62, 18);
            this.lbl_diskSpaceVale.TabIndex = 8;
            this.lbl_diskSpaceVale.Text = "剩余NG";
            // 
            // proBar_diskSpace
            // 
            this.proBar_diskSpace.Location = new System.Drawing.Point(171, 288);
            this.proBar_diskSpace.Name = "proBar_diskSpace";
            this.proBar_diskSpace.Size = new System.Drawing.Size(279, 23);
            this.proBar_diskSpace.TabIndex = 9;
            // 
            // timerDiskInfo
            // 
            this.timerDiskInfo.Interval = 1000;
            this.timerDiskInfo.Tick += new System.EventHandler(this.timerDiskInfo_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 344);
            this.Controls.Add(this.proBar_diskSpace);
            this.Controls.Add(this.lbl_diskSpaceVale);
            this.Controls.Add(this.lbl_diskSpace);
            this.Controls.Add(this.btn_deleteData);
            this.Controls.Add(this.dtPicker_endDate);
            this.Controls.Add(this.lbl_endDate);
            this.Controls.Add(this.lbl_startDate);
            this.Controls.Add(this.dtPicker_startDate);
            this.Controls.Add(this.txt_dataPath);
            this.Controls.Add(this.lbl_dataPath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据清理工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_dataPath;
        private System.Windows.Forms.TextBox txt_dataPath;
        private System.Windows.Forms.DateTimePicker dtPicker_startDate;
        private System.Windows.Forms.Label lbl_startDate;
        private System.Windows.Forms.Label lbl_endDate;
        private System.Windows.Forms.DateTimePicker dtPicker_endDate;
        private System.Windows.Forms.Button btn_deleteData;
        private System.Windows.Forms.Label lbl_diskSpace;
        private System.Windows.Forms.Label lbl_diskSpaceVale;
        private System.Windows.Forms.ProgressBar proBar_diskSpace;
        private System.Windows.Forms.Timer timerDiskInfo;
    }
}

