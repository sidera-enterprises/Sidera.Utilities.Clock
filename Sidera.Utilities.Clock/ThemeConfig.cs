using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sidera.Utilities.Clock
{
    internal class ThemeConfig
    {
        private const string _ILLEGAL_CHARS = @"\/:*?""<>|";
        private XmlConfig _xconfig;

        private string _name;

        public ThemeConfig(string name)
        {
            _name = name;

            //

            FileInfo fiConfig = new FileInfo(Filename);
            fiConfig.Directory.Create();

            //

            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new ArgumentException($"File name cannot be null, empty, or white-space.");
            }
            else
            {
                string chars = string.Join(",", _ILLEGAL_CHARS.Select(c => $"'{c}'"));
                foreach (char c in _ILLEGAL_CHARS)
                {
                    if (name.Contains(c))
                    {
                        throw new ArgumentException($"File name cannot contain any of the characters {{{chars}}}.");
                    }
                }
            }

            //

            _xconfig = new XmlConfig(Filename, "configuration")
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

        #region Config properties
        public string Filename
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

                string themesDir = Path.Combine(exeDir.ToUpper().StartsWith(pgmFilesDir.ToUpper()) || exeDir.ToUpper().StartsWith(pgmFilesX86Dir.ToUpper()) ? appDataDir : exeDir,
                    "themes");

                cfgFilename = Path.Combine(themesDir, $"{_name}.xml");

                return cfgFilename;
            }
        }
        #endregion

        #region Appearance
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

        public void Initialize()
        {
            _xconfig.InitializeDocument();
        }

        public void Delete()
        {
            FileInfo fiXconfig = new FileInfo(_xconfig.Filename);
            if (fiXconfig.Exists)
            {
                fiXconfig.Delete();
            }
        }
    }
}
