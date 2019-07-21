namespace MiniWebServer
{
    partial class WebServerInterface
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebServerInterface));
            this.webServerFiles = new System.Windows.Forms.FlowLayoutPanel();
            this.startServerButton = new System.Windows.Forms.Button();
            this.stopServerButton = new System.Windows.Forms.Button();
            this.serverStatusLabel = new System.Windows.Forms.Label();
            this.statusIndicator = new System.Windows.Forms.Label();
            this.webServerPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.webServerPort)).BeginInit();
            this.trayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // webServerFiles
            // 
            this.webServerFiles.AutoScroll = true;
            this.webServerFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(28)))));
            this.webServerFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webServerFiles.Location = new System.Drawing.Point(-3, 88);
            this.webServerFiles.Name = "webServerFiles";
            this.webServerFiles.Size = new System.Drawing.Size(435, 570);
            this.webServerFiles.TabIndex = 0;
            // 
            // startServerButton
            // 
            this.startServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(28)))));
            this.startServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startServerButton.ForeColor = System.Drawing.Color.White;
            this.startServerButton.Location = new System.Drawing.Point(12, 12);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(130, 39);
            this.startServerButton.TabIndex = 1;
            this.startServerButton.Text = "Start";
            this.startServerButton.UseVisualStyleBackColor = false;
            this.startServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // stopServerButton
            // 
            this.stopServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(28)))));
            this.stopServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopServerButton.ForeColor = System.Drawing.Color.White;
            this.stopServerButton.Location = new System.Drawing.Point(273, 12);
            this.stopServerButton.Name = "stopServerButton";
            this.stopServerButton.Size = new System.Drawing.Size(130, 39);
            this.stopServerButton.TabIndex = 2;
            this.stopServerButton.Text = "Stop";
            this.stopServerButton.UseVisualStyleBackColor = false;
            this.stopServerButton.Click += new System.EventHandler(this.StopServerButton_Click);
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverStatusLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.serverStatusLabel.Location = new System.Drawing.Point(207, 65);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(54, 20);
            this.serverStatusLabel.TabIndex = 3;
            this.serverStatusLabel.Text = "Offline";
            // 
            // statusIndicator
            // 
            this.statusIndicator.AutoSize = true;
            this.statusIndicator.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusIndicator.ForeColor = System.Drawing.Color.White;
            this.statusIndicator.Location = new System.Drawing.Point(158, 65);
            this.statusIndicator.Name = "statusIndicator";
            this.statusIndicator.Size = new System.Drawing.Size(52, 20);
            this.statusIndicator.TabIndex = 3;
            this.statusIndicator.Text = "Status:";
            // 
            // webServerPort
            // 
            this.webServerPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(28)))));
            this.webServerPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webServerPort.ForeColor = System.Drawing.Color.White;
            this.webServerPort.Location = new System.Drawing.Point(148, 31);
            this.webServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.webServerPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.webServerPort.Name = "webServerPort";
            this.webServerPort.Size = new System.Drawing.Size(120, 20);
            this.webServerPort.TabIndex = 4;
            this.webServerPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(185, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Port:";
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipText = "Tray Options";
            this.trayIcon.BalloonTipTitle = "MiniServer";
            this.trayIcon.ContextMenuStrip = this.trayMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "MiniServer";
            this.trayIcon.Visible = true;
            // 
            // trayMenuStrip
            // 
            this.trayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.showToolStripMenuItem,
            this.toggleConsoleToolStripMenuItem});
            this.trayMenuStrip.Name = "trayMenuStrip";
            this.trayMenuStrip.Size = new System.Drawing.Size(181, 92);
            this.trayMenuStrip.Text = "MiniServer Control Strip";
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // toggleConsoleToolStripMenuItem
            // 
            this.toggleConsoleToolStripMenuItem.Name = "toggleConsoleToolStripMenuItem";
            this.toggleConsoleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toggleConsoleToolStripMenuItem.Text = "Toggle Console";
            this.toggleConsoleToolStripMenuItem.Click += new System.EventHandler(this.ToggleConsoleToolStripMenuItem_Click);
            // 
            // WebServerInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(414, 641);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webServerPort);
            this.Controls.Add(this.webServerFiles);
            this.Controls.Add(this.statusIndicator);
            this.Controls.Add(this.serverStatusLabel);
            this.Controls.Add(this.stopServerButton);
            this.Controls.Add(this.startServerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WebServerInterface";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "WebServer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebServerInterface_FormClosing);
            this.Load += new System.EventHandler(this.WebServerInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webServerPort)).EndInit();
            this.trayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel webServerFiles;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.Button stopServerButton;
        private System.Windows.Forms.Label serverStatusLabel;
        private System.Windows.Forms.Label statusIndicator;
        private System.Windows.Forms.NumericUpDown webServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleConsoleToolStripMenuItem;
    }
}

