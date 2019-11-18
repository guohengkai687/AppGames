using System;
using System.IO;

namespace WindowsServiceDemo
{
    class FileOperation
    {
        /// <summary>
        /// 保存至本地文件
        /// </summary>
        /// <param name="ETMID"></param>
        /// <param name="content"></param>
        public static void SaveRecord(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }


            FileStream fileStream = null;


            StreamWriter streamWriter = null;


            try
            {
                string folder = @"\\192.168.0.30\Tool";
                string path = Path.Combine(folder, string.Format("{0:yyyyMMdd}", DateTime.Now));

                using (fileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.Write(content);


                        if (streamWriter != null)
                        {
                            streamWriter.Close();
                        }
                    }


                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }
                }
            }
            catch { }
        }
    }
}
