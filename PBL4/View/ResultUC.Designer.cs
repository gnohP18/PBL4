namespace PBL4.View
{
    partial class ResultUC
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
            this.btnNumber = new System.Windows.Forms.Button();
            this.lblPointName = new System.Windows.Forms.Label();
            this.lblWay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNumber
            // 
            this.btnNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
            this.btnNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNumber.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumber.Location = new System.Drawing.Point(0, 0);
            this.btnNumber.Name = "btnNumber";
            this.btnNumber.Size = new System.Drawing.Size(50, 50);
            this.btnNumber.TabIndex = 0;
            this.btnNumber.Text = "nb";
            this.btnNumber.UseVisualStyleBackColor = false;
            // 
            // lblPointName
            // 
            this.lblPointName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPointName.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointName.Location = new System.Drawing.Point(50, 0);
            this.lblPointName.Name = "lblPointName";
            this.lblPointName.Size = new System.Drawing.Size(500, 25);
            this.lblPointName.TabIndex = 1;
            this.lblPointName.Text = "name";
            // 
            // lblWay
            // 
            this.lblWay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWay.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWay.Location = new System.Drawing.Point(50, 25);
            this.lblWay.Name = "lblWay";
            this.lblWay.Size = new System.Drawing.Size(500, 25);
            this.lblWay.TabIndex = 2;
            this.lblWay.Text = "label1";
            // 
            // ResultUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.lblWay);
            this.Controls.Add(this.lblPointName);
            this.Controls.Add(this.btnNumber);
            this.Name = "ResultUC";
            this.Size = new System.Drawing.Size(550, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNumber;
        private System.Windows.Forms.Label lblPointName;
        private System.Windows.Forms.Label lblWay;
    }
}
