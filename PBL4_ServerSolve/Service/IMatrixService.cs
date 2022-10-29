namespace PBL4_ServerSolve.Service
{
    public interface IMatrixService
    {
        /// <summary>
        /// Tách ma trận dạng chuỗi string sang ma trận 
        /// </summary>
        void SplitMatrixFromData(string data);
        //tim khoang cach ngan nhat trong tap cac dinh chua duoc them vao shortest path tree
        int MinDistance(long[] dist, bool[] sptSet);
        //them diem vao trong danh sach 
        List<string> MergeMap(List<string> mapU, string dst);
        //thuc hien tinh toan dijstra
        void Dijkstra(int src);
        //chuyen ket qua thanh chuoi de gui cho client
        string ConvertResultToString();
    }
}
