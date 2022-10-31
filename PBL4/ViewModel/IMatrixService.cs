using System.Collections.Generic;

namespace PBL4.Model
{
    public interface IMatrixService
    {
        /// <summary>
        /// Danh sách số lượng điểm
        /// </summary>
        List<int> GetNumberOfPoint();

        /// <summary>
        /// Danh sách tên điểm dựa vào số lượng điểm
        /// </summary>
        List<string> GetPointNameByNumberOfPoint(int numberOfPoint);

        /// <summary>
        /// Chuyển ma trận từ dạng số thành chuỗi 
        /// </summary>
        string ConvertMatrixToMatrixString(int numberOfPoint, long[,] matrixInput);

        void TestResultFromServer();
    }
}
