using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Threading;

namespace Sidera.Utilities.Clock
{
    internal partial class ClockControl : UserControl
    {
        private bool _mouseDown;
        private Point _oldPoint;

        private bool _is24Hour, _flashColon, _showDate, _useDDMM, _offColorMatchesOnColor, _positionLocked, _mini;

        public ClockControl()
        {
            InitializeComponent();

            _is24Hour = false;
            _flashColon = true;
            _showDate = true;
            _useDDMM = false;
            _offColorMatchesOnColor = true;
            _positionLocked = false;
            _mini = true;
        }

        public Color DisplayBackColor
        {
            get { return segmentedDisplay.BackColor; }
            set { segmentedDisplay.BackColor = value; }
        }

        public Color DisplayOffColor
        {
            get
            {
                return segmentedDisplay.OffColor;
            }
            set
            {
                segmentedDisplay.OffColor = _offColorMatchesOnColor
                    ? GetOffColor(segmentedDisplay.OnColor)
                    : value;
            }
        }

        public Color DisplayOnColor
        {
            get
            {
                return segmentedDisplay.OnColor;
            }
            set
            {
                segmentedDisplay.OnColor = value;
                if (_offColorMatchesOnColor)
                {
                    segmentedDisplay.OffColor = GetOffColor(value);
                }
            }
        }

        public bool Use24HourTimeFormat
        {
            get { return _is24Hour; }
            set { _is24Hour = value; }
        }

        public bool FlashColon
        {
            get { return _flashColon; }
            set { _flashColon = value; }
        }

        public bool ShowDate
        {
            get { return _showDate; }
            set { _showDate = value; }
        }

        public bool UseDDMMFormat
        {
            get { return _useDDMM; }
            set { _useDDMM = value; }
        }

        public bool OffColorMatchesOnColor
        {
            get
            {
                return _offColorMatchesOnColor;
            }
            set
            {
                _offColorMatchesOnColor = value;
                if (_offColorMatchesOnColor)
                {
                    segmentedDisplay.OffColor = GetOffColor(segmentedDisplay.OnColor);
                }
            }
        }

        public bool PositionLocked
        {
            get { return _positionLocked; }
            set { _positionLocked = value; }
        }

        public bool MiniClock
        {
            get
            {
                return _mini;
            }
            set
            {
                Hide();

                _mini = value;

                Size digitSize = _mini
                    ? new Size(50, 100)
                    : new Size(75, 150);

                int segmentWeight = _mini ? 10 : 16;

                segmentedDisplay.SetSegmentedDigitProperties(segmentWeight, digitSize);

                Invalidate();

                Show();
            }
        }

        private Color GetOffColor(Color color)
        {
            return Color.FromArgb(16, color);
        }

