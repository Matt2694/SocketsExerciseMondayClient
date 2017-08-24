using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketsExerciseMondayClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(new IPEndPoint(IPAddress.Loopback, 50000));
                string command = Console.ReadLine();
                byte[] msg = Encoding.ASCII.GetBytes(command);
                s.Send(msg);
                byte[] retMsg = new byte[1024];
                s.Receive(retMsg);
                string str = Encoding.ASCII.GetString(retMsg);
                Console.WriteLine(str);
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
