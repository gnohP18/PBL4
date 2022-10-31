namespace PBL4_Server
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
            this.rtbShowLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbShowLog
            // 
            this.rtbShowLog.Enabled = false;
            this.rtbShowLog.Location = new System.Drawing.Point(12, 11);
            this.rtbShowLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbShowLog.Name = "rtbShowLog";
            this.rtbShowLog.Size = new System.Drawing.Size(935, 466);
            this.rtbShowLog.TabIndex = 1;
            this.rtbShowLog.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 494);
            this.Controls.Add(this.rtbShowLog);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbShowLog;
    }
}

