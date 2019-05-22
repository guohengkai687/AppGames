using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using System.Runtime.InteropServices;
using NAudio.Wave.SampleProviders;

namespace MixerVoiceFormsDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_selectPath1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_inputPath1.Text = openFileDialog1.FileName;
            }
        }

        private void btn_selectPath2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_inputPath2.Text = openFileDialog1.FileName;
            }
        }

        private void btn_outputButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_outputPath.Text = saveFileDialog1.FileName;
            }
        }
        /// <summary>
        /// 混音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_mixerVoice_Click(object sender, EventArgs e)
        {
            string fileName1 = txt_inputPath1.Text;
            string fileName2 = txt_inputPath2.Text;
            string fileOutPut = txt_outputPath.Text;
            if (fileName1 == "" || fileName1 == string.Empty)
            {
                MessageBox.Show("输入文件为空");
            }
            if (fileName2 == "" || fileName2 == string.Empty)
            {
                MessageBox.Show("输入文件为空");
            }
            if (fileOutPut == "" || fileOutPut == string.Empty)
            {
                MessageBox.Show("输出文件为空");
            }
            List<byte> buf1 = new List<byte>();
            List<byte> buf2 = new List<byte>();
            using (FileStream fsinput1 = new FileStream(fileName1, FileMode.Open, FileAccess.Read))
            {
                int x = 0;
                while (true)
                {
                    x = fsinput1.ReadByte();
                    if (x==-1)
                    {
                        break;
                    }
                    buf1.Add((byte)x);
                }                
            }

            using (FileStream fsinput2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read))
            {
                int y = 0;
                while (true)
                {
                    y = fsinput2.ReadByte();
                    if (y==-1)
                    {
                        break;
                    }
                    buf2.Add((byte)y);
                }
            }
            byte[] datax = buf1.ToArray();
            byte[] datay = buf2.ToArray();                     

            try
            {
                #region 左右声道混音测试，失败
                //int size = datax.Length > datay.Length ? datax.Length : datay.Length;
                //byte[] mixedbuf = new byte[size];
                //if (datax.Length != datay.Length)
                //{
                //    if (datax.Length > datay.Length)
                //    {
                //        byte[] Ndatay = new byte[datax.Length];
                //        Buffer.BlockCopy(datay, 0, Ndatay, 0, datay.Length);
                //        mixedbuf = MixStereoToMono(datax, Ndatay);
                //    }
                //    else
                //    {
                //        byte[] Ndatax = new byte[datay.Length];
                //        Buffer.BlockCopy(datax, 0, Ndatax, 0, datax.Length);
                //        mixedbuf = MixStereoToMono(Ndatax, datay);
                //    }
                //}
                //else
                //{
                //    mixedbuf = MixStereoToMono(datax, datay);
                //}
                //WaveFormat mf = new WaveFormat(8000, 16, 1);
                //using (WaveFileWriter wf = new WaveFileWriter(fileOutPut, mf))
                //{
                //    wf.Write(mixedbuf, 0, mixedbuf.Length);
                //} 
                #endregion

                #region 手动添加Wav Header
                //PCMHeader ph = new PCMHeader();
                //byte[] header1 = ph.GeneratePCMHeader(datax.Length, 1, 8000, 8000, 16, datax.Length + 44);
                //byte[] header2 = ph.GeneratePCMHeader(datay.Length, 1, 8000, 8000, 16, datay.Length + 44);
                //byte[] x = new byte[44 + datax.Length];
                //byte[] y = new byte[44 + datay.Length];

                //Buffer.BlockCopy(header1, 0, x, 0, 44);
                //Buffer.BlockCopy(datax, 0, x, 44, datax.Length);
                //Buffer.BlockCopy(header2, 0, y, 0, 44);
                //Buffer.BlockCopy(datay, 0, y, 44, datay.Length);

                //MemoryStream ms1 = new MemoryStream(x);
                //MemoryStream ms2 = new MemoryStream(y);
                //WaveFileReader wrx = new WaveFileReader(ms1);
                //WaveFileReader wry = new WaveFileReader(ms2); 
                #endregion

                MemoryStream ms1 = new MemoryStream(datax);
                MemoryStream ms2 = new MemoryStream(datay);
                WaveFormat mf = new WaveFormat(8000, 8, 1);
                WaveStream wrx = new RawSourceWaveStream(ms1, mf);
                WaveStream wry = new RawSourceWaveStream(ms2, mf);
                Pcm8BitToSampleProvider reader1 = new Pcm8BitToSampleProvider(wrx);
                Pcm8BitToSampleProvider reader2 = new Pcm8BitToSampleProvider(wry);
                //Wave16ToFloatProvider wx = new Wave16ToFloatProvider(wrx);
                //Wave16ToFloatProvider wy = new Wave16ToFloatProvider(wry);
                //var reader1 = new WaveToSampleProvider(wx);
                //var reader2 = new WaveToSampleProvider(wy);
                
                //using (var reader1 = new AudioFileReader(fileName1))                    //ISampleProvider
                //using (var reader2 = new AudioFileReader(fileName2))                    //ISampleProvider
                //{
                    var mixer = new MixingSampleProvider(new[] { reader1, reader2 });   //ISampleProvider
                    var mm = new SampleToWaveProvider(mixer);                           //转换
                    //WaveFileWriter.CreateWaveFile(fileOutPut, mm);                      //IWaveProvider
                //}
               
                    List<byte> buf = new List<byte>();
                    using (WaveProviderToWaveStream ws = new WaveProviderToWaveStream(mm))
                    {                        
                        int m = 0;
                        while (true)
                        {
                            m = ws.ReadByte();
                            if (m==-1)
                            {
                                break;
                            }
                            buf.Add((byte)m);
                        }                        
                    }
                    if (buf.Count == 0)
                    {
                        return;
                    }
                    byte[] data = buf.ToArray();


                    using (FileStream fs = new FileStream("pcm_" + fileOutPut,FileMode.Create,FileAccess.Write))
                    {
                        fs.Write(data,0,data.Length);
                        fs.Close();
                    }
                    System.IntPtr ptrSource = Marshal.StringToHGlobalAnsi("pcm_" + fileOutPut);
                    System.IntPtr ptrTarget = Marshal.StringToHGlobalAnsi(fileOutPut + ".wav");
                    DJCVT.NativeMethods.PcmtoWaveNew(ptrSource, ptrTarget, 2);
                
                MessageBox.Show("混音成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {                
                txt_inputPath1.Text = string.Empty;
                txt_inputPath2.Text = string.Empty;
                txt_outputPath.Text = string.Empty;
            }
            
        }
        /// <summary>
        /// 左右声道混音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private byte[] MixStereoToMono(byte[] input, byte[] input2)
        {            
            byte[] output = new byte[input.Length / 2];
            int outputIndex = 0;
            for (int n = 0; n < input.Length; n += 8)
            {
                int leftChannel = BitConverter.ToInt16(input, n);
                int rightChannel = BitConverter.ToInt16(input2, n + 4);
                int mixed = (leftChannel + rightChannel) / 2;
                byte[] outSample = BitConverter.GetBytes((short)mixed);

                // copy in the first 16 bit sample
                output[outputIndex++] = outSample[0];
                output[outputIndex++] = outSample[1];
            }
            return output;
        }        
    }
}
