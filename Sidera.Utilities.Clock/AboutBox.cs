using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidera.Utilities.Clock
{
    public partial class AboutBox : Form
    {
        private Dictionary<string, string> _keywords;

        public AboutBox()
        {
            InitializeComponent();

            Assembly exe = Assembly.GetEntryAssembly();
            FileInfo fiExe = new FileInfo(exe.Location);
            FileVersionInfo fviExe = FileVersionInfo.GetVersionInfo(fiExe.FullName);

            _keywords = new Dictionary<string, string>();
            _keywords.Add("{COPYRIGHT}", fviExe.LegalCopyright);
            _keywords.Add("{DESCRIPTION}", fviExe.Comments);
            _keywords.Add("{PRODUCTNAME}", fviExe.ProductName);
            _keywords.Add("{VERSION}", exe.GetName().Version.ToString());

            Icon appIcon = Icon.ExtractAssociatedIcon(fiExe.FullName);
            Icon = appIcon;

            Image appImage = appIcon.ToBitmap();
            picAppIcon.BackgroundImage = appImage;

            foreach (string key in _keywords.Keys)
            {
                string value = _keywords[key];

                lblCredits.Text = lblCredits.Text.Replace(key, value);
                txtLicense.Text = txtLicense.Text.Replace(key, value);
            }
        }
    }
}
