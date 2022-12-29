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
            this.lblNameOfPoint = new System.Windows.Forms.Label();
            this.cbbNumberOfPoints = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnProcessing = new System.Windows.Forms.Panel();
            this.lblResetMatrix = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtbBF = new System.Windows.Forms.TextBox();
            this.btnBF = new System.Windows.Forms.Button();
            this.btnDrawTheGraph = new System.Windows.Forms.Button();
            this.lblSubmitMatrix = new System.Windows.Forms.Label();
            this.lblDrawGraph = new System.Windows.Forms.Label();
            this.pnProcessing.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMatrix
            // 
            this.pnMatrix.AutoScroll = true;
            this.pnMatrix.BackColor = System.Drawing.Color.LightCyan;
            this.pnMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMatrix.Location = new System.Drawing.Point(15, 86);
            this.pnMatrix.Name = "pnMatrix";
            this.pnMatrix.Size = new System.Drawing.Size(1273, 612);
            this.pnMatrix.TabIndex = 2;
            // 
            // lblNameOfPoint
            // 
            this.lblNameOfPoint.AutoSize = true;
            this.lblNameOfPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOfPoint.Location = new System.Drawing.Point(12, 58);
            this.lblNameOfPoint.Name = "lblNameOfPoint";
            this.lblNameOfPoint.Size = new System.Drawing.Size(154, 24);
            this.lblNameOfPoint.TabIndex = 3;
            this.lblNameOfPoint.Text = "Number of points";
            // 
            // cbbNumberOfPoints
            // 
            this.cbbNumberOfPoints.FormattingEnabled = true;
            this.cbbNumberOfPoints.Location = new System.Drawing.Point(184, 57);
            this.cbbNumberOfPoints.Name = "cbbNumberOfPoints";
            this.cbbNumberOfPoints.Size = new System.Drawing.Size(161, 24);
            this.cbbNumberOfPoints.TabIndex = 0;
            this.cbbNumberOfPoints.SelectedIndexChanged += new System.EventHandler(this.cbbNumberOfPoints_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PBL4.Properties.Resources.uncheckedRed;
            this.btnExit.Location = new System.Drawing.Point(1248, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = " ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Enabled = false;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Image = global::PBL4.Properties.Resources.reset_24;
            this.btnReset.Location = new System.Drawing.Point(15, 748);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 40);
            this.btnReset.TabIndex = 6;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Enabled = false;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::PBL4.Properties.Resources.checkedGreen;
            this.btnOK.Location = new System.Drawing.Point(1136, 748);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnProcessing
            // 
            this.pnProcessing.AutoScroll = true;
            this.pnProcessing.BackColor = System.Drawing.Color.White;
            this.pnProcessing.Controls.Add(this.lblResetMatrix);
            this.pnProcessing.Controls.Add(this.lblTitle);
            this.pnProcessing.Controls.Add(this.txtbBF);
            this.pnProcessing.Controls.Add(this.btnBF);
            this.pnProcessing.Controls.Add(this.lblNameOfPoint);
            this.pnProcessing.Controls.Add(this.btnReset);
            this.pnProcessing.Controls.Add(this.pnMatrix);
            this.pnProcessing.Controls.Add(this.cbbNumberOfPoints);
            this.pnProcessing.Controls.Add(this.btnExit);
            this.pnProcessing.Controls.Add(this.btnOK);
            this.pnProcessing.Controls.Add(this.btnDrawTheGraph);
            this.pnProcessing.Controls.Add(this.lblSubmitMatrix);
            this.pnProcessing.Controls.Add(this.lblDrawGraph);
            this.pnProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProcessing.Location = new System.Drawing.Point(0, 0);
            this.pnProcessing.Name = "pnProcessing";
            this.pnProcessing.Size = new System.Drawing.Size(1300, 800);
            this.pnProcessing.TabIndex = 3;
            // 
            // lblResetMatrix
            // 
            this.lblResetMatrix.AutoSize = true;
            this.lblResetMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetMatrix.Location = new System.Drawing.Point(21, 721);
            this.lblResetMatrix.Name = "lblResetMatrix";
            this.lblResetMatrix.Size = new System.Drawing.Size(58, 24);
            this.lblResetMatrix.TabIndex = 11;
            this.lblResetMatrix.Text = "Reset";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(393, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(538, 38);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Dijkstra’s Shortest Path Algorithm";
            // 
            // txtbBF
            // 
            this.txtbBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbBF.Location = new System.Drawing.Point(738, 54);
            this.txtbBF.Name = "txtbBF";
            this.txtbBF.ReadOnly = true;
            this.txtbBF.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtbBF.Size = new System.Drawing.Size(361, 27);
            this.txtbBF.TabIndex = 9;
            this.txtbBF.WordWrap = false;
            // 
            // btnBF
            // 
            this.btnBF.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBF.Location = new System.Drawing.Point(1105, 49);
            this.btnBF.Name = "btnBF";
            this.btnBF.Size = new System.Drawing.Size(183, 31);
            this.btnBF.TabIndex = 8;
            this.btnBF.Text = "Browser File";
            this.btnBF.UseVisualStyleBackColor = true;
            this.btnBF.Click += new System.EventHandler(this.btnBF_Click);
            // 
            // btnDrawTheGraph
            // 
            this.btnDrawTheGraph.BackColor = System.Drawing.Color.Linen;
            this.btnDrawTheGraph.FlatAppearance.BorderSize = 0;
            this.btnDrawTheGraph.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDrawTheGraph.Image = global::PBL4.Properties.Resources.neural_24;
            this.btnDrawTheGraph.Location = new System.Drawing.Point(1136, 748);
            this.btnDrawTheGraph.Name = "btnDrawTheGraph";
            this.btnDrawTheGraph.Size = new System.Drawing.Size(75, 40);
            this.btnDrawTheGraph.TabIndex = 10;
            this.btnDrawTheGraph.UseVisualStyleBackColor = false;
            this.btnDrawTheGraph.Click += new System.EventHandler(this.btnDrawTheGraph_Click);
            // 
            // lblSubmitMatrix
            // 
            this.lblSubmitMatrix.AutoSize = true;
            this.lblSubmitMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmitMatrix.Location = new System.Drawing.Point(1143, 712);
            this.lblSubmitMatrix.Name = "lblSubmitMatrix";
            this.lblSubmitMatrix.Size = new System.Drawing.Size(123, 24);
            this.lblSubmitMatrix.TabIndex = 13;
            this.lblSubmitMatrix.Text = "Submit matrix";
            // 
            // lblDrawGraph
            // 
            this.lblDrawGraph.AutoSize = true;
            this.lblDrawGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawGraph.Location = new System.Drawing.Point(1143, 712);
            this.lblDrawGraph.Name = "lblDrawGraph";
            this.lblDrawGraph.Size = new System.Drawing.Size(107, 24);
            this.lblDrawGraph.TabIndex = 12;
            this.lblDrawGraph.Text = "Draw graph";
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
        private System.Windows.Forms.Label lblNameOfPoint;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnConnectToServer;
        private System.Windows.Forms.Button btnBF;
        private System.Windows.Forms.TextBox txtbBF;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDrawTheGraph;
        private System.Windows.Forms.Label lblSubmitMatrix;
        private System.Windows.Forms.Label lblDrawGraph;
        private System.Windows.Forms.Label lblResetMatrix;
    }
}

