using System.Windows.Forms;

namespace PBL4.View
{
    public partial class ResultUC : UserControl
    {
        #region Local variable
        private string Result { get; set; }
        private long Distance { get; set; }
        #endregion

        public ResultUC()
        {
            InitializeComponent();
        }

        #region Function
        public void SetResult(string name, string path, string distance)
        {
            endPointName.Text = name;
            lblPath.Text = "Path: " + path;
            lbWeight.Text = "Distance: " + distance;
        }
        #endregion

    }
}
