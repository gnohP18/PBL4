namespace PBL4_Server.Data
{
    public class InitData
    {
        public int PortNumber { get; set; }
        public string IpAddress { get; set; }
        public InitData()
        {
            SeedDataForConnectingtoServer();
        }
        private void SeedDataForConnectingtoServer()
        {
            PortNumber = 555;
            IpAddress = "127.0.0.1";
        }
    }
}
