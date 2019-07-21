using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniWebServer
{
    public static class FileManager
    {
        public static void SendToClient(string filePath, HttpListenerResponse response)
        {
            if (!File.Exists(filePath))
                return;

            //Read the file to the web stream 4096 bytes at a time.
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                for (int i = 0; i < fileStream.Length;)
                {
                    //Find the next read size | if the the current read position is less than the block size, read the rest of the bytes.
                    long readSize = fileStream.Length - i < 4096 ? fileStream.Length - i : 4096;

                    byte[] buffer = new byte[readSize];
                    int read = fileStream.Read(buffer, 0, (int)readSize);
                    response.OutputStream.Write(buffer, 0, read);

                    //Increment the for loop by the bytes read.
                    i += (int)read;
                }
            }
        }

        public static string GetLocalLocation(string webLocation)
        {
            // /resource.html -> C:\blah\blah\blah\blah\HyperTextDocuments\resource.html

            StringBuilder resourceAddress = new StringBuilder();
            resourceAddress.Append(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "HyperTextDocuments");
            resourceAddress.Append(CleanWebLocation(webLocation));

            Log.Info($"Resource Address Translation: {webLocation} -> {resourceAddress.ToString()}");
            return resourceAddress.ToString();
        }

        private static string CleanWebLocation(string webLocation)
        {
            // Good tetsing tool DotDotPwn
            ///https://tools.kali.org/information-gathering/dotdotpwn
            //Clean special directory chars example: ../ | ./

            //****Revise this, this looks DIRTY!!!****
            return webLocation.Replace("../", "/").Replace("./", "/").Replace(@"..\", "/").Replace(@".\", "/").Replace(@"//", "/").Replace(@"\\", "/").Replace('/', Path.DirectorySeparatorChar);
        }
    }
}