using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniWebServer
{
    public partial class LogConsole : Form
    {
        public LogConsole()
        {
            InitializeComponent();
        }

        private void LogConsole_Load(object sender, EventArgs e)
        {
            Program.RichWriter.TextOut = consoleOut;
        }

        private void LogConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RichWriter.TextOut = null;
        }
    }
}
