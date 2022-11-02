using PBL4.Data;
using System;
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

        #region Global variable
        public int NumberOfPoint { get; set; }
        public string ResultFromServer { get; set; }
        public  List<string[]> ListPathOfOnePoint { get; set; }
        public string[] ListTotalWeightOfOnePoint { get; set; }

        #endregion

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
        public void ConvertListResultOfAllPoint(int index)
        {
            string resultString = ResultFromServer;
            string[] arrrayResult = new string[NumberOfPoint];
            arrrayResult = resultString.Split('@');
            ConvertToStringResultOfOnePoint(arrrayResult[index]);
        }

        public void ConvertToStringResultOfOnePoint(string resultStringOfOnePoint)
        {
            ListPathOfOnePoint = new List<string[]>();
            ListTotalWeightOfOnePoint = new string[NumberOfPoint];
            string[] s = resultStringOfOnePoint.Split('#');
            List<string> temp = new List<string>();

            //Tách trọng số từ chuỗi "#tongtrongso:dinh1 dinh2 ... dinhN#"
            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i].IndexOf(':');
                ListTotalWeightOfOnePoint[i] = s[i].Substring(0, index);
                temp.Add(s[i].Substring(index + 1));
            }
            
            //Tách đỉnh từ chuỗi "dinh1 dinh2 ... dinhN"
            for (int i = 0; i < s.Length; i++)
            {
                string[] arrListStr = temp[i].Split(' ');
                string[] temp2 = new string[arrListStr.Length];
                for (int j = 0; j < arrListStr.Length; j++)
                {
                    temp2[j] = arrListStr[j];
                }
                ListPathOfOnePoint.Add(temp2);
            }
        }
    }
}
