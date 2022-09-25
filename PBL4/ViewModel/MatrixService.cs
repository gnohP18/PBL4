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

        public void GetLocation()
        {

        }

        public List<int> GetNumberOfPoint()
        {
            foreach (int i in _initData.NumberOfPoints)
            {
                Console.WriteLine(i);
            }
            return _initData.NumberOfPoints;
        }
    }
}
