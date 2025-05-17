using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidera.Utilities.Clock
{
    internal class AppConfig
    {
        private XmlConfig _xconfig;

        public AppConfig()
        {
            FileInfo fiConfig = new FileInfo(Common.ConfigFilename);
            fiConfig.Directory.Create();

            //

            _xconfig = new XmlConfig(Common.ConfigFilename, "configuration")
            {
                AutoSave = true,
            };

            _xconfig.InitializeDocument();

            //

            if (!File.Exists(_xconfig.Filename))
            {
                _xconfig.Save();
            }
        }

        #region Appearance
        public string Theme
        {
            get { return _xconfig.GetAttribute("/persona", "name"); }
            set
            {
                _xconfig.SetAttribute("/persona", "name", value);
                if (value != null)
                {
                    _xconfig.DeleteNode("/persona/colors");
                }
            }
        }

        public Color BezelColor
        {
            get { return ColorTranslator.FromHtml(_xconfig.GetAttribute("/persona/colors", "bezel") ?? "#C0C0C0"); }
            set { _xconfig.SetAttribute("/persona/colors", "bezel", ColorTranslator.ToHtml(value)); }
        }

        public Color DisplayBackgroundColor
        {
            get { return ColorTranslator.FromHtml(_xconfig.GetAttribute("/persona/colors", "background") ?? "#000000"); }
            set { _xconfig.SetAttribute("/persona/colors", "background", ColorTranslator.ToHtml(value)); }
        }

        public Color DisplayForegroundColor
        {
            get { return ColorTranslator.FromHtml(_xconfig.GetAttribute("/persona/colors", "foreground") ?? "#FF0000"); }
            set { _xconfig.SetAttribute("/persona/colors", "foreground", ColorTranslator.ToHtml(value)); }
        }
        #endregion

        #region Behavior
        public bool FlashColon
        {
            get { return bool.Parse(_xconfig.GetAttribute("/behavior/display", "flash-colon") ?? true.ToString()); }
            set { _xconfig.SetAttribute("/behavior/display", "flash-colon", value.ToString()); }
        }

        public bool AutoRotateTimeDate
        {
            get { return bool.Parse(_xconfig.GetAttribute("/behavior/display", "auto-rotate") ?? true.ToString()); }
            set { _xconfig.SetAttribute("/behavior/display", "auto-rotate", value.ToString()); }
        }

        public bool Use24HourTimeFormat
        {
            get { return bool.Parse(_xconfig.GetAttribute("/behavior/format", "time-24hr") ?? false.ToString()); }
            set { _xconfig.SetAttribute("/behavior/format", "time-24hr", value.ToString()); }
        }

        public bool UseDdMmDateFormat
        {
            get { return bool.Parse(_xconfig.GetAttribute("/behavior/format", "date-ddmm") ?? false.ToString()); }
            set { _xconfig.SetAttribute("/behavior/format", "date-ddmm", value.ToString()); }
        }

        public bool AutoStart
        {
            get
            {
                string appName, lnkName, lnkFullPath;
                appName = Path.GetFileNameWithoutExtension(new FileInfo(Common.ExeFilename).Name);
                lnkName = $"{appName}.lnk";
                lnkFullPath = Path.Combine(Common.UserShellStartupDirectory, lnkName);

                return File.Exists(lnkFullPath);
            }
            set
            {
                bool autoStart = value;

                string appName, lnkName, lnkFullPath;
                appName = Path.GetFileNameWithoutExtension(new FileInfo(Common.ExeFilename).Name);
                lnkName = $"{appName}.lnk";

                if (autoStart)
                {
                    Common.CreateShortcut(Common.UserShellStartupDirectory);
                }
                else
                {
                    Common.DeleteShortcut(Common.UserShellStartupDirectory);
                }
            }
        }

        public WidgetAnchor AnchorPosition
        {
            get
            {
                string value = _xconfig.GetAttribute("/behavior/position", "anchor") ?? "TopRight";
                WidgetAnchor anchor;
                bool canParse = Enum.TryParse(value, true, out anchor);
                if (!canParse)
                {
                    anchor = WidgetAnchor.TopRight;
                }

                return anchor;
            }
            set
            {
                WidgetAnchor temp = AnchorPosition;

                _xconfig.SetAttribute("/behavior/position", "anchor", value.ToString());

                //

                if (value != temp)
                {
                    WidgetLocation = new Point(10, 10);
                }
            }
        }

        public Point WidgetLocation
        {
            get
            {
                string value = _xconfig.GetAttribute("/behavior/position", "coordinates") ?? "10,10";
                string[] coords = value.Split(',');
                int x, y;
                if (coords.Length == 2)
                {
                    x = int.Parse(coords[0]);
                    y = int.Parse(coords[1]);
                }
                else
                {
                    x = 10;
                    y = 10;
                }

                Point point = new Point(x, y);
                return point;
            }
            set
            {
                _xconfig.SetAttribute("/behavior/position", "coordinates", string.Join(",", value.X, value.Y));
            }
        }

        public int DefaultMonitor
        {
            get
            {
                int screenCount = Screen.AllScreens.Length;

                int screenIndex = int.Parse(_xconfig.GetAttribute("/behavior/position", "screen") ?? "0") - 1;
                screenIndex = Math.Max(-1, screenIndex % screenCount);

                int screenId = screenIndex + 1;
                return screenId;
            }
            set
            {
                if (value == 0)
                {
                    _xconfig.DeleteAttribute("/behavior/position", "screen");
                }
                else
                {
                    _xconfig.SetAttribute("/behavior/position", "screen", value.ToString());
                }
            }
        }

        public bool LockPosition
        {
            get { return bool.Parse(_xconfig.GetAttribute("/behavior/position", "locked") ?? false.ToString()); }
            set { _xconfig.SetAttribute("/behavior/position", "locked", value.ToString()); }
        }

        public bool AlwaysOnTop
        {
            get { return bool.Parse(_xconfig.GetAttribute("/behavior/position", "always-on-top") ?? false.ToString()); }
            set { _xconfig.SetAttribute("/behavior/position", "always-on-top", value.ToString()); }
        }

        public bool MiniClock
        {
            get { return bool.Parse(_xconfig.GetAttribute("/behavior/position", "mini") ?? true.ToString()); }
            set { _xconfig.SetAttribute("/behavior/position", "mini", value.ToString()); }
        }
        #endregion
    }
}
