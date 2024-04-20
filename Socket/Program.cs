using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Socket
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),9009);
            System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(999);

            if (socket.Connected)
            {
                
                Console.WriteLine("客户端链接成功！");
            }
            
            while (socket.Connected)
            {
                System.Net.Sockets.Socket accept = socket.Accept();
                Console.WriteLine("客户端链接成功");
                string ip = accept.RemoteEndPoint.ToString();
                
                Console.Write("ip为："+ip+"链接成功");
            }
        }
        
    }
}
