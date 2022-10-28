using PBL4_Server.Data;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PBL4_Server.Model
{
    public class ConnectToClient : IConnectToClient
    {
        #region
        private static InitData _initData;
        private static ASCIIEncoding encoding = new ASCIIEncoding();
        private static ConnectToClient _connectToClient;
        public static ConnectToClient Instance
        {
            get
            {
                if (_connectToClient == null) _connectToClient = new ConnectToClient();
                return _connectToClient;
            }
            private set { }
        }
        #endregion
        public ConnectToClient()
        {
            _initData = new InitData();
        }
        #region
        private string ReceivingData { get; set; } = null;
        private bool HasReceived = false;
        #endregion
        public void ShowData(int step, string data)
        {
            Console.WriteLine(data);
            Console.WriteLine("Done Step " + step);
        }

        public void StartANewThread()
        {
            try
            {
                IPAddress address = IPAddress.Parse(_initData.IpAddress);

                TcpListener listener = new TcpListener(address, _initData.PortNumber);

                // 1.Tạo kết nối và lắng nghe
                listener.Start();

                Console.WriteLine("Server started on " + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");

                Socket socket = listener.AcceptSocket();
                Console.WriteLine("Connection received from " + socket.RemoteEndPoint);
                var stream = new NetworkStream(socket);

                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                while (true)
                {
                    // 2.Nhận dữ liệu
                    string data = reader.ReadLine();
                    if (data != null && data.Contains(":"))
                    {
                        ReceivingData = data;
                        ShowData(3, data);
                        //3.Xử lí ma trận
                        //3.1.Tách ma trận 
                        Thread resolveMatrixThread = new Thread(() => MatrixService.Instance.SplitMatrixFromData(ReceivingData));
                        resolveMatrixThread.Start();
                        //3.2.Xử lí thuật toán Dijkstra
                        var numberOfPoint = MatrixService.Instance.NumberOfPoint;
                        var matrixDijkstra = MatrixService.Instance.MatrixDijkstra;
                        //MatrixService.Instance.Dijkstra(numberOfPoint, matrixDijkstra);

                        HasReceived = true;

                        // 4.Gửi lại client
                        writer.WriteLine("OK");
                        Console.WriteLine("Done sent message OK");
                    }
                    //else HasReceived = false;
                    //if (HasReceived)
                    //{
                    //    writer.WriteLine("OK");
                    //    Console.WriteLine("Done sent message OK");
                    //}
                }
                // 4.Đóng kết nối
                stream.Close();
                socket.Close();

                listener.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error from Server: " + ex);
            }
        }
    }
}
