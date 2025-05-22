using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Sidera.Utilities.Clock
{
    internal partial class WidgetForm : Form
    {
        private bool _closing;

        private OptionsDialog _optionsDialog;

        private bool _loadComplete;

        public WidgetForm()
        {
            InitializeComponent();

            _closing = false;

            Opacity = 0;
        }

        private void LoadConfig()
        {
            bool success = false;
            int attempts = 10;

        start:
            try
            {
                Hide();

                //

                if (!File.Exists(Common.ConfigFilename))
                {
                    Common.InitDefaultThemes();
                }

                //

                _loadComplete = false;

                if (Common.AppConfig.Theme == null)
                {
                    clockControl.BackColor = Common.AppConfig.BezelColor;
                    clockControl.DisplayBackColor = Common.AppConfig.DisplayBackgroundColor;
                    clockControl.DisplayOnColor = Common.AppConfig.DisplayForegroundColor;
                }
                else
                {
                    ThemeConfig themeConfig = new ThemeConfig(Common.AppConfig.Theme);
                    clockControl.BackColor = themeConfig.BezelColor;
                    clockControl.DisplayBackColor = themeConfig.DisplayBackgroundColor;
                    clockControl.DisplayOnColor = themeConfig.DisplayForegroundColor;

                }

                clockControl.FlashColon = Common.AppConfig.FlashColon;
                clockControl.ShowDate = Common.AppConfig.AutoRotateTimeDate;
                clockControl.Use24HourTimeFormat = Common.AppConfig.Use24HourTimeFormat;
                clockControl.UseDDMMFormat = Common.AppConfig.UseDdMmDateFormat;

                clockControl.MiniClock = Common.AppConfig.MiniClock;

                int screenId = Common.AppConfig.DefaultMonitor;
                int screenIndex = screenId - 1;
                Rectangle screenBounds = screenId == 0
                    ? Screen.GetWorkingArea(this)
                    : Screen.AllScreens[screenIndex].WorkingArea;

                int anchor = (int)Common.AppConfig.AnchorPosition;
                bool isLeft, isTop;
                isLeft = anchor.ToString("00").StartsWith("0");
                isTop = anchor.ToString("00").EndsWith("0");

                int x, y;
                x = isLeft
                    ? Common.AppConfig.WidgetLocation.X + screenBounds.X
                    : screenBounds.Width - Width - (Common.AppConfig.WidgetLocation.X - screenBounds.X);

                y = isTop
                    ? Common.AppConfig.WidgetLocation.Y + screenBounds.Y
                    : screenBounds.Height - Height - (Common.AppConfig.WidgetLocation.Y - screenBounds.Y);

                Left = x;
                Top = y;

                clockControl.PositionLocked = Common.AppConfig.LockPosition;
                TopMost = Common.AppConfig.AlwaysOnTop;

                //

                success = true;
            }
            catch (Exception ex)
            {
                if (!success && attempts > 0)
                {
                    attempts--;
                    goto start;
                }
                else
                {
                    MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Application.Exit();
                }
            }
            finally
            {
                _loadComplete = true;

                //

                Show();
            }
        }

        private void WidgetForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadConfig();
                bgwFade.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void WidgetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _closing = true;

                bool hidden = Opacity == 0;
                e.Cancel = Opacity > 0;

                if (Opacity > 0)
                    bgwFade.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void WidgetForm_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                if (_loadComplete)
                {
                    int screenId = this.GetScreenId();
                    int screenIndex = screenId - 1;
                    Rectangle screenBounds = Screen.AllScreens[screenIndex].WorkingArea;

                    int x, y;
                    x = Left - screenBounds.X;
                    y = Top - screenBounds.Y;

                    switch (Common.AppConfig.AnchorPosition)
                    {
                        case WidgetAnchor.TopRight:
                            x = screenBounds.Width - Width - x;
                            break;
                        case WidgetAnchor.BottomRight:
                            x = screenBounds.Width - Width - x;
                            y = screenBounds.Height - Height - y;
                            break;
                        case WidgetAnchor.BottomLeft:
                            y = screenBounds.Height - Height - y;
                            break;
                    }

                    Common.AppConfig.DefaultMonitor = screenId;
                    Common.AppConfig.WidgetLocation = new Point(x, y);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void bgwFade_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!_closing)
                {
                    Thread.Sleep(1000);

                    for (int i = 0; i <= 100; i += 4)
                    {
                        Thread.Sleep(1);
                        bgwFade.ReportProgress(i);
                    }
                }
                else
                {
                    for (int i = 100; i >= 0; i -= 4)
                    {
                        Thread.Sleep(1);
                        bgwFade.ReportProgress(i);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void bgwFade_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Opacity = e.ProgressPercentage / 100d;

                if (_closing && Opacity == 0)
                    Close();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void clockControl_OptionsClick(object sender, EventArgs e)
        {
            try
            {
                if (_optionsDialog == null)
                {
                    _optionsDialog = new OptionsDialog();
                    _optionsDialog.FormClosed += (o, i) => _optionsDialog = null;
                    _optionsDialog.ApplyClick += (o, i) => LoadConfig();
                    _optionsDialog.Show();
                }
                else
                {
                    _optionsDialog.WindowState = FormWindowState.Normal;
                    _optionsDialog.Activate();
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void clockControl_MouseDrag(object sender, EventArgs e)
        {
            try
            {
                // Do nothing
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void clockControl_MouseDrop(object sender, EventArgs e)
        {
            try
            {
                // Do nothing
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void mnuContext_Options_Click(object sender, EventArgs e)
        {
            try
            {
                clockControl_OptionsClick(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void mnuContext_About_Click(object sender, EventArgs e)
        {
            try
            {
                mnuContext.Enabled = false;

                AboutBox aboutBox = new AboutBox();
                aboutBox.TopMost = TopMost;
                aboutBox.ShowInTaskbar = true;
                aboutBox.ShowDialog();

                mnuContext.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void mnuContext_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void icoTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Activate();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }
    }
}
