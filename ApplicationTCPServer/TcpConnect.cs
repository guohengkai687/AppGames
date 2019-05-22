using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApplicationASN1
{
    public static class SocketTest
    {
        public static int Port = 5000; // 设定端口号
        private static Encoding encode = Encoding.Default;
        /// <summary>
        /// 监听请求
        /// </summary>
        public static void Listen()
        {            
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
            listenSocket.Listen(100);
            Console.WriteLine("Listen " + Port + " ...");
            while (true)
            {
                Socket acceptSocket = listenSocket.Accept();
                string receiveData = Receive(acceptSocket, 5000); //5 seconds timeout.
                Console.WriteLine("Receive：" + receiveData);
                acceptSocket.Send(encode.GetBytes("ok"));
                DestroySocket(acceptSocket); //import
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Send(string host, int port, string data)
        {
            string result = string.Empty;
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(host, port);
            clientSocket.Send(encode.GetBytes(data));
            //Send Data
            Console.WriteLine("Send：" + data);
            result = Receive(clientSocket, 5000 * 2); //5*2 seconds timeout.
            //Return Data
            Console.WriteLine("Receive：" + result);
            //Destory socket
            DestroySocket(clientSocket);
            return result;
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private static string Receive(Socket socket, int timeout)
        {
            string result = string.Empty;
            socket.ReceiveTimeout = timeout;
            List<byte> data = new List<byte>();
            byte[] buffer = new byte[1024];
            int length = 0;
            try
            {
                while ((length = socket.Receive(buffer)) > 0)
                {
                    for (int j = 0; j < length; j++)
                    {
                        data.Add(buffer[j]);
                    }
                    if (length < buffer.Length)
                    {
                        break;
                    }
                }
            }
            catch { }
            if (data.Count > 0)
            {
                result = encode.GetString(data.ToArray(), 0, data.Count);
            }
            return result;
        }
        /// <summary>
        /// 销毁Socket对象
        /// </summary>
        /// <param name="socket"></param>
        private static void DestroySocket(Socket socket)
        {
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            socket.Close();
            
        }
    }
}