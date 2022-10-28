namespace PBL4.View
{
    partial class ResultGraph
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnResultFromServer = new System.Windows.Forms.Panel();
            this.pnGp = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnGp.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnResultFromServer
            // 
            this.pnResultFromServer.BackColor = System.Drawing.Color.FloralWhite;
            this.pnResultFromServer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnResultFromServer.Location = new System.Drawing.Point(849, 0);
            this.pnResultFromServer.Name = "pnResultFromServer";
            this.pnResultFromServer.Size = new System.Drawing.Size(451, 800);
            this.pnResultFromServer.TabIndex = 1;
            // 
            // pnGp
            // 
            this.pnGp.AutoScroll = true;
            this.pnGp.Controls.Add(this.btnExit);
            this.pnGp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGp.Location = new System.Drawing.Point(0, 0);
            this.pnGp.Name = "pnGp";
            this.pnGp.Size = new System.Drawing.Size(849, 800);
            this.pnGp.TabIndex = 5;
            this.pnGp.Paint += new System.Windows.Forms.PaintEventHandler(this.pnGp_Paint);
            this.pnGp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ResultGraph_MouseClick);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PBL4.Properties.Resources.uncheckedRed;
            this.btnExit.Location = new System.Drawing.Point(3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ResultGraph
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.pnGp);
            this.Controls.Add(this.pnResultFromServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResultGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ResultGraph";
            this.Load += new System.EventHandler(this.ResultGraph_Load);
            this.pnGp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnResultFromServer;
        private System.Windows.Forms.Panel pnGp;
        private System.Windows.Forms.Button btnExit;
    }
}