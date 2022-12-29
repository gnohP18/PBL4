namespace PBL4.View
{
    partial class Connection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connection));
            this.btnExit = new System.Windows.Forms.Button();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.btnSearchComputerName = new System.Windows.Forms.Button();
            this.btnSearchIPAddress = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConnectToServer = new System.Windows.Forms.Button();
            this.cbbLanguageChange = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PBL4.Properties.Resources.uncheckedRed;
            this.btnExit.Location = new System.Drawing.Point(574, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = " ";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtComputerName
            // 
            this.txtComputerName.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComputerName.Location = new System.Drawing.Point(51, 44);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(303, 29);
            this.txtComputerName.TabIndex = 2;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPAddress.Location = new System.Drawing.Point(51, 101);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(303, 29);
            this.txtIPAddress.TabIndex = 3;
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.BackColor = System.Drawing.Color.Transparent;
            this.lblComputerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerName.Location = new System.Drawing.Point(47, 17);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(152, 25);
            this.lblComputerName.TabIndex = 4;
            this.lblComputerName.Text = "Computer name";
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress.Location = new System.Drawing.Point(47, 74);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(105, 25);
            this.lblIPAddress.TabIndex = 5;
            this.lblIPAddress.Text = "IP address";
            // 
            // btnSearchComputerName
            // 
            this.btnSearchComputerName.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchComputerName.BackgroundImage = global::PBL4.Properties.Resources.search_24;
            this.btnSearchComputerName.FlatAppearance.BorderSize = 0;
            this.btnSearchComputerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchComputerName.Location = new System.Drawing.Point(21, 44);
            this.btnSearchComputerName.Name = "btnSearchComputerName";
            this.btnSearchComputerName.Size = new System.Drawing.Size(24, 24);
            this.btnSearchComputerName.TabIndex = 6;
            this.btnSearchComputerName.UseVisualStyleBackColor = false;
            this.btnSearchComputerName.Click += new System.EventHandler(this.btnSearchComputerName_Click);
            // 
            // btnSearchIPAddress
            // 
            this.btnSearchIPAddress.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchIPAddress.BackgroundImage = global::PBL4.Properties.Resources.search_24;
            this.btnSearchIPAddress.FlatAppearance.BorderSize = 0;
            this.btnSearchIPAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchIPAddress.Location = new System.Drawing.Point(21, 101);
            this.btnSearchIPAddress.Name = "btnSearchIPAddress";
            this.btnSearchIPAddress.Size = new System.Drawing.Size(24, 24);
            this.btnSearchIPAddress.TabIndex = 7;
            this.btnSearchIPAddress.UseVisualStyleBackColor = false;
            this.btnSearchIPAddress.Click += new System.EventHandler(this.btnSearchIPAddress_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.btnConnectToServer);
            this.panel1.Controls.Add(this.txtComputerName);
            this.panel1.Controls.Add(this.btnSearchIPAddress);
            this.panel1.Controls.Add(this.txtIPAddress);
            this.panel1.Controls.Add(this.btnSearchComputerName);
            this.panel1.Controls.Add(this.lblComputerName);
            this.panel1.Controls.Add(this.lblIPAddress);
            this.panel1.Location = new System.Drawing.Point(113, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 208);
            this.panel1.TabIndex = 8;
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.BackColor = System.Drawing.Color.Linen;
            this.btnConnectToServer.FlatAppearance.BorderSize = 0;
            this.btnConnectToServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnectToServer.Image = global::PBL4.Properties.Resources.neural_24;
            this.btnConnectToServer.Location = new System.Drawing.Point(150, 147);
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.Size = new System.Drawing.Size(74, 45);
            this.btnConnectToServer.TabIndex = 9;
            this.btnConnectToServer.UseVisualStyleBackColor = false;
            this.btnConnectToServer.Click += new System.EventHandler(this.btnConnectToServer_Click);
            // 
            // cbbLanguageChange
            // 
            this.cbbLanguageChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLanguageChange.FormattingEnabled = true;
            this.cbbLanguageChange.Location = new System.Drawing.Point(453, 569);
            this.cbbLanguageChange.Name = "cbbLanguageChange";
            this.cbbLanguageChange.Size = new System.Drawing.Size(141, 28);
            this.cbbLanguageChange.TabIndex = 9;
            this.cbbLanguageChange.SelectedIndexChanged += new System.EventHandler(this.cbbLanguageChange_SelectedIndexChanged);
            // 
            // Connection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PBL4.Properties.Resources.Internet_BG;
            this.ClientSize = new System.Drawing.Size(626, 626);
            this.Controls.Add(this.cbbLanguageChange);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.Connection_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Button btnSearchComputerName;
        private System.Windows.Forms.Button btnSearchIPAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnectToServer;
        private System.Windows.Forms.ComboBox cbbLanguageChange;
    }
}