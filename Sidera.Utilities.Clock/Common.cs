using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        public static string ExeDirectory { get { return (new FileInfo(ExeFilename)).Directory.FullName; } }
        public static string ExeFilename { get { return Assembly.GetExecutingAssembly().Location; } }
        public static string ProgramFilesDirectory { get { return $@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).TrimEnd('\\')}\"; } }
        public static string ProgramFilesX86Directory { get { return $@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86).TrimEnd('\\')}\"; } }
        public static string UserAppDataDirectory {get { return $@"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sidera", "Clock").TrimEnd('\\')}\"; } }
        public static string UserShellStartupDirectory { get { return $@"{Environment.GetFolderPath(Environment.SpecialFolder.Startup)}\"; } }

        public static string ConfigFilename
        {
            get
            {
                FileInfo fiExe = new FileInfo(Assembly.GetExecutingAssembly().Location);

                string pgmFilesDir, pgmFilesX86Dir, appDataDir, exeDir, exeName, cfgFilename;
                pgmFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                pgmFilesX86Dir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sidera", "Clock");
                exeDir = fiExe.DirectoryName;
                exeName = Path.GetFileNameWithoutExtension(fiExe.FullName);

                string baseDir
                    = exeDir.ToUpper().StartsWith(pgmFilesDir.ToUpper()) || exeDir.ToUpper().StartsWith(pgmFilesX86Dir.ToUpper())
                        ? appDataDir
                        : exeDir;

                cfgFilename = Path.Combine(baseDir, $"{exeName}.Config.xml");

                return cfgFilename;
            }
        }

        public static string ThemesDirectory

        {
            get
            {
                FileInfo fiConfig = new FileInfo(ConfigFilename);
                string dirConfig = fiConfig.DirectoryName;

                return $@"{Path.Combine(dirConfig, "themes")}\";
            }
        }

        public static void InitDefaultThemes()
        {
            ThemeConfig[] themes = new ThemeConfig[]
            {
                new ThemeConfig("Hotdog Stand") { BezelColor = Color.Red, DisplayBackgroundColor = Color.Yellow, DisplayForegroundColor = Color.Red },
                new ThemeConfig("LCD - Black") { BezelColor = Color.Gray, DisplayBackgroundColor = Color.FromArgb(0xe0e0e0), DisplayForegroundColor = Color.Black},
                new ThemeConfig("LCD - Blue") { BezelColor = Color.Gray, DisplayBackgroundColor = Color.FromArgb(0xe0e0e0), DisplayForegroundColor = Color.Navy },
                new ThemeConfig("LCD - Teal") { BezelColor = Color.Gray, DisplayBackgroundColor = Color.FromArgb(0xe0e0e0), DisplayForegroundColor = Color.Teal },
                new ThemeConfig("LCD - Purple") { BezelColor = Color.Gray, DisplayBackgroundColor = Color.FromArgb(0xe0e0e0), DisplayForegroundColor = Color.Purple },
                new ThemeConfig("LCD - Green") { BezelColor = Color.Gray, DisplayBackgroundColor = Color.FromArgb(0xe0e0e0), DisplayForegroundColor = Color.Green },
                new ThemeConfig("LCD - Red") { BezelColor = Color.Gray, DisplayBackgroundColor = Color.FromArgb(0xe0e0e0), DisplayForegroundColor = Color.Maroon },
                new ThemeConfig("LCD - Olive") { BezelColor = Color.Gray, DisplayBackgroundColor = Color.FromArgb(0xe0e0e0), DisplayForegroundColor = Color.Olive },
                new ThemeConfig("LED - Blue") { BezelColor = Color.Silver, DisplayBackgroundColor = Color.Black, DisplayForegroundColor = Color.Blue },
                new ThemeConfig("LED - Cyan") { BezelColor = Color.Silver, DisplayBackgroundColor = Color.Black, DisplayForegroundColor = Color.Cyan },
                new ThemeConfig("LED - Fuchsia") { BezelColor = Color.Silver, DisplayBackgroundColor = Color.Black, DisplayForegroundColor = Color.Fuchsia },
                new ThemeConfig("LED - Green") { BezelColor = Color.Silver, DisplayBackgroundColor = Color.Black, DisplayForegroundColor = Color.Lime },
                new ThemeConfig("LED - Red") { BezelColor = Color.Silver, DisplayBackgroundColor = Color.Black, DisplayForegroundColor = Color.Red },
                new ThemeConfig("LED - White") { BezelColor = Color.Silver, DisplayBackgroundColor = Color.Black, DisplayForegroundColor = Color.White},
                new ThemeConfig("LED - Yellow") { BezelColor = Color.Silver, DisplayBackgroundColor = Color.Black, DisplayForegroundColor = Color.Yellow },
                new ThemeConfig("Mahogany") { BezelColor = Color.FromArgb(0xc04000), DisplayBackgroundColor = Color.FromArgb(0x400000), DisplayForegroundColor = Color.FromArgb(0xffe000)},
                new ThemeConfig("Toy Clock") { BezelColor = Color.FromArgb(0x8080c0), DisplayBackgroundColor = Color.FromArgb(0xc0c060), DisplayForegroundColor = Color.Black },
            };
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

        public static int GetScreenId(this Form form)
        {
            return Screen.AllScreens.ToList().IndexOf(Screen.FromControl(form)) + 1;
        }

        public static void SetScreenLocation(this Form form, int screenId, int x, int y)
        {
            Screen targetScreen = GetScreenFromId(screenId);

            Rectangle screenBounds = targetScreen.Bounds;
            int offsetX, offsetY;
            offsetX = x + screenBounds.X;
            offsetY = y + screenBounds.Y;

            Point newLocation = new Point(offsetX, offsetY);
            form.Location = newLocation;
        }

        public static void CreateShortcut(string directory)
        {
            FileInfo fiExe = new FileInfo(ExeFilename);

            string appName, lnkName, lnkFullPath;
            appName = Path.GetFileNameWithoutExtension(new FileInfo(ExeFilename).Name);
            lnkName = $"{appName}.lnk";
            lnkFullPath = Path.Combine(Common.UserShellStartupDirectory, lnkName);

            var shell = new IWshRuntimeLibrary.WshShell();
            var shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(lnkFullPath);
            shortcut.TargetPath = fiExe.FullName;
            shortcut.Arguments = "";
            shortcut.WorkingDirectory = fiExe.DirectoryName;
            shortcut.Save();
        }

        public static void DeleteShortcut(string directory)
        {
            FileInfo fiExe = new FileInfo(ExeFilename);

            string appName, lnkName, lnkFullPath;
            appName = Path.GetFileNameWithoutExtension(new FileInfo(ExeFilename).Name);
            lnkName = $"{appName}.lnk";
            lnkFullPath = Path.Combine(Common.UserShellStartupDirectory, lnkName);

            File.Delete(lnkFullPath);
        }
    }
}
