namespace Thiscord_Installer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ThiscordBanner = new System.Windows.Forms.PictureBox();
            this.TermsTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InstallButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UninstallButton = new System.Windows.Forms.Button();
            this.UninstallTextbox = new System.Windows.Forms.TextBox();
            this.LegalTextbox = new System.Windows.Forms.TextBox();
            this.VersionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThiscordBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = global::Thiscord_Installer.Properties.Resources.thiscordbanner;
            this.pictureBox1.Location = new System.Drawing.Point(286, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ThiscordBanner
            // 
            this.ThiscordBanner.BackColor = System.Drawing.Color.Transparent;
            this.ThiscordBanner.Image = global::Thiscord_Installer.Properties.Resources.thiscordbanner;
            this.ThiscordBanner.Location = new System.Drawing.Point(17, 12);
            this.ThiscordBanner.Name = "ThiscordBanner";
            this.ThiscordBanner.Size = new System.Drawing.Size(750, 79);
            this.ThiscordBanner.TabIndex = 1;
            this.ThiscordBanner.TabStop = false;
            // 
            // TermsTextBox
            // 
            this.TermsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TermsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TermsTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TermsTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TermsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.TermsTextBox.HideSelection = false;
            this.TermsTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TermsTextBox.Location = new System.Drawing.Point(17, 122);
            this.TermsTextBox.Name = "TermsTextBox";
            this.TermsTextBox.ReadOnly = true;
            this.TermsTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TermsTextBox.Size = new System.Drawing.Size(750, 238);
            this.TermsTextBox.TabIndex = 2;
            this.TermsTextBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 5);
            this.panel1.TabIndex = 3;
            // 
            // InstallButton
            // 
            this.InstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallButton.ForeColor = System.Drawing.Color.White;
            this.InstallButton.Location = new System.Drawing.Point(644, 398);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(128, 41);
            this.InstallButton.TabIndex = 5;
            this.InstallButton.Text = "Install Thiscord";
            this.InstallButton.UseVisualStyleBackColor = false;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            this.InstallButton.MouseEnter += new System.EventHandler(this.InstallButton_MouseEnter);
            this.InstallButton.MouseLeave += new System.EventHandler(this.InstallButton_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(16, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 240);
            this.panel2.TabIndex = 6;
            // 
            // UninstallButton
            // 
            this.UninstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.UninstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UninstallButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UninstallButton.ForeColor = System.Drawing.Color.White;
            this.UninstallButton.Location = new System.Drawing.Point(12, 398);
            this.UninstallButton.Name = "UninstallButton";
            this.UninstallButton.Size = new System.Drawing.Size(128, 41);
            this.UninstallButton.TabIndex = 8;
            this.UninstallButton.Text = "Uninstall Thiscord";
            this.UninstallButton.UseVisualStyleBackColor = false;
            this.UninstallButton.Click += new System.EventHandler(this.UninstallButton_click);
            this.UninstallButton.MouseEnter += new System.EventHandler(this.UninstallButton_MouseEnter);
            this.UninstallButton.MouseLeave += new System.EventHandler(this.UninstallButton_MouseLeave);
            // 
            // UninstallTextbox
            // 
            this.UninstallTextbox.BackColor = System.Drawing.Color.Black;
            this.UninstallTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UninstallTextbox.Enabled = false;
            this.UninstallTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UninstallTextbox.ForeColor = System.Drawing.Color.Gainsboro;
            this.UninstallTextbox.HideSelection = false;
            this.UninstallTextbox.Location = new System.Drawing.Point(146, 413);
            this.UninstallTextbox.Multiline = true;
            this.UninstallTextbox.Name = "UninstallTextbox";
            this.UninstallTextbox.ReadOnly = true;
            this.UninstallTextbox.Size = new System.Drawing.Size(167, 36);
            this.UninstallTextbox.TabIndex = 9;
            // 
            // LegalTextbox
            // 
            this.LegalTextbox.BackColor = System.Drawing.Color.Black;
            this.LegalTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LegalTextbox.Enabled = false;
            this.LegalTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LegalTextbox.ForeColor = System.Drawing.Color.Gainsboro;
            this.LegalTextbox.HideSelection = false;
            this.LegalTextbox.Location = new System.Drawing.Point(471, 398);
            this.LegalTextbox.Multiline = true;
            this.LegalTextbox.Name = "LegalTextbox";
            this.LegalTextbox.ReadOnly = true;
            this.LegalTextbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LegalTextbox.Size = new System.Drawing.Size(167, 36);
            this.LegalTextbox.TabIndex = 7;
            this.LegalTextbox.Text = "By clicking \"Install Thiscord\" you agree to the terms set out above";
            this.LegalTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VersionTextBox
            // 
            this.VersionTextBox.BackColor = System.Drawing.Color.Black;
            this.VersionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VersionTextBox.Enabled = false;
            this.VersionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.VersionTextBox.Location = new System.Drawing.Point(720, 443);
            this.VersionTextBox.Name = "VersionTextBox";
            this.VersionTextBox.ReadOnly = true;
            this.VersionTextBox.Size = new System.Drawing.Size(52, 15);
            this.VersionTextBox.TabIndex = 10;
            this.VersionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.VersionTextBox);
            this.Controls.Add(this.UninstallTextbox);
            this.Controls.Add(this.UninstallButton);
            this.Controls.Add(this.LegalTextbox);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TermsTextBox);
            this.Controls.Add(this.ThiscordBanner);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Thiscord Installer";
            this.Load += new System.EventHandler(this.sz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThiscordBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ThiscordBanner;
        private System.Windows.Forms.RichTextBox TermsTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button UninstallButton;
        private System.Windows.Forms.TextBox UninstallTextbox;
        private System.Windows.Forms.TextBox LegalTextbox;
        private System.Windows.Forms.TextBox VersionTextBox;
    }
}

