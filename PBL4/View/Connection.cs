using PBL4.Data;
using PBL4.Resources.Language;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace PBL4.View
{
    public partial class Connection : Form
    {
        #region Global variable
        private List<string> ListKeyLanguage;
        private string CurrentLanguage;
        private ResourceManager _resourceManager;
        private CultureInfo cultureInfo;
        #endregion

        private static InitData _initData;
        public Connection()
        {
            _initData = new InitData();
            InitializeComponent();
        }

        #region Function
        private void SetupLanguage(string language)
        {
            _resourceManager = new ResourceManager("PBL4.Resources.Language.Resource", typeof(InitLanguage).Assembly);
            cultureInfo = CultureInfo.InvariantCulture;
            cultureInfo = CultureInfo.CreateSpecificCulture(language);
            InitLanguage.Instance.ChangeLanguage(language);
            lblComputerName.Text = _resourceManager.GetString("ComputerName", cultureInfo);
            lblIPAddress.Text = _resourceManager.GetString("IPAddress", cultureInfo);
        }
        private bool IsAvailableComputerName()
        {
            return txtComputerName.Text != null ? true : false;
        }

        private bool IsAvailableIPAddress()
        {
            return txtIPAddress.Text != null ? true : false;
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
                String noticeMessage = _resourceManager.GetString("MsgComputerName", cultureInfo);
                NoticeBox noticeBox = new NoticeBox(noticeMessage);
                noticeBox.Show();
            }
            else if (!IsAvailableIPAddress())
            {
                String noticeMessage = _resourceManager.GetString("MsgIPAddress", cultureInfo);
                NoticeBox noticeBox = new NoticeBox(noticeMessage);
                noticeBox.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            txtComputerName.Text = _initData.ComputerName;
            txtIPAddress.Text = _initData.IpAddress;
            foreach (var i in InitLanguage.Instance.Language())
            {
                cbbLanguageChange.Items.Add(i);
            }
            ListKeyLanguage = InitLanguage.Instance.KeyLanguage();
            CurrentLanguage = "en-US";
            SetupLanguage(CurrentLanguage);
            cbbLanguageChange.SelectedIndex = 1;
        }
        #endregion

        private void cbbLanguageChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupLanguage(ListKeyLanguage[cbbLanguageChange.SelectedIndex]);
            Console.WriteLine(ListKeyLanguage[cbbLanguageChange.SelectedIndex]);
        }
    }
}
