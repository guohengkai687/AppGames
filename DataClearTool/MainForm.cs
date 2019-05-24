using System;
using System.Windows.Forms;

namespace DataClearTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
    }
}
