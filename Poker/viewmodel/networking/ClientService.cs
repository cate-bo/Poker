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

        public bool Connect(string address)
        {
            string[] parts = address.Split(':');
            try
            {
                _tcpClient.Connect(parts[0], int.Parse(parts[1]));
                return true;
            } catch (Exception ex) { }
            return false;
        }
    }
}
