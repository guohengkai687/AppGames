namespace MixerVoiceFormsDemo
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txt_inputPath1 = new System.Windows.Forms.TextBox();
            this.txt_inputPath2 = new System.Windows.Forms.TextBox();
            this.btn_selectPath1 = new System.Windows.Forms.Button();
            this.btn_selectPath2 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txt_outputPath = new System.Windows.Forms.TextBox();
            this.btn_outputButton = new System.Windows.Forms.Button();
            this.btn_mixerVoice = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txt_inputPath1
            // 
            this.txt_inputPath1.Location = new System.Drawing.Point(20, 40);
            this.txt_inputPath1.Name = "txt_inputPath1";
            this.txt_inputPath1.Size = new System.Drawing.Size(176, 21);
            this.txt_inputPath1.TabIndex = 0;
            // 
            // txt_inputPath2
            // 
            this.txt_inputPath2.Location = new System.Drawing.Point(20, 84);
            this.txt_inputPath2.Name = "txt_inputPath2";
            this.txt_inputPath2.Size = new System.Drawing.Size(176, 21);
            this.txt_inputPath2.TabIndex = 1;
            // 
            // btn_selectPath1
            // 
            this.btn_selectPath1.Location = new System.Drawing.Point(215, 40);
            this.btn_selectPath1.Name = "btn_selectPath1";
            this.btn_selectPath1.Size = new System.Drawing.Size(103, 21);
            this.btn_selectPath1.TabIndex = 2;
            this.btn_selectPath1.Text = "选择路径1";
            this.btn_selectPath1.UseVisualStyleBackColor = true;
            this.btn_selectPath1.Click += new System.EventHandler(this.btn_selectPath1_Click);
            // 
            // btn_selectPath2
            // 
            this.btn_selectPath2.Location = new System.Drawing.Point(215, 84);
            this.btn_selectPath2.Name = "btn_selectPath2";
            this.btn_selectPath2.Size = new System.Drawing.Size(103, 21);
            this.btn_selectPath2.TabIndex = 3;
            this.btn_selectPath2.Text = "选择路径2";
            this.btn_selectPath2.UseVisualStyleBackColor = true;
            this.btn_selectPath2.Click += new System.EventHandler(this.btn_selectPath2_Click);
            // 
            // txt_outputPath
            // 
            this.txt_outputPath.Location = new System.Drawing.Point(20, 134);
            this.txt_outputPath.Name = "txt_outputPath";
            this.txt_outputPath.Size = new System.Drawing.Size(176, 21);
            this.txt_outputPath.TabIndex = 4;
            // 
            // btn_outputButton
            // 
            this.btn_outputButton.Location = new System.Drawing.Point(215, 133);
            this.btn_outputButton.Name = "btn_outputButton";
            this.btn_outputButton.Size = new System.Drawing.Size(103, 21);
            this.btn_outputButton.TabIndex = 5;
            this.btn_outputButton.Text = "生成路径";
            this.btn_outputButton.UseVisualStyleBackColor = true;
            this.btn_outputButton.Click += new System.EventHandler(this.btn_outputButton_Click);
            // 
            // btn_mixerVoice
            // 
            this.btn_mixerVoice.Location = new System.Drawing.Point(215, 176);
            this.btn_mixerVoice.Name = "btn_mixerVoice";
            this.btn_mixerVoice.Size = new System.Drawing.Size(103, 21);
            this.btn_mixerVoice.TabIndex = 6;
            this.btn_mixerVoice.Text = "混音";
            this.btn_mixerVoice.UseVisualStyleBackColor = true;
            this.btn_mixerVoice.Click += new System.EventHandler(this.btn_mixerVoice_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 262);
            this.Controls.Add(this.btn_mixerVoice);
            this.Controls.Add(this.btn_outputButton);
            this.Controls.Add(this.txt_outputPath);
            this.Controls.Add(this.btn_selectPath2);
            this.Controls.Add(this.btn_selectPath1);
            this.Controls.Add(this.txt_inputPath2);
            this.Controls.Add(this.txt_inputPath1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txt_inputPath1;
        private System.Windows.Forms.TextBox txt_inputPath2;
        private System.Windows.Forms.Button btn_selectPath1;
        private System.Windows.Forms.Button btn_selectPath2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txt_outputPath;
        private System.Windows.Forms.Button btn_outputButton;
        private System.Windows.Forms.Button btn_mixerVoice;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

