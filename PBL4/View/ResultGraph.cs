﻿using PBL4.Model;
using PBL4.Resources.Language;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace PBL4.View
{
    public partial class ResultGraph : Form
    {
        #region Local variable
        private List<Point> ListOfPoint { get; set; }
        private long[,] MatrixDijktra { get; set; }
        private int NumberOfPoint { get; set; }
        private Label[] UINameOfPoint { get; set; }
        private Label[] UIWeightGraph { get; set; }
        //Danh sách tên điểm dựa vào số lượng điểm 
        private List<string> NamePoint { get; set; }
        private List<string> listTotalWeight { get; set; }
        private List<string[]> listResultFromServer { get; set; }
        //Delegate
        public delegate void DeleDraw(string text);
        //Graphic
        private Graphics CurrentGraphics;
        private string DataFromServer { get; set; }
        #endregion
        public ResultGraph(int numberOfPoint, long[,] matrix, string dataFromServer)
        {
            MatrixDijktra = matrix;
            NumberOfPoint = numberOfPoint;
            DataFromServer = dataFromServer;
            InitializeComponent();
            InitDataForCBB();
            SetupLanguage(InitLanguage.CurrentLanguage);
        }

        #region InitData
        public void DrawerWithEndPoint(string test)
        {
            var index = NamePoint.IndexOf(test);
            var route = listResultFromServer[index].Select(p => int.Parse(p)).ToList();
            RightRoute(route);
        }

        private void InitDataForCBB()
        {
            NamePoint = MatrixService.Instance.GetPointNameByNumberOfPoint(NumberOfPoint);
            foreach (var i in NamePoint)
            {
                cbbStartPoint.Items.Add(i);
            }
            cbbStartPoint.SelectedIndex = 0;
        }
        #endregion

        #region Function
        //Setup language
        private void SetupLanguage(string language)
        {
            ResourceManager _resourceManager = new ResourceManager("PBL4.Resources.Language.Resource", typeof(InitLanguage).Assembly);
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            cultureInfo = CultureInfo.CreateSpecificCulture(language);
            InitLanguage.Instance.ChangeLanguage(language);
            lblTitle.Text = _resourceManager.GetString("Title", cultureInfo);
            lblStartPoint.Text = _resourceManager.GetString("StartPoint", cultureInfo);
        }

        //Resize Result 
        private void SetResultUC(ResultUC resultUC)
        {
            resultUC.Dock = DockStyle.Top;
            pnResultFromServer.Controls.Add(resultUC);
        }

        //Xóa label
        private void ClearUIWeightGraphLabel()
        {
            pnGp.Controls.Clear();
        }

        //Khởi tạo ô kết quả trả về từ server
        private void InitResultFromNumberOfPoint(int numberOfPoint, int index)
        {
            listResultFromServer = new List<string[]>();

            NamePoint = MatrixService.Instance.GetPointNameByNumberOfPoint(numberOfPoint);
            //Bước 1 Tách theo index
            string splitByIndex = MatrixService.Instance.SplitOneResultOfAPointInAllResults(index, DataFromServer);

            //Bước 2 Tách theo '#'
            string[] splitOneResult = MatrixService.Instance.SplitResultFromOneResultOfPoint(splitByIndex);

            //Bước 3.1 Tách theo ':'
            List<string> splitListTotalWeigth = MatrixService.Instance.SplitListTotalWeightOfOnePoint(numberOfPoint, splitOneResult);

            //Bước 3.2 Tách theo ' '(whitespace)
            List<string[]> splitRightRoute = MatrixService.Instance.SplitListPathOfOnePoint(numberOfPoint, splitOneResult);

            listResultFromServer = splitRightRoute;
            listTotalWeight = splitListTotalWeigth;

            ResultUC[] resultUCs = new ResultUC[numberOfPoint];
            for (int i = 0; i < NumberOfPoint; i++)
            {
                string path = null;
                foreach (var j in listResultFromServer[i])
                {
                    path += NamePoint[Convert.ToInt32(j)] + " ";
                }
                resultUCs[i] = new ResultUC(DrawerWithEndPoint);
                resultUCs[i].SetResult(NamePoint[i], path, listTotalWeight[i]);
            }

            for (int i = 0; i < NumberOfPoint; i++)
            {
                SetResultUC(resultUCs[NumberOfPoint - i - 1]);
            }
        }

        //Vẽ  trọng số
        private void DrawWeightGraph(long[,] matrix, int numberOfPoint, List<Point> listOfPoint)
        {
            var count = 0;
            for (int i = 0; i < numberOfPoint; i++)
            {
                for (int j = 0; j < numberOfPoint; j++)
                {
                    //Kiểm tra giá trị ma trận để vẽ đường
                    if ((i == j) || (matrix[i, j] == 0)) continue;
                    if (j > i)
                    {
                        var averageX = 6 * (ListOfPoint[j].X - ListOfPoint[i].X) / 17 + ListOfPoint[i].X;
                        var averageY = 6 * (ListOfPoint[j].Y - ListOfPoint[i].Y) / 17 + ListOfPoint[i].Y;
                        UIWeightGraph[count] = new Label();
                        UIWeightGraph[count].Text = matrix[i, j].ToString();
                        UIWeightGraph[count].AutoSize = true;
                        UIWeightGraph[count].BackColor = Color.Empty;
                        UIWeightGraph[count].Location = new Point(averageX, averageY);
                        pnGp.Controls.Add(UIWeightGraph[count]);
                        count++;
                    }
                }
            }
        }

        // Draw Right Route
        private void RightRoute(List<int> rightRoute)
        {
            pnGp.Controls.Clear();
            cbShowWeightGraph.Checked = false;
            int widthOfPen = EnumMatrix.DefaultWidthOfPen;
            CurrentGraphics = pnGp.CreateGraphics();
            Rectangle rectangle = new Rectangle(1, 1, 8, 1);
            PaintEventArgs e = new PaintEventArgs(CurrentGraphics, rectangle);

            Pen redPen = new Pen(Color.Red, widthOfPen);
            Pen greenPen = new Pen(Color.Green, widthOfPen);

            long[,] matrix = MatrixDijktra;
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    //Kiểm tra giá trị ma trận để vẽ đường
                    if ((i == j) || (matrix[i, j] == 0)) continue;
                    else
                    {
                        e.Graphics.DrawLine(greenPen, ListOfPoint[i], ListOfPoint[j]);
                    }
                }
            }

            for (int i = 0; i < rightRoute.Count - 1; i++)
            {
                e.Graphics.DrawLine(redPen, ListOfPoint[rightRoute[i]], ListOfPoint[rightRoute[i + 1]]);
            }

            for (int i = 0; i < rightRoute.Count - 1; i++)
            {
                int averageX = 0;
                int averageY = 0;
                if (rightRoute[i] > rightRoute[i + 1])
                {
                    averageX = 6 * (ListOfPoint[rightRoute[i + 1]].X - ListOfPoint[rightRoute[i]].X) / 17 + ListOfPoint[rightRoute[i]].X;
                    averageY = 6 * (ListOfPoint[rightRoute[i + 1]].Y - ListOfPoint[rightRoute[i]].Y) / 17 + ListOfPoint[rightRoute[i]].Y;
                }
                else
                {
                    averageX = 6 * (ListOfPoint[rightRoute[i]].X - ListOfPoint[rightRoute[i + 1]].X) / 17 + ListOfPoint[rightRoute[i + 1]].X;
                    averageY = 6 * (ListOfPoint[rightRoute[i]].Y - ListOfPoint[rightRoute[i + 1]].Y) / 17 + ListOfPoint[rightRoute[i + 1]].Y;
                }
                Label weightGraph = new Label();
                weightGraph.Text = MatrixDijktra[rightRoute[i], rightRoute[i + 1]].ToString();
                weightGraph.AutoSize = true;
                weightGraph.BackColor = Color.Red;
                weightGraph.Location = new Point(averageX, averageY);
                pnGp.Controls.Add(weightGraph);
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
        #endregion

        #region Event handle
        private void btnExit_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Main);
            formToShow.Show();
            listResultFromServer.Clear();
            listTotalWeight = null;
            this.Close();
        }

        private void pnGp_Paint(object sender, PaintEventArgs e)
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            int widthOfPen = EnumMatrix.DefaultWidthOfPen;

            Brush aBrush = (Brush)Brushes.Red;
            Pen pPen = new Pen(Color.Red);
            Pen aPen = new Pen(Color.Green, widthOfPen);

            ListOfPoint = InitPointFromNumberOfPoints(NumberOfPoint);
            long[,] matrix = MatrixDijktra;
            List<string> listPointName = MatrixService.Instance.GetPointNameByNumberOfPoint(NumberOfPoint);
            UINameOfPoint = new Label[NumberOfPoint];

            //Vẽ đường thẳng thông qua ma trận
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    //Kiểm tra giá trị ma trận để vẽ đường
                    if ((i == j) || (matrix[i, j] == 0)) continue;
                    else
                    {
                        e.Graphics.DrawLine(aPen, ListOfPoint[i], ListOfPoint[j]);
                    }
                }
            }

            //vẽ tên điểm 
            DrawNameOfPoint(listPointName);

            for (int i = 0; i < NumberOfPoint; i++)
            {

                RectangleF a = new RectangleF(ListOfPoint[i].X - 5, ListOfPoint[i].Y - 5, 10, 10);
                e.Graphics.FillEllipse(aBrush, a);
                e.Graphics.DrawEllipse(pPen, a);
            }
        }

        private void DrawNameOfPoint(List<string> listPointName)
        {
            var centerOfCircleX = EnumMatrix.DefaultCenterOfCircleX;
            var centerOfCircleY = EnumMatrix.DefaultCenterOfCircleY;
            var halfLengthOfMajorAxis = EnumMatrix.DefaultHalfLengthOfMajorAxis;
            var halfLengthOfMinorAxis = EnumMatrix.DefaultHalfLengthOfMinorAxis;

            for (int i = 0; i < NumberOfPoint; i++)
            {
                UINameOfPoint[i] = new Label();
                UINameOfPoint[i].Text = listPointName[i];
                int xlb = (int)(centerOfCircleX - (halfLengthOfMajorAxis + 20) * Math.Cos(2 * Math.PI * i / NumberOfPoint));
                int ylb = (int)(centerOfCircleY - (halfLengthOfMinorAxis + 20) * Math.Sin(2 * Math.PI * i / NumberOfPoint));
                UINameOfPoint[i].Location = new Point(xlb, ylb);
                UINameOfPoint[i].AutoSize = true;
                UINameOfPoint[i].BackColor = Color.Empty;
                pnGp.Controls.Add(UINameOfPoint[i]);
                RectangleF a = new RectangleF(ListOfPoint[i].X - 5, ListOfPoint[i].Y - 5, 10, 10);
            }
        }

        private void cbbStartPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int startPoint = cbbStartPoint.SelectedIndex;
            this.pnResultFromServer.Controls.Clear();
            InitResultFromNumberOfPoint(NumberOfPoint, startPoint);
        }

        private void cbShowWeightGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowWeightGraph.Checked)
            {
                DrawWeightGraph(MatrixDijktra, NumberOfPoint, ListOfPoint);
            }
            else
            {
                DrawWeightGraph(MatrixDijktra, NumberOfPoint, ListOfPoint);
                pnGp.Controls.Clear();
                ClearUIWeightGraphLabel();
            }
        }

        private void ResultGraph_Load(object sender, EventArgs e)
        {
            UIWeightGraph = new Label[NumberOfPoint * NumberOfPoint];
        }
        #endregion
    }
}
