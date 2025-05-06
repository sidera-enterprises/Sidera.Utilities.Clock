namespace Sidera.Utilities.Clock
{
    partial class OptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.tcpnlTabs = new System.Windows.Forms.TabControl();
            this.tabAppearance = new System.Windows.Forms.TabPage();
            this.tpnlAppearance = new System.Windows.Forms.TableLayoutPanel();
            this.grpAppearance_Theme = new System.Windows.Forms.GroupBox();
            this.tpnlAppearance_Theme = new System.Windows.Forms.TableLayoutPanel();
            this.lblAppearance_Theme_Name = new System.Windows.Forms.Label();
            this.cbxAppearance_Theme_Name = new System.Windows.Forms.ComboBox();
            this.btnAppearance_Theme_Save = new System.Windows.Forms.Button();
            this.btnAppearance_Theme_Delete = new System.Windows.Forms.Button();
            this.grpAppearance_Advanced = new System.Windows.Forms.GroupBox();
            this.tpnlAppearance_Advanced = new System.Windows.Forms.TableLayoutPanel();
            this.lblAppearance_Advanced_BezelColor = new System.Windows.Forms.Label();
            this.lblAppearance_Advanced_DisplayBackColor = new System.Windows.Forms.Label();
            this.lblAppearance_Advanced_DisplayForeColor = new System.Windows.Forms.Label();
            this.btnAppearance_Advanced_BezelColor = new System.Windows.Forms.Button();
            this.btnAppearance_Advanced_DisplayBackColor = new System.Windows.Forms.Button();
            this.btnAppearance_Advanced_DisplayForeColor = new System.Windows.Forms.Button();
            this.tabBehavior = new System.Windows.Forms.TabPage();
            this.tpnlBehavior = new System.Windows.Forms.TableLayoutPanel();
            this.grpBehavior_Display = new System.Windows.Forms.GroupBox();
            this.chkBehavior_Display_FlashColon = new System.Windows.Forms.CheckBox();
            this.chkBehavior_Display_ShowDate = new System.Windows.Forms.CheckBox();
            this.chkBehavior_Display_24HourFormat = new System.Windows.Forms.CheckBox();
            this.chkBehavior_Display_DDMMFormat = new System.Windows.Forms.CheckBox();
            this.grpBehavior_Anchoring = new System.Windows.Forms.GroupBox();
            this.tpnlBehavior_Anchoring = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnBehavior_Anchoring_NW = new System.Windows.Forms.RadioButton();
            this.rbtnBehavior_Anchoring_NE = new System.Windows.Forms.RadioButton();
            this.rbtnBehavior_Anchoring_SW = new System.Windows.Forms.RadioButton();
            this.rbtnBehavior_Anchoring_SE = new System.Windows.Forms.RadioButton();
            this.cbxBehavior_Anchoring_Monitor = new System.Windows.Forms.ComboBox();
            this.chkBehavior_Anchoring_Lock = new System.Windows.Forms.CheckBox();
            this.chkBehavior_Anchoring_AlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.tpnlHelp = new System.Windows.Forms.TableLayoutPanel();
            this.btnHelp_Docs = new System.Windows.Forms.Button();
            this.btnHelp_About = new System.Windows.Forms.Button();
            this.pnlAppearance_Sample = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tpnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.clkApperance_Sample = new Sidera.Utilities.Clock.ClockControl();
            this.tcpnlTabs.SuspendLayout();
            this.tabAppearance.SuspendLayout();
            this.tpnlAppearance.SuspendLayout();
            this.grpAppearance_Theme.SuspendLayout();
            this.tpnlAppearance_Theme.SuspendLayout();
            this.grpAppearance_Advanced.SuspendLayout();
            this.tpnlAppearance_Advanced.SuspendLayout();
            this.tabBehavior.SuspendLayout();
            this.tpnlBehavior.SuspendLayout();
            this.grpBehavior_Display.SuspendLayout();
            this.grpBehavior_Anchoring.SuspendLayout();
            this.tpnlBehavior_Anchoring.SuspendLayout();
            this.tabHelp.SuspendLayout();
            this.tpnlHelp.SuspendLayout();
            this.pnlAppearance_Sample.SuspendLayout();
            this.tpnlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcpnlTabs
            // 
            this.tcpnlTabs.Controls.Add(this.tabAppearance);
            this.tcpnlTabs.Controls.Add(this.tabBehavior);
            this.tcpnlTabs.Controls.Add(this.tabHelp);
            this.tcpnlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpnlTabs.Location = new System.Drawing.Point(3, 503);
            this.tcpnlTabs.Name = "tcpnlTabs";
            this.tcpnlTabs.SelectedIndex = 0;
            this.tcpnlTabs.Size = new System.Drawing.Size(773, 211);
            this.tcpnlTabs.TabIndex = 0;
            // 
            // tabAppearance
            // 
            this.tabAppearance.Controls.Add(this.tpnlAppearance);
            this.tabAppearance.Location = new System.Drawing.Point(4, 22);
            this.tabAppearance.Name = "tabAppearance";
            this.tabAppearance.Size = new System.Drawing.Size(765, 185);
            this.tabAppearance.TabIndex = 0;
            this.tabAppearance.Text = "Appearance";
            this.tabAppearance.UseVisualStyleBackColor = true;
            // 
            // tpnlAppearance
            // 
            this.tpnlAppearance.ColumnCount = 2;
            this.tpnlAppearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlAppearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tpnlAppearance.Controls.Add(this.grpAppearance_Theme, 0, 0);
            this.tpnlAppearance.Controls.Add(this.grpAppearance_Advanced, 1, 0);
            this.tpnlAppearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlAppearance.Location = new System.Drawing.Point(0, 0);
            this.tpnlAppearance.Name = "tpnlAppearance";
            this.tpnlAppearance.RowCount = 1;
            this.tpnlAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlAppearance.Size = new System.Drawing.Size(765, 185);
            this.tpnlAppearance.TabIndex = 0;
            // 
            // grpAppearance_Theme
            // 
            this.grpAppearance_Theme.Controls.Add(this.tpnlAppearance_Theme);
            this.grpAppearance_Theme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAppearance_Theme.Location = new System.Drawing.Point(3, 3);
            this.grpAppearance_Theme.Name = "grpAppearance_Theme";
            this.grpAppearance_Theme.Size = new System.Drawing.Size(519, 179);
            this.grpAppearance_Theme.TabIndex = 0;
            this.grpAppearance_Theme.TabStop = false;
            this.grpAppearance_Theme.Text = "Theme";
            // 
            // tpnlAppearance_Theme
            // 
            this.tpnlAppearance_Theme.ColumnCount = 4;
            this.tpnlAppearance_Theme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpnlAppearance_Theme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpnlAppearance_Theme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpnlAppearance_Theme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlAppearance_Theme.Controls.Add(this.lblAppearance_Theme_Name, 0, 0);
            this.tpnlAppearance_Theme.Controls.Add(this.cbxAppearance_Theme_Name, 1, 0);
            this.tpnlAppearance_Theme.Controls.Add(this.btnAppearance_Theme_Save, 1, 1);
            this.tpnlAppearance_Theme.Controls.Add(this.btnAppearance_Theme_Delete, 2, 1);
            this.tpnlAppearance_Theme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlAppearance_Theme.Location = new System.Drawing.Point(3, 16);
            this.tpnlAppearance_Theme.Name = "tpnlAppearance_Theme";
            this.tpnlAppearance_Theme.RowCount = 3;
            this.tpnlAppearance_Theme.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlAppearance_Theme.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlAppearance_Theme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlAppearance_Theme.Size = new System.Drawing.Size(513, 160);
            this.tpnlAppearance_Theme.TabIndex = 0;
            // 
            // lblAppearance_Theme_Name
            // 
            this.lblAppearance_Theme_Name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAppearance_Theme_Name.AutoSize = true;
            this.lblAppearance_Theme_Name.Location = new System.Drawing.Point(3, 7);
            this.lblAppearance_Theme_Name.Name = "lblAppearance_Theme_Name";
            this.lblAppearance_Theme_Name.Size = new System.Drawing.Size(35, 13);
            this.lblAppearance_Theme_Name.TabIndex = 0;
            this.lblAppearance_Theme_Name.Text = "Name";
            // 
            // cbxAppearance_Theme_Name
            // 
            this.tpnlAppearance_Theme.SetColumnSpan(this.cbxAppearance_Theme_Name, 3);
            this.cbxAppearance_Theme_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAppearance_Theme_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAppearance_Theme_Name.FormattingEnabled = true;
            this.cbxAppearance_Theme_Name.Items.AddRange(new object[] {
            "(Custom)"});
            this.cbxAppearance_Theme_Name.Location = new System.Drawing.Point(44, 3);
            this.cbxAppearance_Theme_Name.Name = "cbxAppearance_Theme_Name";
            this.cbxAppearance_Theme_Name.Size = new System.Drawing.Size(466, 21);
            this.cbxAppearance_Theme_Name.TabIndex = 1;
            this.cbxAppearance_Theme_Name.SelectedIndexChanged += new System.EventHandler(this.cbxAppearance_Theme_Name_SelectedIndexChanged);
            // 
            // btnAppearance_Theme_Save
            // 
            this.btnAppearance_Theme_Save.Location = new System.Drawing.Point(44, 30);
            this.btnAppearance_Theme_Save.Name = "btnAppearance_Theme_Save";
            this.btnAppearance_Theme_Save.Size = new System.Drawing.Size(75, 23);
            this.btnAppearance_Theme_Save.TabIndex = 2;
            this.btnAppearance_Theme_Save.Text = "&Save";
            this.btnAppearance_Theme_Save.UseVisualStyleBackColor = true;
            this.btnAppearance_Theme_Save.Click += new System.EventHandler(this.btnAppearance_Theme_Save_Click);
            // 
            // btnAppearance_Theme_Delete
            // 
            this.btnAppearance_Theme_Delete.Enabled = false;
            this.btnAppearance_Theme_Delete.Location = new System.Drawing.Point(125, 30);
            this.btnAppearance_Theme_Delete.Name = "btnAppearance_Theme_Delete";
            this.btnAppearance_Theme_Delete.Size = new System.Drawing.Size(75, 23);
            this.btnAppearance_Theme_Delete.TabIndex = 3;
            this.btnAppearance_Theme_Delete.Text = "&Delete";
            this.btnAppearance_Theme_Delete.UseVisualStyleBackColor = true;
            this.btnAppearance_Theme_Delete.Click += new System.EventHandler(this.btnAppearance_Theme_Delete_Click);
            // 
            // grpAppearance_Advanced
            // 
            this.grpAppearance_Advanced.Controls.Add(this.tpnlAppearance_Advanced);
            this.grpAppearance_Advanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAppearance_Advanced.Location = new System.Drawing.Point(528, 3);
            this.grpAppearance_Advanced.Name = "grpAppearance_Advanced";
            this.grpAppearance_Advanced.Size = new System.Drawing.Size(234, 179);
            this.grpAppearance_Advanced.TabIndex = 1;
            this.grpAppearance_Advanced.TabStop = false;
            this.grpAppearance_Advanced.Text = "Advanced";
            // 
            // tpnlAppearance_Advanced
            // 
            this.tpnlAppearance_Advanced.ColumnCount = 2;
            this.tpnlAppearance_Advanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpnlAppearance_Advanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlAppearance_Advanced.Controls.Add(this.lblAppearance_Advanced_BezelColor, 0, 0);
            this.tpnlAppearance_Advanced.Controls.Add(this.lblAppearance_Advanced_DisplayBackColor, 0, 1);
            this.tpnlAppearance_Advanced.Controls.Add(this.lblAppearance_Advanced_DisplayForeColor, 0, 2);
            this.tpnlAppearance_Advanced.Controls.Add(this.btnAppearance_Advanced_BezelColor, 1, 0);
            this.tpnlAppearance_Advanced.Controls.Add(this.btnAppearance_Advanced_DisplayBackColor, 1, 1);
            this.tpnlAppearance_Advanced.Controls.Add(this.btnAppearance_Advanced_DisplayForeColor, 1, 2);
            this.tpnlAppearance_Advanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlAppearance_Advanced.Location = new System.Drawing.Point(3, 16);
            this.tpnlAppearance_Advanced.Name = "tpnlAppearance_Advanced";
            this.tpnlAppearance_Advanced.RowCount = 4;
            this.tpnlAppearance_Advanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlAppearance_Advanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlAppearance_Advanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlAppearance_Advanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlAppearance_Advanced.Size = new System.Drawing.Size(228, 160);
            this.tpnlAppearance_Advanced.TabIndex = 0;
            // 
            // lblAppearance_Advanced_BezelColor
            // 
            this.lblAppearance_Advanced_BezelColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAppearance_Advanced_BezelColor.AutoSize = true;
            this.lblAppearance_Advanced_BezelColor.Location = new System.Drawing.Point(71, 8);
            this.lblAppearance_Advanced_BezelColor.Name = "lblAppearance_Advanced_BezelColor";
            this.lblAppearance_Advanced_BezelColor.Size = new System.Drawing.Size(59, 13);
            this.lblAppearance_Advanced_BezelColor.TabIndex = 0;
            this.lblAppearance_Advanced_BezelColor.Text = "Bezel color";
            // 
            // lblAppearance_Advanced_DisplayBackColor
            // 
            this.lblAppearance_Advanced_DisplayBackColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAppearance_Advanced_DisplayBackColor.AutoSize = true;
            this.lblAppearance_Advanced_DisplayBackColor.Location = new System.Drawing.Point(3, 37);
            this.lblAppearance_Advanced_DisplayBackColor.Name = "lblAppearance_Advanced_DisplayBackColor";
            this.lblAppearance_Advanced_DisplayBackColor.Size = new System.Drawing.Size(127, 13);
            this.lblAppearance_Advanced_DisplayBackColor.TabIndex = 2;
            this.lblAppearance_Advanced_DisplayBackColor.Text = "Display background color";
            // 
            // lblAppearance_Advanced_DisplayForeColor
            // 
            this.lblAppearance_Advanced_DisplayForeColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAppearance_Advanced_DisplayForeColor.AutoSize = true;
            this.lblAppearance_Advanced_DisplayForeColor.Location = new System.Drawing.Point(9, 66);
            this.lblAppearance_Advanced_DisplayForeColor.Name = "lblAppearance_Advanced_DisplayForeColor";
            this.lblAppearance_Advanced_DisplayForeColor.Size = new System.Drawing.Size(121, 13);
            this.lblAppearance_Advanced_DisplayForeColor.TabIndex = 4;
            this.lblAppearance_Advanced_DisplayForeColor.Text = "Display foreground color";
            // 
            // btnAppearance_Advanced_BezelColor
            // 
            this.btnAppearance_Advanced_BezelColor.BackColor = System.Drawing.Color.Silver;
            this.btnAppearance_Advanced_BezelColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAppearance_Advanced_BezelColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAppearance_Advanced_BezelColor.Location = new System.Drawing.Point(136, 3);
            this.btnAppearance_Advanced_BezelColor.Name = "btnAppearance_Advanced_BezelColor";
            this.btnAppearance_Advanced_BezelColor.Size = new System.Drawing.Size(89, 23);
            this.btnAppearance_Advanced_BezelColor.TabIndex = 1;
            this.btnAppearance_Advanced_BezelColor.UseVisualStyleBackColor = false;
            this.btnAppearance_Advanced_BezelColor.Click += new System.EventHandler(this.btnApperance_Advanced_ElementColor_Click);
            // 
            // btnAppearance_Advanced_DisplayBackColor
            // 
            this.btnAppearance_Advanced_DisplayBackColor.BackColor = System.Drawing.Color.Black;
            this.btnAppearance_Advanced_DisplayBackColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAppearance_Advanced_DisplayBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAppearance_Advanced_DisplayBackColor.Location = new System.Drawing.Point(136, 32);
            this.btnAppearance_Advanced_DisplayBackColor.Name = "btnAppearance_Advanced_DisplayBackColor";
            this.btnAppearance_Advanced_DisplayBackColor.Size = new System.Drawing.Size(89, 23);
            this.btnAppearance_Advanced_DisplayBackColor.TabIndex = 3;
            this.btnAppearance_Advanced_DisplayBackColor.UseVisualStyleBackColor = false;
            this.btnAppearance_Advanced_DisplayBackColor.Click += new System.EventHandler(this.btnApperance_Advanced_ElementColor_Click);
            // 
            // btnAppearance_Advanced_DisplayForeColor
            // 
            this.btnAppearance_Advanced_DisplayForeColor.BackColor = System.Drawing.Color.Red;
            this.btnAppearance_Advanced_DisplayForeColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAppearance_Advanced_DisplayForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAppearance_Advanced_DisplayForeColor.Location = new System.Drawing.Point(136, 61);
            this.btnAppearance_Advanced_DisplayForeColor.Name = "btnAppearance_Advanced_DisplayForeColor";
            this.btnAppearance_Advanced_DisplayForeColor.Size = new System.Drawing.Size(89, 23);
            this.btnAppearance_Advanced_DisplayForeColor.TabIndex = 5;
            this.btnAppearance_Advanced_DisplayForeColor.UseVisualStyleBackColor = false;
            this.btnAppearance_Advanced_DisplayForeColor.Click += new System.EventHandler(this.btnApperance_Advanced_ElementColor_Click);
            // 
            // tabBehavior
            // 
            this.tabBehavior.Controls.Add(this.tpnlBehavior);
            this.tabBehavior.Location = new System.Drawing.Point(4, 22);
            this.tabBehavior.Name = "tabBehavior";
            this.tabBehavior.Size = new System.Drawing.Size(765, 185);
            this.tabBehavior.TabIndex = 3;
            this.tabBehavior.Text = "Behavior";
            this.tabBehavior.UseVisualStyleBackColor = true;
            // 
            // tpnlBehavior
            // 
            this.tpnlBehavior.ColumnCount = 2;
            this.tpnlBehavior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlBehavior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tpnlBehavior.Controls.Add(this.grpBehavior_Display, 0, 0);
            this.tpnlBehavior.Controls.Add(this.grpBehavior_Anchoring, 1, 0);
            this.tpnlBehavior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlBehavior.Location = new System.Drawing.Point(0, 0);
            this.tpnlBehavior.Name = "tpnlBehavior";
            this.tpnlBehavior.RowCount = 1;
            this.tpnlBehavior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlBehavior.Size = new System.Drawing.Size(765, 185);
            this.tpnlBehavior.TabIndex = 1;
            // 
            // grpBehavior_Display
            // 
            this.grpBehavior_Display.Controls.Add(this.chkBehavior_Display_FlashColon);
            this.grpBehavior_Display.Controls.Add(this.chkBehavior_Display_ShowDate);
            this.grpBehavior_Display.Controls.Add(this.chkBehavior_Display_24HourFormat);
            this.grpBehavior_Display.Controls.Add(this.chkBehavior_Display_DDMMFormat);
            this.grpBehavior_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBehavior_Display.Location = new System.Drawing.Point(3, 3);
            this.grpBehavior_Display.Name = "grpBehavior_Display";
            this.grpBehavior_Display.Size = new System.Drawing.Size(559, 179);
            this.grpBehavior_Display.TabIndex = 0;
            this.grpBehavior_Display.TabStop = false;
            this.grpBehavior_Display.Text = "Display options";
            // 
            // chkBehavior_Display_FlashColon
            // 
            this.chkBehavior_Display_FlashColon.AutoSize = true;
            this.chkBehavior_Display_FlashColon.Checked = true;
            this.chkBehavior_Display_FlashColon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBehavior_Display_FlashColon.Location = new System.Drawing.Point(6, 19);
            this.chkBehavior_Display_FlashColon.Name = "chkBehavior_Display_FlashColon";
            this.chkBehavior_Display_FlashColon.Size = new System.Drawing.Size(127, 17);
            this.chkBehavior_Display_FlashColon.TabIndex = 0;
            this.chkBehavior_Display_FlashColon.Text = "Enable flashing colon";
            this.chkBehavior_Display_FlashColon.UseVisualStyleBackColor = true;
            this.chkBehavior_Display_FlashColon.CheckedChanged += new System.EventHandler(this.chkBehavior_Display_Options_CheckedChanged);
            // 
            // chkBehavior_Display_ShowDate
            // 
            this.chkBehavior_Display_ShowDate.AutoSize = true;
            this.chkBehavior_Display_ShowDate.Checked = true;
            this.chkBehavior_Display_ShowDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBehavior_Display_ShowDate.Location = new System.Drawing.Point(6, 42);
            this.chkBehavior_Display_ShowDate.Name = "chkBehavior_Display_ShowDate";
            this.chkBehavior_Display_ShowDate.Size = new System.Drawing.Size(126, 17);
            this.chkBehavior_Display_ShowDate.TabIndex = 1;
            this.chkBehavior_Display_ShowDate.Text = "Auto-rotate time/date";
            this.chkBehavior_Display_ShowDate.UseVisualStyleBackColor = true;
            this.chkBehavior_Display_ShowDate.CheckedChanged += new System.EventHandler(this.chkBehavior_Display_Options_CheckedChanged);
            // 
            // chkBehavior_Display_24HourFormat
            // 
            this.chkBehavior_Display_24HourFormat.AutoSize = true;
            this.chkBehavior_Display_24HourFormat.Location = new System.Drawing.Point(6, 65);
            this.chkBehavior_Display_24HourFormat.Name = "chkBehavior_Display_24HourFormat";
            this.chkBehavior_Display_24HourFormat.Size = new System.Drawing.Size(138, 17);
            this.chkBehavior_Display_24HourFormat.TabIndex = 2;
            this.chkBehavior_Display_24HourFormat.Text = "Use 24-hour time format";
            this.chkBehavior_Display_24HourFormat.UseVisualStyleBackColor = true;
            this.chkBehavior_Display_24HourFormat.CheckedChanged += new System.EventHandler(this.chkBehavior_Display_Options_CheckedChanged);
            // 
            // chkBehavior_Display_DDMMFormat
            // 
            this.chkBehavior_Display_DDMMFormat.AutoSize = true;
            this.chkBehavior_Display_DDMMFormat.Location = new System.Drawing.Point(6, 88);
            this.chkBehavior_Display_DDMMFormat.Name = "chkBehavior_Display_DDMMFormat";
            this.chkBehavior_Display_DDMMFormat.Size = new System.Drawing.Size(151, 17);
            this.chkBehavior_Display_DDMMFormat.TabIndex = 3;
            this.chkBehavior_Display_DDMMFormat.Text = "Use \"DD-MM\" date format";
            this.chkBehavior_Display_DDMMFormat.UseVisualStyleBackColor = true;
            this.chkBehavior_Display_DDMMFormat.CheckedChanged += new System.EventHandler(this.chkBehavior_Display_Options_CheckedChanged);
            // 
            // grpBehavior_Anchoring
            // 
            this.grpBehavior_Anchoring.Controls.Add(this.tpnlBehavior_Anchoring);
            this.grpBehavior_Anchoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBehavior_Anchoring.Location = new System.Drawing.Point(568, 3);
            this.grpBehavior_Anchoring.Name = "grpBehavior_Anchoring";
            this.grpBehavior_Anchoring.Size = new System.Drawing.Size(194, 179);
            this.grpBehavior_Anchoring.TabIndex = 1;
            this.grpBehavior_Anchoring.TabStop = false;
            this.grpBehavior_Anchoring.Text = "Anchoring && positioning";
            // 
            // tpnlBehavior_Anchoring
            // 
            this.tpnlBehavior_Anchoring.ColumnCount = 2;
            this.tpnlBehavior_Anchoring.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlBehavior_Anchoring.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlBehavior_Anchoring.Controls.Add(this.rbtnBehavior_Anchoring_NW, 0, 0);
            this.tpnlBehavior_Anchoring.Controls.Add(this.rbtnBehavior_Anchoring_NE, 1, 0);
            this.tpnlBehavior_Anchoring.Controls.Add(this.rbtnBehavior_Anchoring_SW, 0, 1);
            this.tpnlBehavior_Anchoring.Controls.Add(this.rbtnBehavior_Anchoring_SE, 1, 1);
            this.tpnlBehavior_Anchoring.Controls.Add(this.cbxBehavior_Anchoring_Monitor, 0, 2);
            this.tpnlBehavior_Anchoring.Controls.Add(this.chkBehavior_Anchoring_Lock, 0, 3);
            this.tpnlBehavior_Anchoring.Controls.Add(this.chkBehavior_Anchoring_AlwaysOnTop, 0, 5);
            this.tpnlBehavior_Anchoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlBehavior_Anchoring.Location = new System.Drawing.Point(3, 16);
            this.tpnlBehavior_Anchoring.Name = "tpnlBehavior_Anchoring";
            this.tpnlBehavior_Anchoring.RowCount = 6;
            this.tpnlBehavior_Anchoring.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlBehavior_Anchoring.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlBehavior_Anchoring.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlBehavior_Anchoring.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlBehavior_Anchoring.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlBehavior_Anchoring.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlBehavior_Anchoring.Size = new System.Drawing.Size(188, 160);
            this.tpnlBehavior_Anchoring.TabIndex = 0;
            // 
            // rbtnBehavior_Anchoring_NW
            // 
            this.rbtnBehavior_Anchoring_NW.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBehavior_Anchoring_NW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtnBehavior_Anchoring_NW.Location = new System.Drawing.Point(3, 3);
            this.rbtnBehavior_Anchoring_NW.Name = "rbtnBehavior_Anchoring_NW";
            this.rbtnBehavior_Anchoring_NW.Size = new System.Drawing.Size(88, 37);
            this.rbtnBehavior_Anchoring_NW.TabIndex = 0;
            this.rbtnBehavior_Anchoring_NW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBehavior_Anchoring_NW.UseVisualStyleBackColor = true;
            // 
            // rbtnBehavior_Anchoring_NE
            // 
            this.rbtnBehavior_Anchoring_NE.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBehavior_Anchoring_NE.Checked = true;
            this.rbtnBehavior_Anchoring_NE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtnBehavior_Anchoring_NE.Location = new System.Drawing.Point(97, 3);
            this.rbtnBehavior_Anchoring_NE.Name = "rbtnBehavior_Anchoring_NE";
            this.rbtnBehavior_Anchoring_NE.Size = new System.Drawing.Size(88, 37);
            this.rbtnBehavior_Anchoring_NE.TabIndex = 1;
            this.rbtnBehavior_Anchoring_NE.TabStop = true;
            this.rbtnBehavior_Anchoring_NE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBehavior_Anchoring_NE.UseVisualStyleBackColor = true;
            // 
            // rbtnBehavior_Anchoring_SW
            // 
            this.rbtnBehavior_Anchoring_SW.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBehavior_Anchoring_SW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtnBehavior_Anchoring_SW.Location = new System.Drawing.Point(3, 46);
            this.rbtnBehavior_Anchoring_SW.Name = "rbtnBehavior_Anchoring_SW";
            this.rbtnBehavior_Anchoring_SW.Size = new System.Drawing.Size(88, 37);
            this.rbtnBehavior_Anchoring_SW.TabIndex = 2;
            this.rbtnBehavior_Anchoring_SW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBehavior_Anchoring_SW.UseVisualStyleBackColor = true;
            // 
            // rbtnBehavior_Anchoring_SE
            // 
            this.rbtnBehavior_Anchoring_SE.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBehavior_Anchoring_SE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtnBehavior_Anchoring_SE.Location = new System.Drawing.Point(97, 46);
            this.rbtnBehavior_Anchoring_SE.Name = "rbtnBehavior_Anchoring_SE";
            this.rbtnBehavior_Anchoring_SE.Size = new System.Drawing.Size(88, 37);
            this.rbtnBehavior_Anchoring_SE.TabIndex = 3;
            this.rbtnBehavior_Anchoring_SE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBehavior_Anchoring_SE.UseVisualStyleBackColor = true;
            // 
            // cbxBehavior_Anchoring_Monitor
            // 
            this.tpnlBehavior_Anchoring.SetColumnSpan(this.cbxBehavior_Anchoring_Monitor, 2);
            this.cbxBehavior_Anchoring_Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxBehavior_Anchoring_Monitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBehavior_Anchoring_Monitor.FormattingEnabled = true;
            this.cbxBehavior_Anchoring_Monitor.Items.AddRange(new object[] {
            "(Default Monitor)"});
            this.cbxBehavior_Anchoring_Monitor.Location = new System.Drawing.Point(3, 89);
            this.cbxBehavior_Anchoring_Monitor.Name = "cbxBehavior_Anchoring_Monitor";
            this.cbxBehavior_Anchoring_Monitor.Size = new System.Drawing.Size(182, 21);
            this.cbxBehavior_Anchoring_Monitor.TabIndex = 4;
            // 
            // chkBehavior_Anchoring_Lock
            // 
            this.chkBehavior_Anchoring_Lock.AutoSize = true;
            this.tpnlBehavior_Anchoring.SetColumnSpan(this.chkBehavior_Anchoring_Lock, 2);
            this.chkBehavior_Anchoring_Lock.Location = new System.Drawing.Point(3, 116);
            this.chkBehavior_Anchoring_Lock.Name = "chkBehavior_Anchoring_Lock";
            this.chkBehavior_Anchoring_Lock.Size = new System.Drawing.Size(139, 17);
            this.chkBehavior_Anchoring_Lock.TabIndex = 5;
            this.chkBehavior_Anchoring_Lock.Text = "Lock position on screen";
            this.chkBehavior_Anchoring_Lock.UseVisualStyleBackColor = true;
            this.chkBehavior_Anchoring_Lock.CheckedChanged += new System.EventHandler(this.chkBehavior_Display_Options_CheckedChanged);
            // 
            // chkBehavior_Anchoring_AlwaysOnTop
            // 
            this.chkBehavior_Anchoring_AlwaysOnTop.AutoSize = true;
            this.tpnlBehavior_Anchoring.SetColumnSpan(this.chkBehavior_Anchoring_AlwaysOnTop, 2);
            this.chkBehavior_Anchoring_AlwaysOnTop.Location = new System.Drawing.Point(3, 139);
            this.chkBehavior_Anchoring_AlwaysOnTop.Name = "chkBehavior_Anchoring_AlwaysOnTop";
            this.chkBehavior_Anchoring_AlwaysOnTop.Size = new System.Drawing.Size(92, 17);
            this.chkBehavior_Anchoring_AlwaysOnTop.TabIndex = 5;
            this.chkBehavior_Anchoring_AlwaysOnTop.Text = "Always on top";
            this.chkBehavior_Anchoring_AlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkBehavior_Anchoring_AlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkBehavior_Display_Options_CheckedChanged);
            // 
            // tabHelp
            // 
            this.tabHelp.Controls.Add(this.tpnlHelp);
            this.tabHelp.Location = new System.Drawing.Point(4, 22);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Padding = new System.Windows.Forms.Padding(12);
            this.tabHelp.Size = new System.Drawing.Size(765, 185);
            this.tabHelp.TabIndex = 4;
            this.tabHelp.Text = "Help";
            this.tabHelp.UseVisualStyleBackColor = true;
            // 
            // tpnlHelp
            // 
            this.tpnlHelp.ColumnCount = 3;
            this.tpnlHelp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tpnlHelp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tpnlHelp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpnlHelp.Controls.Add(this.btnHelp_Docs, 0, 0);
            this.tpnlHelp.Controls.Add(this.btnHelp_About, 1, 0);
            this.tpnlHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlHelp.Location = new System.Drawing.Point(12, 12);
            this.tpnlHelp.Name = "tpnlHelp";
            this.tpnlHelp.RowCount = 1;
            this.tpnlHelp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlHelp.Size = new System.Drawing.Size(741, 161);
            this.tpnlHelp.TabIndex = 0;
            // 
            // btnHelp_Docs
            // 
            this.btnHelp_Docs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelp_Docs.Image = global::Sidera.Utilities.Clock.Properties.Resources.LifePreserver32;
            this.btnHelp_Docs.Location = new System.Drawing.Point(12, 12);
            this.btnHelp_Docs.Margin = new System.Windows.Forms.Padding(12);
            this.btnHelp_Docs.Name = "btnHelp_Docs";
            this.btnHelp_Docs.Size = new System.Drawing.Size(176, 137);
            this.btnHelp_Docs.TabIndex = 0;
            this.btnHelp_Docs.Text = "Help Documentation";
            this.btnHelp_Docs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHelp_Docs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHelp_Docs.UseVisualStyleBackColor = true;
            this.btnHelp_Docs.Click += new System.EventHandler(this.btnHelp_Docs_Click);
            // 
            // btnHelp_About
            // 
            this.btnHelp_About.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelp_About.Image = global::Sidera.Utilities.Clock.Properties.Resources.Info32;
            this.btnHelp_About.Location = new System.Drawing.Point(212, 12);
            this.btnHelp_About.Margin = new System.Windows.Forms.Padding(12);
            this.btnHelp_About.Name = "btnHelp_About";
            this.btnHelp_About.Size = new System.Drawing.Size(176, 137);
            this.btnHelp_About.TabIndex = 1;
            this.btnHelp_About.Text = "About Sidera Clock";
            this.btnHelp_About.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHelp_About.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHelp_About.UseVisualStyleBackColor = true;
            this.btnHelp_About.Click += new System.EventHandler(this.btnHelp_About_Click);
            // 
            // pnlAppearance_Sample
            // 
            this.pnlAppearance_Sample.BackColor = System.Drawing.Color.Teal;
            this.pnlAppearance_Sample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAppearance_Sample.Controls.Add(this.clkApperance_Sample);
            this.pnlAppearance_Sample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAppearance_Sample.Location = new System.Drawing.Point(3, 3);
            this.pnlAppearance_Sample.Name = "pnlAppearance_Sample";
            this.pnlAppearance_Sample.Size = new System.Drawing.Size(773, 494);
            this.pnlAppearance_Sample.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(535, 726);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(616, 726);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(697, 726);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tpnlLayout
            // 
            this.tpnlLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpnlLayout.ColumnCount = 1;
            this.tpnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlLayout.Controls.Add(this.pnlAppearance_Sample, 0, 0);
            this.tpnlLayout.Controls.Add(this.tcpnlTabs, 0, 1);
            this.tpnlLayout.Location = new System.Drawing.Point(3, 3);
            this.tpnlLayout.Name = "tpnlLayout";
            this.tpnlLayout.RowCount = 2;
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlLayout.Size = new System.Drawing.Size(779, 717);
            this.tpnlLayout.TabIndex = 4;
            // 
            // clkApperance_Sample
            // 
            this.clkApperance_Sample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clkApperance_Sample.AutoSize = true;
            this.clkApperance_Sample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clkApperance_Sample.BackColor = System.Drawing.Color.Silver;
            this.clkApperance_Sample.DisplayBackColor = System.Drawing.Color.Black;
            this.clkApperance_Sample.DisplayOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.clkApperance_Sample.DisplayOnColor = System.Drawing.Color.Red;
            this.clkApperance_Sample.FlashColon = true;
            this.clkApperance_Sample.Location = new System.Drawing.Point(112, 113);
            this.clkApperance_Sample.Name = "clkApperance_Sample";
            this.clkApperance_Sample.OffColorMatchesOnColor = true;
            this.clkApperance_Sample.PositionLocked = true;
            this.clkApperance_Sample.ShowDate = true;
            this.clkApperance_Sample.Size = new System.Drawing.Size(544, 265);
            this.clkApperance_Sample.TabIndex = 0;
            this.clkApperance_Sample.Use24HourTimeFormat = false;
            this.clkApperance_Sample.UseDDMMFormat = false;
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.tpnlLayout);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sidera Clock Options";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.tcpnlTabs.ResumeLayout(false);
            this.tabAppearance.ResumeLayout(false);
            this.tpnlAppearance.ResumeLayout(false);
            this.grpAppearance_Theme.ResumeLayout(false);
            this.tpnlAppearance_Theme.ResumeLayout(false);
            this.tpnlAppearance_Theme.PerformLayout();
            this.grpAppearance_Advanced.ResumeLayout(false);
            this.tpnlAppearance_Advanced.ResumeLayout(false);
            this.tpnlAppearance_Advanced.PerformLayout();
            this.tabBehavior.ResumeLayout(false);
            this.tpnlBehavior.ResumeLayout(false);
            this.grpBehavior_Display.ResumeLayout(false);
            this.grpBehavior_Display.PerformLayout();
            this.grpBehavior_Anchoring.ResumeLayout(false);
            this.tpnlBehavior_Anchoring.ResumeLayout(false);
            this.tpnlBehavior_Anchoring.PerformLayout();
            this.tabHelp.ResumeLayout(false);
            this.tpnlHelp.ResumeLayout(false);
            this.pnlAppearance_Sample.ResumeLayout(false);
            this.pnlAppearance_Sample.PerformLayout();
            this.tpnlLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcpnlTabs;
        private System.Windows.Forms.TabPage tabAppearance;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel pnlAppearance_Sample;
        private ClockControl clkApperance_Sample;
        private System.Windows.Forms.TableLayoutPanel tpnlAppearance_Advanced;
        private System.Windows.Forms.Label lblAppearance_Advanced_BezelColor;
        private System.Windows.Forms.Label lblAppearance_Advanced_DisplayBackColor;
        private System.Windows.Forms.Label lblAppearance_Advanced_DisplayForeColor;
        private System.Windows.Forms.Button btnAppearance_Advanced_BezelColor;
        private System.Windows.Forms.Button btnAppearance_Advanced_DisplayBackColor;
        private System.Windows.Forms.Button btnAppearance_Advanced_DisplayForeColor;
        private System.Windows.Forms.TabPage tabBehavior;
        private System.Windows.Forms.TableLayoutPanel tpnlBehavior;
        private System.Windows.Forms.GroupBox grpBehavior_Display;
        private System.Windows.Forms.CheckBox chkBehavior_Display_FlashColon;
        private System.Windows.Forms.CheckBox chkBehavior_Display_ShowDate;
        private System.Windows.Forms.CheckBox chkBehavior_Display_24HourFormat;
        private System.Windows.Forms.CheckBox chkBehavior_Display_DDMMFormat;
        private System.Windows.Forms.GroupBox grpBehavior_Anchoring;
        private System.Windows.Forms.TableLayoutPanel tpnlBehavior_Anchoring;
        private System.Windows.Forms.RadioButton rbtnBehavior_Anchoring_NW;
        private System.Windows.Forms.RadioButton rbtnBehavior_Anchoring_NE;
        private System.Windows.Forms.RadioButton rbtnBehavior_Anchoring_SW;
        private System.Windows.Forms.RadioButton rbtnBehavior_Anchoring_SE;
        private System.Windows.Forms.ComboBox cbxBehavior_Anchoring_Monitor;
        private System.Windows.Forms.CheckBox chkBehavior_Anchoring_Lock;
        private System.Windows.Forms.TableLayoutPanel tpnlLayout;
        private System.Windows.Forms.TableLayoutPanel tpnlAppearance;
        private System.Windows.Forms.GroupBox grpAppearance_Theme;
        private System.Windows.Forms.TableLayoutPanel tpnlAppearance_Theme;
        private System.Windows.Forms.GroupBox grpAppearance_Advanced;
        private System.Windows.Forms.Label lblAppearance_Theme_Name;
        private System.Windows.Forms.ComboBox cbxAppearance_Theme_Name;
        private System.Windows.Forms.Button btnAppearance_Theme_Save;
        private System.Windows.Forms.Button btnAppearance_Theme_Delete;
        private System.Windows.Forms.CheckBox chkBehavior_Anchoring_AlwaysOnTop;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.TableLayoutPanel tpnlHelp;
        private System.Windows.Forms.Button btnHelp_Docs;
        private System.Windows.Forms.Button btnHelp_About;
    }
}