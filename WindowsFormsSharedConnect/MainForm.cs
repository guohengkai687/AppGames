using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSharedConnect
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lbl_state.Text = "未连接...";
            listView_sharedFiles.Columns.Add("");
            listView_sharedFiles.Columns.Add("文件名");
            listView_sharedFiles.Columns.Add("文件路径");
            listView_sharedFiles.Columns.Add("文件创建时间");
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            string _Server = this.txt_sharedPath.Text.Trim();
            string _ID = this.txt_userName.Text.Trim();
            string _Password = this.txt_passWord.Text.Trim();
            bool sharedConnect = false;

            string _ConnMsg = NetworkShareConnect.connectToShare(_Server, _ID, _Password);
            if (_ConnMsg == null)
            {

                this.lbl_state.ForeColor = Color.FromName("Green");
                this.lbl_state.Text = "连接成功...";
                sharedConnect = true;
            }
            else
            {
                this.lbl_state.ForeColor = Color.FromName("Red");
                this.lbl_state.Text = "连接失败...";
                sharedConnect = false;
            }

            if (sharedConnect)
            {
                var dicInfo = new DirectoryInfo(_Server);//选择的目录信息    

                FileInfo[] dic = dicInfo.GetFiles();
                foreach (FileInfo temp in dic)
                {
                    SharedFile sharedFile = new SharedFile();
                    sharedFile.Name = temp.Name;
                    sharedFile.FilePath = temp.FullName;
                    sharedFile.FileCreatedTime = temp.CreationTime.ToString("yyyy-MM-dd HH:MM:ss");

                    //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                    ListViewItem lt = new ListViewItem();
                    lt.SubItems.Add(sharedFile.Name);
                    lt.SubItems.Add(sharedFile.FilePath);
                    lt.SubItems.Add(sharedFile.FileCreatedTime);
                    //将lt数据添加到listView1控件中
                    listView_sharedFiles.Items.Add(lt);
                }
            }
            listView_sharedFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //listView_sharedFiles.Invalidate();
        }
    }
    public class SharedFile
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileCreatedTime { get; set; }
         
    }
}
