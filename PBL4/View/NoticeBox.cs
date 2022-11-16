using PBL4.Resources.Language;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace PBL4.View
{
    public partial class NoticeBox : Form
    {
        #region Global variable
        public string Notice { get; set; }
        private ResourceManager _resourceManager;
        private CultureInfo cultureInfo;
        #endregion
        public void SetupLanguage(string language)
        {
            _resourceManager = new ResourceManager("PBL4.Resources.Language.Resource", typeof(InitLanguage).Assembly);
            cultureInfo = CultureInfo.InvariantCulture;
            cultureInfo = CultureInfo.CreateSpecificCulture(language);
            InitLanguage.Instance.ChangeLanguage(language);
            label1.Text = _resourceManager.GetString("Notification", cultureInfo);
            btnConfirm.Text = _resourceManager.GetString("IGotIt",cultureInfo);
        }
        public NoticeBox(string message)
        {
            Notice = message;
            InitializeComponent();
            SetupLanguage(InitLanguage.CurrentLanguage);
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
