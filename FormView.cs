using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using RJJSON;

namespace Thiscord_Installer
{

    public partial class FormView : Form
    {
        Version LatestVersion = new Version("0.0.0");
        Color DiscordGreen = Color.FromArgb(36, 128, 70);
        Color DiscordGreenHover = Color.FromArgb(26, 99, 52);
        Color DiscordGreenPressed = Color.FromArgb(21, 86, 43);
        Color DiscordRed = Color.FromArgb(192, 49, 53);
        Color DiscordRedHover = Color.FromArgb(161, 40, 40);
        Color DiscordRedPressed = Color.FromArgb(126, 28, 30);
        string DefaultDiscordPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\";
        string DefaultThiscordPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord";
        string DefaultUpdateExePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master\\src\\Update.exe";
        string DefaultDiscordUpdateExePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe";
        private void killDiscordProcesses()
        {
            foreach (var process in Process.GetProcessesByName("discord"))
            {
                process.Kill();
            }
        }
        private void fileDeleteIfExists(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        private void dirDeleteIfExists(string path, bool recursive)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, recursive);
            }
        }
        private void fileMoveIfExists(string target, string destination)
        {
            if (File.Exists(target) && !File.Exists(destination))
            {
                File.Move(target, destination);
            }
        }
        private void fileCopyIfExists(string target, string destination, bool overwrite)
        {
            if (File.Exists(target))
            {
                if (!File.Exists(destination))
                {
                    File.Copy(target, destination, overwrite);
                }
                else if (overwrite)
                {
                    File.Copy(target, destination, overwrite);
                }
            }
        }
        private void changeButtonType()
        {
            if (InstallButton.Tag.ToString() == "Install")
            {
                InstallButton.Text = "Uninstall";
                InstallButton.BackColor = DiscordRed;
                InstallButton.FlatAppearance.MouseOverBackColor = DiscordRedHover;
                InstallButton.FlatAppearance.MouseDownBackColor = DiscordRedPressed;
                InstallButton.Tag = "Uninstall";
            }
            else
            {
                InstallButton.Text = $"Install - {LatestVersion}";
                InstallButton.BackColor = DiscordGreen;
                InstallButton.FlatAppearance.MouseOverBackColor = DiscordGreenHover;
                InstallButton.FlatAppearance.MouseDownBackColor = DiscordGreenPressed;
                InstallButton.Tag = "Install";
            }

        }

        public FormView()
        {
            InitializeComponent();
        }

        private void Terms_Enter(object sender, EventArgs e)
        {
            ActiveControl = null; // Hide i-Beam cursor
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            ModifyDiscord.RunWorkerAsync();
        }

        private void ModifyDiscord_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int Progress = 0;
            ModifyDiscord.ReportProgress(0);
            if (InstallButton.Tag.ToString() == "Install")
            {
                killDiscordProcesses();
                ModifyDiscord.ReportProgress(Progress += 10);
                if (!Directory.Exists(DefaultDiscordPath))
                {
                    DialogResult result = MessageBox.Show($"Discord doesnt seem to be installed\nSee how to fix this if you use a custom install location?",
                        "Not Installed",
                        MessageBoxButtons.YesNo
                    );
                    if (result == DialogResult.Yes)
                    {
                        Process.Start("explorer", "https://github.com/RJ-Infinity/ThisCord/blob/master/customInstall.md");
                    }
                    else { return; }
                }

                dirDeleteIfExists(DefaultThiscordPath, true);
                ModifyDiscord.ReportProgress(Progress += 10);
                if (File.Exists($"{DefaultDiscordPath}\\Update_Discord.exe"))
                {
                    fileDeleteIfExists($"{DefaultDiscordPath}\\Update.exe");
                    fileMoveIfExists($"{DefaultDiscordPath}\\Update_Discord.exe", $"{DefaultDiscordPath}\\Update.exe");
                }
                ModifyDiscord.ReportProgress(Progress += 10);
                using (var client = new WebClient())
                {
                    try
                    {
                        if (!Directory.Exists(DefaultThiscordPath))
                        {
                            Directory.CreateDirectory(DefaultThiscordPath);
                            ModifyDiscord.ReportProgress(Progress += 10);
                        }
                        client.DownloadFile("https://github.com/RJ-Infinity/ThisCord/archive/refs/heads/master.zip", $"{DefaultThiscordPath}\\thiscord.zip");
                        ModifyDiscord.ReportProgress(Progress += 10);

                    }
                    catch
                    {
                        MessageBox.Show($"Failed to download thiscord");
                        return;
                    }
                }
                ModifyDiscord.ReportProgress(Progress += 10);
                ZipFile.ExtractToDirectory($"{DefaultThiscordPath}\\thiscord.zip", DefaultThiscordPath);
                ModifyDiscord.ReportProgress(Progress += 10);
                fileDeleteIfExists($"{DefaultThiscordPath}\\thiscord.zip");
                ModifyDiscord.ReportProgress(Progress += 10);
                fileMoveIfExists(DefaultDiscordUpdateExePath, $"{DefaultDiscordPath}\\Update_Discord.exe");
                ModifyDiscord.ReportProgress(Progress += 10);
                fileCopyIfExists(DefaultUpdateExePath, DefaultDiscordUpdateExePath, true);
                ModifyDiscord.ReportProgress(100);
                changeButtonType();

            }
            else if (InstallButton.Tag.ToString() == "Uninstall")
            {
                killDiscordProcesses();
                ModifyDiscord.ReportProgress(Progress += 20);

                dirDeleteIfExists(DefaultThiscordPath, true);
                ModifyDiscord.ReportProgress(Progress += 20);
                fileDeleteIfExists(DefaultDiscordUpdateExePath);
                ModifyDiscord.ReportProgress(Progress += 20);
                fileMoveIfExists($"{DefaultDiscordPath}\\Update_Discord.exe", DefaultDiscordUpdateExePath);
                ModifyDiscord.ReportProgress(100);
                changeButtonType();
            }
        }

        private void ModifyDiscord_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            InstallingBar.Value = e.ProgressPercentage;
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            WebClient Client = new WebClient();
            string Downloaded_Terms = Client.DownloadString("https://raw.githubusercontent.com/RJ-Infinity/ThisCord/master/terms.txt");
            LatestVersion = new Version(JSON.StringToObject(Client.DownloadString("https://raw.githubusercontent.com/RJ-Infinity/ThisCord/master/version.json"))["version"].StringData);
            bool updateRequired = JSON.StringToObject(Client.DownloadString("https://raw.githubusercontent.com/RJ-Infinity/ThisCord/master/version.json"))["required"].BoolData;
            Terms.Text = Downloaded_Terms;
            if (Directory.Exists(DefaultThiscordPath) && File.Exists($"{DefaultThiscordPath}\\ThisCord-master\\version.json"))
            {
                changeButtonType();
                Version InstalledVersion = new Version(JSON.StringToObject(File.ReadAllText($"{DefaultThiscordPath}\\ThisCord-master\\version.json"))["version"].StringData);
                if (LatestVersion > InstalledVersion)
                {
                    InstallButton.Text = $"Update - {LatestVersion}";
                }
            }
            else
            {
                InstallButton.Text = $"Install - {LatestVersion}";
            }
        }
    }
}