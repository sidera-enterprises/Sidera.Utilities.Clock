using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidera.Utilities.Clock
{
    internal static class Log
    {
        public static string LogFilename
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

                cfgFilename = Path.Combine(baseDir, $"{exeName}.Trace.log");

                return cfgFilename;
            }
        }



        public static void Write(Exception ex)
        {
            Write(ex, false);
        }

        public static void Write(Exception ex, bool showMessageBox)
        {
            try
            {
                Write(ex.ToString(), LogType.Error, false);
            }
            catch
            {
                // Do nothing
            }
            finally
            {
                if (showMessageBox)
                {
                    MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }



        public static void Write(string message)
        {
            Write(message, LogType.Information, false);
        }

        public static void Write(string message, bool showMessageBox)
        {
            Write(message, LogType.Information, showMessageBox);
        }

        public static void Write(string message, LogType type)
        {
            Write(message, type, false);
        }

        public static void Write(string message, LogType type, bool showMessageBox)
        {
            try
            {
                bool logFileExists = File.Exists(LogFilename);

                string timestamp, level, exeFilename, version;
                timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                level = type.ToString().ToUpper();
                exeFilename = Common.ExeFilename;
                version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                string line = string.Join("\n",
                    new string[]
                    {
                            $"Timestamp:        {timestamp}",
                            $"Message level:    {level}",
                            $"Source assembly:  {exeFilename}",
                            $"Version:          {version}",
                            $"",
                            $"Message:          {message}",
                            $"",
                            $"",
                            $"",
                    });

                using (StreamWriter sw = new StreamWriter(LogFilename, true))
                {
                    sw.WriteLine(line);
                }
            }
            catch
            {
                // Do nothing
            }
            finally
            {
                if (showMessageBox)
                {
                    MessageBoxIcon icon = default;
                    switch (type)
                    {
                        case LogType.Warning:
                            icon = MessageBoxIcon.Warning;
                            break;
                        case LogType.Error:
                            icon = MessageBoxIcon.Error;
                            break;
                        default:
                            icon = MessageBoxIcon.Information;
                            break;
                    }

                    MessageBox.Show(message,
                        type.ToString(),
                        MessageBoxButtons.OK,
                        icon);
                }
            }
        }
    }
}
