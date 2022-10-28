using System.Collections.Generic;

namespace PBL4_Server.Model
{
    public interface IMatrixService
    {
        void SplitMatrixFromData(string data);
        int MinDistance(int[] dist, bool[] sptSet);
        List<string> MergeMap(List<string> mapU, string dst);
        void Dijkstra(int[,] graph, int src);
    }
}
