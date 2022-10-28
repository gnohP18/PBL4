using PBL4.Model;
using PBL4.View;
using PBL4.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PBL4
{
    public partial class Main : Form
    {
        #region Service

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
                    //Console.Write(matrix[i, j] + " ");
                }
                //Console.WriteLine();
            }
            MatrixDijktra = matrix;
            return matrix;
        }

        #endregion
        #region Event handle
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

        //Test

        private void MatrixTest()
        {
            NumberOfPoint = 8;
            MatrixDijktra = new long[8, 8] {
                { 0, 3, 5, 2, 0, 0, 0, 0 },
                { 3, 0, 1, 0, 7, 0, 0, 0 },
                { 5, 1, 0, 4, 0, 1, 0, 0 },
                { 2, 0, 4, 0, 0, 3, 6, 0 },
                { 0, 7, 0, 0, 0, 2, 0, 3 },
                { 0, 0, 1, 3, 2, 0, 4, 6 },
                { 0, 0, 0, 6, 0, 4, 0, 5 },
                { 0, 0, 0, 0, 3, 6, 5, 0 } };
        }

        private void ShowMatrix(int step)
        {
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    Console.Write(MatrixDijktra[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Done Step " + step);
        }
        private void ShowData(int step, string data)
        {
            Console.WriteLine(data);
            Console.WriteLine("Done Step " + step);
        }
        //End test

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
                ShowMatrix(1);

                //2.Chuyển ma trận từ dạng số sang chuỗi để gửi
                string data = MatrixService.Instance.ConvertMatrixToMatrixString(NumberOfPoint, MatrixDijktra);
                ShowData(2, data);

                //3.Tạo ra 1 luồng riêng để gửi dữ liệu đi
                ConnectToServer.Instance.DataEncapsulation(data);
                Thread send = new Thread(ConnectToServer.Instance.ThreadSendDataToServer);
                //Thread receive = new Thread(ConnectToServer.Instance.ThreadReceiveDataFromServer);
                send.Start();
                //receive.Start();
                //receive.Join();
                //connect.Join();

                //4.Sau khi nhận dữ liệu và kết thúc luồng lúc này mới cho hiện bảng kết quả và vẽ đồ thị
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

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {

        }
    }
}
