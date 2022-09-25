using PBL4.Model;
using PBL4.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PBL4
{
    public partial class Main : Form
    {
        #region Service

        #endregion
        #region Local variable
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
        private void ClearItem()
        {
            pnMatrix.Controls.Clear();
        }

        private void SetupItem(ValueUC valueUC)
        {
            pnMatrix.Controls.Add(valueUC);
        }

        private void InitMatrixWithNumberOfPoint(int numberOfPoint)
        {
            ValueUC[,] listValueUC = new ValueUC[numberOfPoint, numberOfPoint];
            int locaX = EnumMatrix.DefaultX;
            int locaY = EnumMatrix.DefaultY;
            for (int i = 0; i < numberOfPoint; i++)
            {
                for (int j = 0; j < numberOfPoint; j++)
                {
                    listValueUC[i, j] = new ValueUC();
                    Point point = new Point(locaX + EnumMatrix.ValueUCWidth * j, locaY);
                    var coordinates = (i + "," + j).ToString();
                    listValueUC[i, j].SetCoordinates(coordinates);
                    listValueUC[i, j].SetLocation(point);
                    SetupItem(listValueUC[i, j]);
                    Console.Write("[" + locaX + " , " + locaY + "]   ");
                }
                locaY = locaY + EnumMatrix.ValueUCHeight * i;
                Console.WriteLine();
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
            ClearItem();
            var numberOfPoint = cbbNumberOfPoints.SelectedIndex + 1;
            InitMatrixWithNumberOfPoint(numberOfPoint);
        }
        #endregion
    }
}
