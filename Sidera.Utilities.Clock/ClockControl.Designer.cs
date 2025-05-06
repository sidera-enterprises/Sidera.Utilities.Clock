namespace Sidera.Utilities.Clock
{
    partial class ClockControl
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
            this.components = new System.ComponentModel.Container();
            this.tpnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.segmentedDisplay = new Sidera.Utilities.Clock.SegmentedDisplay();
            this.pnlBadge = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tpnlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpnlLayout
            // 
            this.tpnlLayout.AutoSize = true;
            this.tpnlLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tpnlLayout.ColumnCount = 5;
            this.tpnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tpnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tpnlLayout.Controls.Add(this.segmentedDisplay, 0, 0);
            this.tpnlLayout.Controls.Add(this.pnlBadge, 2, 1);
            this.tpnlLayout.Controls.Add(this.btnOptions, 4, 1);
            this.tpnlLayout.Location = new System.Drawing.Point(12, 12);
            this.tpnlLayout.Margin = new System.Windows.Forms.Padding(12);
            this.tpnlLayout.Name = "tpnlLayout";
            this.tpnlLayout.RowCount = 2;
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlLayout.Size = new System.Drawing.Size(520, 241);
            this.tpnlLayout.TabIndex = 1;
            // 
            // segmentedDisplay
            // 
            this.segmentedDisplay.AutoSize = true;
            this.segmentedDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.segmentedDisplay.BackColor = System.Drawing.Color.Black;
            this.tpnlLayout.SetColumnSpan(this.segmentedDisplay, 5);
            this.segmentedDisplay.Length = 5;
            this.segmentedDisplay.Location = new System.Drawing.Point(0, 0);
            this.segmentedDisplay.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.segmentedDisplay.Name = "segmentedDisplay";
            this.segmentedDisplay.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.segmentedDisplay.OnColor = System.Drawing.Color.Red;
            this.segmentedDisplay.Size = new System.Drawing.Size(519, 193);
            this.segmentedDisplay.TabIndex = 0;
            // 
            // pnlBadge
            // 
            this.pnlBadge.Location = new System.Drawing.Point(185, 208);
            this.pnlBadge.Name = "pnlBadge";
            this.pnlBadge.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBadge.Size = new System.Drawing.Size(150, 30);
            this.pnlBadge.TabIndex = 2;
            this.pnlBadge.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBadge_Paint);
            this.pnlBadge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBadge_MouseDown);
            this.pnlBadge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBadge_MouseMove);
            this.pnlBadge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlBadge_MouseUp);
            // 
            // btnOptions
            // 
            this.btnOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Image = global::Sidera.Utilities.Clock.Properties.Resources.Gear16;
            this.btnOptions.Location = new System.Drawing.Point(484, 205);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(0);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(36, 36);
            this.btnOptions.TabIndex = 3;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ClockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tpnlLayout);
            this.Name = "ClockControl";
            this.Size = new System.Drawing.Size(544, 265);
            this.Load += new System.EventHandler(this.ClockControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WidgetForm_Paint);
            this.tpnlLayout.ResumeLayout(false);
            this.tpnlLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpnlLayout;
        private SegmentedDisplay segmentedDisplay;
        private System.Windows.Forms.Panel pnlBadge;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Timer timer;
    }
}
