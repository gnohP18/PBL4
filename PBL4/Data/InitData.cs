using PBL4.Model;
using System.Collections.Generic;

namespace PBL4.Data
{
    public class InitData
    {
        #region Local variable
        public List<int> NumberOfPoints { get; set; }
        public List<string> PointName { get; set; }
        public int PortNumber { get; set; }
        public string IpAddress { get; set; }
        #endregion
        public InitData()
        {
            SeedNumberOfPoint();
            SeedPointName();
            SeedDataForConnectingtoServer();
        }

        #region Seeding data 
        private void SeedNumberOfPoint()
        {
            NumberOfPoints = new List<int>();
            for (int i = 1; i < EnumMatrix.MaximumNumberOfPoint; i++)
            {
                NumberOfPoints.Add(i);
            }
        }

        private void SeedPointName()
        {
            PointName = new List<string>();
            for (int i = 1; i <= EnumMatrix.MaximumNumberOfPoint; i++)
            {
                const int beginChar = 65;
                if (i <= 26)
                {
                    string name = char.ConvertFromUtf32(i + beginChar);
                    PointName.Add(name);
                }
                else
                {
                    string name = char.ConvertFromUtf32(i + beginChar) + (i % 26).ToString();
                    PointName.Add(name);
                }
            }
        }

        private void SeedDataForConnectingtoServer()
        {
            PortNumber = 555;
            IpAddress = "127.0.0.1";
        }

        #endregion
    }
}
