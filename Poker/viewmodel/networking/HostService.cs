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
        public string IPAdd { get; set; }
        public HostService()
        {
            IPHostEntry temp =  Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress address in temp.AddressList)
            {
                if(address.AddressFamily == AddressFamily.InterNetwork)
                {
                    _tcpListener = new TcpListener(address, 6969);
                    IPAdd = address.ToString() + ":6969";
                }
                
            }
            
        }
    }
}
