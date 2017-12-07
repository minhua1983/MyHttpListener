using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;

namespace MyHttpListener.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener httpListener = new HttpListener();
            List<string> prefixList = new List<string>() {
                "http://localhost:12001/",
                "http://localhost:12002/",
                "http://localhost:12003/"
            };
            prefixList.ForEach(prefix =>
            {
                httpListener.Prefixes.Add(prefix);
            });
            httpListener.Start();
            Console.WriteLine("HttpListener is started...");

            while (true)
            {
                //HttpListenerContext context =  httpListener.GetContext();
                IAsyncResult asyncResult = httpListener.BeginGetContext(null, null);
                HttpListenerContext context = httpListener.EndGetContext(asyncResult);
                ThreadPool.QueueUserWorkItem(ProcessRequest, context);
            }
        }

        static void ProcessRequest(object state)
        {
            HttpListenerContext context = state as HttpListenerContext;
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string json = @"{""title"":""test"",""id"":1,""time"":""" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"""}";

            response.ContentType = "application/json";
            using (StreamWriter writer = new StreamWriter(response.OutputStream))
            {
                writer.Write(json);
            }
        }
    }
}
