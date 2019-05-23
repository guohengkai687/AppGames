using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
namespace MDRServerImpl
{
    public enum FtpInfoLevel
    {
        User = 0,
        System,
        Error
    }
    /// <summary>
    /// FTP信息
    /// </summary>
    public class FtpInfoEventArgs : EventArgs
    {
        private FtpInfoLevel m_Level = FtpInfoLevel.User;

        public FtpInfoLevel Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        private string m_Message;

        public string Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }
        private FtpSession m_Session;

        public FtpSession Session
        {
            get { return m_Session; }
            set { m_Session = value; }
        }
        private FtpUser m_User;

        public FtpUser User
        {
            get { return m_User; }
            set { m_User = value; }
        }
        private object m_State;

        public object State
        {
            get { return m_State; }
            set { m_State = value; }
        }
    }
    /// <summary>
    /// FTP传输方式
    /// </summary>
    public enum FtpTransferMode
    {
        Download = 0,
        Upload = 1
    }

    /// <summary>
    /// FTP传输进度 2011 0802 add
    /// </summary>
    public class FtpFileTransferProgressChangedEventArgs : EventArgs
    {
        public FtpFileTransferProgressChangedEventArgs(string clientIP, string filename, long fileLength, long fileTransfer)
        {
            m_ClientIP = clientIP;
            m_FileName = filename;
            m_FileLength = fileLength;
            m_FileTransfer = fileTransfer;
        }
        public FtpFileTransferProgressChangedEventArgs(FtpTransferMode transferMode, string clientIP, string filename, long fileLength, long fileTransfer)
        {
            m_FtpTransferMode = transferMode;
            m_ClientIP = clientIP;
            m_FileName = filename;
            m_FileLength = fileLength;
            m_FileTransfer = fileTransfer;
        }

        FtpTransferMode m_FtpTransferMode = FtpTransferMode.Download;//传输模式

        string m_ClientIP = "";

        public string ClientIP
        {
            get { return m_ClientIP; }
            set { m_ClientIP = value; }
        }
        int m_ClientPort = 0;

        public int ClientPort
        {
            get { return m_ClientPort; }
            set { m_ClientPort = value; }
        }


        string m_FileName = "";//GUID

        long m_FileLength = 0;//文件长度
        long m_FileTransfer = 0;//已完成传输

        public FtpTransferMode FtpTransferMode
        {
            get { return m_FtpTransferMode; }
            set { m_FtpTransferMode = value; }
        }

        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

        public long FileLength
        {
            get { return m_FileLength; }
            set { m_FileLength = value; }
        }

        public long FileTransfer
        {
            get { return m_FileTransfer; }
            set { m_FileTransfer = value; }
        }

        private object m_Target = null;//参数

        public object Target
        {
            get { return m_Target; }
            set { m_Target = value; }
        }
    }

    /// <summary>
    /// Ftp用户
    /// </summary>
    public class FtpUser
    {
        public FtpUser()
        {
            //FtpUserPolicy fup01 = new FtpUserPolicy("/MDR01/", @"D:\WorkSpace\");
            //FtpUserPolicy fup02 = new FtpUserPolicy("/MDR02/", @"E:\安装程序\");
            //m_PolicyList.Add(fup01);
            //m_PolicyList.Add(fup02);
            //this.UseVirtualSubDirectory = true;

            //FtpUserPolicy fup = new FtpUserPolicy("/MDR01/", @"D:\WorkSpace\");
            //m_PolicyList.Add(fup);
            //this.UseVirtualSubDirectory = true;

            FtpUserPolicy fup = new FtpUserPolicy("/", @"D:\");
            m_PolicyList.Add(fup);
            //fup.DirBrowser = false;
            this.UseVirtualSubDirectory = false;
        }

        private string m_UserName;//用户名
        private string m_Password;//密码

        private List<FtpUserPolicy> m_PolicyList = new List<FtpUserPolicy>();

        //是否使用虚拟子目录,不使用使用虚拟子目录时只能有一个FtpUserPolicy对象,并且FtpUserPolicy.VirtualPath = '\'
        private bool m_UseVirtualSubDirectory = false;

        private long m_MaxTransUnit = 1024;//最大传输单元,单位:字节
        private long m_MaxDownloadSpeed = 0;// 100*1024;//最大下载速度,单位:字节/秒,必须为m_MaxTransUnit的整数倍;0为不限制
        private long m_MaxUploadSpeed = 1024;//最大上传速度,单位:字节/秒,必须为m_MaxTransUnit的整数倍;0为不限制

        #region 属性
        public List<FtpUserPolicy> PolicyList
        {
            get { return m_PolicyList; }
            set { m_PolicyList = value; }
        }
        public bool UseVirtualSubDirectory
        {
            get { return m_UseVirtualSubDirectory; }
            set { m_UseVirtualSubDirectory = value; }
        }
        public long MaxTransUnit
        {
            get { return m_MaxTransUnit; }
            set { m_MaxTransUnit = value; }
        }
        public long MaxDownloadSpeed
        {
            get { return m_MaxDownloadSpeed; }
            set { m_MaxDownloadSpeed = value; }
        }
        public long MaxUploadSpeed
        {
            get { return m_MaxUploadSpeed; }
            set { m_MaxUploadSpeed = value; }
        }
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        #endregion
    }

    //用户目录控制
    public class FtpUserPolicy
    {
        public FtpUserPolicy(string virtualPath, string localPath)
        {
            m_VirtualPath = virtualPath;
            m_LocalPath = localPath;
        }

        private string m_LocalPath;//本地路径,格式为"D:\"或者"D:\Data\"
        private string m_VirtualPath;//虚拟路径,格式为"/"或者"/MDR001/";"/"代表虚拟路径就是本地路径根目录下

        private bool m_DirBrowser = true;//浏览文件夹
        private bool m_DirCreate = false;//创建文件夹
        private bool m_DirDelete = false;//删除文件夹
        private bool m_DirRename = false;//重命名文件夹

        private bool m_FileDownload = true;//文件下载
        private bool m_FileDelete = false;//文件删除
        private bool m_FileUpload = true;//文件上传
        private bool m_FileRename = false;//文件重命名

        #region 属性
        public bool DirBrowser
        {
            get { return m_DirBrowser; }
            set { m_DirBrowser = value; }
        }
        public bool DirCreate
        {
            get { return m_DirCreate; }
            set { m_DirCreate = value; }
        }
        public bool DirDelete
        {
            get { return m_DirDelete; }
            set { m_DirDelete = value; }
        }
        public bool DirRename
        {
            get { return m_DirRename; }
            set { m_DirRename = value; }
        }
        public bool FileDownload
        {
            get { return m_FileDownload; }
            set { m_FileDownload = value; }
        }
        public bool FileDelete
        {
            get { return m_FileDelete; }
            set { m_FileDelete = value; }
        }
        public bool FileUpload
        {
            get { return m_FileUpload; }
            set { m_FileUpload = value; }
        }
        public bool FileRename
        {
            get { return m_FileRename; }
            set { m_FileRename = value; }
        }
        public string LocalPath
        {
            get { return m_LocalPath; }
            set { m_LocalPath = value; }
        }
        public string VirtualPath
        {
            get { return m_VirtualPath; }
            set { m_VirtualPath = value; }
        }
        #endregion
    }

    /// <summary>
    /// FTP Session
    /// </summary>
    public class FtpSession
    {
        private FtpServer m_Server = null;//FtpServer引用
        private Socket m_Socket = null;//处理远程连接的Socket
        private IPEndPoint m_LocalEP = null;//本地端口
        private IPEndPoint m_RemoteEP = null;//远程地址,与21端口连接的
        private IPEndPoint m_RemoteDataEP = null;//远程地址,主动模式时传输数据

        private byte[] m_MaxBuffer = new byte[1024];//缓冲区
        private Encoding m_SessionEncoding = Encoding.Default;//采用默认编码
        private bool m_Authenticated = false;//验证用户登录成功
        private FtpUser m_User = null;//登录用户帐户

        private string m_RootDir = "/";//虚拟根目录
        private string m_CurrentDir = "/";//当前路径(虚拟路径)

        private bool m_PassiveMode = false;//是否为被动模式(被动模式等待来自客户端的服务连接;主动模式,连接客户端指定的端口传输数据)
        private Socket m_PassiveListener = null;//被动模式监听器,等待客户端连接

        private long m_BreakPoint = 0;//断点续传位置

        private static Regex m_RegexIP = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");//验证IP正则式

        //虚拟路径分隔符号
        private char m_VirtualPathSpliter = '/';
        private char m_LocalPathSpliter = '\\';// '\\' - Windows(第一个\是转义); '/' - Unix

        //当前用户权限;虚拟根目录时为null
        private FtpUserPolicy m_CurrentPolicy = null;
        //查找与本地路径最匹配的FTP权限
        private FtpUserPolicy FindMatchFtpUserPolicy(string localPath)
        {
            FtpUserPolicy m_MatchedPolicy = null;
            int m_LastMachedCharNum = -1;
            foreach (FtpUserPolicy policy in m_User.PolicyList)
            {
                if (localPath.ToLower().StartsWith(policy.LocalPath.TrimEnd(m_LocalPathSpliter).ToLower()))
                {
                    if (m_LastMachedCharNum < policy.LocalPath.Length)
                    {
                        m_LastMachedCharNum = policy.LocalPath.Length;
                        m_MatchedPolicy = policy;
                    }
                }
            }
            return m_MatchedPolicy;
        }

        //本地路径映射到虚拟路径
        private string MapLocalPathToVirtualPath(string localPath)
        {
            string fullVirtualPath = "";
            FtpUserPolicy policy = null;
            //包含虚拟子目录
            if (m_User.UseVirtualSubDirectory)
            {
                policy = FindMatchFtpUserPolicy(localPath);

            }
            else
            {
                policy = m_User.PolicyList[0];
            }

            fullVirtualPath = localPath.Replace(policy.LocalPath, policy.VirtualPath);
            fullVirtualPath = fullVirtualPath.Replace("\\", m_VirtualPathSpliter.ToString());
            fullVirtualPath = fullVirtualPath.Replace("//", m_VirtualPathSpliter.ToString());

            return fullVirtualPath;
        }

        //虚拟路径映射到本地路径,返回值:false,虚拟根目录(带虚拟子目录);true,本地路径
        private bool MapVirtualPathToLocalPath(string argsText, out string localPath)
        {
            //避免处理带空格的路径
            string fullVirtualPath = argsText.TrimEnd('*');

            //收到"LIST -al"命令时
            if (fullVirtualPath.StartsWith("-"))
            {
                //TODO:参数检查功能
                fullVirtualPath = "";
            }

            //如果不是以'/'开始(以'/'开始说明是完整路径)
            if (!fullVirtualPath.StartsWith(m_VirtualPathSpliter.ToString()))
            {
                //如果不是是以'/'结束的
                if (!m_CurrentDir.EndsWith(m_VirtualPathSpliter.ToString()))
                {
                    fullVirtualPath = m_CurrentDir + m_VirtualPathSpliter.ToString() + fullVirtualPath;
                }
                else
                {
                    fullVirtualPath = m_CurrentDir + fullVirtualPath;
                }
            }
            //至此获得完整的虚拟路径/xxx/xxx/xxx(中间可能包含..等)
            fullVirtualPath = fullVirtualPath.Replace("\\", m_VirtualPathSpliter.ToString());
            fullVirtualPath = fullVirtualPath.Replace("//", m_VirtualPathSpliter.ToString());

            //分割完整路径
            if (!string.IsNullOrEmpty(fullVirtualPath))
            {
                string[] dirParties = fullVirtualPath.Trim(m_VirtualPathSpliter).Split(m_VirtualPathSpliter);
                fullVirtualPath = "";
                if (dirParties != null && dirParties.Length > 0)
                {
                    foreach (string part in dirParties)
                    {
                        if (!string.IsNullOrEmpty(part))
                        {
                            if (part != "..")
                            {
                                if (!fullVirtualPath.EndsWith(m_VirtualPathSpliter.ToString()))
                                {
                                    fullVirtualPath = fullVirtualPath + m_VirtualPathSpliter + part;
                                }
                                else
                                {
                                    fullVirtualPath = fullVirtualPath + part;
                                }
                            }
                            else
                            {
                                int index = fullVirtualPath.LastIndexOf(m_VirtualPathSpliter) + 1;
                                if (index > 0)
                                {
                                    fullVirtualPath = fullVirtualPath.Substring(0, index);
                                }
                            }
                        }
                    }
                }
            }
            fullVirtualPath = fullVirtualPath.Trim(m_VirtualPathSpliter);
            //至此获得完整的虚拟路径xxx/xxx/xxx(中间不包含..等,两边不包含'/')

            //虚拟目录 = "",说明是根目录
            if (string.IsNullOrEmpty(fullVirtualPath))
            {
                if (m_User.UseVirtualSubDirectory)
                {
                    localPath = "";
                    return false;
                }
                else
                {
                    //m_CurrentPolicy = m_User.PolicyList[0];
                    localPath = m_User.PolicyList[0].LocalPath;
                    return true;
                }
            }
            else
            {
                string[] dirParties = fullVirtualPath.Split(m_VirtualPathSpliter);
                string virtualPathInPolicy = dirParties[0];
                string fullLocalPath = "";
                if (m_User.UseVirtualSubDirectory)
                {
                    foreach (FtpUserPolicy policy in m_User.PolicyList)
                    {
                        if (policy.VirtualPath.Trim(m_VirtualPathSpliter).ToLower().Equals(virtualPathInPolicy.Trim(m_VirtualPathSpliter).ToLower()))
                        {
                            //m_CurrentPolicy = policy;
                            fullLocalPath = policy.LocalPath;
                            break;
                        }
                    }

                    //包含虚拟子目录从index = 1 开始
                    for (int i = 1; i < dirParties.Length; i++)
                    {
                        if (!fullLocalPath.EndsWith(m_LocalPathSpliter.ToString()))
                        {
                            fullLocalPath = fullLocalPath + m_LocalPathSpliter.ToString() + dirParties[i];
                        }
                        else
                        {
                            fullLocalPath = fullLocalPath + dirParties[i];
                        }
                    }

                }
                else
                {
                    //m_CurrentPolicy = m_User.PolicyList[0];
                    fullLocalPath = m_User.PolicyList[0].LocalPath;
                    //不包含虚拟子目录从index = 0 开始
                    for (int i = 0; i < dirParties.Length; i++)
                    {
                        if (!fullLocalPath.EndsWith(m_LocalPathSpliter.ToString()))
                        {
                            fullLocalPath = fullLocalPath + m_LocalPathSpliter.ToString() + dirParties[i];
                        }
                        else
                        {
                            fullLocalPath = fullLocalPath + dirParties[i];
                        }
                    }
                }
                localPath = fullLocalPath;
                return true;
            }
        }

        //递归删除文件夹
        public static void DeleteFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件   
                }
                else
                    DeleteFolder(d);//递归删除子文件夹   
            }
            Directory.Delete(dir);//删除已空文件夹   
        }

        //获取数据连接Socket
        private Socket GetDataConnection()
        {
            Socket socket = null;
            try
            {
                if (m_PassiveMode)
                {
                    //等待Ftp客户端数据连接			
                    long startTime = DateTime.Now.Ticks;
                    //Socket.Poll代替TcpListener.Pending方式判断是否有连接
                    while (!m_PassiveListener.Poll(1000, SelectMode.SelectRead))
                    {
                        System.Threading.Thread.Sleep(50);

                        //30秒超时
                        if ((DateTime.Now.Ticks - startTime) / 10000 > 20000)
                        {
                            throw new Exception("Ftp server didn't respond !");
                        }
                    }

                    socket = m_PassiveListener.Accept();
                    this.Socket.Send(SessionEncoding.GetBytes("125 Data connection open, Transfer starting.\r\n"));
                }
                else
                {
                    this.Socket.Send(SessionEncoding.GetBytes("150 Opening data connection.\r\n"));

                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(m_RemoteDataEP);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                System.Diagnostics.Debug.Print(ex.StackTrace);

                this.Socket.Send(SessionEncoding.GetBytes("425 Can't open data connection.\r\n"));
                return null;
            }

            m_PassiveMode = false;

            return socket;
        }

        public FtpSession(FtpServer server, Socket socket)
        {
            m_Server = server;
            m_Socket = socket;
            m_RemoteEP = m_Socket.RemoteEndPoint as IPEndPoint;
            m_LocalEP = m_Socket.LocalEndPoint as IPEndPoint;
            StartSession();
        }
        //开始
        private void StartSession()
        {
            m_Server.AddSession(this);

            byte[] data = SessionEncoding.GetBytes("220 Ftp server 0.1 ready \r\n");
            m_Socket.Send(data);
            m_Socket.BeginReceive(m_MaxBuffer, 0, m_MaxBuffer.Length,
                SocketFlags.None, new AsyncCallback(RecvSessionData), m_Socket);
        }
        //结束
        private void EndSession()
        {
            m_Server.RemoveSession(this);

            //关闭命令传输Session
            if (m_Socket != null)
            {
                m_Socket.Shutdown(SocketShutdown.Both);
                m_Socket.Close();
                m_Socket = null;
            }

            ////关闭被动模式监听
        }

        //接收Session数据
        public void RecvSessionData(IAsyncResult iar)
        {
            try
            {
                int recv = m_Socket.EndReceive(iar);
                if (recv > 0)
                {
                    //默认编码
                    string text = SessionEncoding.GetString(m_MaxBuffer, 0, recv);

                    //日志
                    FtpInfoEventArgs args = new FtpInfoEventArgs();
                    args.Session = this;
                    args.User = this.User;
                    args.Level = FtpInfoLevel.System;
                    args.Message = string.Format("收到来自{0}:{1}的命令:{2}", RemoteEP.Address, RemoteEP.Port, text);
                    this.m_Server.ReportFtpInfoEventArgs(args);

                    //System.Diagnostics.Debug.Print("收到来自{0}:{1}的命令:{2}", RemoteEP.Address, RemoteEP.Port,text);
                    if (this.SwitchFtpCommand(text))
                    {
                        //收到QUIT命令
                        EndSession();
                        return;
                    }
                    else
                    {
                        //m_Socket.BeginReceive(m_MaxBuffer, 0, m_MaxBuffer.Length,
                        //    SocketFlags.None, new AsyncCallback(RecvSessionData), this);
                    }

                    m_Socket.BeginReceive(m_MaxBuffer, 0, m_MaxBuffer.Length,
                                         SocketFlags.None, new AsyncCallback(RecvSessionData), m_Socket);
                }
                else
                {
                    this.EndSession();
                }
            }
            catch (SocketException ex)
            {
                this.EndSession();
            }
            catch (Exception ex)
            {
                this.EndSession();
            }
        }

        //命令分拣器
        private bool SwitchFtpCommand(string commandText)
        {
            bool bTerminal = false;//是否终止
            string[] cmdParts = commandText.TrimStart().Split(new char[] { ' ' });

            string command = cmdParts[0].ToUpper().Trim();//命令
            string argsText = commandText.Substring(command.Length).Trim();//参数

            //2011 1116 jjzhang add
            FtpInfoEventArgs args = new FtpInfoEventArgs();
            args.Session = this;
            args.User = this.User;
            switch (command)
            {
                case "USER"://用户名
                    USER(argsText);
                    break;
                case "PASS"://密码
                    PASS(argsText);
                    break;
                case "OPTS":
                    OPTS(argsText);
                    break;
                case "NOOP":
                    NOOP(argsText);
                    break;
                case "NOP":
                    NOOP(argsText);
                    break;
                case "SYST"://系统
                    SYST(argsText);
                    break;
                case "SITE":
                    SITE(argsText);
                    break;
                case "EPSV":
                    EPSV(argsText);
                    break;
                case "MODE":
                    MODE(argsText);
                    break;
                case "FEAT"://查询扩展命令(不支持)
                    FEAT(argsText);
                    break;
                case "PWD"://查询当前目录
                    PWD(argsText);
                    break;
                case "CWD"://改变服务器上的工作目录
                    CWD(argsText);
                    break;
                case "TYPE"://数据类型（A=ASCII，E=EBCDIC，I=binary）
                    TYPE(argsText);
                    break;
                case "PASV"://请求服务器等待客户端连接
                    PASV(argsText);
                    break;
                case "PORT"://请求服务器连接客户端
                    PORT(argsText);
                    break;
                case "NLST"://显示列表
                    NLST(argsText);
                    break;
                case "LIST"://显示列表
                    LIST(argsText);
                    break;
                case "RETR"://下载文件
                    RETR(argsText);
                    break;
                case "REST"://断点续传
                    REST(argsText);
                    break;
                case "SIZE"://读取文件大小
                    SIZE(argsText);
                    break;
                case "DELE"://删除文件
                    DELE(argsText);
                    break;
                case "STOR"://上传文件
                    STOR(argsText);
                    break;
                case "MKD"://创建文件夹
                    MKD(argsText);
                    break;
                case "RMD"://删除文件夹(递归)
                    RMD(argsText);
                    break;
                case "QUIT":
                    QUIT(argsText);
                    bTerminal = true;
                    break;
                default:

                    //日志
                    args.Level = FtpInfoLevel.System;
                    args.Message = string.Format("未能识别来自{0}:{1}的命令:{2}", RemoteEP.Address, RemoteEP.Port, commandText);
                    this.m_Server.ReportFtpInfoEventArgs(args);

                    //bTerminal = true;
                    this.Socket.Send(SessionEncoding.GetBytes("500 Invalid Command " + commandText + ". \r\n"));
                    if (m_BadCmdCount > m_Server.MaxBadCommands - 1)
                    {
                        this.Socket.Send(SessionEncoding.GetBytes("421 Too many bad commands, closing transmission channel.\r\n"));
                        bTerminal = true;
                    }
                    m_BadCmdCount++;
                    if (m_BadCmdCount == int.MaxValue)
                    {
                        m_BadCmdCount = 1;
                    }
                    break;
            }
            return bTerminal;
        }

        //错误命令计数
        private int m_BadCmdCount = 0;

        //2011 1116 jjzhang add
        private void MODE(string argsText)
        {
            this.Socket.Send(SessionEncoding.GetBytes("200 MODE OK.\r\n"));
        }

        //2011 1116 jjzhang add
        private void EPSV(string argsText)
        {
            this.Socket.Send(SessionEncoding.GetBytes("229 Entering passive mode.\r\n"));
        }

        //2011 1116 jjzhang add
        private void SITE(string argsText)
        {
            this.Socket.Send(SessionEncoding.GetBytes("200 SITE OK .\r\n"));
        }

        //2011 1111 jjzhang add
        private void NOOP(string argsText)
        {
            this.Socket.Send(SessionEncoding.GetBytes("200 NOOP OK .\r\n"));
        }
        //2011 1111 jjzhang add
        private void OPTS(string argsText)
        {
            if (!string.IsNullOrEmpty(argsText))
            {
                string[] param = argsText.Split(new char[] { ' ' });
                if (param != null && param.Length == 2)
                {
                    if (param[1].ToLower().Trim().Equals("on"))
                    {
                        if (param[0].ToLower().Trim().Equals("utf8"))
                        {
                            //this.SessionEncoding = Encoding.GetEncoding(@"utf-8");
                            this.SessionEncoding = Encoding.UTF8;
                        }
                        else
                        {
                            //this.SessionEncoding = Encoding.GetEncoding(param[0].ToUpper().Trim());
                        }
                    }
                    else
                    {
                        this.SessionEncoding = Encoding.Default;
                    }

                    this.Socket.Send(SessionEncoding.GetBytes("200 OPTS " + param[0] + " command successful - " + param[0] + " encoding now " + param[1] + ". \r\n"));
                }
                else
                {
                    this.Socket.Send(SessionEncoding.GetBytes("500 Invalid param " + argsText + ". \r\n"));
                }
            }
            else
            {
                this.Socket.Send(SessionEncoding.GetBytes("500 Invalid param " + argsText + ". \r\n"));
            }

        }
        //退出
        private void QUIT(string argsText)
        {
            this.Socket.Send(SessionEncoding.GetBytes("221 FTP server signing off. \r\n"));
        }
        //验证用户名
        private void USER(string argsText)
        {
            //已经登录成功
            if (this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("500 You are already authenticated. \r\n"));
                return;
            }
            else
            {
                //已经输入用户名
                if (m_User != null)
                {
                    this.Socket.Send(SessionEncoding.GetBytes("500 Username is already specified, please specify password.\r\n"));
                    return;
                }
                m_User = new FtpUser();
            }
            string[] param = argsText.Split(new char[] { ' ' });

            //参数只能有一个
            if (argsText.Length > 0 && param.Length == 1)
            {
                m_User.UserName = param[0];
                this.Socket.Send(SessionEncoding.GetBytes("331 Password required or user:'" + m_User.UserName + "'\r\n"));
            }
            else
            {
                this.Socket.Send(SessionEncoding.GetBytes("500 Syntax error. Syntax:{USER username} \r\n"));
            }
        }
        //验证密码
        private void PASS(string argsText)
        {
            //已经登录成功
            if (this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("500 You are already authenticated \r\n"));
                return;
            }
            else
            {
                //还未输入用户名
                if (m_User == null)
                {
                    this.Socket.Send(SessionEncoding.GetBytes("503 Please specify username first \r\n"));
                    return;
                }
            }

            string[] param = argsText.Split(new char[] { ' ' });

            //参数只能有一个
            if (param.Length == 1)
            {
                m_User.Password = param[0];
                //验证用户
                if (m_Server.OnAuthUser(this, m_User))
                {
                    this.Socket.Send(SessionEncoding.GetBytes("230 Password ok. \r\n"));
                    m_Authenticated = true;//验证通过
                }
                else
                {
                    this.Socket.Send(SessionEncoding.GetBytes("530 UserName or Password is incorrect. \r\n"));
                    m_User = null;
                }
            }
            else
            {
                this.Socket.Send(SessionEncoding.GetBytes("500 Syntax error. Syntax:{PASS userName} \r\n"));
            }
        }
        //操作系统类型
        private void SYST(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            this.Socket.Send(SessionEncoding.GetBytes("215 Windows_NT\r\n"));
            //this.Socket.Send(SessionEncoding.GetBytes("215 UNIX Type:L8\r\n"));
        }
        //查询扩展命令
        private void FEAT(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            //Response("211-Features:\r\n MDTM\r\n SIZE\r\n REST STREAM\r\n PASV\r\n211 End");
            this.Socket.Send(SessionEncoding.GetBytes("211-Extensions support:\r\n SIZE\r\n MDTM\r\n211 End\r\n"));
        }
        //查询当前目录
        private void PWD(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            this.Socket.Send(SessionEncoding.GetBytes("257 \"" + m_CurrentDir + "\" is current directory.\r\n"));
        }
        //改变服务器上的工作目录
        private void CWD(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }

            //string virtualPath = argsText.Split(' ')[0].TrimEnd('*');
            string localPath;
            bool bFind = MapVirtualPathToLocalPath(argsText, out localPath);

            m_CurrentPolicy = FindMatchFtpUserPolicy(localPath);

            //虚拟根目录(带虚拟子目录)
            if (!bFind)
            {
                m_CurrentDir = m_RootDir;
            }
            else
            {
                m_CurrentDir = MapLocalPathToVirtualPath(localPath);
            }

            this.Socket.Send(SessionEncoding.GetBytes("250 \"" + m_CurrentDir + "\" is current directory. \r\n"));
        }

        //数据类型（A=ASCII，E=EBCDIC，I=binary）
        private void TYPE(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            if (argsText.Trim().ToUpper() == "A" || argsText.Trim().ToUpper() == "I")
            {
                this.Socket.Send(SessionEncoding.GetBytes("200 Type is set to " + argsText + ".\r\n"));
                return;
            }
            this.Socket.Send(SessionEncoding.GetBytes("500 Invalid type " + argsText + ".\r\n"));
        }
        //请求服务器等待数据连接
        private void PASV(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }

            //查找一个可用端口,并且监听这个端口
            int port = m_Server.PassiveStartPort;
            while (true)
            {
                try
                {
                    if (m_PassiveListener != null)
                    {
                        m_PassiveListener.Shutdown(SocketShutdown.Both);
                        m_PassiveListener.Close();
                        m_PassiveListener = null;
                    }

                    if (m_PassiveListener == null)
                    {
                        m_PassiveListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        m_PassiveListener.Bind(new IPEndPoint(IPAddress.Any, port));
                        m_PassiveListener.Listen(1);
                    }
                    break;
                }
                catch (Exception ex)
                {
                    m_PassiveListener = null;
                    System.Diagnostics.Debug.Print(ex.Message);
                    System.Diagnostics.Debug.Print(ex.StackTrace);
                }
                port++;
            }

            m_PassiveMode = true;
            m_BreakPoint = 0;
            //如果对Ftp Server设置了Passive的IP地址
            if (m_Server.PassivePublicIP != null)
            {
                this.Socket.Send(SessionEncoding.GetBytes("227 Entering Passive Mode (" +
                    m_Server.PassivePublicIP.ToString().Replace(".", ",") + "," + (port >> 8) + "," + (port & 255) + "). \r\n"));
            }
            else
            {
                this.Socket.Send(SessionEncoding.GetBytes("227 Entering Passive Mode (" +
                    m_LocalEP.Address.ToString().Replace(".", ",") + "," + (port >> 8) + "," + (port & 255) + "). \r\n"));
            }
        }
        //请求服务器连接客户端
        private void PORT(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }

            string[] parts = argsText.Split(',');
            if (parts.Length != 6)
            {
                this.Socket.Send(SessionEncoding.GetBytes("550 Invalid arguments. \r\n"));
                return;
            }

            string ip = parts[0] + "." + parts[1] + "." + parts[2] + "." + parts[3];
            int port = (Convert.ToInt32(parts[4]) << 8) | Convert.ToInt32(parts[5]);
            if (m_RegexIP.IsMatch(ip))
            {
                m_RemoteDataEP = new IPEndPoint(IPAddress.Parse(ip), port);
            }
            else
            {
                m_RemoteDataEP = new IPEndPoint(System.Net.Dns.GetHostEntry(ip).AddressList[0], port);
            }

            m_PassiveMode = false;
            this.Socket.Send(SessionEncoding.GetBytes("200 PORT Command successful.\r\n"));
        }
        //列出用户目录
        private void NLST(string argsText)
        {
            LIST(argsText);
        }

        //列出用户目录
        private void LIST(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }

            string localPath;
            bool bFind = MapVirtualPathToLocalPath(argsText, out localPath);
            if (m_CurrentPolicy == null)
            {
                m_CurrentPolicy = FindMatchFtpUserPolicy(localPath);
            }

            Socket m_DataSocket = this.GetDataConnection();

            //虚拟根目录
            if (!bFind)
            {
                foreach (FtpUserPolicy policy in m_User.PolicyList)
                {
                    //MM-dd-yy
                    string response = string.Format("{0} {1} {2}\r\n",
                            DateTime.Now.AddDays(-1).ToString("MM-dd-yy HH:mm:ss"),
                            "<DIR>",
                            policy.VirtualPath.Trim(m_VirtualPathSpliter));
                    m_DataSocket.Send(SessionEncoding.GetBytes(response));
                }

                this.Socket.Send(SessionEncoding.GetBytes("226 Transfer Complete.\r\n"));
            }
            else
            {
                if (m_CurrentPolicy == null || m_CurrentPolicy.DirBrowser)
                {
                    if (Directory.Exists(localPath))
                    {
                        DirectoryInfo localDir = new DirectoryInfo(localPath);
                        DirectoryInfo[] dirs = localDir.GetDirectories();
                        if (dirs != null && dirs.Length > 0)
                        {
                            foreach (DirectoryInfo dir in dirs)
                            {
                                string response = string.Format("{0} {1} {2}\r\n",
                                    dir.LastWriteTime.ToString("MM-dd-yy HH:mm:ss"),
                                    "<DIR>",
                                    dir.Name);
                                m_DataSocket.Send(SessionEncoding.GetBytes(response));
                            }
                        }
                        FileInfo[] files = localDir.GetFiles();
                        if (files != null && files.Length > 0)
                        {
                            foreach (FileInfo file in files)
                            {
                                string response = string.Format("{0} {1} {2}\r\n",
                                    file.LastWriteTime.ToString("MM-dd-yy HH:mm:ss"),
                                    file.Length,
                                    file.Name);
                                m_DataSocket.Send(SessionEncoding.GetBytes(response));
                            }
                        }

                        this.Socket.Send(SessionEncoding.GetBytes("226 Transfer Complete.\r\n"));
                    }
                    else
                    {
                        this.Socket.Send(SessionEncoding.GetBytes("553 Direcory not exits.\r\n"));
                    }
                }
                else
                {
                    this.Socket.Send(SessionEncoding.GetBytes("501 Permission NLST LIST denied.\r\n"));
                }
            }

            m_DataSocket.Shutdown(SocketShutdown.Both);
            m_DataSocket.Close();
        }
        private DateTime m_lastReportDt = DateTime.Now;
        //下载文件
        private void RETR(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            //string virtualPath = argsText.Split(' ')[0].TrimEnd('*');
            string localPath;
            bool bFind = MapVirtualPathToLocalPath(argsText, out localPath);
            try
            {
                if (m_CurrentPolicy == null || m_CurrentPolicy.FileDownload)
                {
                    if (File.Exists(localPath))
                    {
                        FileInfo fileInfo = new FileInfo(localPath);
                        using (Stream fileStream = new FileStream(localPath, FileMode.Open, FileAccess.Read))
                        {
                            Socket socket = GetDataConnection();

                            int speedLimitSleepTime = 0;
                            //需要限速
                            if (m_User.MaxDownloadSpeed > 0)
                            {
                                speedLimitSleepTime = (int)(1000 * m_User.MaxTransUnit / m_User.MaxDownloadSpeed);
                            }

                            long m_Readed = 0;

                            IPEndPoint m_CleintIPEndPoint = (IPEndPoint)socket.RemoteEndPoint;
                            string m_CleintIP = m_CleintIPEndPoint.Address.ToString();
                            FtpFileTransferProgressChangedEventArgs e = new FtpFileTransferProgressChangedEventArgs(m_CleintIP, fileInfo.Name, fileInfo.Length, m_Readed);

                            fileStream.Seek(m_BreakPoint, SeekOrigin.Begin);
                            m_Readed += m_BreakPoint;
                            int readed = 1;

                            while (readed > 0)
                            {

                                byte[] data = new byte[m_User.MaxTransUnit];//最大传输单元
                                if (m_User.MaxDownloadSpeed <= 0)
                                {
                                    readed = fileStream.Read(data, 0, data.Length);
                                    socket.Send(data, readed, SocketFlags.None);
                                    m_Readed += readed;
                                }
                                else//速度限制
                                {
                                    readed = fileStream.Read(data, 0, data.Length);
                                    socket.Send(data, readed, SocketFlags.None);
                                    m_Readed += readed;
                                    Thread.Sleep(speedLimitSleepTime);
                                }

                                //最多每秒钟通知一次
                                if (Math.Abs((DateTime.Now - m_lastReportDt).TotalMilliseconds) >= 1000)
                                {
                                    m_lastReportDt = DateTime.Now;
                                    m_Server.ReportFtpFileTransferProgressChanged(e);
                                }
                            }

                            m_Server.ReportFtpFileTransferProgressChanged(e);

                            socket.Shutdown(SocketShutdown.Both);
                            socket.Close();
                        }
                        this.Socket.Send(SessionEncoding.GetBytes("226 Transfer Complete.\r\n"));
                    }
                    else
                    {
                        this.Socket.Send(SessionEncoding.GetBytes("550 File not found.\r\n"));
                    }
                }
                else
                {
                    this.Socket.Send(SessionEncoding.GetBytes("501 Permission RETR denied.\r\n"));
                }
            }
            catch (Exception ex)
            {
                this.Socket.Send(SessionEncoding.GetBytes("426 Connection closed; transfer aborted.\r\n"));
            }
        }
        //断点续传(与RETR配合实现)
        private void REST(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            long temp = long.Parse(argsText);
            if (temp >= 0)
            {
                m_BreakPoint = temp;
                this.Socket.Send(SessionEncoding.GetBytes(string.Format("350 Restarting at {0}\r\n", m_BreakPoint)));
            }
        }
        //读取文件大小
        private void SIZE(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            //string virtualPath = argsText.Split(' ')[0].TrimEnd('*');
            string localPath;
            bool bFind = MapVirtualPathToLocalPath(argsText, out localPath);
            if (File.Exists(localPath))
            {
                FileInfo file = new FileInfo(localPath);
                this.Socket.Send(SessionEncoding.GetBytes("213 \"" + file.Length + "\" \r\n"));
            }
            else
            {
                this.Socket.Send(SessionEncoding.GetBytes("550 File not found.\r\n"));
            }
        }
        //删除文件
        private void DELE(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            //string virtualPath = argsText.Split(' ')[0].TrimEnd('*');
            string localPath;
            bool bFind = MapVirtualPathToLocalPath(argsText, out localPath);
            if (File.Exists(localPath))
            {
                File.Delete(localPath);
                this.Socket.Send(SessionEncoding.GetBytes("250 File deleted.\r\n"));
            }
            else
            {
                this.Socket.Send(SessionEncoding.GetBytes("550 File not found.\r\n"));
            }
        }
        //上传文件
        private void STOR(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            //string virtualPath = argsText.Split(' ')[0].TrimEnd('*');
            string localPath;
            bool bFind = MapVirtualPathToLocalPath(argsText, out localPath);
            try
            {
                if (m_CurrentPolicy == null || m_CurrentPolicy.FileUpload)
                {
                    using (Stream fileStream = new FileStream(localPath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        Socket socket = GetDataConnection();
                        long m_Writed = 0;
                        fileStream.Seek(m_BreakPoint, SeekOrigin.Begin);
                        m_Writed += m_BreakPoint;
                        int m_Recv = 1;//接受数据包实际大小
                        while (m_Recv > 0)
                        {
                            //m_DataSessionLastActivityDate = DateTime.Now;

                            byte[] data = new byte[10000];
                            m_Recv = socket.Receive(data);
                            if (m_Recv > 0)
                            {
                                fileStream.Write(data, 0, m_Recv);
                            }
                            m_Writed += m_Recv;
                        }
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                    this.Socket.Send(SessionEncoding.GetBytes("226 Transfer Complete.\r\n"));
                }
                else
                {
                    this.Socket.Send(SessionEncoding.GetBytes("501 Permission STOR denied.\r\n"));
                }

            }
            catch (Exception ex)
            {
                this.Socket.Send(SessionEncoding.GetBytes("426 Connection closed; transfer aborted.\r\n"));
            }
        }
        //创建文件夹
        private void MKD(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            string localPath;
            bool bFind = MapVirtualPathToLocalPath(argsText, out localPath);
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
                if (m_CurrentPolicy == null || m_CurrentPolicy.DirCreate)
                {
                    this.Socket.Send(SessionEncoding.GetBytes("257 \"" + argsText + "\" directory created. \r\n"));
                }
                else
                {
                    this.Socket.Send(SessionEncoding.GetBytes("501 Permission MKD denied. \r\n"));
                }
                return;
            }
            this.Socket.Send(SessionEncoding.GetBytes("550 Directory creation failed. \r\n"));

        }
        //删除文件夹
        private void RMD(string argsText)
        {
            if (!this.Authenticated)
            {
                this.Socket.Send(SessionEncoding.GetBytes("530 Please authenticate firtst ! \r\n"));
                return;
            }
            //string virtualPath = argsText.Split(' ')[0].TrimEnd('*');
            string localPath;
            bool bFind = MapVirtualPathToLocalPath(argsText, out localPath);
            if (m_CurrentPolicy == null || m_CurrentPolicy.DirDelete)
            {
                if (Directory.Exists(localPath))
                {
                    DeleteFolder(localPath);
                    this.Socket.Send(SessionEncoding.GetBytes("250 \"" + argsText + "\" directory deleted.\r\n"));
                    return;
                }
            }
            else
            {
                this.Socket.Send(SessionEncoding.GetBytes("501 Permission RMD denied.\r\n"));
                return;
            }

            this.Socket.Send(SessionEncoding.GetBytes("550 Directory deletion failed. \r\n"));
        }

        #region 属性
        public FtpUser User
        {
            get { return m_User; }
            set { m_User = value; }
        }
        public bool Authenticated
        {
            get { return m_Authenticated; }
        }
        public Encoding SessionEncoding
        {
            get { return m_SessionEncoding; }
            set { m_SessionEncoding = value; }
        }
        public IPEndPoint RemoteEP
        {
            get { return m_RemoteEP; }
        }
        public Socket Socket
        {
            get { return m_Socket; }
        }
        #endregion
    }

    /// <summary>
    /// Ftp Server
    /// </summary>
    public class FtpServer
    {
        public event EventHandler<FtpInfoEventArgs> FtpInfoReceived;

        public void ReportFtpInfoEventArgs(FtpInfoEventArgs args)
        {
            if (FtpInfoReceived != null)
            {
                FtpInfoReceived(this, args);
            }
        }

        public event EventHandler<FtpFileTransferProgressChangedEventArgs> FtpFileTransferProgressChanged;//FTP文件传输进度

        public void ReportFtpFileTransferProgressChanged(FtpFileTransferProgressChangedEventArgs e)
        {
            if (FtpFileTransferProgressChanged != null)
            {
                FtpFileTransferProgressChanged(this, e);
            }
        }

        private List<FtpSession> m_SessionList = new List<FtpSession>();//Ftp连接Session列表
        private int m_ServerPort = 21;//Ftp Server端口

        private int m_MaxBadCommands = 10;

        public int MaxBadCommands
        {
            get { return m_MaxBadCommands; }
            set { m_MaxBadCommands = value; }
        }
        public int ServerPort
        {
            get { return m_ServerPort; }
            set { m_ServerPort = value; }
        }

        private Socket m_ServerSocket = null;//Ftp Server监听Socket
        private IPEndPoint m_ServerEP = null;//

        private int m_PassiveStartPort = 3000;//20000;被动模式试提供给客户端用于数据连接的起始端口
        private IPAddress m_PassivePublicIP = null;//被动模式时提供给客户端用于数据连接的IP地址,为空的话根据当前Session取值

        #region 属性
        public IPAddress PassivePublicIP
        {
            get { return m_PassivePublicIP; }
            set { m_PassivePublicIP = value; }
        }
        public int PassiveStartPort
        {
            get { return m_PassiveStartPort; }
            set { m_PassiveStartPort = value; }
        }
        #endregion

        public FtpServer()
        {

        }

        //启动Server
        public void Start()
        {
            m_ServerEP = new IPEndPoint(IPAddress.Any, m_ServerPort);
            m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //设置监听端口
            m_ServerSocket.Bind(m_ServerEP);

            //设置端口可以重用
            m_ServerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            m_ServerSocket.Listen(10);

            m_ServerSocket.BeginAccept(new AsyncCallback(AcceptFtpConnet), m_ServerSocket);
        }
        public void Start(int port)
        {
            m_ServerPort = port;
            m_ServerEP = new IPEndPoint(IPAddress.Any, m_ServerPort);
            m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //设置监听端口
            m_ServerSocket.Bind(m_ServerEP);

            //设置端口可以重用
            m_ServerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            m_ServerSocket.Listen(10);

            m_ServerSocket.BeginAccept(new AsyncCallback(AcceptFtpConnet), m_ServerSocket);
        }

        //停止Server
        public void Stop()
        {
            m_ServerSocket.Close();
        }

        //异步接受Ftp客户端连接请求
        private void AcceptFtpConnet(IAsyncResult iar)
        {
            Socket serverSocket = iar.AsyncState as Socket;
            try
            {
                Socket handleSocket = serverSocket.EndAccept(iar);

                //创建一个新的session,并开始工作
                FtpSession session = new FtpSession(this, handleSocket);

                //异步接受下一个连接
                serverSocket.BeginAccept(new AsyncCallback(AcceptFtpConnet), serverSocket);
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        //增加一个FtpSession
        public void AddSession(FtpSession session)
        {
            lock (m_SessionList)
            {
                m_SessionList.Add(session);
            }
        }

        //删除一个FtpSession
        public void RemoveSession(FtpSession session)
        {
            lock (m_SessionList)
            {
                m_SessionList.Remove(session);
            }
        }

        //验证用户
        public event EventHandler<FtpAuthUserEventArgs> AuthUser;

        //验证用户合法性
        public bool OnAuthUser(FtpSession session, FtpUser user)
        {
            if (AuthUser != null)
            {
                FtpAuthUserEventArgs e = new FtpAuthUserEventArgs(session, user);
                this.AuthUser(this, e);
                return e.Validated;
            }
            return true;
        }
    }

    //验证用户事件参数
    public class FtpAuthUserEventArgs : EventArgs
    {
        private FtpSession m_Session;
        private FtpUser m_User;
        private bool m_Validated = true;

        public FtpAuthUserEventArgs(FtpSession session, FtpUser user)
        {
            m_Session = session;
            m_User = user;
        }

        public FtpSession Session
        {
            get { return m_Session; }

        }
        public FtpUser User
        {
            get { return m_User; }
            set { m_User = value; }
        }
        public bool Validated
        {
            get { return m_Validated; }
            set { m_Validated = value; }
        }
    }
}
