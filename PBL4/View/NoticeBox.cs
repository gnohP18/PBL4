using System.Windows.Forms;

namespace PBL4.View
{
    public partial class NoticeBox : Form
    {
        #region Local variable
        public string Notice { get; set; }
        #endregion

        public NoticeBox(string message)
        {
            Notice = message;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Event Handle
        private void NoticeBox_Load(object sender, System.EventArgs e)
        {
            lblMessage.Text = Notice;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
