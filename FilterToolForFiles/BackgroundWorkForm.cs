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
    public partial class BackgroundWorkForm : Form
    {
        //校验文件夹格式 yyyyMMdd
        Regex _RegexForFolderName = new Regex(@"((^((1[8-9]\d{2})|([2-9]\d{3}))(10|12|0?[13578])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(11|0?[469])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(0?2)(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)(0?2)(29)$)|(^([3579][26]00)(0?2)(29)$)|(^([1][89][0][48])(0?2)(29)$)|(^([2-9][0-9][0][48])(0?2)(29)$)|(^([1][89][2468][048])(0?2)(29)$)|(^([2-9][0-9][2468][048])(0?2)(29)$)|(^([1][89][13579][26])(0?2)(29)$)|(^([2-9][0-9][13579][26])(0?2)(29)$))");
        //校验文件名格式 HHmmss.001
        Regex _RegexForFileName = new Regex(@"^([0-1][0-9]|[2][0-3])([0-5][0-9])([0-5][0-9])(.)([0-9][0-9][0-9])$");
        //校验文件名格式 HHmmssfff.001
        Regex _RegexForFileNamesqlite = new Regex(@"^([0-1][0-9]|[2][0-3])([0-5][0-9])([0-5][0-9])([0-9][0-9][0-9])(.)([0-9][0-9][0-9])$");

        public List<FileFilter> fileFilters = new List<FileFilter>();
        private string filePath;
        private long standardSize;
        private int standardDistance;
        int _Total = 0;
        int _Percent = 0;
        public BackgroundWorkForm(string filterPath, long StandaFileSize, string distance)
        {
            InitializeComponent();
            filePath = filterPath;
            standardSize = StandaFileSize;
            standardDistance = Convert.ToInt32(distance);
            this.bakg_worker.RunWorkerAsync();
        }

        private void Filter_DoWork(object sender, DoWorkEventArgs e)
        {
            _Total = 0;
            _Percent = 0;

            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
            #region BackUp
            //DirectoryInfo[] directories = directoryInfo.GetDirectories();
            //List<FileInfo> fileInfos = new List<FileInfo>();
            ////计算文件总数
            //foreach (DirectoryInfo directory in directories)
            //{
            //    if (IsSystemHidden(directory))
            //    {
            //        continue;
            //    }
            //    string folderName = directory.Name.Substring(directory.Name.LastIndexOf("\\") + 1);
            //    if (_RegexForFolderName.IsMatch(folderName) == false)
            //    {
            //        continue;
            //    }
            //    FileInfo[] files = directory.GetFiles();
            //    foreach (FileInfo info in files)
            //    {
            //        string fileName = info.Name.Substring(info.Name.LastIndexOf("\\") + 1);
            //        if (_RegexForFileName.IsMatch(fileName) == true)
            //        {
            //            _Total++;
            //            fileInfos.Add(info);
            //        }
            //    }
            //}
            ////数据绑定进List
            //foreach (FileInfo info in fileInfos)
            //{
            //    if (info.Length != standardSize)
            //    {
            //        fileFilters.Add(new FileFilter { FileName = info.FullName, FileSize = info.Length, FileStandardSize = standardSize });
            //    }
            //    bakg_worker.ReportProgress(++_Percent, "");
            //} 
            #endregion

            //计算文件总数
            string folderName = directoryInfo.Name.Substring(directoryInfo.Name.LastIndexOf("\\") + 1);
            if (_RegexForFolderName.IsMatch(folderName) == false)
            {
                MessageBox.Show("请选择正确的数据文件夹[yyyyMMdd]");
                return;
            }
            FileInfo[] files = directoryInfo.GetFiles();
            _Total = files.Count();
            foreach (FileInfo info in files)
            {
                string fileName = info.Name.Substring(info.Name.LastIndexOf("\\") + 1);
                if (_RegexForFileName.IsMatch(fileName) == true)
                {
                    if (info.Length != standardSize && Math.Abs(standardSize - info.Length) >= standardDistance)
                    {
                        fileFilters.Add(new FileFilter { FileName = info.FullName, FileCreatedTime= info.CreationTime.ToString("HH:mm:ss.fff"), FileSize = info.Length, FileStandardSize = standardSize });
                    }
                }
                bakg_worker.ReportProgress(++_Percent, "");
            }

        }

        private void Filter_ProcessChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Maximum = _Total + 1;
            progressBar.Value = _Percent;

            lbl_totalFiles.Text = string.Format("共计{0}条", _Total);
            lbl_completedFiles.Text = string.Format("已完成{0}条", _Percent - 1);
        }

        private void Filter_RunWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private static bool IsSystemHidden(DirectoryInfo dirInfo)
        {
            if (dirInfo.Parent == null)
            {
                return false;
            }
            string attributes = dirInfo.Attributes.ToString();
            if (attributes.IndexOf("Hidden") > -1 && attributes.IndexOf("System") > -1)
            {
                return true;
            }
            return false;
        }
    }
}
