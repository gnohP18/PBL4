using PBL4.Data;
using PBL4.Model;
using PBL4.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace PBL4
{
    public partial class Main : Form
    {
        #region Service
        private InitData _initData;
        private TcpClient _tcpClient;
        private Stream _stream;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        #endregion

        #region Local variable
        private ValueUC[,] ListValueUC { get; set; }
        private List<string> NamePoint { get; set; }
        private long[,] MatrixDijktra { get; set; }
        private int NumberOfPoint { get; set; }
        #endregion

        public Main()
        {
            InitializeComponent();
            InitDataForCBB();
        }

        #region InitData
        private void InitDataForCBB()
        {
            NamePoint = MatrixService.Instance.GetPointNameByNumberOfPoint(NumberOfPoint);
            foreach (int i in MatrixService.Instance.GetNumberOfPoint())
            {
                cbbNumberOfPoints.Items.Add(i);
            }
        }
        #endregion

        #region Function
        //Luồng nhận dữ liệu được gửi từ server
        private void ReceiveDataFromServer()
        {
            while (true)
            {
                try
                {
                    _streamReader = new StreamReader(_stream);
                    string dataFromServer = _streamReader.ReadLine();
                    Console.WriteLine("Data from server " + dataFromServer);
                }
                catch (Exception ex)
                {
                    NoticeBox box = new NoticeBox(ex.ToString());
                    box.Show();
                    break;
                }
            }
        }
        //Xóa item mỗi lần chuyển cbb
        private void ClearMatrixItem()
        {
            pnMatrix.Controls.Clear();
        }


        //thêm ô của ma trận vào panel
        private void SetupItem(ValueUC valueUC)
        {
            pnMatrix.Controls.Add(valueUC);
        }

        //Kiểm tra ma trận có hợp lệ hay không
        private bool IsAvailableMatrix(long[,] matrix, int numberOfPoint)
        {
            for (int i = 0; i < numberOfPoint; i++)
            {
                for (int j = 0; j < numberOfPoint; j++)
                {
                    if (matrix[i, j] == -1) return false;
                }
            }
            return true;
        }

        //Khởi tạo ma trận nhập UI từ số lượng điểm
        private void InitMatrixWithNumberOfPoint(int numberOfPoint)
        {
            ListValueUC = new ValueUC[numberOfPoint, numberOfPoint];
            int locaX = EnumMatrix.DefaultItemMatrixX;
            int locaY = EnumMatrix.DefaultItemMatrixY;
            for (int i = 0; i < numberOfPoint; i++)
            {
                locaY = EnumMatrix.ValueUCHeight * i + EnumMatrix.DistanceBetween2Points;
                for (int j = 0; j < numberOfPoint; j++)
                {
                    ListValueUC[i, j] = new ValueUC();
                    Point point = new Point(locaX + EnumMatrix.ValueUCWidth * j + EnumMatrix.DistanceBetween2Points, locaY);
                    var coordinates = (i + "," + j).ToString();
                    ListValueUC[i, j].SetCoordinates(coordinates);
                    ListValueUC[i, j].SetLocation(point);
                    SetupItem(ListValueUC[i, j]);
                }
            }
        }

        //Lấy tất cả giá trị từ ô ma trận
        private long[,] GetMatrixFromView(ValueUC[,] listValueUC, int numberOfPoint)
        {
            long[,] matrix = new long[numberOfPoint, numberOfPoint];
            for (int i = 0; i < numberOfPoint; i++)
            {
                for (int j = 0; j < numberOfPoint; j++)
                {
                    listValueUC[i, j].SetValue();
                    matrix[i, j] = listValueUC[i, j].Value;
                }
            }
            MatrixDijktra = matrix;
            return matrix;
        }

        private void DisconnectFromServer()
        {
            _tcpClient.Close();
            _stream.Close();
        }
        #endregion

        #region Event handle
        private void Main_Load(object sender, EventArgs e)
        {
            _initData = new InitData();
            try
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(_initData.IpAddress, _initData.PortNumber);
                _stream = _tcpClient.GetStream();
            }
            catch (Exception ex)
            {
                NoticeBox box = new NoticeBox(ex.ToString());
                box.Show();
                Console.WriteLine(ex);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbNumberOfPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearMatrixItem();
            NumberOfPoint = cbbNumberOfPoints.SelectedIndex + 1;
            InitMatrixWithNumberOfPoint(NumberOfPoint);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsAvailableMatrix(GetMatrixFromView(ListValueUC, NumberOfPoint), NumberOfPoint))
            {
                NoticeBox noticeBox = new NoticeBox("Value is unavailable! Please try again");
                noticeBox.Show();
            }
            else
            {
                //1.Lấy ma trận từ UI nhập vào
                MatrixDijktra = GetMatrixFromView(ListValueUC, NumberOfPoint);

                //2.Chuyển ma trận từ dạng số sang chuỗi để gửi
                string data = MatrixService.Instance.ConvertMatrixToMatrixString(NumberOfPoint, MatrixDijktra);

                //3.Gửi dữ liệu đi
                try
                {
                    _streamWriter = new StreamWriter(_stream);
                    _streamWriter.AutoFlush = true;
                    _streamWriter.WriteLine(data);
                }
                catch (Exception ex)
                {
                    NoticeBox box = new NoticeBox(ex.ToString());
                    box.Show();
                    Console.WriteLine(ex);
                }

                //4. Tạo luồng mới nhận dữ liệu
                Thread receiveThread = new Thread(ReceiveDataFromServer);
                receiveThread.Start();

                //5.Sau khi nhận dữ liệu và kết thúc luồng lúc này mới cho hiện bảng kết quả và vẽ đồ thị
                ResultGraph resultGraph = new ResultGraph(NumberOfPoint, MatrixDijktra);
                resultGraph.StartPosition = FormStartPosition.CenterScreen;
                resultGraph.Show();
            };

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    ListValueUC[i, j].ClearValue();
                }
            }

            NoticeBox noticeBox = new NoticeBox("You have cleared all value!");
            noticeBox.Show();

        }
        private void btnDisConnectToServer_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
            this.Close();
        }
        #endregion

    }
}
