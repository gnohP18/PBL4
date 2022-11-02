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

        //Khởi tạo giá trị ban đầu của ma trận
        public void SetInitValue()
        {
            bool isAvalableValue = true;
            char[] arrChar = txtValue.Text.ToCharArray();
            if (arrChar.Length > 0)
            {
                foreach (char c in arrChar)
                {
                    if ('0' > c && c > '9') isAvalableValue = false;
                }
            }
            else isAvalableValue = false;
            if (isAvalableValue)
            {
                lbMatLoca.BackColor = Color.LightSkyBlue;
                Value = Convert.ToInt32(txtValue.Text);
            }
            else
            {
                lbMatLoca.BackColor = Color.LightCoral;
                Value = -1;
            }
        }

        public void SetValueEqualZero()
        {
            Value = 0;
            txtValue.Text = "0";
            txtValue.Enabled = false;
        }

        public void ClearValue()
        {
            txtValue.Text = null;
            Value = 0;
        }
        #endregion
    }
}
