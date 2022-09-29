using PBL4.Model;
using PBL4.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PBL4
{
    public partial class Main : Form
    {
        #region Service

        #endregion
        #region Local variable
        private ValueUC[,] ListValueUC { get; set; }
        private int NumberOfPoint { get; set; }
        private long[,] MatrixDijktra { get; set; }
        #endregion
        public Main()
        {
            InitializeComponent();
            InitDataForCBB();
        }

        #region InitData
        private void InitDataForCBB()
        {
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

        //Xóa item mỗi lần chuyển cbb
        private void ClearRadioButton()
        {
            gbPointName.Controls.Clear();
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

        //Chỉnh size về kích cỡ mặc định
        private RadioButton ResizeRadioButton(RadioButton radioButton)
        {
            radioButton.Width = EnumMatrix.RadioButtonWidth;
            radioButton.Height = EnumMatrix.RadioButtonHeight;
            return radioButton;
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
                Console.WriteLine();
            }
        }

        //Khởi tạo radio button từ số lượng điểm cbb
        private void InitRadioButtonWithNumberOfPoint(int numberOfPoint)
        {
            RadioButton[] radioButtons = new RadioButton[numberOfPoint];
            List<string> listPointName = MatrixService.Instance.GetPointNameByNumberOfPoint(numberOfPoint);
            int locaX = EnumMatrix.DefaultRadioButtonX;
            int locaY = EnumMatrix.DefaultRadioButtonY;
            for (int i = 0; i < numberOfPoint; i++)
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i] = ResizeRadioButton(radioButtons[i]);
                if (i == 0)
                {
                    radioButtons[i].Location = new Point(locaX, locaY);
                }
                if (i != 0)
                {
                    if (i % 4 != 0)
                    {
                        locaX = locaX + EnumMatrix.DistanceBetween2RabioButton + EnumMatrix.RadioButtonWidth;
                        radioButtons[i].Location = new Point(locaX, locaY);
                    }
                    else if (i % 4 == 0)
                    {
                        locaX = EnumMatrix.DefaultRadioButtonX;
                        locaY = locaY + EnumMatrix.RadioButtonHeight;
                        radioButtons[i].Location = new Point(locaX, locaY);
                    }
                }
                Console.WriteLine(locaX + " " + locaY);
                gbPointName.Controls.Add(radioButtons[i]);
                radioButtons[i].Text = listPointName[i];
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
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            MatrixDijktra = matrix;
            return matrix;
        }

        //Resize Result 
        private void SetResultUC(ResultUC resultUC)
        {
            resultUC.Dock = DockStyle.Top;
        }

        //Thêm Result vào trong panel
        private void SetupResultUC(ResultUC resultUC)
        {
            pnResultFromServer.Controls.Add(resultUC);
        }

        //Khởi tạo ô kết quả trả về từ server
        private void InitResultFromNumberOfPoint(int numberOfPoint)
        {
            List<string> listPointName = MatrixService.Instance.GetPointNameByNumberOfPoint(numberOfPoint);
            ResultUC[] resultUCs = new ResultUC[numberOfPoint];
            for (int i = 0; i < numberOfPoint; i++)
            {
                resultUCs[i] = new ResultUC();
                resultUCs[i].SetResult(listPointName[i], "ABC", i);
                SetResultUC(resultUCs[i]);
            }
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
            ClearRadioButton();
            NumberOfPoint = cbbNumberOfPoints.SelectedIndex + 1;
            InitMatrixWithNumberOfPoint(NumberOfPoint);
            InitRadioButtonWithNumberOfPoint(NumberOfPoint);
            InitResultFromNumberOfPoint(NumberOfPoint);
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
    }
}
