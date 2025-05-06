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
            this.clockControl = new Sidera.Utilities.Clock.ClockControl();
            this.icoTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTrayIcon_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrayIcon_About = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrayIcon_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrayIcon_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwFade
            // 
            this.bgwFade.WorkerReportsProgress = true;
            this.bgwFade.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFade_DoWork);
            this.bgwFade.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwFade_ProgressChanged);
            // 
            // clockControl
            // 
            this.clockControl.AutoSize = true;
            this.clockControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clockControl.BackColor = System.Drawing.Color.Silver;
            this.clockControl.DisplayBackColor = System.Drawing.Color.Black;
            this.clockControl.DisplayOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.clockControl.DisplayOnColor = System.Drawing.Color.Red;
            this.clockControl.FlashColon = true;
            this.clockControl.Location = new System.Drawing.Point(0, 0);
            this.clockControl.Margin = new System.Windows.Forms.Padding(0);
            this.clockControl.Name = "clockControl";
            this.clockControl.OffColorMatchesOnColor = true;
            this.clockControl.PositionLocked = false;
            this.clockControl.ShowDate = true;
            this.clockControl.Size = new System.Drawing.Size(544, 265);
            this.clockControl.TabIndex = 0;
            this.clockControl.Use24HourTimeFormat = false;
            this.clockControl.UseDDMMFormat = false;
            this.clockControl.OptionsClick += new System.EventHandler(this.clockControl_OptionsClick);
            this.clockControl.MouseDrag += new System.EventHandler(this.clockControl_MouseDrag);
            this.clockControl.MouseDrop += new System.EventHandler(this.clockControl_MouseDrop);
            // 
            // icoTrayIcon
            // 
            this.icoTrayIcon.ContextMenuStrip = this.mnuTrayIcon;
            this.icoTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("icoTrayIcon.Icon")));
            this.icoTrayIcon.Text = "Sidera Clock";
            this.icoTrayIcon.Visible = true;
            this.icoTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.icoTrayIcon_MouseDoubleClick);
            // 
            // mnuTrayIcon
            // 
            this.mnuTrayIcon.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mnuTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrayIcon_Options,
            this.mnuTrayIcon_About,
            this.mnuTrayIcon_sep1,
            this.mnuTrayIcon_Exit});
            this.mnuTrayIcon.Name = "mnuTrayIcon";
            this.mnuTrayIcon.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuTrayIcon.Size = new System.Drawing.Size(120, 76);
            // 
            // mnuTrayIcon_Options
            // 
            this.mnuTrayIcon_Options.Name = "mnuTrayIcon_Options";
            this.mnuTrayIcon_Options.Size = new System.Drawing.Size(119, 22);
            this.mnuTrayIcon_Options.Text = "&Options";
            this.mnuTrayIcon_Options.Click += new System.EventHandler(this.mnuTrayIcon_Options_Click);
            // 
            // mnuTrayIcon_About
            // 
            this.mnuTrayIcon_About.Name = "mnuTrayIcon_About";
            this.mnuTrayIcon_About.Size = new System.Drawing.Size(119, 22);
            this.mnuTrayIcon_About.Text = "&About ...";
            this.mnuTrayIcon_About.Click += new System.EventHandler(this.mnuTrayIcon_About_Click);
            // 
            // mnuTrayIcon_sep1
            // 
            this.mnuTrayIcon_sep1.Name = "mnuTrayIcon_sep1";
            this.mnuTrayIcon_sep1.Size = new System.Drawing.Size(116, 6);
            // 
            // mnuTrayIcon_Exit
            // 
            this.mnuTrayIcon_Exit.Name = "mnuTrayIcon_Exit";
            this.mnuTrayIcon_Exit.Size = new System.Drawing.Size(119, 22);
            this.mnuTrayIcon_Exit.Text = "E&xit";
            this.mnuTrayIcon_Exit.Click += new System.EventHandler(this.mnuTrayIcon_Exit_Click);
            // 
            // WidgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(544, 265);
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
            this.mnuTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwFade;
        private ClockControl clockControl;
        private NotifyIcon icoTrayIcon;
        private ContextMenuStrip mnuTrayIcon;
        private ToolStripMenuItem mnuTrayIcon_Options;
        private ToolStripMenuItem mnuTrayIcon_About;
        private ToolStripSeparator mnuTrayIcon_sep1;
        private ToolStripMenuItem mnuTrayIcon_Exit;
    }
}
