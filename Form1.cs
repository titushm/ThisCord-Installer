using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using RJJSON;

namespace Thiscord_Installer
{
    public partial class MainForm : Form
    {
        Version InstalledVersion = new Version("0.0.0");
        Version LatestVersion = new Version("0.0.0");
        public MainForm()
        {
            InitializeComponent();
        }

        private void InstallButton_MouseEnter(object sender, EventArgs e)
        {
            InstallButton.BackColor = Color.FromArgb(49, 57, 140);
        }

        private void InstallButton_MouseLeave(object sender, EventArgs e)
        {
            InstallButton.BackColor = Color.FromArgb(88, 101, 242);
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("discord"))
            {
                process.Kill();
            }
            Thread.Sleep(1000);
            if (!Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\"))
            {
                MessageBox.Show("Discord doesnt seem to be installed\r\nInstall it at https://discord.com/download");
                return;
            }
            TermsTextBox.Hide();
            panel2.Hide();
            if (Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master"))
            {
                LegalTextbox.Text = "Uninstalling...";
                if (Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord"))
                {
                    Directory.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord", true);
                }
                UninstallTextbox.Text = "Removed Folder";
                if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update_Discord.exe"))
                {
                    File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe");
                    File.Move($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update_Discord.exe", $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe");
                }
            }
            LegalTextbox.Text = "Starting install";
            using (var client = new WebClient())
            {
                try
                {
                    if (!Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\"))
                    {
                        Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\");
                    }
                    LegalTextbox.Text = "Downloading...";
                    client.DownloadFile("https://github.com/RJ-Infinity/ThisCord/archive/refs/heads/master.zip", $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\thiscord.zip");
                }
                catch (Exception error)
                {
                    Clipboard.SetText(error.ToString());
                    LegalTextbox.Text = $"Error : copied to clipboard";
                    return;
                }
            }
            if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\thiscord.zip"))
            {
                LegalTextbox.Text = "Error (File not downloaded)";
                return;
            }
            LegalTextbox.Text = "Download Complete";
            try
            {
                if (Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master"))
                {
                    Directory.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master", true);
                }
                ZipFile.ExtractToDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\thiscord.zip", $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord");
                string sourceFile = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master\\src\\Update.exe";
                string destinationFile = $"{ Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe";
                File.Move($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe", $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update_Discord.exe");
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (Exception error)
            {
                Clipboard.SetText(error.ToString());
                LegalTextbox.Text = $"Error : copied to clipboard";
                return;
            }
            LegalTextbox.Text = "Extracted and Copied";
            InstallButton.Text = "Installed";
            InstallButton.Enabled = false;
            VersionTextBox.Text = LatestVersion.ToString();
        }

        private void sz_Load(object sender, EventArgs e)
        {
            WebClient Client = new WebClient();
            string Terms = Client.DownloadString("https://raw.githubusercontent.com/RJ-Infinity/ThisCord/master/terms.txt");
            LatestVersion = new Version(JSON.StringToObject(Client.DownloadString("https://raw.githubusercontent.com/RJ-Infinity/ThisCord/master/version.json"))["version"].StringData);
            bool updateRequired = JSON.StringToObject(Client.DownloadString("https://raw.githubusercontent.com/RJ-Infinity/ThisCord/master/version.json"))["required"].BoolData;
            TermsTextBox.Text = Terms;
            bool thiscordInstalled = Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master");
            if(thiscordInstalled) {
                InstalledVersion = new Version(JSON.StringToObject(File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master\\version.json"))["version"].StringData);
                VersionTextBox.Text = InstalledVersion.ToString();
                if(InstalledVersion < LatestVersion)
                {
                    if (updateRequired)
                    {
                        InstallButton.Text = $"Required Update Available ({InstalledVersion} >> {LatestVersion})";
                        MessageBox.Show("A required update has been fetched, click OK to install", "Update");
                        InstallButton.PerformClick();
                    } else {
                        InstallButton.Text = $"Update Available ({InstalledVersion} >> {LatestVersion})";
                    }
                }
                else
                {
                    InstallButton.Text = "Re-install Thiscord";
                }
            }
        }

        private void UninstallButton_click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("discord"))
            {
                process.Kill();
            }
            Thread.Sleep(1000);
            UninstallTextbox.Text = "Uninstalling...";
            if (Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord"))
            {
                Directory.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord", true);
            }
            UninstallTextbox.Text = "Removed Folder";
            if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update_Discord.exe"))
            {
                File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe");
                File.Move($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update_Discord.exe", $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe");
            }
            UninstallTextbox.Text = "Reset Discord Appdata";
            UninstallButton.Text = "Not Installed";
            UninstallButton.Enabled = false;
        }

        private void UninstallButton_MouseEnter(object sender, EventArgs e)
        {
            UninstallButton.BackColor = Color.FromArgb(14, 14, 14);
        }

        private void UninstallButton_MouseLeave(object sender, EventArgs e)
        {
            UninstallButton.BackColor = Color.FromArgb(34, 34, 34);
        }
    }
}