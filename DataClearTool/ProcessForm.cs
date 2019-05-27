using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace DataClearTool
{
    public partial class ProcessForm : Form
    {
        private DateTime _StartDate = DateTime.MinValue;
        private DateTime _EndDate = DateTime.MaxValue;
        private string _Path = string.Empty;
        int _Total = 0;
        int _Percent = 0;
        public ProcessForm(DateTime startDate, DateTime endDate, string workPath)
        {
            InitializeComponent();
            _StartDate = startDate;
            _EndDate = endDate;
            _Path = workPath;
            this.bakg_work.RunWorkerAsync();
        }

        private void bakg_workDoWork(object sender, DoWorkEventArgs e)
        {
            _Percent = 0;
            _Total = 0;
            List<FileInfo> fileInfos = GetDateFiles(_StartDate, _EndDate, _Path);
            _Total = fileInfos.Count;
            //搜素备份数据库所在路径，查看是否已经备份，存在则删除
            string _BackUpDBPath = _Path + "\\MDRDB";
            DirectoryInfo directoryInfo = new DirectoryInfo(_BackUpDBPath);
            FileInfo[] files = directoryInfo.GetFiles();
            for (int j = 0; j < Convert.ToInt32((_EndDate - _StartDate).Days) + 1; j++)
            {
                foreach (FileInfo file in files)
                {
                    if (file.Name.Substring(0,8) == _StartDate.AddDays(j).ToString("yyyyMMdd"))
                    {
                        file.Delete();
                    }
                }
            }
            //删除数据库，按天删除
            for (int i = 0; i < Convert.ToInt32((_EndDate - _StartDate).Days) + 1; i++)
            {
                DeleteRecord(_StartDate.AddDays(i));
            }
            //删除文件,保留存储数据的文件夹，以便于自动清理功能来判断30天的阈值，进行自动删除。
            for (int i = 0; i < _Total; i++)
            {
                fileInfos[i].Delete();
                bakg_work.ReportProgress(++_Percent);
            }
        }
        /// <summary>
        /// 获取数据文件夹集合
        /// </summary>
        /// <param name="path">数据存储路径</param>
        /// <returns></returns>
        private List<FileInfo> GetDateFiles(DateTime dtstart, DateTime dtend, string path)
        {
            List<DirectoryInfo> deleteDir = new List<DirectoryInfo>();
            try
            {
                DirectoryInfo wInfo = new DirectoryInfo(path);
                if (wInfo.Exists)
                {
                    //获取磁盘下的所有目录
                    DirectoryInfo[] dirInfos = wInfo.GetDirectories();
                    //遍历所有文件夹名，排除非数据文件夹
                    for (int i = 0; i < dirInfos.Length; i++)
                    {
                        var info = dirInfos[i];
                        try
                        {
                            var dt = DateTime.ParseExact(info.Name, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                            if (dt >= dtstart && dt <= dtend)
                            {
                                deleteDir.Add(info);
                            }
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.Print(e.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            if (deleteDir.Count > 0)
            {
                List<FileInfo> files = GetFiles(deleteDir);
                return files;
            }
            return null;
        }

        private List<FileInfo> GetFiles(List<DirectoryInfo> deleteDir)
        {
            List<FileInfo> files = new List<FileInfo>();
            try
            {
                foreach (DirectoryInfo directory in deleteDir)
                {
                    files.AddRange(directory.GetFiles());
                }
                return files;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
                return null;
            }
        }

        private void bakg_workProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Maximum = _Total + 1;
            progressBar.Value = _Percent;

            this.lbl_currentItem.Text = string.Format("正在删除第{0}条", _Percent - 1);
            this.lbl_totalItems.Text = string.Format("总计{0}条", _Total);
        }

        private void bakg_eorkRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private string ConStr = "Data Source = localhost;Initial Catalog = mdr;User Id = sa;Password = bjdj;";
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int DeleteRecord(DateTime dt)
        {
            string sql = "delete from RecordSound where RTime between " + "'" + dt.ToString("yyyy-MM-dd") + "'" + " and " + "'" + dt.AddDays(1).ToString("yyyy-MM-dd") + "'";
            SqlConnection connection = new SqlConnection(ConStr);
            try
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandTimeout = 600;
                sqlCommand.CommandText = sql;
                connection.Open();
                if (sqlCommand.ExecuteNonQuery() != 1)
                {
                    return -1;
                }
                return 1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("数据库删除记录信息失败");
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public int GetRecord(DateTime startDate, DateTime endDate)
        {
            SqlConnection connection = new SqlConnection(ConStr);
            try
            {
                DataSet ds = new DataSet();
                string sql = "select * from RecordSound where RTime between " + "'" + startDate.ToString("yyyy-MM-dd") + "'" + " and " + "'" + endDate.ToString("yyyy-MM-dd") + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(ds, "SoundRecord");
                return ds.Tables.Count;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("数据库查询记录信息失败");
                System.Diagnostics.Debug.Print(ex.ToString());
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
