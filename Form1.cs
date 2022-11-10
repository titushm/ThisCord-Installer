using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thiscord_Installer
{
    public partial class MainForm : Form
    {
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
            string dir;
            dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\";
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("Discord doesnt seem to be installed\rInstall it at https://discord.com/download");
                return;
            }
            TermsTextBox.Hide();
            panel2.Hide();
            dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master";
            if (Directory.Exists(dir))
            {
                LegalTextbox.Text = "Uninstalling...";
                dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord";
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }
                UninstallTextbox.Text = "Removed Folder";
                dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update_Discord.exe";
                if (File.Exists(dir))
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
                    dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\";
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
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
            dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\thiscord.zip";
            if (!File.Exists(dir))
            {
                LegalTextbox.Text = "Error (File not downloaded)";
                return;
            }
            LegalTextbox.Text = "Download Complete";
            try
            {
                dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master";
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
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
            LegalTextbox.Text = "Extracted and Copied Successfully";

            InstallButton.Text = "Installed successfully";
            InstallButton.Enabled = false;
        }

        private void sz_Load(object sender, EventArgs e)
        {
            string dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord\\ThisCord-master";
            if (Directory.Exists(dir))
            {
                InstallButton.Text = "Reinstall Thiscord";
            }
        }

        private void UninstallButton_click(object sender, EventArgs e)
        {
            UninstallTextbox.Text = "Uninstalling...";
            string dir;
            dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Thiscord";
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
            UninstallTextbox.Text = "Removed Folder";
            dir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update_Discord.exe";
            if (File.Exists(dir))
            {
                File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe");
                File.Move($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update_Discord.exe", $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Discord\\Update.exe");
            }
            UninstallTextbox.Text = "Reset Discord Appdata Successfully";
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