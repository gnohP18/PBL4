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
            this.lblPath = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.endPointName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPath.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(75, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(475, 25);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "path";
            // 
            // lbWeight
            // 
            this.lbWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWeight.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWeight.Location = new System.Drawing.Point(75, 25);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(475, 25);
            this.lbWeight.TabIndex = 2;
            this.lbWeight.Text = "weight";
            // 
            // endPointName
            // 
            this.endPointName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(185)))));
            this.endPointName.Dock = System.Windows.Forms.DockStyle.Left;
            this.endPointName.Enabled = false;
            this.endPointName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.endPointName.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPointName.Location = new System.Drawing.Point(0, 0);
            this.endPointName.Name = "endPointName";
            this.endPointName.Size = new System.Drawing.Size(75, 50);
            this.endPointName.TabIndex = 0;
            this.endPointName.Text = "Name";
            this.endPointName.UseVisualStyleBackColor = false;
            // 
            // ResultUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.lbWeight);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.endPointName);
            this.Name = "ResultUC";
            this.Size = new System.Drawing.Size(550, 50);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.Button endPointName;
    }
}
