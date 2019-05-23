namespace WindowsFormsAppTestGames
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
            this.btn_Test = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.lbl_Path = new System.Windows.Forms.Label();
            this.btn_selectPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(46, 12);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(120, 35);
            this.btn_Test.TabIndex = 0;
            this.btn_Test.Text = "启动监控";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(46, 53);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1157, 505);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(311, 17);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(336, 28);
            this.txt_Path.TabIndex = 12;
            this.txt_Path.Text = "C:\\\\";
            // 
            // lbl_Path
            // 
            this.lbl_Path.AutoSize = true;
            this.lbl_Path.Location = new System.Drawing.Point(210, 20);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(80, 18);
            this.lbl_Path.TabIndex = 13;
            this.lbl_Path.Text = "监控路径";
            // 
            // btn_selectPath
            // 
            this.btn_selectPath.Location = new System.Drawing.Point(675, 12);
            this.btn_selectPath.Name = "btn_selectPath";
            this.btn_selectPath.Size = new System.Drawing.Size(140, 35);
            this.btn_selectPath.TabIndex = 14;
            this.btn_selectPath.Text = "选择监控路径";
            this.btn_selectPath.UseVisualStyleBackColor = true;
            this.btn_selectPath.Click += new System.EventHandler(this.Btn_selectPath_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 587);
            this.Controls.Add(this.btn_selectPath);
            this.Controls.Add(this.lbl_Path);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_Test);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件监控界面";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label lbl_Path;
        private System.Windows.Forms.Button btn_selectPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

