using PBL4_Server.Data;
using PBL4_Server.ViewModel;
using System;
using System.Collections.Generic;
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
        private List<Thread> ListThreadSolve { get; set; }
        private Thread listenThread;
        #endregion

        #region Global variable
        private static string BeginLog = null;
        private static InitData _initData = new InitData();
        #endregion
        public Main()
        {
            InitializeComponent();
            listenThread = new Thread(InitServer);
            listenThread.Start();
        }
        private void InitServer()
        {
            ListThreadSolve = new List<Thread>();
            try
            {
                IPAddress address = IPAddress.Parse(_initData.IpAddress);
                TcpListener listener = new TcpListener(address, _initData.PortNumber);
                // 1. listen
                BeginLog += "Server started on " + listener.LocalEndpoint + "\n";
                BeginLog += "Waiting for a connection..." + "\n";
                UpdateRTB(BeginLog);
                while (true)
                {
                    listener.Start();
                    Socket socket = listener.AcceptSocket();
                    var orderClient = ListThreadSolve.Count;
                    Thread newClient = new Thread(() => NewThreadAfterAcceptingAConnection(orderClient, socket));
                    ListThreadSolve.Add(newClient);
                    newClient.Start();
                }
                listener.Stop();
            }
            catch (Exception ex)
            {
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtHostName.Text = _initData.IpAddress;
        }

        #region
        private void NewThreadAfterAcceptingAConnection(int orderClient, Socket socket)
        {
            var startLog = "[IP:" + socket.RemoteEndPoint + "] has joined ";
            UpdateRTB(startLog);
            var stream = new NetworkStream(socket);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            MatrixService matrixService = new MatrixService();
            while (true)
            {
                // 2. receive
                string str = null;
                str = reader.ReadLine();
                if (str != null && str.ToUpper() != "EXIT")
                {

                    matrixService.SplitMatrixFromData(str);
                    var log = "[" + matrixService.ComputerName + "] " + str;
                    UpdateRTB(log);
                    // 3. send
                    writer.WriteLine(matrixService.CalculateDijskstraOfAllPoint());
                }
                // 4. close
                if (str.ToUpper() == "EXIT")
                {
                    writer.WriteLine("BYE");
                    UpdateRTB("[IP:" + socket.RemoteEndPoint + "] has left");
                    break;
                }
            }
            stream.Close();
            socket.Close();
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
                rtbShowLog.AppendText("[" + currentTime.ToLongTimeString() + "] " + log + "\n");
            }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            foreach (var i in ListThreadSolve)
            {
                i.Abort();
            }
            this.Close();
            listenThread.Abort();
        }
    }
}
