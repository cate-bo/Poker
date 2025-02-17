using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Poker.viewmodel.networking
{
    public class ClientService
    {
        private TcpClient _tcpClient = new TcpClient();
        private NetworkStream _stream;
        public GameController Controller { get; set; }

        public ClientService(GameController controller)
        {
            Controller = controller;
        }
        public bool TryConnect(string address)
        {
            string[] parts = address.Split(':');
            try
            {
                _tcpClient.Connect(parts[0], int.Parse(parts[1]));
                _stream = _tcpClient.GetStream();
                return true;
            } catch (Exception ex) { }
            return false;
        }

        public void TryJoin(string name)
        {
            _stream.Write(System.Text.Encoding.ASCII.GetBytes("1" + name));
        }

        public void Sendmessage(string message)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);
            _stream.Write(msg, 0, msg.Length);
        }
    }
}
