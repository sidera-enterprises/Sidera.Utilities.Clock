using System.Windows.Forms;

namespace Sidera.Utilities.Clock
{
    partial class WidgetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WidgetForm));
            this.bgwFade = new System.ComponentModel.BackgroundWorker();
            this.icoTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContecxt_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContecxt_About = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContecxt_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContecxt_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.clockControl = new Sidera.Utilities.Clock.ClockControl();
            this.mnuContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwFade
            // 
            this.bgwFade.WorkerReportsProgress = true;
            this.bgwFade.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFade_DoWork);
            this.bgwFade.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwFade_ProgressChanged);
            // 
            // icoTrayIcon
            // 
            this.icoTrayIcon.ContextMenuStrip = this.mnuContext;
            this.icoTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("icoTrayIcon.Icon")));
            this.icoTrayIcon.Text = "Sidera Clock";
            this.icoTrayIcon.Visible = true;
            this.icoTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.icoTrayIcon_MouseDoubleClick);
            // 
            // mnuContext
            // 
            this.mnuContext.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mnuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContecxt_Options,
            this.mnuContecxt_About,
            this.mnuContecxt_sep1,
            this.mnuContecxt_Exit});
            this.mnuContext.Name = "mnuContecxt";
            this.mnuContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuContext.Size = new System.Drawing.Size(120, 76);
            // 
            // mnuContecxt_Options
            // 
            this.mnuContecxt_Options.Name = "mnuContecxt_Options";
            this.mnuContecxt_Options.Size = new System.Drawing.Size(119, 22);
            this.mnuContecxt_Options.Text = "&Options";
            this.mnuContecxt_Options.Click += new System.EventHandler(this.mnuContext_Options_Click);
            // 
            // mnuContecxt_About
            // 
            this.mnuContecxt_About.Name = "mnuContecxt_About";
            this.mnuContecxt_About.Size = new System.Drawing.Size(119, 22);
            this.mnuContecxt_About.Text = "&About ...";
            this.mnuContecxt_About.Click += new System.EventHandler(this.mnuContext_About_Click);
            // 
            // mnuContecxt_sep1
            // 
            this.mnuContecxt_sep1.Name = "mnuContecxt_sep1";
            this.mnuContecxt_sep1.Size = new System.Drawing.Size(116, 6);
            // 
            // mnuContecxt_Exit
            // 
            this.mnuContecxt_Exit.Name = "mnuContecxt_Exit";
            this.mnuContecxt_Exit.Size = new System.Drawing.Size(119, 22);
            this.mnuContecxt_Exit.Text = "E&xit";
            this.mnuContecxt_Exit.Click += new System.EventHandler(this.mnuContext_Exit_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // clockControl
            // 
            this.clockControl.AutoSize = true;
            this.clockControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clockControl.BackColor = System.Drawing.Color.Silver;
            this.clockControl.ContextMenuStrip = this.mnuContext;
            this.clockControl.DisplayBackColor = System.Drawing.Color.Black;
            this.clockControl.DisplayOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.clockControl.DisplayOnColor = System.Drawing.Color.Red;
            this.clockControl.FlashColon = true;
            this.clockControl.Location = new System.Drawing.Point(0, 0);
            this.clockControl.Margin = new System.Windows.Forms.Padding(0);
            this.clockControl.MiniClock = true;
            this.clockControl.Name = "clockControl";
            this.clockControl.OffColorMatchesOnColor = true;
            this.clockControl.PositionLocked = false;
            this.clockControl.ShowDate = true;
            this.clockControl.Size = new System.Drawing.Size(418, 220);
            this.clockControl.TabIndex = 0;
            this.clockControl.Use24HourTimeFormat = false;
            this.clockControl.UseDDMMFormat = false;
            this.clockControl.OptionsClick += new System.EventHandler(this.clockControl_OptionsClick);
            this.clockControl.MouseDrag += new System.EventHandler(this.clockControl_MouseDrag);
            this.clockControl.MouseDrop += new System.EventHandler(this.clockControl_MouseDrop);
            // 
            // WidgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(418, 220);
            this.Controls.Add(this.clockControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WidgetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sidera Clock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WidgetForm_FormClosing);
            this.Load += new System.EventHandler(this.WidgetForm_Load);
            this.LocationChanged += new System.EventHandler(this.WidgetForm_LocationChanged);
            this.mnuContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwFade;
        private ClockControl clockControl;
        private NotifyIcon icoTrayIcon;
        private ContextMenuStrip mnuContext;
        private ToolStripMenuItem mnuContecxt_Options;
        private ToolStripMenuItem mnuContecxt_About;
        private ToolStripSeparator mnuContecxt_sep1;
        private ToolStripMenuItem mnuContecxt_Exit;
        private Timer timer;
    }
}
