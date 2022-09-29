using PBL4.Model;
using System.Collections.Generic;

namespace PBL4.Data
{
    public class InitData
    {
        #region Local variable
        public List<int> NumberOfPoints { get; set; }
        public List<Location> Locations { get; set; }
        public List<string> PoitnName { get; set; }
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
            for (int i = 1; i < 10; i++)
            {
                NumberOfPoints.Add(i);
            }
        }

        private void SeedPointName()
        {
            PoitnName = new List<string>();
            for (int i = 65; i < 75; i++)
            {
                PoitnName.Add(char.ConvertFromUtf32(i));
            }
        }

        private void SeedDataForConnectingtoServer()
        {
            PortNumber = 111;
            IpAddress = "127.0.0.1";
        }

        private void SeedLocationOfPoint()
        {
            Locations = new List<Location>();
            //Quy will seed data of location in here
            //Quy da o day
        }

        #endregion
    }
}
