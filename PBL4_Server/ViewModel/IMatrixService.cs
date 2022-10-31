using System.Collections.Generic;

namespace PBL4_Server.ViewModel
{
    public interface IMatrixService
    {
        /// <summary>
        /// Tách ma trận dạng chuỗi string sang ma trận 
        /// </summary>
        void SplitMatrixFromData(string data);
        int MinDistance(long[] dist, bool[] sptSet);
        List<string> MergeMap(List<string> mapU, string dst);
        void Dijkstra(int src);
        string ConvertResultToString();
    }
}
