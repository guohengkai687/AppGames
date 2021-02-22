using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsoleAppIO_Operation
{
    class Program
    {
        static string path = @"F:\TempFiles\";
        static int counter = 102400;
        static byte[] vs = new byte[counter];
        static TimeSpan startTime = new TimeSpan(21, 0, 0);
        static TimeSpan criticalTime = new TimeSpan(23, 59, 59);
        static TimeSpan criticalTime0 = new TimeSpan(0, 0, 0);
        static TimeSpan endTime = new TimeSpan(4, 0, 0);

        public delegate bool ControlCtrlDelegate(int CtrlType);
        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(ControlCtrlDelegate HandlerRoutine, bool Add);
        private static ControlCtrlDelegate cancelHandler = new ControlCtrlDelegate(HandlerRoutine);

        public static bool HandlerRoutine(int CtrlType)
        {
            switch (CtrlType)
            {
                case 0:
                    Console.WriteLine("0工具被强制关闭"); //Ctrl+C关闭  
                    break;
                case 2:
                    Console.WriteLine("2工具被强制关闭");//按控制台关闭按钮关闭  
                    break;
            }
            //DelectDir(path);

            Console.ReadLine();
            return false;
        }

        static void Main(string[] args)
        {
            SetConsoleCtrlHandler(cancelHandler, true);
            Console.WriteLine("请输入文件数：");
            string result = Console.ReadLine();

            while (int.Parse(result) > 0)
            {
                TimeSpan time = DateTime.Now.TimeOfDay;
                if ((time > startTime && time < criticalTime) || (time > criticalTime0 && time < endTime))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }
                    //填充数据
                    for (int i = 0; i < counter; i++)
                    {
                        vs[i] = 0XFE;
                    }
                    //写文件操作
                    for (int i = 0; i < int.Parse(result); i++)
                    {
                        using (FileStream fileStream = new FileStream(path + i, FileMode.Create, FileAccess.Write))
                        {
                            fileStream.Write(vs, 0, vs.Length);
                        }
                    }
                    //读文件操作
                    for (int i = 0; i < int.Parse(result); i++)
                    {
                        using (FileStream fileStream = new FileStream(path + i, FileMode.Open, FileAccess.Read))
                        {
                            if (File.Exists(path + i))
                            {
                                fileStream.Read(vs, 0, vs.Length);
                            }
                        }
                    }
                    //删除文件操作
                    for (int i = 0; i < int.Parse(result); i++)
                    {
                        if (File.Exists(path + i))
                        {
                            File.Delete(path + i);
                        }
                    }
                }
            }
            Console.ReadLine();
        }

        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
                dir.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
