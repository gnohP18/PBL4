using PBL4.Data;
using System;
using System.Windows.Forms;

namespace PBL4.View
{
    public partial class Connection : Form
    {
        private static InitData _initData;
        public Connection()
        {
            _initData = new InitData();
            InitializeComponent();
        }

        #region Function
        private bool IsAvailableComputerName()
        {
            return txtComputerName.Text != null ? true : false;
        }

        private bool IsAvailableIPAddress()
        {
            //var charConvert = txtIPAddress.Text.ToCharArray();
            //bool result = true;
            //for (int i = 0; i < charConvert.Length; i++)
            //{
            //    if (charConvert[i] <= '9' && charConvert[i] >= '0' || charConvert[i] == '.')
            //    {
            //        result = false;
            //    }
            //}
            //return result;
            return true;
        }

        #endregion

        #region Handle event
        private void btnSearchComputerName_Click(object sender, EventArgs e)
        {
            txtComputerName.Text = _initData.ComputerName;
        }

        private void btnSearchIPAddress_Click(object sender, EventArgs e)
        {
            txtIPAddress.Text = _initData.IpAddress;
        }

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            if (IsAvailableComputerName() && IsAvailableIPAddress())
            {
                Main main = new Main(txtComputerName.Text, txtIPAddress.Text, _initData.PortNumber.ToString());
                main.Show();
                this.Hide();
            }
            else if (!IsAvailableComputerName())
            {
                NoticeBox noticeBox = new NoticeBox("Computer name is null");
                noticeBox.Show();
            }
            else if (!IsAvailableIPAddress())
            {
                NoticeBox noticeBox = new NoticeBox("Wrong IP Address");
                noticeBox.Show();
            }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            txtComputerName.Text = _initData.ComputerName;
            txtIPAddress.Text = _initData.IpAddress;
        }
    }
}
