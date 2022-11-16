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

        public string GetValue()
        {
            return txtValue.Text;
        }

        public void SetValue(long value)
        {
            Value = value;
            txtValue.Text = Convert.ToString(value);
        }

        //Khởi tạo giá trị ban đầu của ma trận
        public void SetInitValue()
        {
            bool isAvailableValue = true;
            char[] arrChar = txtValue.Text.ToCharArray();
            if (arrChar.Length > 0)
            {
                foreach (char c in arrChar)
                {
                    if ('0' > c && c > '9' || c == '-') isAvailableValue = false;
                }
            }
            else isAvailableValue = false;
            if (isAvailableValue)
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

        public void SetEnableTextBox()
        {
            txtValue.Enabled = false;
        }
        #endregion
    }
}
