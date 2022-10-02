using PBL4.Model;
using PBL4.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PBL4
{
    public partial class Main : Form
    {
        #region Service

        #endregion
        #region Local variable
        private ValueUC[,] ListValueUC { get; set; }
        private long[,] MatrixDijktra { get; set; }
        private List<string> NamePoint { get; set; }
        private List<Point> listOfPoint { get; set; }
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

        //Xóa item mỗi lần chuyển cbb
        private void ClearRadioButton()
        {
            gbPointName.Controls.Clear();
        }

        //Xóa item mỗi lần chuyển cbb
        private void ClearGraphic()
        {
            pnGp.Invalidate();
            pnGp.Controls.Clear();
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

        // Draw Point
        private List<Point> InitPointFromNumberOfPoints(int numberOfPoints)
        {
            int centerOfCircleX = EnumMatrix.DefaultCenterOfCircleX;
            int centerOfCircleY = EnumMatrix.DefaultCenterOfCircleY;
            int halfLengthOfMajorAxis = EnumMatrix.DefaultHalfLengthOfMajorAxis;
            int halfLengthOfMinorAxis = EnumMatrix.DefaultHalfLengthOfMinorAxis;
            List<Point> listPoint = new List<Point>();
            for (int i = 0; i < NumberOfPoint; i++)
            {
                int x = (int)(centerOfCircleX - halfLengthOfMajorAxis * Math.Cos(2 * Math.PI * i / NumberOfPoint));
                int y = (int)(centerOfCircleY - halfLengthOfMinorAxis * Math.Sin(2 * Math.PI * i / NumberOfPoint));
                Point pt = new Point(x, y);
                listPoint.Add(pt);
            }
            return listPoint;
        }

        // Draw Right Route
        private void RightRoute(int[] rightRoute)
        {
            int widthOfPen = EnumMatrix.DefaultWidthOfPen;
            Graphics graphics = pnGp.CreateGraphics();
            Rectangle rectangle = new Rectangle(1, 1, 8, 1);
            PaintEventArgs e = new PaintEventArgs(graphics, rectangle);
            Pen aPen = new Pen(Color.Red, widthOfPen);
            for (int i = 0; i < rightRoute.Length - 1; i++)
            {
                e.Graphics.DrawLine(aPen, listOfPoint[rightRoute[i]], listOfPoint[rightRoute[i + 1]]);
                Console.WriteLine("Draw" + listOfPoint[i].X.ToString() + " " + listOfPoint[i].Y.ToString());
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
            ClearGraphic();
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
                DrawLines(sender);
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

       
        //Draw Lines
        private void DrawLines(object sender)
        {
            int widthOfPen = EnumMatrix.DefaultWidthOfPen;
            Graphics graphics = pnGp.CreateGraphics();
            Rectangle rectangle = new Rectangle(1, 1, 8, 1);
            PaintEventArgs e = new PaintEventArgs(graphics, rectangle);
            int centerOfCircleX = EnumMatrix.DefaultCenterOfCircleX;
            int centerOfCircleY = EnumMatrix.DefaultCenterOfCircleY;
            int halfLengthOfMajorAxis = EnumMatrix.DefaultHalfLengthOfMajorAxis;
            int halfLengthOfMinorAxis = EnumMatrix.DefaultHalfLengthOfMinorAxis;
            Brush aBrush = (Brush)Brushes.Red;
            Pen pPen = new Pen(Color.Red);
            Pen aPen = new Pen(Color.Green, widthOfPen);
            listOfPoint = InitPointFromNumberOfPoints(NumberOfPoint);
            long[,] matrix = GetMatrixFromView(ListValueUC, NumberOfPoint);
            List<string> listPointName = MatrixService.Instance.GetPointNameByNumberOfPoint(NumberOfPoint);
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    // Kiểm tra giá trị ma trận để vẽ đường
                    //if ((i == j) || (matrix[i, j] == 0)) continue;
                    //else
                    //{
                    //   e.Graphics.DrawLine(aPen, listOfPoint[i], listOfPoint[j]);
                    //}
                    e.Graphics.DrawLine(aPen, listOfPoint[i], listOfPoint[j]);

                }
            }
            //Draw label + fill point
            for (int i = 0; i < NumberOfPoint; i++)
            {
                Label lb = new Label();
                lb.Text = listPointName[i];
                int xlb = (int)(centerOfCircleX - (halfLengthOfMajorAxis + 20) * Math.Cos(2 * Math.PI * i / NumberOfPoint));
                int ylb = (int)(centerOfCircleY - (halfLengthOfMinorAxis + 20)  * Math.Sin(2 * Math.PI * i / NumberOfPoint));
                lb.Location = new Point(xlb, ylb);
                lb.Size = new Size(12, 12);
                lb.BackColor = TransparencyKey;
                pnGp.Controls.Add(lb);
                RectangleF a = new RectangleF(listOfPoint[i].X - 5, listOfPoint[i].Y - 5, 10, 10);
                e.Graphics.FillEllipse(aBrush, a);
                e.Graphics.DrawEllipse(pPen, a);
            }
            //RightRoute(rightRoute);
        }
        #endregion
    }
}
