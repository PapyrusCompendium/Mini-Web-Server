using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniWebServer
{
    public class WebListener
    {
        public delegate void HttpCallEvent(HttpListenerContext context, HttpListener listener);
        public event HttpCallEvent HttpCall;

        public delegate void WebServerStoppedEvent();
        public event WebServerStoppedEvent WebServerStopped;

        public delegate void WebServerStartedEvent();
        public event WebServerStartedEvent WebServerStarted;

        public HttpListener listener;
        public Thread listenerThread;

        public WebListener(string prefix)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(prefix);
        }

        public void Start()
        {
            listenerThread = new Thread(() =>
            {
                listener.Start();
                Log.Info($"Http Listener started - Prefix: {listener.Prefixes.First()}");

                while (listener.IsListening)
                    Listen();
            });

            listenerThread.Name = "Http_Listener";
            listenerThread.Start();

            if (WebServerStarted.GetInvocationList().Count() > 0)
                WebServerStarted.Invoke();                 
        }

        public void Listen()
        {
            HttpListenerContext context;
            context = listener.GetContext();
            Task.Run(() =>
            {
                if (HttpCall.GetInvocationList().Count() > 0)
                {
                    HttpCall.Invoke(context, listener);
                    context.Response.Abort();
                    context = null;
                    GC.Collect();
                    return;
                }

                Log.Error("WebServer has an empty invocation list. This should never happen!");
            });
        }

        public void Stop()
        {
            if (!listener.IsListening)
                return;

            try
            {
                listener.Stop();
                listenerThread.Interrupt();
                listenerThread.Abort();
                listenerThread = null;
            }
            catch (ThreadAbortException e)
            {
                Log.Error($"Error stopping webserver, {e.Message}");
                Log.Error($"Stack Trace: {e.StackTrace}");
            }
            finally
            {
                if (WebServerStopped.GetInvocationList().Count() > 0)
                    WebServerStopped.Invoke();
            }
        }
    }
}
