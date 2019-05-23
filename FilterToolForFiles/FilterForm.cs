using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FilterToolForFiles
{
    public partial class FilterForm : Form
    {
        Regex _RegexForFileName = new Regex(@"^([0-1][0-9]|[2][0-3])([0-5][0-9])([0-5][0-9])(.)([0-9][0-9][0-9])$");
        public FilterForm()
        {
            InitializeComponent();
            txt_filesPath.Text = @"E:";
            txt_standardFile.Text = "";
            txt_distance.Text = "4000";//字节
        }

        private void Btn_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "选择准则文件";
            openFileDialog.Filter = "准则文件|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf("\\") + 1);
                if (_RegexForFileName.IsMatch(fileName) == false)
                {
                    MessageBox.Show("数据文件选择错误", "提示消息");
                    txt_standardFile.Text = "";
                    return;
                }
                txt_standardFile.Text = openFileDialog.FileName;
            }
        }

        private long StandaFileSize = 0;
        private string filterPath = "";
        private string distance = "";
        private void Btn_filter_Click(object sender, EventArgs e)
        {
            filterPath = txt_filesPath.Text.ToString();
            distance = txt_distance.Text.ToString();
            FileInfo file = new FileInfo(txt_standardFile.Text.ToString());
            if (file.Exists)
            {
                StandaFileSize = file.Length;
            }

            BackgroundWorkForm backgroundWorkForm = new BackgroundWorkForm(filterPath, StandaFileSize, distance);
            backgroundWorkForm.ShowDialog(this);
            backgroundWorkForm.Close();

            data_filterFiles.DataSource = backgroundWorkForm.fileFilters;
            //int rowNum = 1;
            //foreach (DataGridViewRow item in data_filterFiles.Rows)
            //{
            //    item.HeaderCell.Value = rowNum.ToString();
            //    rowNum++;
            //}
            this.lbl_totalCount.Text = string.Format("总计：{0}", backgroundWorkForm.fileFilters.Count);
        }

        private void Btn_filesPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择文件夹路径";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txt_filesPath.Text = folderBrowserDialog.SelectedPath.ToString();
            }
        }

        private void DataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
    public class FileFilter
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public long FileStandardSize { get; set; }
        public string FileCreatedTime { get; set; }
    }
}
