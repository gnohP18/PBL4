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
        #region Service threads
        private delegate void SafeCallDelegate(string text);
        #endregion
        #region Global variable
        private static string Data = null;
        private static string BeginLog = null;
        private static bool IsShow = false;
        #endregion
        public Main()
        {
            InitializeComponent();
            Thread listenThread = new Thread(InitServer);
            listenThread.Start();
        }
        private void InitServer()
        {
            InitData _initData = new InitData();
            try
            {
                IPAddress address = IPAddress.Parse(_initData.IpAddress);
                TcpListener listener = new TcpListener(address, _initData.PortNumber);
                // 1. listen
                listener.Start();

                Console.WriteLine("Server started on " + listener.LocalEndpoint);
                BeginLog += "Server started on " + listener.LocalEndpoint + "\n";

                Console.WriteLine("Waiting for a connection...");
                BeginLog += "Waiting for a connection..." + "\n";

                Socket socket = listener.AcceptSocket();
                Console.WriteLine("Connection received from " + socket.RemoteEndPoint);
                BeginLog += "Connection received from " + socket.RemoteEndPoint + "\n";

                UpdateRTB(BeginLog);

                var stream = new NetworkStream(socket);
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                while (true)
                {
                    // 2. receive
                    string str = reader.ReadLine();
                    MatrixService.Instance.SplitMatrixFromData(str);
                    if (str != null)
                    {
                        Data = str;
                        UpdateRTB(Data);
                        //MatrixService.Instance.CalculateDijskstraOfAllPoint();
                    }
                    else IsShow = false;
                    Console.WriteLine();
                    Console.WriteLine("Server has receive" + str);
                    if (str.ToUpper() == "EXIT")
                    {
                        writer.WriteLine("bye");
                        break;
                    }
                    // 3. send
                    writer.WriteLine(MatrixService.Instance.CalculateDijskstraOfAllPoint());
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
            //Coming soon function
        }

        private void UpdateRTB(string log)
        {
            if (rtbShowLog.InvokeRequired)
            {
                var dele = new SafeCallDelegate(UpdateRTB);
                rtbShowLog.Invoke(dele, new object[] { log });
            }
            else
            {
                DateTime currentTime = DateTime.Now;
                rtbShowLog.AppendText("[" + currentTime.ToShortTimeString() + "] " + log + "\n");
            }
        }
    }
}
