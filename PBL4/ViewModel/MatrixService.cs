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
            List<string> listPointName = new List<string>();
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

        public string SplitOneResultOfAPointInAllResults(int index, string dataFromServer)
        {
            string[] result = dataFromServer.Split('@');
            return result[index];
        }

        public string[] SplitResultFromOneResultOfPoint(string result)
        {
            return result.Split('#');
        }

        public List<string> SplitListTotalWeightOfOnePoint(int numberOfPoint, string[] data)
        {
            List<string> listTotalWeightOfOnePoint = new List<string>();
            for (int i = 0; i < numberOfPoint; i++)
            {
                int index = data[i].IndexOf(':');
                string result = data[i].Substring(0, index);
                listTotalWeightOfOnePoint.Add(result);
            }
            return listTotalWeightOfOnePoint;
        }

        public List<string[]> SplitListPathOfOnePoint(int numberOfPoint, string[] data)
        {
            List<string> splitstring = new List<string>();
            List<string[]> listPathOfOnePoint = new List<string[]>();

            for (int i = 0; i < numberOfPoint; i++)
            {
                int index = data[i].IndexOf(':');
                string result = data[i].Substring(index + 1);
                splitstring.Add(result);
            }

            for (int i = 0; i < numberOfPoint; i++)
            {
                string[] arrListStr = splitstring[i].Split(' ');
                string[] temp2 = new string[arrListStr.Length];
                for (int j = 0; j < arrListStr.Length; j++)
                {
                    temp2[j] = arrListStr[j];
                }
                listPathOfOnePoint.Add(temp2);
            }
            return listPathOfOnePoint;
        }
    }
}
