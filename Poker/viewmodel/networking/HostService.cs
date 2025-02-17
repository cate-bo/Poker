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
        private TcpListener _tcpListener;
        private List<TcpClient> _tcpClients = new List<TcpClient>();
        public GameController Controller { get; set; }
        public string IPAdd { get; set; }
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
            WaitForConnection();
        }

        public async Task WaitForConnection()
        {
            TcpClient temp = await _tcpListener.AcceptTcpClientAsync();
            _tcpClients.Add(temp);
            await ReadFromClient(temp.GetStream(), _tcpClients.IndexOf(temp));
        }

        public async Task ReadFromClient(NetworkStream stream, int ID)
        {
            if(!stream.CanRead || !stream.CanWrite)
            {
                throw new Exception("aaaaaaaahhhhhhhhhhh");
            }
            byte[] buffer = new byte[256];
            int i;
            string message = "";
            //while ((i = stream.ReadAsync(buffer, 0, buffer.Length).Result) != 0)
            //{
            //    message += System.Text.Encoding.ASCII.GetString(buffer, 0, i);
            //}
            i = stream.ReadAsync(buffer, 0, buffer.Length).Result;
            message = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
            DecodeMessage(message, ID);
        }

        public void DecodeMessage(string message, int ID)
        {
            if (message == null || message.Length < 1) return;

            int messageType = int.Parse(message[0].ToString());
            string messageContent = "";
            if (message.Length < 2)
            {
                messageContent = message.Substring(1);
            }
            switch (messageType)
            {
                case 1: Controller.JoinAttemt(messageContent, ID); break;
                default: break;
            }
        }

        public void Sendmessage(int recipientID, string message)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);
            _tcpClients[recipientID].GetStream().Write(msg, 0, msg.Length);
        }
    }
}
