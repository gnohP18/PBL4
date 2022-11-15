using PBL4.Model;
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
        //Setup laanuage
        private void SetupLanguage(string language)
        {
            ResourceManager _resourceManager = new ResourceManager("PBL4.Resources.Language.Resource", typeof(InitLanguage).Assembly);
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            cultureInfo = CultureInfo.CreateSpecificCulture(language);
            InitLanguage.Instance.ChangeLanguage(language);
            lblStartPoint.Text = _resourceManager.GetString("StartPoint", cultureInfo);
        }
        //Resize Result 
        private void SetResultUC(ResultUC resultUC)
        {
            resultUC.Dock = DockStyle.Top;
            pnResultFromServer.Controls.Add(resultUC);
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

        // Draw Right Route
        private void RightRoute(List<int> rightRoute)
        {
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
            listResultFromServer.Clear();
            listTotalWeight = null;
            this.Close();
        }

        private void pnGp_Paint(object sender, PaintEventArgs e)
        {
            int widthOfPen = EnumMatrix.DefaultWidthOfPen;
            int centerOfCircleX = EnumMatrix.DefaultCenterOfCircleX;
            int centerOfCircleY = EnumMatrix.DefaultCenterOfCircleY;

            int halfLengthOfMajorAxis = EnumMatrix.DefaultHalfLengthOfMajorAxis;
            int halfLengthOfMinorAxis = EnumMatrix.DefaultHalfLengthOfMinorAxis;

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
            for (int i = 0; i < NumberOfPoint; i++)
            {
                UINameOfPoint[i] = new Label();
                UINameOfPoint[i].Text = listPointName[i];
                int xlb = (int)(centerOfCircleX - (halfLengthOfMajorAxis + 20) * Math.Cos(2 * Math.PI * i / NumberOfPoint));
                int ylb = (int)(centerOfCircleY - (halfLengthOfMinorAxis + 20) * Math.Sin(2 * Math.PI * i / NumberOfPoint));
                UINameOfPoint[i].Location = new Point(xlb, ylb);
                UINameOfPoint[i].AutoSize = true;
                UINameOfPoint[i].BackColor = TransparencyKey;
                pnGp.Controls.Add(UINameOfPoint[i]);
                RectangleF a = new RectangleF(ListOfPoint[i].X - 5, ListOfPoint[i].Y - 5, 10, 10);
                e.Graphics.FillEllipse(aBrush, a);
                e.Graphics.DrawEllipse(pPen, a);
            }

            //Vẽ trọng số ma trận
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    //Kiểm tra giá trị ma trận để vẽ đường
                    if ((i == j) || (matrix[i, j] == 0)) continue;
                    else
                    {
                        var averageX = (ListOfPoint[i].X + ListOfPoint[j].X) / 2;
                        var averageY = (ListOfPoint[i].Y + ListOfPoint[j].Y) / 2;
                        Label weightGraph = new Label();
                        weightGraph.Text = matrix[i, j].ToString();
                        weightGraph.AutoSize = true;
                        weightGraph.Location = new Point(averageX, averageY);
                        pnGp.Controls.Add(weightGraph);
                    }
                }
            }
        }

        private void cbbStartPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int startPoint = cbbStartPoint.SelectedIndex;
            this.pnResultFromServer.Controls.Clear();
            InitResultFromNumberOfPoint(NumberOfPoint, startPoint);
        }
        #endregion
    }
}
