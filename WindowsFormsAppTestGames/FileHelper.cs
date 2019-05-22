using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppTestGames
{
    class FileHelper
    {
        /// <summary>
        /// FileStream写文件
        /// </summary>
        /// <param name="str">写入的内容</param>
        public void FileStreamWrite(string str)
        {
            byte[] bt;
            char[] ch;
            try
            {
                using (FileStream file = new FileStream("test.txt",FileMode.Create))
                {
                    ch = str.ToCharArray();
                    bt = new byte[ch.Length];
                    Encoder encoder = System.Text.Encoding.UTF8.GetEncoder();
                    encoder.GetBytes(ch, 0, ch.Length, bt, 0,true);
                    file.Seek(0, SeekOrigin.Begin);
                    file.Write(bt, 0, bt.Length);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }                 
        }
        /// <summary>
        /// FileStream 读文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public string FileStreamRead(string path)
        {
            byte[] bt;
            char[] ch;
            try
            {
                using (FileStream file = new FileStream(path, FileMode.Open))
                {
                    long length = file.Length;
                    bt = new byte[length];
                    ch = new char[length];
                    file.Seek(0, SeekOrigin.Begin);
                    file.Read(bt, 0, bt.Length);
                    Decoder decoder = System.Text.Encoding.UTF8.GetDecoder();
                    decoder.GetChars(bt, 0, bt.Length, ch, 0);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            if (ch.Length > 0)
            {
                return ch.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// StreamWrite写文件
        /// </summary>
        public void StreamWrite()
        {
            try
            {
                using (FileStream file = new FileStream("Test.text",FileMode.Create))
                {
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine("Test01");
                    writer.WriteLine("Test02");
                    writer.Write("Test03");

                    writer.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// StreamRead读文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string StreamRead(string path)
        {
            string str = string.Empty;
            try
            {
                using (FileStream file = new FileStream(path,FileMode.Open))
                {
                    StreamReader reader = new StreamReader(file);
                    str = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            else
            {
                return "";
            }
        }

    }
}
