using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Poker.viewmodel.networking
{
    public class ClientService
    {
        private TcpClient _tcpClient = new TcpClient();
        public static NetworkStream _stream;
        public GameController Controller { get; set; }
        public string Message { get; set; }
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
                StartReadingFromStream();
                return true;
            } catch (Exception ex) { }
            return false;
        }

        public async void StartReadingFromStream()
        {
            Message = "";
            await ReadFromStream();
        }

        public async Task ReadFromStream()
        {
            if (!_stream.CanRead || !_stream.CanWrite)
            {
                throw new Exception("aaaaaaaahhhhhhhhhhh");
            }
            byte[] buffer = new byte[1024];
            int i;
            string message = "";
            i = await _stream.ReadAsync(buffer, 0, buffer.Length);
            message += System.Text.Encoding.ASCII.GetString(buffer, 0, i);
            DecodeMessage(message);
            if (message.Length > 2) await ReadFromStream();
        }

        public void DecodeMessage(string message)
        {
            if (message == null || message.Length < 2) return;

            int messageType = int.Parse(message[0].ToString());
            string messageContent = "";

            messageContent = message.Substring(1);

            switch (messageType)
            {
                case 1: Controller.JoinSuccess(messageContent); break;
                case 5: Controller.GetCardsFromHost(messageContent); break;
                default: break;
            }
        }

        public void TryJoin(string name)
        {
            Sendmessage("1" + name);
        }

        public void Sendmessage(string message)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);
            _stream.Write(msg, 0, msg.Length);
        }

        
    }
}
