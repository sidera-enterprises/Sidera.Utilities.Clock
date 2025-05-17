namespace Sidera.Utilities.Clock
{
    partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.tpnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBadge = new System.Windows.Forms.Panel();
            this.picBadgeLogo = new System.Windows.Forms.PictureBox();
            this.tcpnlAbout = new System.Windows.Forms.TabControl();
            this.tabCredits = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tpnlCredits = new System.Windows.Forms.TableLayoutPanel();
            this.picAppIcon = new System.Windows.Forms.PictureBox();
            this.lblCredits = new System.Windows.Forms.Label();
            this.tabLicense = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tpnlLayout.SuspendLayout();
            this.pnlBadge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBadgeLogo)).BeginInit();
            this.tcpnlAbout.SuspendLayout();
            this.tabCredits.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpnlCredits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).BeginInit();
            this.tabLicense.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpnlLayout
            // 
            this.tpnlLayout.ColumnCount = 1;
            this.tpnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlLayout.Controls.Add(this.pnlBadge, 0, 0);
            this.tpnlLayout.Controls.Add(this.tcpnlAbout, 0, 1);
            this.tpnlLayout.Controls.Add(this.btnOK, 0, 2);
            this.tpnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlLayout.Location = new System.Drawing.Point(0, 0);
            this.tpnlLayout.Name = "tpnlLayout";
            this.tpnlLayout.RowCount = 3;
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tpnlLayout.Size = new System.Drawing.Size(464, 361);
            this.tpnlLayout.TabIndex = 1;
            // 
            // pnlBadge
            // 
            this.pnlBadge.BackColor = System.Drawing.Color.Black;
            this.pnlBadge.Controls.Add(this.picBadgeLogo);
            this.pnlBadge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBadge.Location = new System.Drawing.Point(0, 0);
            this.pnlBadge.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBadge.Name = "pnlBadge";
            this.pnlBadge.Size = new System.Drawing.Size(464, 80);
            this.pnlBadge.TabIndex = 0;
            // 
            // picBadgeLogo
            // 
            this.picBadgeLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBadgeLogo.BackgroundImage = global::Sidera.Utilities.Clock.Properties.Resources.BadgeLogo;
            this.picBadgeLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBadgeLogo.Location = new System.Drawing.Point(88, 8);
            this.picBadgeLogo.Name = "picBadgeLogo";
            this.picBadgeLogo.Size = new System.Drawing.Size(288, 64);
            this.picBadgeLogo.TabIndex = 0;
            this.picBadgeLogo.TabStop = false;
            // 
            // tcpnlAbout
            // 
            this.tcpnlAbout.Controls.Add(this.tabCredits);
            this.tcpnlAbout.Controls.Add(this.tabLicense);
            this.tcpnlAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpnlAbout.Location = new System.Drawing.Point(3, 83);
            this.tcpnlAbout.Name = "tcpnlAbout";
            this.tcpnlAbout.SelectedIndex = 0;
            this.tcpnlAbout.Size = new System.Drawing.Size(458, 227);
            this.tcpnlAbout.TabIndex = 1;
            // 
            // tabCredits
            // 
            this.tabCredits.Controls.Add(this.groupBox1);
            this.tabCredits.Location = new System.Drawing.Point(4, 22);
            this.tabCredits.Name = "tabCredits";
            this.tabCredits.Padding = new System.Windows.Forms.Padding(3);
            this.tabCredits.Size = new System.Drawing.Size(450, 201);
            this.tabCredits.TabIndex = 0;
            this.tabCredits.Text = "Credits";
            this.tabCredits.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tpnlCredits);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Software information";
            // 
            // tpnlCredits
            // 
            this.tpnlCredits.ColumnCount = 2;
            this.tpnlCredits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpnlCredits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlCredits.Controls.Add(this.picAppIcon, 0, 0);
            this.tpnlCredits.Controls.Add(this.lblCredits, 1, 0);
            this.tpnlCredits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlCredits.Location = new System.Drawing.Point(3, 16);
            this.tpnlCredits.Name = "tpnlCredits";
            this.tpnlCredits.RowCount = 1;
            this.tpnlCredits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlCredits.Size = new System.Drawing.Size(438, 176);
            this.tpnlCredits.TabIndex = 0;
            // 
            // picAppIcon
            // 
            this.picAppIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picAppIcon.Location = new System.Drawing.Point(3, 3);
            this.picAppIcon.Name = "picAppIcon";
            this.picAppIcon.Size = new System.Drawing.Size(48, 48);
            this.picAppIcon.TabIndex = 0;
            this.picAppIcon.TabStop = false;
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Location = new System.Drawing.Point(57, 3);
            this.lblCredits.Margin = new System.Windows.Forms.Padding(3);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(340, 130);
            this.lblCredits.TabIndex = 1;
            this.lblCredits.Text = "{PRODUCTNAME}\r\nVersion {VERSION}\r\n{COPYRIGHT}\r\n\r\n{DESCRIPTION}\r\n\r\n\r\n\r\nThis softwa" +
    "re is licensed under the terms of the MIT License. For more information, click t" +
    "he License tab.";
            // 
            // tabLicense
            // 
            this.tabLicense.Controls.Add(this.groupBox2);
            this.tabLicense.Location = new System.Drawing.Point(4, 22);
            this.tabLicense.Name = "tabLicense";
            this.tabLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tabLicense.Size = new System.Drawing.Size(450, 201);
            this.tabLicense.TabIndex = 1;
            this.tabLicense.Text = "License";
            this.tabLicense.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLicense);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 195);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MIT License";
            // 
            // txtLicense
            // 
            this.txtLicense.BackColor = System.Drawing.SystemColors.Window;
            this.txtLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLicense.Location = new System.Drawing.Point(3, 16);
            this.txtLicense.Multiline = true;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ReadOnly = true;
            this.txtLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLicense.Size = new System.Drawing.Size(438, 176);
            this.txtLicense.TabIndex = 0;
            this.txtLicense.Text = resources.GetString("txtLicense.Text");
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(194, 325);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.tpnlLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.tpnlLayout.ResumeLayout(false);
            this.pnlBadge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBadgeLogo)).EndInit();
            this.tcpnlAbout.ResumeLayout(false);
            this.tabCredits.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tpnlCredits.ResumeLayout(false);
            this.tpnlCredits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).EndInit();
            this.tabLicense.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpnlLayout;
        private System.Windows.Forms.Panel pnlBadge;
        private System.Windows.Forms.PictureBox picBadgeLogo;
        private System.Windows.Forms.TabControl tcpnlAbout;
        private System.Windows.Forms.TabPage tabCredits;
        private System.Windows.Forms.TabPage tabLicense;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.TableLayoutPanel tpnlCredits;
        private System.Windows.Forms.PictureBox picAppIcon;
        private System.Windows.Forms.Label lblCredits;
    }
}