using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniWebServer
{
    public static class WebUtils
    {
        public static void EndStream(HttpListenerResponse response, System.Net.HttpStatusCode status, string responseData = "")
        {
            response.Headers["Access-Control-Allow-Headers"] = "X-Requested-With, Content-Type, Authorization";
            response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, DELETE, OPTIONS";
            response.Headers["Access-Control-Allow-Origin"] = "*";
            response.ContentType = "application/json";
            response.StatusCode = (int)status;

            if (responseData.Length > 0)
            {
                byte[] Buffer = Encoding.UTF8.GetBytes(responseData);
                Stream stream = response.OutputStream;
                stream.Write(Buffer, 0, Buffer.Length);
            }

            try
            {
                response.OutputStream.Close();
                response.OutputStream.Flush();
                response.Close();
                response = null;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
        }

        public static string GetIP(HttpListenerContext context)
        {
            return context.Request.Headers.AllKeys.Contains("X-Forwarded-For") ? context.Request.Headers["X-Forwarded-For"] : context.Request.RemoteEndPoint.ToString().Split(':')[0];
        }
    }
}
