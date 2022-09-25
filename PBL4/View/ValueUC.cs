using System;
using System.Drawing;
using System.Windows.Forms;

namespace PBL4.View
{
    public partial class ValueUC : UserControl
    {
        public ValueUC()
        {
            InitializeComponent();
        }
        #region Local variable
        public string Text { get; set; }
        public long Value { get; set; }
        #endregion
        #region Function
        public void SetCoordinates(string text)
        {
            this.Text = text;
            lbMatLoca.Text = Text;
        }
        public void SetLocation(Point point)
        {
            this.Location = point;
        }
        public long GetValue()
        {
            return Convert.ToInt32(txtValue.Text);
        }
        #endregion
    }
}
