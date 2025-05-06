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

namespace Sidera.Utilities.Clock
{
    public partial class WidgetForm: Form
    {
        private bool _closing;
        private Point _oldPoint;

        private OptionsDialog _optionsDialog;

        private bool _loadComplete, _windowDragging;

        public WidgetForm()
        {
            InitializeComponent();

            _closing = false;

            Opacity = 0;
        }

        private void LoadConfig()
        {
            try
            {
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
                //Rectangle screenBounds = Screen.GetWorkingArea(this);
                //int x, y;
                //switch (Common.AppConfig.AnchorPosition)
                //{
                //    case WidgetAnchor.TopLeft:
                //        x = Common.AppConfig.WidgetLocation.X;
                //        y = Common.AppConfig.WidgetLocation.Y;
                //        break;
                //    case WidgetAnchor.TopRight:
                //        x = screenBounds.Width - Width - Common.AppConfig.WidgetLocation.X;
                //        y = Common.AppConfig.WidgetLocation.Y;
                //        break;
                //    case WidgetAnchor.BottomRight:
                //        x = screenBounds.Width - Width - Common.AppConfig.WidgetLocation.X;
                //        y = screenBounds.Height - Height - Common.AppConfig.WidgetLocation.Y;
                //        break;
                //    case WidgetAnchor.BottomLeft:
                //        x = Common.AppConfig.WidgetLocation.X;
                //        y = screenBounds.Height - Height - Common.AppConfig.WidgetLocation.Y;
                //        break;
                //    default:
                //        x = y = 0;
                //        break;
                //}

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

                //switch (Common.AppConfig.AnchorPosition)
                //{
                //    case WidgetAnchor.TopLeft:
                //        x = Common.AppConfig.WidgetLocation.X + screenBounds.X;
                //        y = Common.AppConfig.WidgetLocation.Y + screenBounds.Y;
                //        break;
                //    case WidgetAnchor.TopRight:
                //        x = screenBounds.Width - Width - (Common.AppConfig.WidgetLocation.X + screenBounds.X);
                //        y = Common.AppConfig.WidgetLocation.Y + screenBounds.Y;
                //        break;
                //    case WidgetAnchor.BottomRight:
                //        x = screenBounds.Width - Width - (Common.AppConfig.WidgetLocation.X + screenBounds.X);
                //        y = screenBounds.Height - Height - (Common.AppConfig.WidgetLocation.Y + screenBounds.Y);
                //        break;
                //    case WidgetAnchor.BottomLeft:
                //        x = Common.AppConfig.WidgetLocation.X + screenBounds.X;
                //        y = screenBounds.Height - Height - (Common.AppConfig.WidgetLocation.Y + screenBounds.Y);
                //        break;
                //    default:
                //        x = y = 0;
                //        break;
                //}

                //Left = Math.Max(0, Math.Min(screenBounds.Width - Width, x));
                //Top = Math.Max(0, Math.Min(screenBounds.Height - Height, y));

                Left = x;
                Top = y;

                //Common.SetScreenLocation(this, Common.AppConfig.DefaultMonitor, x, y);
                //this.SetScreenId(Common.AppConfig.DefaultMonitor);
                clockControl.PositionLocked = Common.AppConfig.LockPosition;
                TopMost = Common.AppConfig.AlwaysOnTop;
            }
            catch (Exception ex)
            {
                Application.Restart();
                //LoadConfig();
            }
            finally
            {
                _loadComplete = true;
            }
        }

        private void WidgetForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
            bgwFade.RunWorkerAsync();
        }

        private void WidgetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;

            bool hidden = Opacity == 0;
            e.Cancel = Opacity > 0;
            
            if (Opacity > 0)
                bgwFade.RunWorkerAsync();
        }

        private void WidgetForm_LocationChanged(object sender, EventArgs e)
        {
            if (_loadComplete)
            {
                int screenId = this.GetScreenId();
                int screenIndex = screenId - 1;
                Rectangle screenBounds = Screen.AllScreens[screenIndex].WorkingArea;

                int x, y;
                x = Left - screenBounds.X;
                y = Top - screenBounds.Y;

                //WidgetAnchor anchor = Common.AppConfig.AnchorPosition;
                //string anchorName = anchor.ToString();
                //if (anchorName.ToUpper().StartsWith("RIGHT"))
                //    x = (screenBounds.Width) - Width - x;

                //if (anchorName.ToUpper().StartsWith("BOTTOM"))
                //    y = (screenBounds.Height) - Height - y;

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

                //clockControl.Cursor = Cursors.Default;

                //int screenId = this.GetScreenId();
                //int screenIndex = screenId - 1;
                //Rectangle screenBounds = Screen.AllScreens[screenIndex].WorkingArea;

                //int x, y;
                //switch (Common.AppConfig.AnchorPosition)
                //{
                //    case WidgetAnchor.TopLeft:
                //        x = Left;
                //        y = Top;
                //        break;
                //    case WidgetAnchor.TopRight:
                //        x = screenBounds.Width - Width - Left;
                //        y = Top;
                //        break;
                //    case WidgetAnchor.BottomRight:
                //        x = screenBounds.Width - Width - Left;
                //        y = screenBounds.Height - Height - Left;
                //        break;
                //    case WidgetAnchor.BottomLeft:
                //        x = Left;
                //        y = screenBounds.Height - Height - Left;
                //        break;
                //    default:
                //        x = y = 0;
                //        break;
                //}

                //x -= screenBounds.X;
                //y += screenBounds.Y;

                //Common.AppConfig.DefaultMonitor = screenId;
                //Common.AppConfig.WidgetLocation = new Point(x, y);
            }
        }

        private void bgwFade_DoWork(object sender, DoWorkEventArgs e)
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

        private void bgwFade_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Opacity = e.ProgressPercentage / 100d;

            if (_closing && Opacity == 0)
                Close();
        }

        private void clockControl_OptionsClick(object sender, EventArgs e)
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
            //DialogResult dr = optionsDialog.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    optionsDialog.SaveConfig();
            //    LoadConfig();
            //}
        }

        private void clockControl_MouseDrag(object sender, EventArgs e)
        {
            _windowDragging = true;
        }

        private void mnuTrayIcon_Options_Click(object sender, EventArgs e)
        {
            clockControl_OptionsClick(null, EventArgs.Empty);
        }

        private void mnuTrayIcon_About_Click(object sender, EventArgs e)
        {
            mnuTrayIcon.Enabled = false;

            AboutBox aboutBox = new AboutBox();
            aboutBox.TopMost = TopMost;
            aboutBox.ShowInTaskbar = true;
            aboutBox.ShowDialog();

            mnuTrayIcon.Enabled = true;
        }

        private void mnuTrayIcon_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void icoTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Activate();
        }

        private void clockControl_MouseDrop(object sender, EventArgs e)
        {
            _windowDragging = false;
        }
    }
}
