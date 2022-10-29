using PBL4_ServerSolve.Data;

namespace PBL4_ServerSolve.Service
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

        #region Local variable
        public long[,] MatrixDijkstra { get; set; }
        public int NumberOfPoint { get; set; }
        public static long[] dist { get; set; }
        public static List<List<string>> pred = new List<List<string>>();
        #endregion

        #region Function
        public void SplitMatrixFromData(string data)
        {
            Console.WriteLine("After split matrix from data");
            int index = data.IndexOf(":");
            NumberOfPoint = Convert.ToInt32((data.Substring(0, index)));
            var matrixString = data.Substring(index + 1);
            MatrixDijkstra = new long[NumberOfPoint, NumberOfPoint];
            string[] arrListStr = matrixString.Split(' ');
            int count = 0;
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    MatrixDijkstra[i, j] = Convert.ToInt32(arrListStr[count++]);
                    Console.Write(MatrixDijkstra[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int MinDistance(long[] dist, bool[] sptSet)
        {
            // Initialize min value
            long min = long.MaxValue;
            int min_index = -1;

            for (int i = 0; i < dist.Length; i++)
                if (sptSet[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    min_index = i;
                }

            return min_index;
        }

        public List<string> MergeMap(List<string> mapU, string dst)
        {
            List<string> rs = new List<string>(mapU);
            rs.Add(dst);
            return rs;
        }

        public void Dijkstra(int src)
        {
            long[,] graph = MatrixDijkstra;
            dist = new long[NumberOfPoint];
            int numberOfPoint = NumberOfPoint;
            int N = numberOfPoint;

            for (int i = 0; i < N; i++)
            {
                pred.Add(new List<string>());
            }

            bool[] sptSet = new bool[N];
            // Initialize all distances as INFINITE and stpSet[] as false
            for (int i = 0; i < N; i++)
            {
                dist[i] = long.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex from itself is always 0
            dist[src] = 0;
            pred[src].Add(src.ToString());

            // Find shortest path for all vertices
            for (int count = 0; count < N - 1; count++)
            {
                int u = MinDistance(dist, sptSet);

                // Mark the picked vertex as processed
                sptSet[u] = true;
                for (int i = 0; i < N; i++)
                    if (!sptSet[i] && graph[u, i] != 0 && dist[u] != long.MaxValue && dist[u] + graph[u, i] < dist[i])
                    {
                        dist[i] = dist[u] + graph[u, i];
                        pred[i] = MergeMap(pred[u], i.ToString());
                    }
            }
            List<string> weight = new List<string>();
            for (int i = 0; i < pred[N - 1].Count - 1; i++)
            {
                weight.Add(graph[Convert.ToInt32(pred[N - 1][i]), Convert.ToInt32(pred[N - 1][i + 1])].ToString());
            }
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(i + " : " + dist[i]);
                for (int j = 0; j < pred[i].Count; j++)
                {
                    Console.WriteLine(pred[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Right way: ");
            for (int i = 0; i < pred[N - 1].Count; i++)
            {
                Console.WriteLine(pred[N - 1][i]);
            }
            Console.WriteLine();
            Console.WriteLine("Weight: ");
            for (int i = 0; i < weight.Count; i++)
            {
                Console.WriteLine(weight[i]);
            }
        }

        public string ConvertResultToString()
        {
            var resultString = "";
            for (int i = 0; i < NumberOfPoint; i++)
            {
                resultString += dist[i] + ":";
                for (int j = 0; j < pred[i].Count; j++)
                {
                    resultString += " " + pred[i][j];
                }
                resultString += "#";
            }
            resultString = resultString.Remove(resultString.Length - 1);
            return resultString;
        }
        #endregion
    }
}
