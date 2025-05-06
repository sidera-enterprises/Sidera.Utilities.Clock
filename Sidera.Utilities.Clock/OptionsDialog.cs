using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sidera.Utilities.Clock
{
    public partial class OptionsDialog : Form
    {
        public OptionsDialog()
        {
            InitializeComponent();
            InitApplyButtonEnablingEvents();

            Screen[] screens = Screen.AllScreens;
            int id = 0;
            foreach (Screen screen in screens)
            {
                string name, dimensions, primary;
                name = $"Monitor {++id}";
                dimensions = $"({string.Join("×", screen.Bounds.Width, screen.Bounds.Height)})";
                primary = screen.Primary ? "(Primary)" : "";
                cbxBehavior_Anchoring_Monitor.Items.Add(string.Join(" ", name, dimensions, primary));
            }

            Image wallpaper;
            if (TryGetDesktopBackground(out wallpaper))
            {
                pnlAppearance_Sample.BackgroundImage = wallpaper;
                pnlAppearance_Sample.BackgroundImageLayout = ImageLayout.Stretch;
            }
            cbxAppearance_Theme_Name.SelectedIndex = 0;
            cbxBehavior_Anchoring_Monitor.SelectedIndex = 0;
        }

        private bool TryGetDesktopBackground(out Image image)
        {
            try
            {
                RegistryKey rkDesktop = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop");
                string imagePath = rkDesktop.GetValue("WallPaper").ToString();
                image = Image.FromFile(imagePath);
                return true;
            }
            catch
            {
                image = null;
                return false;
            }
        }

        private string[] GetInstalledThemes()
        {
            List<string> list = new List<string>();
            
            //
            
            FileInfo fiExe = new FileInfo(Assembly.GetExecutingAssembly().Location);

            string exeDir, exeName, cfgFilename;
            exeDir = fiExe.DirectoryName;
            exeName = Path.GetFileNameWithoutExtension(fiExe.FullName);

            string themesDir = Path.Combine(exeDir, "themes");
            DirectoryInfo diThemes = new DirectoryInfo(themesDir);

            if (diThemes.Exists)
            {
                FileInfo[] themeFiles = diThemes.GetFiles("*.xml", SearchOption.TopDirectoryOnly);
                foreach (FileInfo fiTheme in themeFiles)
                {
                    list.Add(Path.GetFileNameWithoutExtension(fiTheme.Name));
                }
            }
            
            //

            return list.ToArray();
        }

        private void RefreshThemesDropdown()
        {
            int selIndex = cbxAppearance_Theme_Name.SelectedIndex;
            cbxAppearance_Theme_Name.Items.Clear();
            cbxAppearance_Theme_Name.Items.Add("(Custom)");
            foreach (string s in GetInstalledThemes())
            {
                cbxAppearance_Theme_Name.Items.Add(s);
            }

            cbxAppearance_Theme_Name.SelectedIndex = selIndex;
        }

        private void InitApplyButtonEnablingEvents()
        {
            cbxAppearance_Theme_Name.SelectedIndexChanged += Control_ValueChanged;
            btnAppearance_Advanced_BezelColor.BackColorChanged += Control_ValueChanged;
            btnAppearance_Advanced_DisplayBackColor.BackColorChanged += Control_ValueChanged;
            btnAppearance_Advanced_DisplayForeColor.BackColorChanged += Control_ValueChanged;

            chkBehavior_Display_FlashColon.CheckedChanged += Control_ValueChanged;
            chkBehavior_Display_ShowDate.CheckedChanged += Control_ValueChanged;
            chkBehavior_Display_24HourFormat.CheckedChanged += Control_ValueChanged;
            chkBehavior_Display_DDMMFormat.CheckedChanged += Control_ValueChanged;
            rbtnBehavior_Anchoring_NW.CheckedChanged += Control_ValueChanged;
            rbtnBehavior_Anchoring_NE.CheckedChanged += Control_ValueChanged;
            rbtnBehavior_Anchoring_SW.CheckedChanged += Control_ValueChanged;
            rbtnBehavior_Anchoring_SE.CheckedChanged += Control_ValueChanged;
            cbxBehavior_Anchoring_Monitor.SelectedIndexChanged += Control_ValueChanged;
            chkBehavior_Anchoring_Lock.CheckedChanged += Control_ValueChanged;
            chkBehavior_Anchoring_AlwaysOnTop.CheckedChanged += Control_ValueChanged;
        }

        private void LoadConfig()
        {
            RefreshThemesDropdown();

            bool themed = Common.AppConfig.Theme != null;
            ThemeConfig themeConfig = themed ? new ThemeConfig(Common.AppConfig.Theme) : null;

            Color bezelColor, backColor, foreColor;
            bezelColor = themed ? themeConfig.BezelColor : Common.AppConfig.BezelColor;
            backColor = themed ? themeConfig.DisplayBackgroundColor : Common.AppConfig.DisplayBackgroundColor;
            foreColor = themed ? themeConfig.DisplayForegroundColor : Common.AppConfig.DisplayForegroundColor;

            if (themed)
            {
                cbxAppearance_Theme_Name.Text = Common.AppConfig.Theme;
            }
            else
            {
                cbxAppearance_Theme_Name.SelectedIndex = 0;
            }

            btnAppearance_Advanced_BezelColor.BackColor = bezelColor;
            btnAppearance_Advanced_DisplayBackColor.BackColor = backColor;
            btnAppearance_Advanced_DisplayForeColor.BackColor = foreColor;

            clkApperance_Sample.BackColor = btnAppearance_Advanced_BezelColor.BackColor;
            clkApperance_Sample.DisplayBackColor = btnAppearance_Advanced_DisplayBackColor.BackColor;
            clkApperance_Sample.DisplayOnColor = btnAppearance_Advanced_DisplayForeColor.BackColor;

            chkBehavior_Display_FlashColon.Checked = Common.AppConfig.FlashColon;
            chkBehavior_Display_ShowDate.Checked = Common.AppConfig.AutoRotateTimeDate;
            chkBehavior_Display_24HourFormat.Checked = Common.AppConfig.Use24HourTimeFormat;
            chkBehavior_Display_DDMMFormat.Checked = Common.AppConfig.UseDdMmDateFormat;
            switch (Common.AppConfig.AnchorPosition)
            {
                case WidgetAnchor.TopLeft:
                    rbtnBehavior_Anchoring_NW.Checked = true;
                    break;
                case WidgetAnchor.TopRight:
                    rbtnBehavior_Anchoring_NE.Checked = true;
                    break;
                case WidgetAnchor.BottomRight:
                    rbtnBehavior_Anchoring_SE.Checked = true;
                    break;
                case WidgetAnchor.BottomLeft:
                    rbtnBehavior_Anchoring_SW.Checked = true;
                    break;
            }
            try { cbxBehavior_Anchoring_Monitor.SelectedIndex = Common.AppConfig.DefaultMonitor; } catch { /* Do nothing */ }
            chkBehavior_Anchoring_Lock.Checked = Common.AppConfig.LockPosition;
            chkBehavior_Anchoring_AlwaysOnTop.Checked = Common.AppConfig.AlwaysOnTop;

            //

            TopMost = Common.AppConfig.AlwaysOnTop;
        }

        public void SaveConfig()
        {
            if (cbxAppearance_Theme_Name.SelectedIndex == 0)
            {
                Common.AppConfig.Theme = null;
                Common.AppConfig.BezelColor = btnAppearance_Advanced_BezelColor.BackColor;
                Common.AppConfig.DisplayBackgroundColor = btnAppearance_Advanced_DisplayBackColor.BackColor;
                Common.AppConfig.DisplayForegroundColor = btnAppearance_Advanced_DisplayForeColor.BackColor;
            }
            else
            {
                Common.AppConfig.Theme = cbxAppearance_Theme_Name.Text;
            }
            Common.AppConfig.FlashColon = chkBehavior_Display_FlashColon.Checked;
            Common.AppConfig.AutoRotateTimeDate = chkBehavior_Display_ShowDate.Checked;
            Common.AppConfig.Use24HourTimeFormat = chkBehavior_Display_24HourFormat.Checked;
            Common.AppConfig.UseDdMmDateFormat = chkBehavior_Display_DDMMFormat.Checked;
            if (rbtnBehavior_Anchoring_NW.Checked)
            {
                Common.AppConfig.AnchorPosition = WidgetAnchor.TopLeft;
            }
            else if (rbtnBehavior_Anchoring_NE.Checked)
            {
                Common.AppConfig.AnchorPosition = WidgetAnchor.TopRight;
            }
            else if (rbtnBehavior_Anchoring_SE.Checked)
            {
                Common.AppConfig.AnchorPosition = WidgetAnchor.BottomRight;
            }
            else if (rbtnBehavior_Anchoring_SW.Checked)
            {
                Common.AppConfig.AnchorPosition = WidgetAnchor.BottomLeft;
            }

            if (!string.IsNullOrEmpty(cbxAppearance_Theme_Name.Text))
            {
                Common.AppConfig.DefaultMonitor = cbxBehavior_Anchoring_Monitor.SelectedIndex;
            }
            Common.AppConfig.LockPosition = chkBehavior_Anchoring_Lock.Checked;
            Common.AppConfig.AlwaysOnTop = chkBehavior_Anchoring_AlwaysOnTop.Checked;

            //

            TopMost = Common.AppConfig.AlwaysOnTop;
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            LoadConfig();

            //

            btnApply.Enabled = false;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void cbxAppearance_Theme_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAppearance_Theme_Delete.Enabled = cbxAppearance_Theme_Name.SelectedIndex != 0;

            //

            if (cbxAppearance_Theme_Name.SelectedIndex > 0)
            {
                string name = cbxAppearance_Theme_Name.Text;
                ThemeConfig themeConfig = new ThemeConfig(name);
                
                Color bezelColor, backColor, foreColor;
                bezelColor = themeConfig.BezelColor;
                backColor = themeConfig.DisplayBackgroundColor;
                foreColor = themeConfig.DisplayForegroundColor;

                btnAppearance_Advanced_BezelColor.BackColor = bezelColor;
                btnAppearance_Advanced_DisplayBackColor.BackColor = backColor;
                btnAppearance_Advanced_DisplayForeColor.BackColor = foreColor;

                clkApperance_Sample.BackColor = bezelColor;
                clkApperance_Sample.DisplayBackColor = backColor;
                clkApperance_Sample.DisplayOnColor = foreColor;
            }
        }

        private void btnAppearance_Theme_Save_Click(object sender, EventArgs e)
        {
        start:
            bool custom = cbxAppearance_Theme_Name.SelectedIndex == 0;
            string name = "";
            if (custom)
            {
                TextInputDialog textInputDialog = new TextInputDialog("Please specify a theme name:", "Save theme")
                {
                    TopMost = this.TopMost,
                };

                DialogResult dr = textInputDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    name = textInputDialog.Input;
                    if (string.IsNullOrWhiteSpace(name)
                        || name.ToUpper() == cbxAppearance_Theme_Name.Items[0].ToString().ToUpper())
                    {
                        MessageBox.Show($"Please specify a name for your theme.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        goto start;
                    }
                    else
                    {
                        Color bezelColor, backColor, foreColor;
                        bezelColor = btnAppearance_Advanced_BezelColor.BackColor;
                        backColor = btnAppearance_Advanced_DisplayBackColor.BackColor;
                        foreColor = btnAppearance_Advanced_DisplayForeColor.BackColor;

                        ThemeConfig newTheme = new ThemeConfig(name);
                        newTheme.BezelColor = bezelColor;
                        newTheme.DisplayBackgroundColor = backColor;
                        newTheme.DisplayForegroundColor = foreColor;
                    }
                }
            }
            else
            {
                name = cbxAppearance_Theme_Name.Text;
                DialogResult dr = MessageBox.Show($"Do you want to overwrite the theme '{name}'?",
                    "Overwrite theme?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    Color bezelColor, backColor, foreColor;
                    bezelColor = btnAppearance_Advanced_BezelColor.BackColor;
                    backColor = btnAppearance_Advanced_DisplayBackColor.BackColor;
                    foreColor = btnAppearance_Advanced_DisplayForeColor.BackColor;

                    ThemeConfig themeConfig = new ThemeConfig(name);
                    themeConfig.BezelColor = bezelColor;
                    themeConfig.DisplayBackgroundColor = backColor;
                    themeConfig.DisplayForegroundColor = foreColor;
                }
            }

            RefreshThemesDropdown();
        }

        private void btnAppearance_Theme_Delete_Click(object sender, EventArgs e)
        {
            string name = cbxAppearance_Theme_Name.Text;
            DialogResult dr = MessageBox.Show($"Are you sure you want to delete the theme '{name}'?",
                "Delete theme?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                ThemeConfig themeConfig = new ThemeConfig(name);
                themeConfig.Delete();

                int selIndex, maxIndex;
                selIndex = cbxAppearance_Theme_Name.SelectedIndex;
                cbxAppearance_Theme_Name.Items.Remove(name);
                maxIndex = cbxAppearance_Theme_Name.Items.Count - 1;
                cbxAppearance_Theme_Name.SelectedIndex = Math.Min(selIndex, maxIndex);
            }
        }

        private void btnApperance_Advanced_ElementColor_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;

            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = btnSender.BackColor;
            DialogResult dr = colorDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                btnSender.BackColor = colorDialog.Color;
                cbxAppearance_Theme_Name.SelectedIndex = 0;
            }

            //

            clkApperance_Sample.BackColor = btnAppearance_Advanced_BezelColor.BackColor;
            clkApperance_Sample.DisplayBackColor = btnAppearance_Advanced_DisplayBackColor.BackColor;
            clkApperance_Sample.DisplayOnColor = btnAppearance_Advanced_DisplayForeColor.BackColor;
        }

        private void chkBehavior_Display_Options_CheckedChanged(object sender, EventArgs e)
        {
            clkApperance_Sample.FlashColon = chkBehavior_Display_FlashColon.Checked;
            clkApperance_Sample.ShowDate = chkBehavior_Display_ShowDate.Checked;
            clkApperance_Sample.Use24HourTimeFormat = chkBehavior_Display_24HourFormat.Checked;
            clkApperance_Sample.UseDDMMFormat = chkBehavior_Display_DDMMFormat.Checked;
        }

        private void btnHelp_Docs_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_About_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.TopMost = TopMost;
            aboutBox.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnApply.PerformClick();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveConfig();
            OnApplyClick();

            btnApply.Enabled = false;
        }

        public event EventHandler ApplyClick;
        private void OnApplyClick()
        {
            var handler = ApplyClick;
            if (handler != null)
                handler(this, new EventArgs());
        }
    }
}
