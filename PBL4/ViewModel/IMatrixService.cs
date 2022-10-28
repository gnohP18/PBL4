using System.Collections.Generic;

namespace PBL4.Model
{
    public interface IMatrixService
    {
        List<int> GetNumberOfPoint();
        List<string> GetPointNameByNumberOfPoint(int numberOfPoint);
        string ConvertMatrixToMatrixString(int numberOfPoint, long[,] matrixInput);
    }
}
