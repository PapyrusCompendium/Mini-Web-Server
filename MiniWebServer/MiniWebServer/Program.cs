using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniWebServer
{
    static class Program
    {
        public static RichWriter RichWriter { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RichWriter = new RichWriter();
            Console.SetOut(RichWriter);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WebServerInterface());
        }
    }

    public class RichWriter : TextWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
        public RichTextBox TextOut { private get; set; }

        public override void Write(string data)
        {
            if (TextOut != null)
                TextOut.Invoke(new MethodInvoker(() => TextOut.AppendText(data)));

            base.Write(data);
        }

        public override void WriteLine(string data)
        {
            if (TextOut != null)
            {
                TextOut.Invoke(new MethodInvoker(() =>
                {
                    TextOut.AppendText(data + Environment.NewLine);
                    TextOut.AppendText("System@MiniServer:~$ ");
                }));
            }

            base.WriteLine(data);
        }
    }
}