namespace PBL4.View
{
    partial class ValueUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lbMatLoca = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtValue.Location = new System.Drawing.Point(35, 0);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(35, 22);
            this.txtValue.TabIndex = 0;
            // 
            // lbMatLoca
            // 
            this.lbMatLoca.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbMatLoca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMatLoca.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatLoca.Location = new System.Drawing.Point(0, 0);
            this.lbMatLoca.Name = "lbMatLoca";
            this.lbMatLoca.Size = new System.Drawing.Size(35, 22);
            this.lbMatLoca.TabIndex = 1;
            this.lbMatLoca.Text = "lb";
            this.lbMatLoca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ValueUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbMatLoca);
            this.Controls.Add(this.txtValue);
            this.Name = "ValueUC";
            this.Size = new System.Drawing.Size(70, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lbMatLoca;
    }
}
