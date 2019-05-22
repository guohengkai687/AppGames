using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NAudioPractice1
{
    public partial class Form1 : Form
    {
        BSoundPlayer bsp1;
        BSoundPlayer bsp2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bsp1 = new BSoundPlayer();
            bsp1.FileName = System.Environment.CurrentDirectory + "\\OpenDoorSound.wav";
            //bsp1.FileName = System.Environment.CurrentDirectory + "\\a.raw";
            bsp2 = new BSoundPlayer();
            bsp2.FileName = System.Environment.CurrentDirectory + "\\ClickSound1.wav";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bsp1.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bsp1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bsp2.Play();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            float volumn = (float)trackBar1.Value / 10f;
            bsp1.Volume = volumn;
            bsp2.Volume = volumn;
        }
    }
}
