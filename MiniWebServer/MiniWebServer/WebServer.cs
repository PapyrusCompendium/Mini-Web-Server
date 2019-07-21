using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniWebServer
{
    public class WebServer
    {
        private WebServerInterface ServerInterface { get; }
        private WebListener webListener;

        private void WebListener_WebServerStopped() => ServerInterface.SetServerStatus(false);

        private void WebListener_WebServerStarted() => ServerInterface.SetServerStatus(true);

        public void Start()
        {
            webListener.SetPrefix($"http://*:{ServerInterface.GetPortNumber()}/");
            webListener.Start();
        }

        public void Stop() => webListener.Stop();

        public WebServer(WebServerInterface serverInterface)
        {
            if (!HyperTextDocumentsExists())
                return;

            ServerInterface = serverInterface;
            webListener = new WebListener($"http://*:{ServerInterface.GetPortNumber()}/");
            webListener.HttpCall += WebListener_HttpCall;
            webListener.WebServerStarted += WebListener_WebServerStarted;
            webListener.WebServerStopped += WebListener_WebServerStopped;

            foreach (var file in Directory.GetFiles("HyperTextDocuments"))
            {
                FileInfo fileInfo = new FileInfo(file);
                ServerInterface.Invoke(new MethodInvoker(() => ServerInterface.UpdateFileLayout(fileInfo.Name, fileInfo.FullName)));
            }

            WatchFiles();
        }

        private void WatchFiles()
        {
            //Only watch for files that have an extention
            FileSystemWatcher htdocsWatcher = new FileSystemWatcher("HyperTextDocuments", "*.*");
            htdocsWatcher.IncludeSubdirectories = true;

            htdocsWatcher.Created += HtdocsWatcher_Created;
            htdocsWatcher.Deleted += HtdocsWatcher_Deleted;
            htdocsWatcher.Renamed += HtdocsWatcher_Renamed;
            htdocsWatcher.EnableRaisingEvents = true;
        }

        private bool HyperTextDocumentsExists()
        {
            if (!Directory.Exists("HyperTextDocuments"))
            {
                Log.Error($"{Environment.CurrentDirectory + Path.DirectorySeparatorChar}HyperTextDocuments, does not exist!");
                Log.Info("Creating HyperTextDocuments folder...");
                Directory.CreateDirectory("HyperTextDocuments");
            }

            return true;
        }

        /// <summary>
        /// Invoke our server interface instance, to remove old files and add new files in the layout panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HtdocsWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            ServerInterface.Invoke(new MethodInvoker(() => ServerInterface.UpdateFileLayout(e.OldName, e.OldFullPath, true)));
            ServerInterface.Invoke(new MethodInvoker(() => ServerInterface.UpdateFileLayout(e.Name, e.FullPath)));
        }

        /// <summary>
        /// Invoke our server interface instance, to remove old files in the layout panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HtdocsWatcher_Deleted(object sender, FileSystemEventArgs e) => ServerInterface.Invoke(new MethodInvoker(() => ServerInterface.UpdateFileLayout(e.Name, e.FullPath, true)));

        /// <summary>
        /// Invoke our server interface instance, to update new files in the layout panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HtdocsWatcher_Created(object sender, FileSystemEventArgs e) => ServerInterface.Invoke(new MethodInvoker(() => ServerInterface.UpdateFileLayout(e.Name, e.FullPath)));

        /// <summary>
        /// This will be called if the server receives a request.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="listener"></param>
        private void WebListener_HttpCall(System.Net.HttpListenerContext context, System.Net.HttpListener listener)
        {
            string resourceLocation = FileManager.GetLocalLocation(context.Request.RawUrl);

            if(!File.Exists(resourceLocation))
            {
                WebUtils.EndStream(context.Response, System.Net.HttpStatusCode.NotFound, "Resource not found!");
                return;
            }

            FileManager.SendToClient(resourceLocation, context.Response);
            WebUtils.EndStream(context.Response, System.Net.HttpStatusCode.Accepted);
        }
    }
}