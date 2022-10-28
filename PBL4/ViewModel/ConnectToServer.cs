using PBL4.Data;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace PBL4.ViewModel
{
    public class ConnectToServer : IConnectToServer
    {
        #region Instance
        private static InitData _initData;
        private static ASCIIEncoding encoding = new ASCIIEncoding();
        private static ConnectToServer _connectToServer;
        public static ConnectToServer Instance
        {
            get
            {
                if (_connectToServer == null) _connectToServer = new ConnectToServer();
                return _connectToServer;
            }
            private set { }
        }
        #endregion
        #region Local Variable
        private string Data { get; set; }
        private Stream stream { get; set; }
        private TcpClient client { get; set; }
        #endregion

        private ConnectToServer()
        {
            _initData = new InitData();
            client = new TcpClient();
            client.Connect(_initData.IpAddress, _initData.PortNumber);
            stream = client.GetStream();
        }

        public void DataEncapsulation(string data)
        {
            Data = data;
        }

        public void ThreadSendDataToServer()
        {
            try
            {
                // 1. connect
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                // 2. send
                Console.WriteLine("Data is" + Data);
                writer.Write(Data);
                // 3. receive
                //Thread threadReceive = new Thread(() => ThreadReceiveDataFromServer(reader));
                //threadReceive.Start();
                //threadReceive.Join();
                // 4. close
                stream.Close();
                client.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error from Client: " + ex);
            }
        }

        public void ThreadReceiveDataFromServer()
        {
            try
            {
                // 1. connect
                var reader = new StreamReader(stream);
                while (true)
                {
                    var mess = reader.ReadLine();
                    if (mess != null && mess == "OK")
                    {
                        Console.WriteLine(mess);
                        break;
                    }
                }
                stream.Close();
                client.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error from Client: " + ex);
            }
        }
    }
}
