namespace DataAnalyze_E1
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_loadFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filePath = new System.Windows.Forms.TextBox();
            this.bt_selectFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1234, 302);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DataGridView_RowStateChanged);
            // 
            // btn_loadFile
            // 
            this.btn_loadFile.Location = new System.Drawing.Point(1164, 358);
            this.btn_loadFile.Name = "btn_loadFile";
            this.btn_loadFile.Size = new System.Drawing.Size(102, 35);
            this.btn_loadFile.TabIndex = 1;
            this.btn_loadFile.Text = "加载数据";
            this.btn_loadFile.UseVisualStyleBackColor = true;
            this.btn_loadFile.Click += new System.EventHandler(this.Btn_loadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件路径：";
            // 
            // txt_filePath
            // 
            this.txt_filePath.Location = new System.Drawing.Point(116, 363);
            this.txt_filePath.Name = "txt_filePath";
            this.txt_filePath.Size = new System.Drawing.Size(862, 28);
            this.txt_filePath.TabIndex = 3;
            // 
            // bt_selectFile
            // 
            this.bt_selectFile.Location = new System.Drawing.Point(984, 358);
            this.bt_selectFile.Name = "bt_selectFile";
            this.bt_selectFile.Size = new System.Drawing.Size(133, 35);
            this.bt_selectFile.TabIndex = 4;
            this.bt_selectFile.Text = "选择加载文件";
            this.bt_selectFile.UseVisualStyleBackColor = true;
            this.bt_selectFile.Click += new System.EventHandler(this.Bt_selectFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 418);
            this.Controls.Add(this.bt_selectFile);
            this.Controls.Add(this.txt_filePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_loadFile);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_loadFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_filePath;
        private System.Windows.Forms.Button bt_selectFile;
    }
}