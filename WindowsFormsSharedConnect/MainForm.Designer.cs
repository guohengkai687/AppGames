namespace WindowsFormsSharedConnect
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
            this.btn_connect = new System.Windows.Forms.Button();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.lbl_passWord = new System.Windows.Forms.Label();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.txt_passWord = new System.Windows.Forms.TextBox();
            this.lbl_state = new System.Windows.Forms.Label();
            this.lbl_sharedPath = new System.Windows.Forms.Label();
            this.txt_sharedPath = new System.Windows.Forms.TextBox();
            this.listView_sharedFiles = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(191, 137);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Location = new System.Drawing.Point(47, 58);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(53, 12);
            this.lbl_userName.TabIndex = 1;
            this.lbl_userName.Text = "用户名：";
            // 
            // lbl_passWord
            // 
            this.lbl_passWord.AutoSize = true;
            this.lbl_passWord.Location = new System.Drawing.Point(49, 100);
            this.lbl_passWord.Name = "lbl_passWord";
            this.lbl_passWord.Size = new System.Drawing.Size(41, 12);
            this.lbl_passWord.TabIndex = 2;
            this.lbl_passWord.Text = "密码：";
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(106, 55);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(160, 21);
            this.txt_userName.TabIndex = 3;
            this.txt_userName.Text = "user";
            // 
            // txt_passWord
            // 
            this.txt_passWord.Location = new System.Drawing.Point(106, 97);
            this.txt_passWord.Name = "txt_passWord";
            this.txt_passWord.Size = new System.Drawing.Size(160, 21);
            this.txt_passWord.TabIndex = 4;
            this.txt_passWord.Text = "123456";
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Location = new System.Drawing.Point(51, 147);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(59, 12);
            this.lbl_state.TabIndex = 5;
            this.lbl_state.Text = "未连接...";
            // 
            // lbl_sharedPath
            // 
            this.lbl_sharedPath.AutoSize = true;
            this.lbl_sharedPath.Location = new System.Drawing.Point(47, 22);
            this.lbl_sharedPath.Name = "lbl_sharedPath";
            this.lbl_sharedPath.Size = new System.Drawing.Size(41, 12);
            this.lbl_sharedPath.TabIndex = 6;
            this.lbl_sharedPath.Text = "共享：";
            // 
            // txt_sharedPath
            // 
            this.txt_sharedPath.Location = new System.Drawing.Point(106, 19);
            this.txt_sharedPath.Name = "txt_sharedPath";
            this.txt_sharedPath.Size = new System.Drawing.Size(160, 21);
            this.txt_sharedPath.TabIndex = 7;
            this.txt_sharedPath.Text = "\\\\192.168.0.30\\tool";
            // 
            // listView_sharedFiles
            // 
            this.listView_sharedFiles.HideSelection = false;
            this.listView_sharedFiles.Location = new System.Drawing.Point(53, 211);
            this.listView_sharedFiles.Name = "listView_sharedFiles";
            this.listView_sharedFiles.Size = new System.Drawing.Size(1084, 369);
            this.listView_sharedFiles.TabIndex = 8;
            this.listView_sharedFiles.UseCompatibleStateImageBehavior = false;
            this.listView_sharedFiles.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 613);
            this.Controls.Add(this.listView_sharedFiles);
            this.Controls.Add(this.txt_sharedPath);
            this.Controls.Add(this.lbl_sharedPath);
            this.Controls.Add(this.lbl_state);
            this.Controls.Add(this.txt_passWord);
            this.Controls.Add(this.txt_userName);
            this.Controls.Add(this.lbl_passWord);
            this.Controls.Add(this.lbl_userName);
            this.Controls.Add(this.btn_connect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConnectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.Label lbl_passWord;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.TextBox txt_passWord;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.Label lbl_sharedPath;
        private System.Windows.Forms.TextBox txt_sharedPath;
        private System.Windows.Forms.ListView listView_sharedFiles;
    }
}

