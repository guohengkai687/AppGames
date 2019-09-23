using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataAnalyze_E1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Bt_selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "选择数据文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_filePath.Text = openFileDialog.FileName;
            }
        }
        OperaFile operaFile = new OperaFile();
        private void Btn_loadFile_Click(object sender, EventArgs e)
        {
            //string path = @"D:\_文档\9，E1\华东现场资料\feikun数据\FRQ STA\Stat20181001.txt";
            string path = txt_filePath.Text;
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                operaFile.Read(path);
                if (operaFile.Flist.Count > 0)
                {
                    dataGridView1.DataSource = operaFile.Flist;
                }
            }
        }
        private void DataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
