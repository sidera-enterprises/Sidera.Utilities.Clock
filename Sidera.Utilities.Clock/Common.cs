using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidera.Utilities.Clock
{
    internal static class Common
    {
        private static AppConfig _appConfig;

        public static AppConfig AppConfig
        {
            get
            {
                if (_appConfig == null)
                {
                    _appConfig = new AppConfig();
                }

                return _appConfig;
            }
        }

        public static Screen GetScreenFromId(int screenId)
        {
            int screenIndex = screenId - 1;
            Screen targetScreen = Screen.AllScreens[screenIndex];
            return targetScreen;
        }

        public static Screen GetScreenFromLocation(this Form form)
        {
            Screen targetScreen = Screen.FromControl(form);
            return targetScreen;
        }

        public static int GetScreenIdFromLocation(this Form form)
        {
            Screen targetScreen = GetScreenFromLocation(form);
            int screenIndex = Screen.AllScreens.ToList().IndexOf(targetScreen);

            int screenId = screenIndex + 1;
            return screenId;
        }

        public static void SetScreenLocation(this Form form, int screenId, int x, int y)
        {
            Screen targetScreen = GetScreenFromId(screenId);

            Rectangle screenBounds = targetScreen.Bounds;
            int offsetX, offsetY;
            offsetX = x + screenBounds.X;
            offsetY = y + screenBounds.Y;

            //offsetX = Math.Max(0, Math.Min(offsetX, screenBounds.Width - form.Width));
            //offsetY = Math.Max(0, Math.Min(offsetY, screenBounds.Height - form.Height));

            Point newLocation = new Point(offsetX, offsetY);
            form.Location = newLocation;
        }

        //public static void SetScreenId(this Form form, int id)
        //{
        //    int index = id - 1;

        //    Screen targetScreen = Screen.AllScreens[index - 1];
        //    Rectangle screenBounds = targetScreen.Bounds;

        //    int offsetX, offsetY;
        //    offsetX = screenBounds.X;
        //    offsetY = screenBounds.Y;

        //    int x, y;
        //    x = form.Left + offsetX;
        //    y = form.Top + offsetY;

        //    Point newPoint = new Point(x, y);
        //    form.Location = newPoint;

        //    //int index = id - 1;
        //    //if (index >= 0 && index < Screen.AllScreens.Length)
        //    //{
        //    //    Screen targetScreen = Screen.AllScreens[index];
        //    //    Rectangle screenBounds = new Rectangle(0,
        //    //        0,
        //    //        targetScreen.WorkingArea.Width,
        //    //        targetScreen.WorkingArea.Height);

        //    //    Point point = screenBounds.Location;
        //    //    point.X += form.DesktopLocation.X;
        //    //    point.Y += form.DesktopLocation.Y;

        //    //    form.SetBounds(targetScreen.Bounds.X,
        //    //        targetScreen.Bounds.Y,
        //    //        targetScreen.Bounds.Width,
        //    //        targetScreen.Bounds.Height);

        //    //    form.Show();

        //    //int x, y;
        //    //switch (AppConfig.AnchorPosition)
        //    //{
        //    //    case WidgetAnchor.TopLeft:
        //    //        x = Common.AppConfig.WidgetLocation.X;
        //    //        y = Common.AppConfig.WidgetLocation.Y;
        //    //        break;
        //    //    case WidgetAnchor.TopRight:
        //    //        x = screenBounds.Width - form.Width - Common.AppConfig.WidgetLocation.X;
        //    //        y = Common.AppConfig.WidgetLocation.Y;
        //    //        break;
        //    //    case WidgetAnchor.BottomRight:
        //    //        x = screenBounds.Width - form.Width - Common.AppConfig.WidgetLocation.X;
        //    //        y = screenBounds.Height - form.Height - Common.AppConfig.WidgetLocation.Y;
        //    //        break;
        //    //    case WidgetAnchor.BottomLeft:
        //    //        x = Common.AppConfig.WidgetLocation.X;
        //    //        y = screenBounds.Height - form.Height - Common.AppConfig.WidgetLocation.Y;
        //    //        break;
        //    //    default:
        //    //        x = y = 0;
        //    //        break;
        //    //}

        //    //Point point = Screen.AllScreens[index].Bounds.Location;
        //    //point.X += x;
        //    //point.Y += y;

        //    //form.StartPosition = FormStartPosition.Manual;
        //    //form.Location = point;
        //    //form.Show();
        //    //}
        //}

        public static int GetScreenId(this Form form)
        {
            return Screen.AllScreens.ToList().IndexOf(Screen.FromControl(form)) + 1;
        }
    }
}
