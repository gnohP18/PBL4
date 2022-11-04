using System;
using System.Collections.Generic;

namespace PBL4_Server.Model
{
    public class MatrixService : IMatrixService
    {
        #region Instance

        #endregion

        #region Global variable
        /// <summary>
        /// Ma trận chứa trọng số của đồ thị
        /// </summary>
        public long[,] MatrixDijkstra { get; set; }

        /// <summary>
        /// Số điểm trong đồ thị
        /// </summary>
        public int NumberOfPoint { get; set; }

        /// <summary>
        /// Mảng 1 chiều chứa khoảng cách từ nguồn đến một điểm bất kỳ
        /// </summary>
        public static long[] dist { get; set; }

        /// <summary>
        /// Danh sách chứa các đường đi đến các điểm
        /// </summary>
        public List<List<string>> pred { get; set; }

        /// <summary>
        ///  Chuỗi kết quả thực hiện tính toán của tất cả các điểm
        /// </summary>
        public string StringResultOfAllPoint { get; set; }

        /// <summary>
        ///  Tên của Client khi tách ra
        /// </summary>
        public string ComputerName { get; set; }
        #endregion

        #region Function
        public void SplitMatrixFromData(string dataFromServer)
        {
            Console.WriteLine("After split matrix from data");
            //Tách tên máy
            int indexOfName = dataFromServer.IndexOf("@");
            ComputerName = dataFromServer.Substring(0, indexOfName);

            //Tách số lượng điểm
            var data = dataFromServer.Substring(indexOfName + 1);
            int index = data.IndexOf(":");
            NumberOfPoint = Convert.ToInt32((data.Substring(0, index)));

            //Tách ma trận
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

        public string CalculateDijskstraOfAllPoint()
        {
            StringResultOfAllPoint = "";

            for (int i = 0; i < NumberOfPoint; i++)
            {
                Dijkstra(i);
                StringResultOfAllPoint += ConvertResultToString() + "@";
            }
            StringResultOfAllPoint = StringResultOfAllPoint.Remove(StringResultOfAllPoint.Length - 1);
            Console.Write(StringResultOfAllPoint);
            return StringResultOfAllPoint;
        }

        public void Dijkstra(int src)
        {
            pred = new List<List<string>>();
            long[,] graph = MatrixDijkstra;
            dist = new long[NumberOfPoint];
            int numberOfPoint = NumberOfPoint;
            int N = numberOfPoint;
            for (int i = 0; i < N; i++)
            {
                pred.Add(new List<string>());
            }
            //Mảng đánh dấu điểm đã được xử lý 
            bool[] sptSet = new bool[N];
            //Khởi tạo khoảng cách bằng max value của long
            //và gán tất các phần tử sptSet(shortest path tree set) bằng false
            for (int i = 0; i < N; i++)
            {
                dist[i] = long.MaxValue;
                sptSet[i] = false;
            }

            // Khoảng cách từ điểm nguồn đến chính nó bằng 0
            dist[src] = 0;
            pred[src].Add(src.ToString());

            //Tìm đường đi ngắn nhất cho tất cả các đỉnh
            for (int count = 0; count < N - 1; count++)
            {
                int u = MinDistance(dist, sptSet);

                //Đánh dấu điểm đã được xử lý
                sptSet[u] = true;
                for (int i = 0; i < N; i++)
                    if (!sptSet[i] && graph[u, i] != 0 && dist[u] != long.MaxValue && dist[u] + graph[u, i] < dist[i])
                    {
                        dist[i] = dist[u] + graph[u, i];
                        pred[i] = MergeMap(pred[u], i.ToString());
                    }
            }
            //Hiển thị kết quả
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(i + " : " + dist[i]);
                for (int j = 0; j < pred[i].Count; j++)
                {
                    Console.WriteLine(pred[i][j] + " ");
                }
                Console.WriteLine();
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
                    if (j == 0)
                        resultString += pred[i][j];
                    else
                        resultString += " " + pred[i][j];
                }
                resultString += "#";
            }
            //Xóa dấu # ở vị trí cuối
            resultString = resultString.Remove(resultString.Length - 1);
            return resultString;
        }

        #endregion
    }
}
