using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsAppTestGames
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //添加表头
            listView1.Columns.Add("");
            listView1.Columns[0].Width = 0;
            listView1.Columns.Add("时间");
            listView1.Columns[1].Width = 120;
            listView1.Columns.Add("事件");
            listView1.Columns[2].Width = 70;
            listView1.Columns.Add("原文件名");
            listView1.Columns[3].Width = 150;
            listView1.Columns.Add("新文件名");
            listView1.Columns[4].Width = 150;
            listView1.Columns.Add("原文件路径");
            listView1.Columns[5].Width = 200;
            listView1.Columns.Add("新文件路径");
            listView1.Columns[6].Width = 200;

            listView1.Scrollable = true;
            btn_Test.Text = "启动监控";

        }

        private delegate void setLogTextDelegate(FileSystemEventArgs e); //声明传递FileSystemEventArgs对象的委托，用于文件Created，Deleted和Changed变动时更新UI界面。 
        private delegate void renamedDelegate(RenamedEventArgs e);  //声明传递RenamedEventArgs对象的委托，用于文件Renamed时更新UI界面。 

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            //.NET Framework要求把对象标记为可序列化对象才能序列化他们            
            //序列化
            FileStream file = new FileStream("Text.txt", FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            object obj = null;
            formatter.Serialize(file, obj);//把obj内容 序列化到file stream
            //反序列化
            obj = formatter.Deserialize(file);//把file stream 反序列化到obj  
            */
        }
        private void FileSystemWatcher_EventHandle(object sender, FileSystemEventArgs e)  //文件增删改时被调用的处理方法
        {
            if (this.listView1.InvokeRequired)  //判断是否跨线程      
            {
                this.listView1.Invoke(new setLogTextDelegate(SetLogText), new object[] { e });   //使用委托将方法封送到UI主线程处理      
            }
        }
        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)   //文件重命名时被调用的处理方法
        {
            if (this.listView1.InvokeRequired) //判断是否跨线程       
            {
                this.listView1.Invoke(new renamedDelegate(SetRenamedLogText), new object[] { e });  //使用委托将方法封送到UI主线程处理       
            }
        }
        private void SetLogText(FileSystemEventArgs e)  //更新UI界面
        {
            ListViewItem lvi = new ListViewItem();            
            lvi.SubItems.Add(DateTime.Now.ToString());
            lvi.SubItems.Add(e.ChangeType.ToString());   //受影响文件的变动类型(可能为Created、Changed、Deleted）                  
            lvi.SubItems.Add(e.Name);   //受影响的文件名 
            lvi.SubItems.Add("");
            lvi.SubItems.Add(e.FullPath);     //受影响的文件完整路径   
            lvi.SubItems.Add("");
            this.listView1.Items.Add(lvi);
        }
        private void SetRenamedLogText(RenamedEventArgs e)  //更新UI界面
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add(DateTime.Now.ToString());
            lvi.SubItems.Add(e.ChangeType.ToString());  //受影响的文件的改动类型（Rename）        
            lvi.SubItems.Add(e.OldName);   //受影响的文件的原名        
            lvi.SubItems.Add(e.Name);   //受影响的文件的新名        
            lvi.SubItems.Add(e.OldFullPath);     //受影响的文件的原路径        
            lvi.SubItems.Add(e.FullPath);  //受影响的文件的完整路径（其实和原路径一样）        
            this.listView1.Items.Add(lvi);
        }
        private void Btn_Test_Click(object sender, EventArgs e)
        {
            btn_Test.Text = "已启动";
            FileSystemWatcher fsw = new FileSystemWatcher
            {
                Path = ConfigurationManager.AppSettings["WatcherPath"].ToString(),   //设置监控的文件目录 
                IncludeSubdirectories = true,   //设置监控C盘目录下的所有子目录 
                                                //fsw.Filter = "*.txt|*.doc|*.jpg";   //设置监控文件的类型
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size   //设置文件的文件名、目录名及文件的大小改动会触发Changed事件 
            };
            fsw.Created += new FileSystemEventHandler(this.FileSystemWatcher_EventHandle);  //绑定事件触发后处理数据的方法。 
            fsw.Deleted += new FileSystemEventHandler(this.FileSystemWatcher_EventHandle);
            fsw.Changed += new FileSystemEventHandler(this.FileSystemWatcher_EventHandle);
            fsw.Renamed += new RenamedEventHandler(this.FileSystemWatcher_Renamed);  //重命名事件与增删改传递的参数不一样。 
            fsw.EnableRaisingEvents = true;  //启动监控 

        }
    }
    [Serializable]
    public class Ser1 { }
}
