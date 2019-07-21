using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniWebServer
{
    public partial class WebServerInterface : Form
    {
        private WebServer webServer;
        private LogConsole logConsole;

        public WebServerInterface()
        {
            InitializeComponent();
        }

        public int GetPortNumber()
        {
            return (int)webServerPort.Value;
        }

        public void SetServerStatus(bool online)
        {
            serverStatusLabel.Text = online ? "Online" : "Offline";
            serverStatusLabel.ForeColor = online ? Color.Green : Color.Gray;
            webServerPort.Enabled = !online;
        }

        public void UpdateFileLayout(string fileName, string fullPath, bool removed = false)
        {
            if (Directory.Exists(fullPath))
                return;

            if (removed)
            {
                if (webServerFiles.Controls.Cast<Control>().Any(i => (string)i.Tag == fullPath))
                    webServerFiles.Controls.Remove(webServerFiles.Controls.Cast<Control>().Single(i => (string)i.Tag == fullPath));
                return;
            }

            if (webServerFiles.Controls.Cast<Control>().Any(i => (string)i.Tag == fullPath))
                webServerFiles.Controls.Remove(webServerFiles.Controls.Cast<Control>().Single(i => (string)i.Tag == fullPath));

            Panel hyperTextDocument = new Panel() { Size = new Size(132, 37), BackColor = Color.FromArgb(25, 25, 28), Tag = fullPath };
            hyperTextDocument.Click += (s, e) => Process.Start($"http://127.0.0.1/{fileName}");

            Label titleLabel = new Label() { Location = new Point(0, 12), BackColor = Color.FromArgb(25, 25, 28), ForeColor = Color.White, Text = fileName };
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            titleLabel.Click += (s, e) => Process.Start($"http://127.0.0.1/{fileName}");

            hyperTextDocument.Controls.Add(titleLabel);
            webServerFiles.Controls.Add(hyperTextDocument);
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            if (webServer != null)
                webServer.Start();
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            if (webServer != null)
                webServer.Stop();
        }

        private void WebServerInterface_Load(object sender, EventArgs e) => webServer = new WebServer(this);

        private void HideToolStripMenuItem_Click(object sender, EventArgs e) => this.Hide();

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e) => this.Show();

        private void WebServerInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            webServer.Stop();
            Environment.Exit(0x00);
        }

        private void ToggleConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logConsole != null)
                logConsole.Invoke(new MethodInvoker(() => logConsole.Close()));

            new Thread(() =>
            {
                logConsole = new LogConsole();
                logConsole.ShowDialog();
                logConsole.Dispose();
                logConsole = null;
            }).Start();
        }
    }
}