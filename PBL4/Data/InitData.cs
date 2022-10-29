using PBL4.Model;
using System.Collections.Generic;

namespace PBL4.Data
{
    public class InitData
    {
        #region Local variable
        //Danh sách số lượng điểm 
        public List<int> NumberOfPoints { get; set; }
        
        // Danh sách tên điểm dựa vào số lượng điểm
        public List<string> PointName { get; set; }

        // Số hiệu của cổng để kết nối client-server
        public int PortNumber { get; set; }

        //Địa chỉ IP để kết nối client-server
        public string IpAddress { get; set; }
        #endregion
        public InitData()
        {
            SeedNumberOfPoint();
            SeedPointName();
            SeedDataForConnectingtoServer();
        }

        #region Seeding data 
        //Khởi tạo danh sách số lượng điểm
        private void SeedNumberOfPoint()
        {
            NumberOfPoints = new List<int>();
            for (int i = 1; i < EnumMatrix.MaximumNumberOfPoint; i++)
            {
                NumberOfPoints.Add(i);
            }
        }

        //Khởi tạo danh sách tên điểm dựa vào số lượng điểm
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

        //Khởi tạo dữ liệu để kết nối client-server
        private void SeedDataForConnectingtoServer()
        {
            PortNumber = 555;
            IpAddress = "127.0.0.1";
        }
        #endregion
    }
}
