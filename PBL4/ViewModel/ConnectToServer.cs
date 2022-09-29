using PBL4.Data;
using System;
using System.IO;
using System.Net.Sockets;

namespace PBL4.ViewModel
{
    public class ConnectToServer : IConnectToServer
    {
        #region Instance
        private static InitData _initData;
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
        public Exception ExWhileConnectServer { get; set; }
        #endregion

        public ConnectToServer()
        {
            _initData = new InitData();
        }

        public bool ClientConnectToServer(int numberOfPoint, int[,] matrixDijktra)
        {
            var arrayLength = numberOfPoint * numberOfPoint + 1;
            try
            {
                // 1. Open connection
                TcpClient client = new TcpClient();
                client.Connect(_initData.IpAddress, _initData.PortNumber);
                Stream stream = client.GetStream();
                // 2. read data 
                byte[] numberOfPointDataSend = new byte[arrayLength];
                numberOfPointDataSend[0] = Convert.ToByte(numberOfPoint);
                int count = 1;
                for (int i = 0; i < numberOfPoint; i++)
                {
                    for (int j = 0; j < numberOfPoint; j++)
                    {
                        numberOfPointDataSend[count] = Convert.ToByte(matrixDijktra[i, j]);
                    }
                }
                stream.Write(numberOfPointDataSend, 0, arrayLength);
                // 3. receive data
                byte[] numberOfPointDataReceive = new byte[arrayLength];
                // Change your function here to receive data

                // 4. Close connection
                client.Close();
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExWhileConnectServer = ex;
                return false;
            }
        }
    }
}
