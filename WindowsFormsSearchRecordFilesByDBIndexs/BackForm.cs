using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsSearchRecordFilesByDBIndexs
{
    public partial class BackForm : Form
    {
        public BackForm()
        {
            InitializeComponent();
        }
        private string _db;
        private BackgroundWorker _backgroundWorker = null;
        private List<RecordSound> _records = new List<RecordSound>();
        private int _Percent = 0;
        private List<string> _list = new List<string>();
        public List<string> List { get => _list; set => _list = value; }

        public BackForm(string db)
        {
            _db = db;
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoWork);
            _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.ProcessChanged);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            InitializeComponent();

        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ProcessChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = _Percent;

            label1.Text = string.Format("共计{0}条", _records.Count);
            label2.Text = string.Format("已完成{0}条", _Percent - 1);
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            _Percent = 0;

            for (int i = 0; i < _records.Count; i++)
            {
                string path = "E:\\" + _records[i].RTime.ToString("yyyyMMdd") + "\\" + _records[i].RTime.ToString("HHmmss") + "." + _records[i].ChnlID.ToString().PadLeft(3, '0');

                FileInfo fileInfo = new FileInfo(path);
                if (!fileInfo.Exists)
                {
                    _list.Add(path);
                }
                _backgroundWorker.ReportProgress(++_Percent);
            }
        }

        //查询语音记录
        public List<RecordSound> QuerySoundFromSqlServer(string sql)
        {
            SqlConnection connection = new SqlConnection(_db);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.CommandTimeout = 300;
                DataSet ds = new DataSet("RecordSound");
                adapter.Fill(ds);//.Fill(ds);
                return FuncHelper.ConvertFromDataSet<RecordSound>(ds);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        private void BackForm_Load(object sender, EventArgs e)
        {
            string sql = "select * from RecordSound";
            _records = QuerySoundFromSqlServer(sql);

            if (_records.Count > 0)
            {
                progressBar1.Maximum = _records.Count;
                _backgroundWorker.RunWorkerAsync();
            }
            else
            {
                if (MessageBox.Show("数据库索引数量为空", "提示信息", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
