using System.Windows.Forms;

namespace PBL4.View
{
    public partial class ResultUC : UserControl
    {
        #region Local variable
        private string PointName { get; set; }
        private string Result { get; set; }
        private long Distance { get; set; }
        #endregion

        public ResultUC()
        {
            InitializeComponent();
        }

        #region Function
        public void SetResult(string name, string result, int distance)
        {
            PointName = name;
            Result = result;
            Distance = distance;
            lblPointName.Text = "From " + name + "To";
            lblWay.Text = "Way" + result + " distance " + distance.ToString();
        }
        #endregion

    }
}
