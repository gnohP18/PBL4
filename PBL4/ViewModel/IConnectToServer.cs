namespace PBL4.ViewModel
{
    public interface IConnectToServer
    {
        void DataEncapsulation(string data);
        void ThreadReceiveDataFromServer();
        void ThreadSendDataToServer();
    }
}
