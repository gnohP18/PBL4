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
        /// Biến đổi ma trận từ dạng số thành chuỗi 
        /// </summary>
        string ConvertMatrixToMatrixString(int numberOfPoint, long[,] matrixInput);

        /// <summary>
        /// Tách kết quả gửi từ server thành danh sách các kết quả của các điểm
        /// </summary>
        void ConvertListResultOfAllPoint(int index);

        /// <summary>
        /// Biến đổi chuỗi kết quả của một điểm
        /// </summary>
        void ConvertToStringResultOfOnePoint(string s);
    }
}
