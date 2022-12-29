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
        /// Bước 1 Tách lấy từ dữ liệu của server qua các kí tự '@'.
        /// Kết quả trả về là 1 kết quả của điểm bắt đầu đó.
        /// </summary>
        string SplitOneResultOfAPointInAllResults(int index, string dataFromServer);

        /// <summary>
        /// Bước 2 Từ kết quả ở bước 1 tách lấy từ chuỗi từng kết quả con thông qua kí tự '#'.
        /// Kết quả trả về là danh sách các chuỗi có dạng "TongTrongSo: diem1 diem2 ... diemN".
        /// </summary>
        string[] SplitResultFromOneResultOfPoint(string result);

        /// <summary>
        /// Bước 3.1 Từ kết quả bước 2 tách lấy danh sách tổng trọng số thông qua kí tự ':'.
        /// Kết quả trả về danh sách chuỗi tổng trọng số bắt đầu từ điểm 1. 
        /// </summary>
        List<string> SplitListTotalWeightOfOnePoint(int numberOfPoint, string[] data);

        /// <summary>
        /// Bước 3.2 Từ kết quả bước 2 tách lấy danh sách các đường đi ngắn nhất thông qua các điểm.
        /// Kết quả trả về là danh sách các chuỗi đường đi bắt đầu từ điểm 1 .
        /// </summary>
        List<string[]> SplitListPathOfOnePoint(int numberOfPoint, string[] data);

        /// <summary>
        /// Lấy số điểm của ma trận từ file
        /// </summary>
        int GetNumberOfPointFromBrowseFile(string s);

        /// <summary>
        /// Kiểm tra ma trận nhập từ file có hợp lệ hay không 
        /// </summary>
        bool CheckMatrixFromBrowserFile(int numberOfPoint, string[] s);

        /// <summary>
        /// Lấy ma trận từ file
        /// </summary>
        long[,] GetMatrixFromBrowseFile(int numberOfPoint, string[] s);


    }
}
