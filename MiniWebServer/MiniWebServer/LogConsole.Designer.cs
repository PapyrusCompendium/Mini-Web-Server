namespace MiniWebServer
{
    partial class LogConsole
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
            this.consoleOut = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // consoleOut
            // 
            this.consoleOut.BackColor = System.Drawing.Color.Black;
            this.consoleOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleOut.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleOut.ForeColor = System.Drawing.Color.Green;
            this.consoleOut.Location = new System.Drawing.Point(0, 0);
            this.consoleOut.Name = "consoleOut";
            this.consoleOut.ReadOnly = true;
            this.consoleOut.Size = new System.Drawing.Size(1183, 538);
            this.consoleOut.TabIndex = 0;
            this.consoleOut.Text = "System@MiniServer:~$ ";
            // 
            // LogConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1183, 538);
            this.Controls.Add(this.consoleOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LogConsole";
            this.Text = "LogConsole";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogConsole_FormClosing);
            this.Load += new System.EventHandler(this.LogConsole_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox consoleOut;
    }
}