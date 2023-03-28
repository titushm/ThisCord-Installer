namespace Thiscord_Installer
{
    partial class FormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormView));
            this.ThiscordBanner = new System.Windows.Forms.PictureBox();
            this.Terms = new System.Windows.Forms.RichTextBox();
            this.ModifyDiscord = new System.ComponentModel.BackgroundWorker();
            this.InstallingBar = new System.Windows.Forms.ProgressBar();
            this.InstallButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ThiscordBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // ThiscordBanner
            // 
            this.ThiscordBanner.Image = global::Thiscord_Installer.Properties.Resources.thiscordbanner;
            this.ThiscordBanner.Location = new System.Drawing.Point(-52, -1);
            this.ThiscordBanner.Name = "ThiscordBanner";
            this.ThiscordBanner.Size = new System.Drawing.Size(856, 122);
            this.ThiscordBanner.TabIndex = 0;
            this.ThiscordBanner.TabStop = false;
            // 
            // Terms
            // 
            this.Terms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.Terms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Terms.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Terms.ForeColor = System.Drawing.Color.White;
            this.Terms.Location = new System.Drawing.Point(3, 127);
            this.Terms.Name = "Terms";
            this.Terms.ReadOnly = true;
            this.Terms.Size = new System.Drawing.Size(785, 254);
            this.Terms.TabIndex = 1;
            this.Terms.Text = "";
            // 
            // ModifyDiscord
            // 
            this.ModifyDiscord.WorkerReportsProgress = true;
            this.ModifyDiscord.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ModifyDiscord_DoWork);
            this.ModifyDiscord.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ModifyDiscord_ProgressChanged);
            // 
            // InstallingBar
            // 
            this.InstallingBar.Location = new System.Drawing.Point(309, 443);
            this.InstallingBar.Name = "InstallingBar";
            this.InstallingBar.Size = new System.Drawing.Size(182, 10);
            this.InstallingBar.TabIndex = 3;
            // 
            // InstallButton
            // 
            this.InstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(128)))), ((int)(((byte)(70)))));
            this.InstallButton.FlatAppearance.BorderSize = 0;
            this.InstallButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(86)))), ((int)(((byte)(43)))));
            this.InstallButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(99)))), ((int)(((byte)(52)))));
            this.InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallButton.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallButton.ForeColor = System.Drawing.Color.White;
            this.InstallButton.Location = new System.Drawing.Point(309, 387);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(182, 50);
            this.InstallButton.TabIndex = 6;
            this.InstallButton.Tag = "Install";
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = false;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(800, 459);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.InstallingBar);
            this.Controls.Add(this.Terms);
            this.Controls.Add(this.ThiscordBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormView";
            this.Text = "Installer";
            this.Load += new System.EventHandler(this.FormView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ThiscordBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ThiscordBanner;
        private System.Windows.Forms.RichTextBox Terms;
        private System.ComponentModel.BackgroundWorker ModifyDiscord;
        private System.Windows.Forms.ProgressBar InstallingBar;
        private System.Windows.Forms.Button InstallButton;
    }
}

