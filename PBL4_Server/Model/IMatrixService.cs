using System.Collections.Generic;

namespace PBL4_Server.Model
{
    public interface IMatrixService
    {
        /// <summary>
        /// Tách ma trận dạng chuỗi string sang ma trận 
        /// </summary>
        void SplitMatrixFromData(string data);

        /// <summary>
        ///tìm khoảng cách ngắn nhất trong tập các đỉnh chưa được thêm vào shortest path tree
        /// </summary>
        int MinDistance(long[] dist, bool[] sptSet);

        /// <summary>
        ///thêm điểm vào trong danh sách đường đi
        /// </summary>
        List<string> MergeMap(List<string> mapU, string dst);

        /// <summary>
        ///thực hiện tính toán theo thuật toán Dijsktra
        /// </summary>
        void Dijkstra(int src);

        /// <summary>
        ///chuyển kết quả của thuật toán Dijsktra thành chuỗi để gửi cho client
        /// </summary>
        string ConvertResultToString();

        /// <summary>
        /// thực hiện tính toán Dijsktra cho tất cả các điểm
        /// </summary>
        string CalculateDijskstraOfAllPoint();
    }
}
