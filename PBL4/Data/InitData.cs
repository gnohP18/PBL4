using PBL4.Model;
using System.Collections.Generic;

namespace PBL4.Data
{
    public class InitData
    {
        #region Local variable
        public List<int> NumberOfPoints { get; set; }
        public List<Location> Locations { get; set; }
        #endregion
        public InitData()
        {
            SeedNumberOfPoint();
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

        private void SeedLocationOfPoint()
        {
            Locations = new List<Location>();
            //Quy will seed data of location in here
        }
        #endregion
    }
}
