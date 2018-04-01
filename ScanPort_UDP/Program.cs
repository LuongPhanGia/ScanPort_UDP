using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ScanPort_UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 1000; i++)
            {
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("118.102.1.119"), i);
                UdpClient server;
                byte[] data;
                try
                {
                    server = new UdpClient();
                    server.Client.ReceiveTimeout = 10;
                    server.Connect(ipe);
                    data = new byte[1024];
                    server.Send(data, data.Length);
                    data = server.Receive(ref ipe);
                    Console.WriteLine(ipe + "  open");
                }
                catch
                {
                    Console.WriteLine(ipe + "  Close");
                }
            }
            Console.ReadKey();
        }
    }
}
