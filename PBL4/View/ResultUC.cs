using PBL4.Resources.Language;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using static PBL4.View.ResultGraph;

namespace PBL4.View
{
    public partial class ResultUC : UserControl
    {
        #region Global variable
        private string Result { get; set; }
        private long Distance { get; set; }
        private ResourceManager _resourceManager;
        private CultureInfo cultureInfo;
        public DeleDraw Drawer;
        #endregion

        public ResultUC(DeleDraw drawer)
        {
            InitializeComponent();
            Drawer = drawer;
            SetupLanguage(InitLanguage.CurrentLanguage);
        }

        #region Function
        private void SetupLanguage(string language)
        {
            _resourceManager = new ResourceManager("PBL4.Resources.Language.Resource", typeof(InitLanguage).Assembly);
            cultureInfo = CultureInfo.InvariantCulture;
            cultureInfo = CultureInfo.CreateSpecificCulture(language);
            InitLanguage.Instance.ChangeLanguage(language);
        }
        public void SetResult(string name, string path, string distance)
        {
            endPointName.Text = name;
            lblPath.Text = _resourceManager.GetString("Path", cultureInfo) + ": " + path;
            lbWeight.Text = _resourceManager.GetString("Distance", cultureInfo) + ": " + distance;
        }
        #endregion

        private void endPointName_Click(object sender, System.EventArgs e)
        {
            Drawer(endPointName.Text);
        }
    }
}
