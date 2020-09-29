namespace WindowsFormsSearchRecordFilesByDBIndexs
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
            this.txt_DbAdress = new System.Windows.Forms.TextBox();
            this.lb_DbAdress = new System.Windows.Forms.Label();
            this.btn_Go = new System.Windows.Forms.Button();
            this.list_Files = new System.Windows.Forms.ListBox();
            this.lb_files = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_DbAdress
            // 
            this.txt_DbAdress.Location = new System.Drawing.Point(95, 12);
            this.txt_DbAdress.Name = "txt_DbAdress";
            this.txt_DbAdress.Size = new System.Drawing.Size(433, 21);
            this.txt_DbAdress.TabIndex = 1;
            // 
            // lb_DbAdress
            // 
            this.lb_DbAdress.AutoSize = true;
            this.lb_DbAdress.Location = new System.Drawing.Point(12, 18);
            this.lb_DbAdress.Name = "lb_DbAdress";
            this.lb_DbAdress.Size = new System.Drawing.Size(77, 12);
            this.lb_DbAdress.TabIndex = 2;
            this.lb_DbAdress.Text = "数据库地址：";
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(548, 12);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(75, 23);
            this.btn_Go.TabIndex = 3;
            this.btn_Go.Text = "检索";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // list_Files
            // 
            this.list_Files.FormattingEnabled = true;
            this.list_Files.ItemHeight = 12;
            this.list_Files.Location = new System.Drawing.Point(14, 66);
            this.list_Files.Name = "list_Files";
            this.list_Files.Size = new System.Drawing.Size(606, 340);
            this.list_Files.TabIndex = 4;
            // 
            // lb_files
            // 
            this.lb_files.AutoSize = true;
            this.lb_files.Location = new System.Drawing.Point(12, 43);
            this.lb_files.Name = "lb_files";
            this.lb_files.Size = new System.Drawing.Size(101, 12);
            this.lb_files.TabIndex = 5;
            this.lb_files.Text = "缺失的文件路径：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 424);
            this.Controls.Add(this.lb_files);
            this.Controls.Add(this.list_Files);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.lb_DbAdress);
            this.Controls.Add(this.txt_DbAdress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "根据数据库索引检查语音文件";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_DbAdress;
        private System.Windows.Forms.Label lb_DbAdress;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.ListBox list_Files;
        private System.Windows.Forms.Label lb_files;
    }
}

