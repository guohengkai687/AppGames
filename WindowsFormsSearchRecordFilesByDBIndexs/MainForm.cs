using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsSearchRecordFilesByDBIndexs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            this.txt_DbAdress.Text = "Data Source = localhost;Initial Catalog = mdr;User Id = sa;Password = bjdj;";
            this.btn_Go.Enabled = true;
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            list_Files.Items.Clear();
            BackForm backForm = new BackForm(this.txt_DbAdress.Text);
            if (backForm.ShowDialog(this) == DialogResult.OK)
            {
                if (backForm.List.Count != 0)
                {
                    list_Files.Items.AddRange(backForm.List.ToArray());
                }
                else
                {
                    list_Files.Items.Add("Null");
                }
            }
            backForm.Close();
        }

    }
}
