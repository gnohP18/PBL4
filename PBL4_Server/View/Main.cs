using PBL4_Server.Data;
using PBL4_Server.Model;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace PBL4_Server
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitData _initData = new InitData();
            try
            {
                IPAddress address = IPAddress.Parse(_initData.IpAddress);

                TcpListener listener = new TcpListener(address, _initData.PortNumber);

                // 1. listen
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
                    // 2. receive
                    string str = reader.ReadLine();
                    MatrixService.Instance.SplitMatrixFromData(str);
                    //MatrixService.Instance.Dijkstra(0);
                    if (str.ToUpper() == "EXIT")
                    {
                        writer.WriteLine("bye");
                        break;
                    }
                    // 3. send
                    writer.WriteLine("hihiii");
                }
                // 4. close
                stream.Close();
                socket.Close();
                listener.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            Console.Read();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //ConnectToClient.Instance.ShowResult();
        }
    }
}
