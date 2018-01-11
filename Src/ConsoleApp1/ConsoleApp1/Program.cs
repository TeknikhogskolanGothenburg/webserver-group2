using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // URI prefixes are required,
            // for example "http://contoso.com:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Listening...");
            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request. 
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                switch (request.RawUrl.Split(new[] { '.' }).Last())
                {
                    case "jpg": response.ContentType = "image/jpg"; break;
                    case "htm": response.ContentType = "htm"; break;
                    case "html": response.ContentType = "text/html"; break;
                    case "css": response.ContentType = "css"; break;
                    case "js": response.ContentType = "js"; break;
                    case "gif": response.ContentType = "gif"; break;
                    case "pdf": response.ContentType = "pdf"; break;

                }
                if (request.RawUrl.EndsWith(".html") || request.RawUrl.EndsWith(".htm"))
                {
                    response.ContentType = "text/html";
                }
                if (request.RawUrl.EndsWith(".jg") || request.RawUrl.EndsWith(".htm"))
                {
                    
                }
                response.ContentEncoding = System.Text.Encoding.UTF8;
                // Construct a response.
                //string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                byte[] buffer = File.ReadAllBytes("Content/" + request.RawUrl);
                Directory.GetFiles("Content");
                
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            listener.Stop();

        }

    }
}