namespace PBL4_ServerSolve.Service
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
