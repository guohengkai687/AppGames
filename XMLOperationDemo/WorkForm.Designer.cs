namespace XMLOperationDemo
{
    partial class WorkForm
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
            this.Btn_ReadXML = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btn_AddItem = new System.Windows.Forms.Button();
            this.Btn_Modify = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_XMLTextRead = new System.Windows.Forms.Button();
            this.Btn_XMLTextWrite = new System.Windows.Forms.Button();
            this.BookType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_ReadXML
            // 
            this.Btn_ReadXML.Location = new System.Drawing.Point(37, 30);
            this.Btn_ReadXML.Name = "Btn_ReadXML";
            this.Btn_ReadXML.Size = new System.Drawing.Size(77, 34);
            this.Btn_ReadXML.TabIndex = 0;
            this.Btn_ReadXML.Text = "读取";
            this.Btn_ReadXML.UseVisualStyleBackColor = true;
            this.Btn_ReadXML.Click += new System.EventHandler(this.Btn_ReadXML_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookType,
            this.BookISBN,
            this.BookName,
            this.BookAuthor,
            this.BookPrice});
            this.dataGridView1.Location = new System.Drawing.Point(37, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(833, 232);
            this.dataGridView1.TabIndex = 1;
            // 
            // Btn_AddItem
            // 
            this.Btn_AddItem.Location = new System.Drawing.Point(155, 30);
            this.Btn_AddItem.Name = "Btn_AddItem";
            this.Btn_AddItem.Size = new System.Drawing.Size(77, 34);
            this.Btn_AddItem.TabIndex = 2;
            this.Btn_AddItem.Text = "添加";
            this.Btn_AddItem.UseVisualStyleBackColor = true;
            this.Btn_AddItem.Click += new System.EventHandler(this.Btn_AddItem_Click);
            // 
            // Btn_Modify
            // 
            this.Btn_Modify.Location = new System.Drawing.Point(279, 30);
            this.Btn_Modify.Name = "Btn_Modify";
            this.Btn_Modify.Size = new System.Drawing.Size(77, 34);
            this.Btn_Modify.TabIndex = 3;
            this.Btn_Modify.Text = "修改";
            this.Btn_Modify.UseVisualStyleBackColor = true;
            this.Btn_Modify.Click += new System.EventHandler(this.Btn_Modify_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Location = new System.Drawing.Point(405, 30);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(77, 34);
            this.Btn_Delete.TabIndex = 4;
            this.Btn_Delete.Text = "删除";
            this.Btn_Delete.UseVisualStyleBackColor = true;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_XMLTextRead
            // 
            this.Btn_XMLTextRead.Location = new System.Drawing.Point(555, 30);
            this.Btn_XMLTextRead.Name = "Btn_XMLTextRead";
            this.Btn_XMLTextRead.Size = new System.Drawing.Size(161, 34);
            this.Btn_XMLTextRead.TabIndex = 5;
            this.Btn_XMLTextRead.Text = "XMLTextRead读取";
            this.Btn_XMLTextRead.UseVisualStyleBackColor = true;
            this.Btn_XMLTextRead.Click += new System.EventHandler(this.Btn_XMLTextRead_Click);
            // 
            // Btn_XMLTextWrite
            // 
            this.Btn_XMLTextWrite.Location = new System.Drawing.Point(743, 30);
            this.Btn_XMLTextWrite.Name = "Btn_XMLTextWrite";
            this.Btn_XMLTextWrite.Size = new System.Drawing.Size(168, 34);
            this.Btn_XMLTextWrite.TabIndex = 6;
            this.Btn_XMLTextWrite.Text = "XMLTextWrite写入";
            this.Btn_XMLTextWrite.UseVisualStyleBackColor = true;
            this.Btn_XMLTextWrite.Click += new System.EventHandler(this.Btn_XMLTextWrite_Click);
            // 
            // BookType
            // 
            this.BookType.DataPropertyName = "BooKType";
            this.BookType.HeaderText = "类型";
            this.BookType.Name = "BookType";
            // 
            // BookISBN
            // 
            this.BookISBN.DataPropertyName = "BookISBN";
            this.BookISBN.HeaderText = "ISBN";
            this.BookISBN.Name = "BookISBN";
            // 
            // BookName
            // 
            this.BookName.DataPropertyName = "BookName";
            this.BookName.HeaderText = "书名";
            this.BookName.Name = "BookName";
            // 
            // BookAuthor
            // 
            this.BookAuthor.DataPropertyName = "BookAuthor";
            this.BookAuthor.HeaderText = "作者";
            this.BookAuthor.Name = "BookAuthor";
            // 
            // BookPrice
            // 
            this.BookPrice.DataPropertyName = "BookPrice";
            this.BookPrice.HeaderText = "价格";
            this.BookPrice.Name = "BookPrice";
            // 
            // WorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 518);
            this.Controls.Add(this.Btn_XMLTextWrite);
            this.Controls.Add(this.Btn_XMLTextRead);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.Btn_Modify);
            this.Controls.Add(this.Btn_AddItem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Btn_ReadXML);
            this.MaximizeBox = false;
            this.Name = "WorkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_ReadXML;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_AddItem;
        private System.Windows.Forms.Button Btn_Modify;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_XMLTextRead;
        private System.Windows.Forms.Button Btn_XMLTextWrite;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookPrice;
    }
}

