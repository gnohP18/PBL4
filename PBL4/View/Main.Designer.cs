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
            this.btnExit = new System.Windows.Forms.Button();
            this.pnScreen = new System.Windows.Forms.Panel();
            this.cbbNumberOfPoints = new System.Windows.Forms.ComboBox();
            this.pnResult = new System.Windows.Forms.Panel();
            this.pnMatrix = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnScreen.SuspendLayout();
            this.pnMatrix.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PBL4.Properties.Resources.uncheckedRed;
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnScreen
            // 
            this.pnScreen.Controls.Add(this.cbbNumberOfPoints);
            this.pnScreen.Controls.Add(this.btnExit);
            this.pnScreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnScreen.Location = new System.Drawing.Point(0, 0);
            this.pnScreen.Name = "pnScreen";
            this.pnScreen.Size = new System.Drawing.Size(737, 800);
            this.pnScreen.TabIndex = 1;
            // 
            // cbbNumberOfPoints
            // 
            this.cbbNumberOfPoints.FormattingEnabled = true;
            this.cbbNumberOfPoints.Location = new System.Drawing.Point(228, 16);
            this.cbbNumberOfPoints.Name = "cbbNumberOfPoints";
            this.cbbNumberOfPoints.Size = new System.Drawing.Size(270, 24);
            this.cbbNumberOfPoints.TabIndex = 0;
            this.cbbNumberOfPoints.SelectedIndexChanged += new System.EventHandler(this.cbbNumberOfPoints_SelectedIndexChanged);
            // 
            // pnResult
            // 
            this.pnResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnResult.Location = new System.Drawing.Point(737, 522);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(563, 278);
            this.pnResult.TabIndex = 2;
            // 
            // pnMatrix
            // 
            this.pnMatrix.AutoScroll = true;
            this.pnMatrix.Controls.Add(this.label1);
            this.pnMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMatrix.Location = new System.Drawing.Point(737, 0);
            this.pnMatrix.Name = "pnMatrix";
            this.pnMatrix.Size = new System.Drawing.Size(563, 522);
            this.pnMatrix.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.pnMatrix);
            this.Controls.Add(this.pnResult);
            this.Controls.Add(this.pnScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnScreen.ResumeLayout(false);
            this.pnMatrix.ResumeLayout(false);
            this.pnMatrix.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnScreen;
        private System.Windows.Forms.ComboBox cbbNumberOfPoints;
        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.Panel pnMatrix;
        private System.Windows.Forms.Label label1;
    }
}

