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
            // Note: The GetContext method blocks while waiting for a request. 
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;
            response.ContentType = "text/html";
            // Construct a response.
            //string responseString = "index.html";
            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            byte[] buffer = GetFile("index.html");
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
            listener.Stop();
            
        }

        public static byte[] GetFile(string file)
        {
            if (!File.Exists(file))
            {
                return null;
            }
            FileStream readIn = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024 * 1000];
            int nRead = readIn.Read(buffer, 0, 10240);
            int total = 0;
            while (nRead > 0)
            {
                total += nRead;
                nRead = readIn.Read(buffer, total, 10240);
            }
            readIn.Close();
            byte[] maxresponse_complete = new byte[total];
            System.Buffer.BlockCopy(buffer, 0, maxresponse_complete, 0, total);
            return maxresponse_complete;
        }
    }
}
