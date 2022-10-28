using PBL4.Data;
using System.Collections.Generic;

namespace PBL4.Model
{
    public class MatrixService : IMatrixService
    {
        #region Instance
        private static InitData _initData;
        private static MatrixService _matrixService;
        public static MatrixService Instance
        {
            get
            {
                if (_matrixService == null) _matrixService = new MatrixService();
                return _matrixService;
            }
            private set { }
        }
        #endregion

        public MatrixService()
        {
            _initData = new InitData();
        }

        public List<int> GetNumberOfPoint()
        {
            return _initData.NumberOfPoints;
        }

        public List<string> GetPointNameByNumberOfPoint(int numberOfPoint)
        {
            var listPointName = new List<string>();
            for (int i = 0; i < numberOfPoint; i++)
            {
                listPointName.Add(_initData.PointName[i]);
            }
            return listPointName;
        }

        public string ConvertMatrixToMatrixString(int numberOfPoint, long[,] matrixInput)
        {
            var matrixString = numberOfPoint.ToString() + ":";
            for (int i = 0; i < numberOfPoint; i++)
            {
                for (int j = 0; j < numberOfPoint; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matrixString += matrixInput[i, j].ToString();
                    }
                    else
                    {
                        matrixString += " " + matrixInput[i, j].ToString();
                    }
                }
            }
            return matrixString;
        }
    }
}
