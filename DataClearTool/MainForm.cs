using System;
using System.Windows.Forms;

namespace DataClearTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.timerDiskInfo.Start();
        }

        private void Btn_deleteData_Click(object sender, EventArgs e)
        {
            DateTime dt_StartDate = dtPicker_startDate.Value.Date;
            DateTime dt_EndDate = dtPicker_endDate.Value.Date;
            string workPath = txt_dataPath.Text;
            ProcessForm processForm = new ProcessForm(dt_StartDate, dt_EndDate, workPath);
            processForm.ShowDialog(this);
            processForm.Close();
        }

        private void timerDiskInfo_Tick(object sender, EventArgs e)
        {
            string _path = txt_dataPath.Text.ToString().Substring(0, 1);
            this.proBar_diskSpace.Maximum = (Int32)GetHardDiskSpace(_path);
            this.proBar_diskSpace.Value = (Int32)GetHardDiskSpace(_path) - (Int32)GetHardDiskFreeSpace(_path);

            this.lbl_diskSpaceVale.Text = string.Format("剩余{0}G", GetHardDiskFreeSpace(_path).ToString());

        }
        ///  <summary> 
        /// 获取指定驱动器的空间总大小(单位为GB) 
        ///  </summary> 
        ///  <param name="str_HardDiskName">只需输入代表驱动器的字母即可 （大写）</param> 
        ///  <returns> </returns> 
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            long totalSize = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                }
            }
            return totalSize;
        }

        ///  <summary> 
        /// 获取指定驱动器的剩余空间总大小(单位为GB) 
        ///  </summary> 
        ///  <param name="str_HardDiskName">只需输入代表驱动器的字母即可 </param> 
        ///  <returns> </returns> 
        public static long GetHardDiskFreeSpace(string str_HardDiskName)
        {
            long freeSpace = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                }
            }
            return freeSpace;
        }
    }
}
