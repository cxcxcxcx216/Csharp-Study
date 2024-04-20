using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Test_001.com.chen;

namespace Test_001
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 定义服务器的IP地址和端口号
            string ipAddress = "127.0.0.1"; // 本地回环地址
            int port = 8009;

            // 创建TcpListener对象并指定IP地址和端口号
            TcpListener server = new TcpListener(IPAddress.Parse(ipAddress), port);

            try
            {
                // 开始监听传入的连接请求
                server.Start();
                Console.WriteLine("服务器已启动，等待客户端连接...");

                // 接受客户端连接，并返回一个表示连接的TcpClient对象
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("客户端已连接！");

                // 获取与客户端连接关联的网络流
                NetworkStream stream = client.GetStream();

                // 接收客户端发送的消息
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    // 将接收到的消息转换为字符串并输出到控制台
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("接收到客户端消息： " + message);

                    // 向客户端发送响应消息
                    byte[] response = Encoding.UTF8.GetBytes("服务器已收到消息：" + message);
                    stream.Write(response, 0, response.Length);
                }

                // 关闭连接
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生异常：" + ex.Message);
            }
            finally
            {
                // 停止监听
                server.Stop();
            }
            
            Client.Start();
        }
    }
}