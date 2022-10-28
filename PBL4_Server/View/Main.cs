using PBL4_Server.Model;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PBL4_Server
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Thread connect = new Thread(ConnectToClient.Instance.StartANewThread);
            connect.Start();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //ConnectToClient.Instance.ShowResult();
        }
    }
}
