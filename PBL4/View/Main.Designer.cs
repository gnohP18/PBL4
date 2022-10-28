namespace PBL4
{
    partial class Main
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
            this.pnMatrix = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbNumberOfPoints = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConnectToServer = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnProcessing = new System.Windows.Forms.Panel();
            this.pnProcessing.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMatrix
            // 
            this.pnMatrix.AutoScroll = true;
            this.pnMatrix.BackColor = System.Drawing.SystemColors.Info;
            this.pnMatrix.Location = new System.Drawing.Point(12, 90);
            this.pnMatrix.Name = "pnMatrix";
            this.pnMatrix.Size = new System.Drawing.Size(1276, 652);
            this.pnMatrix.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of points";
            // 
            // cbbNumberOfPoints
            // 
            this.cbbNumberOfPoints.FormattingEnabled = true;
            this.cbbNumberOfPoints.Location = new System.Drawing.Point(494, 12);
            this.cbbNumberOfPoints.Name = "cbbNumberOfPoints";
            this.cbbNumberOfPoints.Size = new System.Drawing.Size(270, 21);
            this.cbbNumberOfPoints.TabIndex = 0;
            this.cbbNumberOfPoints.SelectedIndexChanged += new System.EventHandler(this.cbbNumberOfPoints_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PBL4.Properties.Resources.uncheckedRed;
            this.btnExit.Location = new System.Drawing.Point(1256, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = " ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.BackColor = System.Drawing.Color.Transparent;
            this.btnConnectToServer.FlatAppearance.BorderSize = 0;
            this.btnConnectToServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectToServer.Image = global::PBL4.Properties.Resources.neural_24;
            this.btnConnectToServer.Location = new System.Drawing.Point(84, 757);
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.Size = new System.Drawing.Size(75, 40);
            this.btnConnectToServer.TabIndex = 7;
            this.btnConnectToServer.UseVisualStyleBackColor = false;
            this.btnConnectToServer.Click += new System.EventHandler(this.btnConnectToServer_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Image = global::PBL4.Properties.Resources.reset_24;
            this.btnReset.Location = new System.Drawing.Point(3, 757);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 40);
            this.btnReset.TabIndex = 6;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::PBL4.Properties.Resources.checkedGreen;
            this.btnOK.Location = new System.Drawing.Point(1186, 748);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnProcessing
            // 
            this.pnProcessing.AutoScroll = true;
            this.pnProcessing.BackColor = System.Drawing.Color.FloralWhite;
            this.pnProcessing.Controls.Add(this.btnConnectToServer);
            this.pnProcessing.Controls.Add(this.label1);
            this.pnProcessing.Controls.Add(this.btnReset);
            this.pnProcessing.Controls.Add(this.pnMatrix);
            this.pnProcessing.Controls.Add(this.cbbNumberOfPoints);
            this.pnProcessing.Controls.Add(this.btnOK);
            this.pnProcessing.Controls.Add(this.btnExit);
            this.pnProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProcessing.Location = new System.Drawing.Point(0, 0);
            this.pnProcessing.Name = "pnProcessing";
            this.pnProcessing.Size = new System.Drawing.Size(1300, 800);
            this.pnProcessing.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.pnProcessing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnProcessing.ResumeLayout(false);
            this.pnProcessing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbbNumberOfPoints;
        private System.Windows.Forms.Panel pnProcessing;
        private System.Windows.Forms.Panel pnMatrix;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnConnectToServer;
    }
}

