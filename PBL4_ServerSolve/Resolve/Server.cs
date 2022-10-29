using PBL4_ServerSolve.Data;
using PBL4_ServerSolve.Service;
using System.Net;
using System.Net.Sockets;

public class Server
{
    public static void Main()
    {
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
                MatrixService.Instance.Dijkstra(0);
                if (str.ToUpper() == "EXIT")
                {
                    writer.WriteLine("bye");
                    break;
                }
                // 3. send
                writer.WriteLine("hihiii" + MatrixService.Instance.ConvertResultToString());
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
}