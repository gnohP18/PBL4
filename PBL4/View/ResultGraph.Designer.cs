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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStartPoint = new System.Windows.Forms.Label();
            this.cbbStartPoint = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbShowWeightGraph = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pnResultFromServer
            // 
            this.pnResultFromServer.AutoScroll = true;
            this.pnResultFromServer.BackColor = System.Drawing.Color.LightCyan;
            this.pnResultFromServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnResultFromServer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnResultFromServer.Location = new System.Drawing.Point(849, 0);
            this.pnResultFromServer.Name = "pnResultFromServer";
            this.pnResultFromServer.Size = new System.Drawing.Size(451, 800);
            this.pnResultFromServer.TabIndex = 1;
            // 
            // pnGp
            // 
            this.pnGp.AutoScroll = true;
            this.pnGp.BackColor = System.Drawing.Color.White;
            this.pnGp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnGp.Location = new System.Drawing.Point(0, 43);
            this.pnGp.Name = "pnGp";
            this.pnGp.Size = new System.Drawing.Size(849, 731);
            this.pnGp.TabIndex = 5;
            this.pnGp.Paint += new System.Windows.Forms.PaintEventHandler(this.pnGp_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(148, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(71, 31);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Title";
            // 
            // lblStartPoint
            // 
            this.lblStartPoint.AutoSize = true;
            this.lblStartPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartPoint.Location = new System.Drawing.Point(615, 777);
            this.lblStartPoint.Name = "lblStartPoint";
            this.lblStartPoint.Size = new System.Drawing.Size(75, 18);
            this.lblStartPoint.TabIndex = 4;
            this.lblStartPoint.Text = "Start point";
            // 
            // cbbStartPoint
            // 
            this.cbbStartPoint.FormattingEnabled = true;
            this.cbbStartPoint.Location = new System.Drawing.Point(696, 777);
            this.cbbStartPoint.Name = "cbbStartPoint";
            this.cbbStartPoint.Size = new System.Drawing.Size(150, 21);
            this.cbbStartPoint.TabIndex = 2;
            this.cbbStartPoint.SelectedIndexChanged += new System.EventHandler(this.cbbStartPoint_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PBL4.Properties.Resources.backicon;
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 43);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbShowWeightGraph
            // 
            this.cbShowWeightGraph.AutoSize = true;
            this.cbShowWeightGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cbShowWeightGraph.Location = new System.Drawing.Point(3, 775);
            this.cbShowWeightGraph.Name = "cbShowWeightGraph";
            this.cbShowWeightGraph.Size = new System.Drawing.Size(152, 22);
            this.cbShowWeightGraph.TabIndex = 6;
            this.cbShowWeightGraph.Text = "Show weight graph";
            this.cbShowWeightGraph.UseVisualStyleBackColor = true;
            this.cbShowWeightGraph.CheckedChanged += new System.EventHandler(this.cbShowWeightGraph_CheckedChanged);
            // 
            // ResultGraph
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.pnGp);
            this.Controls.Add(this.cbShowWeightGraph);
            this.Controls.Add(this.pnResultFromServer);
            this.Controls.Add(this.lblStartPoint);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cbbStartPoint);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResultGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResultGraph";
            this.Load += new System.EventHandler(this.ResultGraph_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnResultFromServer;
        private System.Windows.Forms.Panel pnGp;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbbStartPoint;
        private System.Windows.Forms.Label lblStartPoint;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox cbShowWeightGraph;
    }
}