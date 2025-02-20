using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Poker.viewmodel.networking
{
    public class HostService
    {
        //private List<Socket> _sockets;
        private static TcpListener _tcpListener;
        private static TcpClient _tcpClient = new TcpClient();
        public static GameController Controller { get; set; }
        public static string IPAdd { get; set; }
        public HostService(GameController controller)
        {
            Controller = controller;
            IPHostEntry temp =  Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress address in temp.AddressList)
            {
                if(address.AddressFamily == AddressFamily.InterNetwork)
                {
                    _tcpListener = new TcpListener(address, 6969);
                    IPAdd = address.ToString() + ":6969";
                }
                
            }
            _tcpListener.Start();
            //Thread extrathread = new Thread(HostService.StartOfExtraThread);
            //extrathread.Start();
            WaitForConnection();
        }

        
        public static void StartOfExtraThread()
        {
            WaitForConnection();

        }

        public static async Task WaitForConnection()
        {
            TcpClient temp = await _tcpListener.AcceptTcpClientAsync();
            _tcpClient = temp;
            ReadFromClient(temp.GetStream());
        }

        public static async Task ReadFromClient(NetworkStream stream)
        {
            if(!stream.CanRead || !stream.CanWrite)
            {
                throw new Exception("aaaaaaaahhhhhhhhhhh");
            }
            byte[] buffer = new byte[1024];
            int i;
            string message = "";
            //while ((i = stream.ReadAsync(buffer, 0, buffer.Length).Result) != 0)
            //{
            //    message += System.Text.Encoding.ASCII.GetString(buffer, 0, i);
            //}
            i = await stream.ReadAsync(buffer, 0, buffer.Length);
            message = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
            DecodeMessage(message);
        }

        public static void DecodeMessage(string message)
        {
            if (message == null || message.Length < 2) return;

            int messageType = int.Parse(message[0].ToString());
            string messageContent = "";

            messageContent = message.Substring(1);

            switch (messageType)
            {
                case 1: Controller.JoinAttemt(messageContent); break;
                default: break;
            }
        }

        public void Sendmessage(string message)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);
            _tcpClient.GetStream().Write(msg, 0, msg.Length);
        }
    }
}
