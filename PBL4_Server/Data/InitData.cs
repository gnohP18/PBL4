using System;
using System.Net;
using System.Net.Sockets;

namespace PBL4_Server.Data
{
    public class InitData
    {
        public int PortNumber { get; set; }
        public string IpAddress { get; set; }
        public InitData()
        {
            SeedDataForConnectingtoServer();
        }
        private void SeedDataForConnectingtoServer()
        {
            PortNumber = 555;
            IpAddress = GetHostName();
        }

        public string GetHostName()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
