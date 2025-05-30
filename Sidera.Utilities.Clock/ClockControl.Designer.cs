﻿namespace Sidera.Utilities.Clock
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
            this.pnlBadge = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.segmentedDisplay = new Sidera.Utilities.Clock.SegmentedDisplay();
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
            this.tpnlLayout.Location = new System.Drawing.Point(12, 12);
            this.tpnlLayout.Margin = new System.Windows.Forms.Padding(12);
            this.tpnlLayout.Name = "tpnlLayout";
            this.tpnlLayout.RowCount = 2;
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlLayout.Size = new System.Drawing.Size(394, 196);
            this.tpnlLayout.TabIndex = 1;
            // 
            // pnlBadge
            // 
            this.pnlBadge.Location = new System.Drawing.Point(122, 163);
            this.pnlBadge.Name = "pnlBadge";
            this.pnlBadge.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBadge.Size = new System.Drawing.Size(150, 30);
            this.pnlBadge.TabIndex = 2;
            this.pnlBadge.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBadge_Paint);
            this.pnlBadge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBadge_MouseDown);
            this.pnlBadge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBadge_MouseMove);
            this.pnlBadge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlBadge_MouseUp);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.segmentedDisplay.Size = new System.Drawing.Size(394, 148);
            this.segmentedDisplay.TabIndex = 0;
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
            this.Size = new System.Drawing.Size(418, 220);
            this.Load += new System.EventHandler(this.ClockControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClockControl_Paint);
            this.tpnlLayout.ResumeLayout(false);
            this.tpnlLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpnlLayout;
        private SegmentedDisplay segmentedDisplay;
        private System.Windows.Forms.Panel pnlBadge;
        private System.Windows.Forms.Timer timer;
    }
}
