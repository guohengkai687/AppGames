namespace FilterToolForFiles
{
    partial class FilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.btn_select = new System.Windows.Forms.Button();
            this.txt_standardFile = new System.Windows.Forms.TextBox();
            this.btn_filter = new System.Windows.Forms.Button();
            this.data_filterFiles = new System.Windows.Forms.DataGridView();
            this.btn_filesPath = new System.Windows.Forms.Button();
            this.txt_filesPath = new System.Windows.Forms.TextBox();
            this.lbl_totalCount = new System.Windows.Forms.Label();
            this.lbl_distance = new System.Windows.Forms.Label();
            this.txt_distance = new System.Windows.Forms.TextBox();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileCreatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileStandardSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.data_filterFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(29, 20);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(144, 40);
            this.btn_select.TabIndex = 0;
            this.btn_select.Text = "选择准则文件";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.Btn_select_Click);
            // 
            // txt_standardFile
            // 
            this.txt_standardFile.Location = new System.Drawing.Point(179, 20);
            this.txt_standardFile.Name = "txt_standardFile";
            this.txt_standardFile.Size = new System.Drawing.Size(333, 28);
            this.txt_standardFile.TabIndex = 1;
            // 
            // btn_filter
            // 
            this.btn_filter.Location = new System.Drawing.Point(534, 20);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(245, 40);
            this.btn_filter.TabIndex = 2;
            this.btn_filter.Text = "开始筛选";
            this.btn_filter.UseVisualStyleBackColor = true;
            this.btn_filter.Click += new System.EventHandler(this.Btn_filter_Click);
            // 
            // data_filterFiles
            // 
            this.data_filterFiles.AllowUserToAddRows = false;
            this.data_filterFiles.AllowUserToDeleteRows = false;
            this.data_filterFiles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.data_filterFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_filterFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileCreatedTime,
            this.FileSize,
            this.FileStandardSize});
            this.data_filterFiles.Location = new System.Drawing.Point(29, 115);
            this.data_filterFiles.Name = "data_filterFiles";
            this.data_filterFiles.ReadOnly = true;
            this.data_filterFiles.RowTemplate.Height = 30;
            this.data_filterFiles.Size = new System.Drawing.Size(750, 510);
            this.data_filterFiles.TabIndex = 3;
            // 
            // btn_filesPath
            // 
            this.btn_filesPath.Location = new System.Drawing.Point(29, 70);
            this.btn_filesPath.Name = "btn_filesPath";
            this.btn_filesPath.Size = new System.Drawing.Size(144, 40);
            this.btn_filesPath.TabIndex = 4;
            this.btn_filesPath.Text = "文件集所在路径";
            this.btn_filesPath.UseVisualStyleBackColor = true;
            this.btn_filesPath.Click += new System.EventHandler(this.Btn_filesPath_Click);
            // 
            // txt_filesPath
            // 
            this.txt_filesPath.Location = new System.Drawing.Point(179, 70);
            this.txt_filesPath.Name = "txt_filesPath";
            this.txt_filesPath.Size = new System.Drawing.Size(333, 28);
            this.txt_filesPath.TabIndex = 5;
            // 
            // lbl_totalCount
            // 
            this.lbl_totalCount.AutoSize = true;
            this.lbl_totalCount.Location = new System.Drawing.Point(26, 643);
            this.lbl_totalCount.Name = "lbl_totalCount";
            this.lbl_totalCount.Size = new System.Drawing.Size(71, 18);
            this.lbl_totalCount.TabIndex = 6;
            this.lbl_totalCount.Text = "总计：N";
            // 
            // lbl_distance
            // 
            this.lbl_distance.AutoSize = true;
            this.lbl_distance.Location = new System.Drawing.Point(531, 73);
            this.lbl_distance.Name = "lbl_distance";
            this.lbl_distance.Size = new System.Drawing.Size(152, 18);
            this.lbl_distance.TabIndex = 7;
            this.lbl_distance.Text = "准差范围：(字节)";
            // 
            // txt_distance
            // 
            this.txt_distance.Location = new System.Drawing.Point(689, 70);
            this.txt_distance.Name = "txt_distance";
            this.txt_distance.Size = new System.Drawing.Size(90, 28);
            this.txt_distance.TabIndex = 8;
            this.txt_distance.Text = "4000";
            this.txt_distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "文件路径";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 125;
            // 
            // FileCreatedTime
            // 
            this.FileCreatedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FileCreatedTime.DataPropertyName = "FileCreatedTime";
            this.FileCreatedTime.HeaderText = "文件创建时间(BTC)";
            this.FileCreatedTime.Name = "FileCreatedTime";
            this.FileCreatedTime.ReadOnly = true;
            this.FileCreatedTime.Width = 130;
            // 
            // FileSize
            // 
            this.FileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FileSize.DataPropertyName = "FileSize";
            this.FileSize.HeaderText = "文件大小";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // FileStandardSize
            // 
            this.FileStandardSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FileStandardSize.DataPropertyName = "FileStandardSize";
            this.FileStandardSize.HeaderText = "准则文件大小";
            this.FileStandardSize.Name = "FileStandardSize";
            this.FileStandardSize.ReadOnly = true;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 679);
            this.Controls.Add(this.txt_distance);
            this.Controls.Add(this.lbl_distance);
            this.Controls.Add(this.lbl_totalCount);
            this.Controls.Add(this.txt_filesPath);
            this.Controls.Add(this.btn_filesPath);
            this.Controls.Add(this.data_filterFiles);
            this.Controls.Add(this.btn_filter);
            this.Controls.Add(this.txt_standardFile);
            this.Controls.Add(this.btn_select);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件过滤工具";
            ((System.ComponentModel.ISupportInitialize)(this.data_filterFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.TextBox txt_standardFile;
        private System.Windows.Forms.Button btn_filter;
        private System.Windows.Forms.DataGridView data_filterFiles;
        private System.Windows.Forms.Button btn_filesPath;
        private System.Windows.Forms.TextBox txt_filesPath;
        private System.Windows.Forms.Label lbl_totalCount;
        private System.Windows.Forms.Label lbl_distance;
        private System.Windows.Forms.TextBox txt_distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileCreatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileStandardSize;
    }
}

