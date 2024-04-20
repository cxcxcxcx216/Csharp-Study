using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Test_001
{
    public class Client
    {
        public static void Start()
        {
            // 定义服务器的IP地址和端口号
            string ipAddress = "127.0.0.1"; // 本地回环地址
            int port = 8080;

            try
            {
                // 创建TcpClient对象并连接到服务器
                TcpClient client = new TcpClient(ipAddress, port);
                Console.WriteLine("连接到服务器成功！");

                // 获取与服务器连接关联的网络流
                NetworkStream stream = client.GetStream();

                // 发送消息给服务器
                string message = "Hello, server!";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("已发送消息给服务器： " + message);

                // 接收服务器的响应
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("服务器响应： " + response);

                // 关闭连接
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生异常：" + ex.Message);
            }
        }
    }
}