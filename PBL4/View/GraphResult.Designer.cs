namespace PBL4.View
{
    partial class GraphResult
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
            this.btnExit = new System.Windows.Forms.Button();
            this.pnResultFromServer = new System.Windows.Forms.Panel();
            this.pnScreen = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PBL4.Properties.Resources.uncheckedRed;
            this.btnExit.Location = new System.Drawing.Point(1157, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // pnResultFromServer
            // 
            this.pnResultFromServer.BackColor = System.Drawing.SystemColors.Info;
            this.pnResultFromServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnResultFromServer.Location = new System.Drawing.Point(0, 0);
            this.pnResultFromServer.Name = "pnResultFromServer";
            this.pnResultFromServer.Size = new System.Drawing.Size(1200, 700);
            this.pnResultFromServer.TabIndex = 2;
            // 
            // pnScreen
            // 
            this.pnScreen.BackColor = System.Drawing.Color.Cornsilk;
            this.pnScreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnScreen.Location = new System.Drawing.Point(0, 0);
            this.pnScreen.Name = "pnScreen";
            this.pnScreen.Size = new System.Drawing.Size(750, 700);
            this.pnScreen.TabIndex = 3;
            // 
            // GraphResult
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnScreen);
            this.Controls.Add(this.pnResultFromServer);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GraphResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphResult";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnResultFromServer;
        private System.Windows.Forms.Panel pnScreen;
    }
}