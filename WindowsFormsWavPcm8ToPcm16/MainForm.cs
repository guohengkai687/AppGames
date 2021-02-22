using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsWavPcm8ToPcm16
{
    public partial class Mainform : Form
    {
        //加载dll库，参数为dll库的名称，返回句柄
        [DllImport("kernel32")]
        public static extern IntPtr LoadLibrary(string lpFileName);
        //通过句柄释放dll库
        [DllImport("Kernel32")]
        public static extern bool FreeLibrary(IntPtr handle);
        //根据函数名输出库函数，返回函数的指针
        [DllImport("Kernel32")]
        public static extern IntPtr GetProcAddress(IntPtr handle, String funcname);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        unsafe public delegate void TestNoise_delegate(char* pSrcFile, char* pDenoiseFile);
        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            txtPath.Text = @"F:\123\123.wav";
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string _inPutPath = txtPath.Text.Trim();
            string _outPutPath = txtPath.Text + "output.wav";
            string _removeNoisePath = txtPath.Text + "removeNoise.wav";
            WavPcm8ToPcm16(_inPutPath, _outPutPath);

            //RemoveNoise(_outPutPath, _removeNoisePath);

            //this.Close();
        }

        unsafe private void RemoveNoise(string fileNameInput, string fileNameOutPut)
        {
            //加载c++对应的dll库
            IntPtr dll = LoadLibrary("SpeexWinProj.dll");

            IntPtr TestNoise_func = GetProcAddress(dll, "TestNoise");
            //根据库函数TestNoise_func获取委托实例
            TestNoise_delegate TestNoise = (TestNoise_delegate)Marshal.GetDelegateForFunctionPointer(TestNoise_func, typeof(TestNoise_delegate));

            char* fileName_Iniput = (char*)Marshal.StringToHGlobalAnsi(fileNameInput).ToPointer();

            char* fileName_Output = (char*)Marshal.StringToHGlobalAnsi(fileNameOutPut).ToPointer();

            TestNoise(fileName_Iniput, fileName_Output);
        }

        public void WavPcm16ToPcm8(string outPutPath_pcm16, string outPutPath)
        {
            using (WaveFileReader reader = new WaveFileReader(outPutPath_pcm16))
            {
                var newFormat = new WaveFormat(8000, 8, 1);
                using (var conversionStream = new WaveFormatConversionStream(newFormat, reader))
                {
                    WaveFileWriter.CreateWaveFile(outPutPath, conversionStream);
                }
            }

        }

        public void WavPcm8ToPcm16(string outPutPath_pcm16, string outPutPath)
        {
            using (WaveFileReader reader = new WaveFileReader(outPutPath_pcm16))
            {
                var newFormat = new WaveFormat(8000, 16, 1);
                using (var conversionStream = new WaveFormatConversionStream(newFormat, reader))
                {
                    WaveFileWriter.CreateWaveFile(outPutPath, conversionStream);
                }
            }

        }
    }
}
