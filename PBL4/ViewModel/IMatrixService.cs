using System.Collections.Generic;

namespace PBL4.Model
{
    public interface IMatrixService
    {
        void GetLocation();
        List<int> GetNumberOfPoint();
        List<string> GetPointNameByNumberOfPoint(int numberOfPoint);
    }
}
