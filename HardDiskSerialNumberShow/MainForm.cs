using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardDiskSerialNumberShow
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Btn_GetDiskNum_Click(object sender, EventArgs e)
        {
            list.Clear();
            listBox1.DataSource = GetHardDiskSerialNumber();
        }
        public List<String> list = new List<string>();
        //获取硬盘序列号,可以通过磁盘序列号来获取磁盘数量（包括插入设备的U盘）
        public List<string> GetHardDiskSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                //string sHardDiskSerialNumber = "";
                //foreach (ManagementObject mo in searcher.Get())
                //{
                //    sHardDiskSerialNumber = mo["SerialNumber"].ToString().Trim();
                //    list.Add(sHardDiskSerialNumber);
                //}
                //return list;

                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    list.Add(mo.Properties["Model"].Value.ToString());//SerialNumber
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
