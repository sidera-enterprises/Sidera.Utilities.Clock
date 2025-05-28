using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sidera.Utilities.Clock
{
    internal partial class OptionsDialog : Form
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
            lbxAppearance_Theme_Name.SelectedIndex = 0;
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

            string pgmFilesDir, pgmFilesX86Dir, appDataDir, exeDir, exeName;
            pgmFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            pgmFilesX86Dir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sidera", "Clock");
            exeDir = fiExe.DirectoryName;
            exeName = Path.GetFileNameWithoutExtension(fiExe.FullName);

            string themesDir = Path.Combine(exeDir.ToUpper().StartsWith(pgmFilesDir.ToUpper()) || exeDir.ToUpper().StartsWith(pgmFilesX86Dir.ToUpper()) ? appDataDir : exeDir,
                "themes");

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
            int selIndex = lbxAppearance_Theme_Name.SelectedIndex;
            lbxAppearance_Theme_Name.Items.Clear();
            lbxAppearance_Theme_Name.Items.Add("(Custom)");
            foreach (string s in GetInstalledThemes())
            {
                lbxAppearance_Theme_Name.Items.Add(s);
            }

            lbxAppearance_Theme_Name.SelectedIndex = selIndex;
        }

        private void InitApplyButtonEnablingEvents()
        {
            lbxAppearance_Theme_Name.SelectedIndexChanged += Control_ValueChanged;
            btnAppearance_Advanced_BezelColor.BackColorChanged += Control_ValueChanged;
            btnAppearance_Advanced_DisplayBackColor.BackColorChanged += Control_ValueChanged;
            btnAppearance_Advanced_DisplayForeColor.BackColorChanged += Control_ValueChanged;

            chkBehavior_Display_FlashColon.CheckedChanged += Control_ValueChanged;
            chkBehavior_Display_ShowDate.CheckedChanged += Control_ValueChanged;
            chkBehavior_Display_24HourFormat.CheckedChanged += Control_ValueChanged;
            chkBehavior_Display_DDMMFormat.CheckedChanged += Control_ValueChanged;
            chkBehavior_Miscellaneous_AutoStart.CheckedChanged += Control_ValueChanged;
            rbtnBehavior_Anchoring_NW.CheckedChanged += Control_ValueChanged;
            rbtnBehavior_Anchoring_NE.CheckedChanged += Control_ValueChanged;
            rbtnBehavior_Anchoring_SW.CheckedChanged += Control_ValueChanged;
            rbtnBehavior_Anchoring_SE.CheckedChanged += Control_ValueChanged;
            cbxBehavior_Anchoring_Monitor.SelectedIndexChanged += Control_ValueChanged;
            chkBehavior_Anchoring_Lock.CheckedChanged += Control_ValueChanged;
            chkBehavior_Anchoring_AlwaysOnTop.CheckedChanged += Control_ValueChanged;
            chkBehavior_Anchoring_MiniClock.CheckedChanged += Control_ValueChanged;
        }

        public void AnchorSampleClock()
        {
            int top, left, right, bottom;
            top = 10;
            left = 10;
            right = clkAppearance_Sample.Parent.Width - clkAppearance_Sample.Width - left;
            bottom = clkAppearance_Sample.Parent.Height - clkAppearance_Sample.Height - top;

            if (rbtnBehavior_Anchoring_NW.Checked)
            {
                clkAppearance_Sample.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                clkAppearance_Sample.Location = new Point(left, top);
            }
            else if (rbtnBehavior_Anchoring_NE.Checked)
            {
                clkAppearance_Sample.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                clkAppearance_Sample.Location = new Point(right, top);
            }
            else if (rbtnBehavior_Anchoring_SE.Checked)
            {
                clkAppearance_Sample.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                clkAppearance_Sample.Location = new Point(right, bottom);
            }
            else if (rbtnBehavior_Anchoring_SW.Checked)
            {
                clkAppearance_Sample.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                clkAppearance_Sample.Location = new Point(left, bottom);
            }
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
                lbxAppearance_Theme_Name.Text = Common.AppConfig.Theme;
            }
            else
            {
                lbxAppearance_Theme_Name.SelectedIndex = 0;
            }

            btnAppearance_Advanced_BezelColor.BackColor = bezelColor;
            btnAppearance_Advanced_DisplayBackColor.BackColor = backColor;
            btnAppearance_Advanced_DisplayForeColor.BackColor = foreColor;

            clkAppearance_Sample.BackColor = btnAppearance_Advanced_BezelColor.BackColor;
            clkAppearance_Sample.DisplayBackColor = btnAppearance_Advanced_DisplayBackColor.BackColor;
            clkAppearance_Sample.DisplayOnColor = btnAppearance_Advanced_DisplayForeColor.BackColor;

            chkBehavior_Display_FlashColon.Checked = Common.AppConfig.FlashColon;
            chkBehavior_Display_ShowDate.Checked = Common.AppConfig.AutoRotateTimeDate;
            chkBehavior_Display_24HourFormat.Checked = Common.AppConfig.Use24HourTimeFormat;
            chkBehavior_Display_DDMMFormat.Checked = Common.AppConfig.UseDdMmDateFormat;
            chkBehavior_Miscellaneous_AutoStart.Checked = Common.AppConfig.AutoStart;
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
            chkBehavior_Anchoring_MiniClock.Checked = Common.AppConfig.MiniClock;

            clkAppearance_Sample.MiniClock = Common.AppConfig.MiniClock;

            AnchorSampleClock();

            //

            TopMost = Common.AppConfig.AlwaysOnTop;
        }

        public void SaveConfig()
        {
            if (lbxAppearance_Theme_Name.SelectedIndex == 0)
            {
                Common.AppConfig.Theme = null;
                Common.AppConfig.BezelColor = btnAppearance_Advanced_BezelColor.BackColor;
                Common.AppConfig.DisplayBackgroundColor = btnAppearance_Advanced_DisplayBackColor.BackColor;
                Common.AppConfig.DisplayForegroundColor = btnAppearance_Advanced_DisplayForeColor.BackColor;
            }
            else
            {
                Common.AppConfig.Theme = lbxAppearance_Theme_Name.Text;
            }
            Common.AppConfig.FlashColon = chkBehavior_Display_FlashColon.Checked;
            Common.AppConfig.AutoRotateTimeDate = chkBehavior_Display_ShowDate.Checked;
            Common.AppConfig.Use24HourTimeFormat = chkBehavior_Display_24HourFormat.Checked;
            Common.AppConfig.UseDdMmDateFormat = chkBehavior_Display_DDMMFormat.Checked;
            Common.AppConfig.AutoStart = chkBehavior_Miscellaneous_AutoStart.Checked;
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

            if (!string.IsNullOrEmpty(lbxAppearance_Theme_Name.Text))
            {
                Common.AppConfig.DefaultMonitor = cbxBehavior_Anchoring_Monitor.SelectedIndex;
            }
            Common.AppConfig.LockPosition = chkBehavior_Anchoring_Lock.Checked;
            Common.AppConfig.AlwaysOnTop = chkBehavior_Anchoring_AlwaysOnTop.Checked;
            Common.AppConfig.MiniClock = chkBehavior_Anchoring_MiniClock.Checked;

            //

            TopMost = Common.AppConfig.AlwaysOnTop;
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            try
            {
                LoadConfig();

                //

                btnApply.Enabled = false;
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnApply.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void lbxAppearance_Theme_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnAppearance_Theme_Delete.Enabled = lbxAppearance_Theme_Name.SelectedIndex != 0;

                //

                if (lbxAppearance_Theme_Name.SelectedIndex > 0)
                {
                    string name = lbxAppearance_Theme_Name.Text;
                    ThemeConfig themeConfig = new ThemeConfig(name);

                    Color bezelColor, backColor, foreColor;
                    bezelColor = themeConfig.BezelColor;
                    backColor = themeConfig.DisplayBackgroundColor;
                    foreColor = themeConfig.DisplayForegroundColor;

                    btnAppearance_Advanced_BezelColor.BackColor = bezelColor;
                    btnAppearance_Advanced_DisplayBackColor.BackColor = backColor;
                    btnAppearance_Advanced_DisplayForeColor.BackColor = foreColor;

                    clkAppearance_Sample.BackColor = bezelColor;
                    clkAppearance_Sample.DisplayBackColor = backColor;
                    clkAppearance_Sample.DisplayOnColor = foreColor;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnAppearance_Theme_Save_Click(object sender, EventArgs e)
        {
            try
            {
            start:
                bool custom = lbxAppearance_Theme_Name.SelectedIndex == 0;
                string name = "";
                string[] themes = new string[lbxAppearance_Theme_Name.Items.Count - 1];
                for (int i = 0; i < themes.Length; i++)
                {
                    themes[i] = lbxAppearance_Theme_Name.Items[i + 1].ToString();
                }

                if (custom)
                {
                    TextInputDialog textInputDialog = new TextInputDialog("Please specify a theme name:",
                        "Save theme",
                        themes)
                    {
                        TopMost = this.TopMost,
                    };

                    DialogResult dr = textInputDialog.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        name = textInputDialog.Input;
                        if (string.IsNullOrWhiteSpace(name)
                            || name.ToUpper() == lbxAppearance_Theme_Name.Items[0].ToString().ToUpper())
                        {
                            MessageBox.Show($"Please specify a name for your theme.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            goto start;
                        }
                        else
                        {
                            if (themes.Select(s => s.ToUpper()).Contains(name.ToUpper()))
                            {
                                dr = MessageBox.Show($"Do you want to overwrite the theme '{name}'?",
                                    "Overwrite theme?",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                                if (dr == DialogResult.No)
                                {
                                    return;
                                }
                            }

                            //

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
                    name = lbxAppearance_Theme_Name.Text;
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

                lbxAppearance_Theme_Name.Text = name;
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnAppearance_Theme_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string name = lbxAppearance_Theme_Name.Text;
                DialogResult dr = MessageBox.Show($"Are you sure you want to delete the theme '{name}'?",
                    "Delete theme?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    ThemeConfig themeConfig = new ThemeConfig(name);
                    themeConfig.Delete();

                    int selIndex, maxIndex;
                    selIndex = lbxAppearance_Theme_Name.SelectedIndex;
                    lbxAppearance_Theme_Name.Items.Remove(name);
                    maxIndex = lbxAppearance_Theme_Name.Items.Count - 1;
                    lbxAppearance_Theme_Name.SelectedIndex = Math.Min(selIndex, maxIndex);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnApperance_Advanced_ElementColor_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnSender = sender as Button;

                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = btnSender.BackColor;
                DialogResult dr = colorDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    btnSender.BackColor = colorDialog.Color;
                    lbxAppearance_Theme_Name.SelectedIndex = 0;
                }

                //

                clkAppearance_Sample.BackColor = btnAppearance_Advanced_BezelColor.BackColor;
                clkAppearance_Sample.DisplayBackColor = btnAppearance_Advanced_DisplayBackColor.BackColor;
                clkAppearance_Sample.DisplayOnColor = btnAppearance_Advanced_DisplayForeColor.BackColor;
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void chkBehavior_Display_Options_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                clkAppearance_Sample.FlashColon = chkBehavior_Display_FlashColon.Checked;
                clkAppearance_Sample.ShowDate = chkBehavior_Display_ShowDate.Checked;
                clkAppearance_Sample.Use24HourTimeFormat = chkBehavior_Display_24HourFormat.Checked;
                clkAppearance_Sample.UseDDMMFormat = chkBehavior_Display_DDMMFormat.Checked;
                clkAppearance_Sample.MiniClock = chkBehavior_Anchoring_MiniClock.Checked;

                AnchorSampleClock();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void rbtnBehavior_Anchoring_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AnchorSampleClock();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnBehavior_Advanced_SetTime_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("timedate.cpl");
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnHelp_Docs_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/sidera-enterprises/Sidera.Utilities.Clock");
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnHelp_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show(string.Join("\n",
                new string[]
                {
                    "Are you sure you want to reset the software to factory defaults?",
                    "",
                    "This should only be done if you are experiencing undesirable behaviors within the software.",
                }),
                "Factory reset?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    File.Delete(Common.ConfigFilename);
                    Directory.Delete(Common.ThemesDirectory, true);
                    Common.DeleteShortcut(Common.UserShellStartupDirectory);
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnHelp_Update_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/sidera-enterprises/Sidera.Utilities.Clock/releases");
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnHelp_About_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox aboutBox = new AboutBox();
                aboutBox.TopMost = TopMost;
                aboutBox.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                btnApply.PerformClick();
                Close();
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfig();
                OnApplyClick();

                btnApply.Enabled = false;
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }

        public event EventHandler ApplyClick;
        private void OnApplyClick()
        {
            var handler = ApplyClick;
            if (handler != null)
                handler(this, new EventArgs());
        }

        private void btnHelp_ViewLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Log.LogFilename))
                {
                    Process.Start(Log.LogFilename);
                }
                else
                {
                    MessageBox.Show($"A log file has not been created.",
                        "No log file",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, true);
            }
        }
    }
}