        private void ClockControl_Load(object sender, EventArgs e)
        {
            try
            {
                pnlBadge.Invalidate();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void ClockControl_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Pen penBlack, penLight, penDark;
                penBlack = new Pen(Color.Black, 1);
                penLight = new Pen(Color.FromArgb(128, Color.White), 2);
                penDark = new Pen(Color.FromArgb(128, Color.Black), 2);

                Rectangle rectBezel_Border, rectBezel_Light, rectBezel_Dark;
                rectBezel_Border = new Rectangle(new Point(0, 0),
                    new Size(Width - 1, Height - 1));
                rectBezel_Light = new Rectangle(new Point(rectBezel_Border.X + 1, rectBezel_Border.Y + 1),
                    new Size(rectBezel_Border.Width, rectBezel_Border.Height));
                rectBezel_Dark = new Rectangle(new Point(rectBezel_Light.X - 1, rectBezel_Light.Y - 1),
                    new Size(rectBezel_Light.Width, rectBezel_Light.Height));

                e.Graphics.DrawRectangle(penBlack, rectBezel_Border);
                e.Graphics.DrawRectangle(penLight, rectBezel_Light);
                e.Graphics.DrawRectangle(penDark, rectBezel_Dark);
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void pnlBadge_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (!_positionLocked)
                {
                    _mouseDown = true;
                    _oldPoint = e.Location;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void pnlBadge_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (!_positionLocked)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        pnlBadge.Cursor = Cursors.SizeAll;

                        Form parentForm = FindForm();
                        Screen parentScreen = Screen.FromControl(parentForm);
                        Rectangle screenBounds = parentScreen.WorkingArea;
                        int x, y;
                        //x = Math.Max(screenBounds.Left, Math.Min(screenBounds.Width - parentForm.Width, (ParentForm.Location.X - _oldPoint.X) + e.X));
                        //y = Math.Max(screenBounds.Top, Math.Min(screenBounds.Height - parentForm.Height, (ParentForm.Location.Y - _oldPoint.Y) + e.Y));
                        x = (ParentForm.DesktopLocation.X - _oldPoint.X) + e.X;
                        y = (ParentForm.DesktopLocation.Y - _oldPoint.Y) + e.Y;

                        Point newPoint = new Point(x, y);

                        ParentForm.Location = newPoint;
                        ParentForm.Update();

                        OnMouseDrag();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void pnlBadge_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (!_positionLocked)
                {
                    pnlBadge.Cursor = Cursors.Default;
                    _mouseDown = false;

                    OnMouseDrop();
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void pnlBadge_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Brush bBlack, bWhite;
                bBlack = new SolidBrush(Color.FromArgb(128, Color.Black));
                bWhite = new SolidBrush(Color.FromArgb(128, Color.White));

                Pen pBlack, pWhite;
                pBlack = new Pen(Color.FromArgb(128, Color.Black));
                pWhite = new Pen(Color.FromArgb(128, Color.White));

                for (int i = 0; i < pnlBadge.Width; i += 10)
                {
                    for (int j = 0; j < pnlBadge.Height; j += 10)
                    {
                        int width = 4;

                        Rectangle rBlack, rWhite;
                        rBlack = new Rectangle(i + 3, j + 3, width, width);
                        rWhite = new Rectangle(rBlack.X - 1, rBlack.Y - 1, rBlack.Width, rBlack.Height);

                        //e.Graphics.FillRectangle(bBlack, rBlack);
                        //e.Graphics.FillRectangle(bWhite, rWhite);

                        // Top
                        e.Graphics.DrawLine(pWhite,
                            new Point(i + 1, j),
                            new Point(i + rBlack.Width - 1, j));

                        // Right
                        e.Graphics.DrawLine(pBlack,
                            new Point(i + rBlack.Width, j + 1),
                            new Point(i + rBlack.Width, j + rBlack.Height - 1));

                        // Bottom
                        e.Graphics.DrawLine(pBlack,
                            new Point(i + 1, j + rBlack.Height),
                            new Point(i + rBlack.Width - 1, j + rBlack.Height));

                        // Left
                        e.Graphics.DrawLine(pWhite,
                            new Point(i, j + 1),
                            new Point(i, j + rBlack.Height - 1));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            try
            {
                OnOptionsClick();
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
                DateTime now = DateTime.Now;

                string format, timeFormat, dateFormat;

                timeFormat = _is24Hour
                    ? "H:mm"
                    : "h:mm";

                timeFormat = _flashColon
                    ? timeFormat.Replace(":", now.Millisecond < 500 ? ":" : " ")
                    : timeFormat;

                dateFormat = _useDDMM
                    ? (now.Month < 10 ? "d- M" : "d-MM")
                    : (now.Day < 10 ? "M- d" : "M-dd");

                if (_showDate)
                {
                    format = now.Second % 4 < 2
                        ? timeFormat
                        : dateFormat;
                }
                else
                {
                    format = timeFormat;
                }

                segmentedDisplay.Text = now.ToString(format);
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        public event EventHandler OptionsClick;
        private void OnOptionsClick()
        {
            var handler = OptionsClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler MouseDrag;
        private void OnMouseDrag()
        {
            var handler = MouseDrag;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler MouseDrop;
        private void OnMouseDrop()
        {
            var handler = MouseDrop;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
