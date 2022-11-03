using PBL4.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

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
        //Tên máy tính hiện hành
        public string ComputerName { get; set; }
        #endregion
        public InitData()
        {
            SeedNumberOfPoint();
            SeedPointName();
            SeedDataForConnectingtoServer();
            SeedComputerName();
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
            for (int i = 1; i <= 150; i++)
            {
                const int beginChar = 64;
                int suffixes = i / 26;
                string name = "";
                if (i % 26 == 0)
                {
                    name = char.ConvertFromUtf32(26 + beginChar) + (suffixes - 1);
                }
                else
                {
                    name = char.ConvertFromUtf32(i % 26 + beginChar) + suffixes;
                }
                PointName.Add(name);
            }

        }

        //Khởi tạo dữ liệu để kết nối client-server
        private void SeedDataForConnectingtoServer()
        {
            PortNumber = 555;
            IpAddress = GetIPAddress();
        }

        //Lấy giá trị của IP hiện hành
        public string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }

        private void SeedComputerName()
        {
            ComputerName = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
        }
        #endregion
    }
}
