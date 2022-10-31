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
        public List<long[]> ListResultFromServer { get; set; }
        #endregion

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

        public void ConvertStringInputToShow()
        {
            ListResultFromServer = new List<long[]>();
            string resultString = ResultFromServer;

            string[] s = resultString.Split('#');
            long[] tongtrongso = new long[NumberOfPoint];
            List<string> temp = new List<string>();

            //Tách trọng số từ chuỗi "#tongtrongso:dinh1 dinh2 ... dinhN#"
            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i].IndexOf(":");
                tongtrongso[i] = Convert.ToInt32(s[i].Substring(0, index));
                temp.Add(s[i].Substring(index + 2));
            }

            //Tách đỉnh từ chuỗi "dinh1 dinh2 ... dinhN"
            for (int i = 0; i < s.Length; i++)
            {
                string[] arrListStr = temp[i].Split(' ');
                long[] temp2 = new long[arrListStr.Length];
                for (int j = 0; j < arrListStr.Length; j++)
                {
                    temp2[j] = Convert.ToInt64(arrListStr[j]);
                }
                ListResultFromServer.Add(temp2);
            }
        }

        //This is a testing function
        public void TestResultFromServer()
        {
            Console.WriteLine("Data from server after unpacking");
            foreach (var i in ListResultFromServer)
            {
                foreach (int j in i)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
