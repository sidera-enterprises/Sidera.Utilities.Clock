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

namespace Sidera.Utilities.Clock
{
    internal class ThemeConfig
    {
        private const string _ILLEGAL_CHARS = @"\/:*?""<>|";
        private XmlConfig _xconfig;

        public ThemeConfig(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
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

            FileInfo fiExe = new FileInfo(Assembly.GetExecutingAssembly().Location);

            string exeDir, exeName, cfgFilename;
            exeDir = fiExe.DirectoryName;
            exeName = Path.GetFileNameWithoutExtension(fiExe.FullName);

            string themesDir = Path.Combine(exeDir, "themes");
            cfgFilename = Path.Combine(themesDir, $"{name}.xml");
            Directory.CreateDirectory(themesDir);
            _xconfig = new XmlConfig(cfgFilename, "configuration")
            {
                AutoSave = true,
            };

            //

            if (!File.Exists(_xconfig.Filename))
            {
                _xconfig.Save();
            }
        }

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
