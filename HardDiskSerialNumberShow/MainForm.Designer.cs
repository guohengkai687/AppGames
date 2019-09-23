namespace HardDiskSerialNumberShow
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
            this.btn_GetDiskNum = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_GetDiskNum
            // 
            this.btn_GetDiskNum.Location = new System.Drawing.Point(50, 52);
            this.btn_GetDiskNum.Name = "btn_GetDiskNum";
            this.btn_GetDiskNum.Size = new System.Drawing.Size(164, 32);
            this.btn_GetDiskNum.TabIndex = 0;
            this.btn_GetDiskNum.Text = "获取硬盘序列号";
            this.btn_GetDiskNum.UseVisualStyleBackColor = true;
            this.btn_GetDiskNum.Click += new System.EventHandler(this.Btn_GetDiskNum_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(50, 110);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(247, 148);
            this.listBox1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 322);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_GetDiskNum);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetDiskNum;
        private System.Windows.Forms.ListBox listBox1;
    }
}

