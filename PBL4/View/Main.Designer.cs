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
            this.pnScreen = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnMatrix = new System.Windows.Forms.Panel();
            this.cbbNumberOfPoints = new System.Windows.Forms.ComboBox();
            this.pnResult = new System.Windows.Forms.Panel();
            this.gbPointName = new System.Windows.Forms.GroupBox();
            this.pnProcessing = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnResultFromServer = new System.Windows.Forms.Panel();
            this.pnScreen.SuspendLayout();
            this.pnResult.SuspendLayout();
            this.pnProcessing.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnScreen
            // 
            this.pnScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.pnScreen.Controls.Add(this.label1);
            this.pnScreen.Controls.Add(this.pnMatrix);
            this.pnScreen.Controls.Add(this.cbbNumberOfPoints);
            this.pnScreen.Controls.Add(this.btnExit);
            this.pnScreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnScreen.Location = new System.Drawing.Point(0, 0);
            this.pnScreen.Name = "pnScreen";
            this.pnScreen.Size = new System.Drawing.Size(750, 800);
            this.pnScreen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of points";
            // 
            // pnMatrix
            // 
            this.pnMatrix.AutoScroll = true;
            this.pnMatrix.BackColor = System.Drawing.SystemColors.Info;
            this.pnMatrix.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnMatrix.Location = new System.Drawing.Point(0, 535);
            this.pnMatrix.Name = "pnMatrix";
            this.pnMatrix.Size = new System.Drawing.Size(750, 265);
            this.pnMatrix.TabIndex = 2;
            // 
            // cbbNumberOfPoints
            // 
            this.cbbNumberOfPoints.FormattingEnabled = true;
            this.cbbNumberOfPoints.Location = new System.Drawing.Point(283, 12);
            this.cbbNumberOfPoints.Name = "cbbNumberOfPoints";
            this.cbbNumberOfPoints.Size = new System.Drawing.Size(270, 24);
            this.cbbNumberOfPoints.TabIndex = 0;
            this.cbbNumberOfPoints.SelectedIndexChanged += new System.EventHandler(this.cbbNumberOfPoints_SelectedIndexChanged);
            // 
            // pnResult
            // 
            this.pnResult.BackColor = System.Drawing.Color.LightSalmon;
            this.pnResult.Controls.Add(this.button1);
            this.pnResult.Controls.Add(this.btnReset);
            this.pnResult.Controls.Add(this.gbPointName);
            this.pnResult.Controls.Add(this.btnOK);
            this.pnResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnResult.Location = new System.Drawing.Point(750, 535);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(550, 265);
            this.pnResult.TabIndex = 2;
            // 
            // gbPointName
            // 
            this.gbPointName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPointName.Location = new System.Drawing.Point(35, 20);
            this.gbPointName.Name = "gbPointName";
            this.gbPointName.Size = new System.Drawing.Size(410, 187);
            this.gbPointName.TabIndex = 5;
            this.gbPointName.TabStop = false;
            this.gbPointName.Text = "From A to";
            // 
            // pnProcessing
            // 
            this.pnProcessing.AutoScroll = true;
            this.pnProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.pnProcessing.Controls.Add(this.pnResultFromServer);
            this.pnProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProcessing.Location = new System.Drawing.Point(750, 0);
            this.pnProcessing.Name = "pnProcessing";
            this.pnProcessing.Size = new System.Drawing.Size(550, 535);
            this.pnProcessing.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::PBL4.Properties.Resources.neural_24;
            this.button1.Location = new System.Drawing.Point(481, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Image = global::PBL4.Properties.Resources.reset_24;
            this.btnReset.Location = new System.Drawing.Point(481, 213);
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
            this.btnOK.Location = new System.Drawing.Point(35, 213);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PBL4.Properties.Resources.uncheckedRed;
            this.btnExit.Location = new System.Drawing.Point(40, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnResultFromServer
            // 
            this.pnResultFromServer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnResultFromServer.Location = new System.Drawing.Point(0, 35);
            this.pnResultFromServer.Name = "pnResultFromServer";
            this.pnResultFromServer.Size = new System.Drawing.Size(550, 500);
            this.pnResultFromServer.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.pnProcessing);
            this.Controls.Add(this.pnResult);
            this.Controls.Add(this.pnScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnScreen.ResumeLayout(false);
            this.pnScreen.PerformLayout();
            this.pnResult.ResumeLayout(false);
            this.pnProcessing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnScreen;
        private System.Windows.Forms.ComboBox cbbNumberOfPoints;
        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.Panel pnProcessing;
        private System.Windows.Forms.Panel pnMatrix;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbPointName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnResultFromServer;
    }
}

