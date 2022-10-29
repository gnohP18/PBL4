namespace PBL4_ServerSolve.Data
{
    public class InitData
    {
        #region Local variable
        public int PortNumber { get; set; }
        public string IpAddress { get; set; }
        #endregion
        public InitData()
        {
            SeedDataForConnectingtoServer();
        }

        #region Seeding data 
        private void SeedDataForConnectingtoServer()
        {
            PortNumber = 555;
            IpAddress = "127.0.0.1";
        }

        #endregion
    }
}
