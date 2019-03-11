using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using MyHttpListener.Core.Common;

namespace MyHttpListener.Core
{
    class Program
    {
        static BasePipe _entrancePipe;

        static void Main(string[] args)
        {
            //调用开发者批量注册的管道
            PipeConfig.Register();
            //注册最后一个WebPipe管道
            PipeBuilder.Bind(typeof(WebPipe));
            //创建管道
            _entrancePipe = PipeBuilder.Build();

            //基于HttpListener的web容器，实际也是依赖于http.sys来监听当前服务器的所有http请求
            HttpListener httpListener = new HttpListener();
            List<string> prefixList = new List<string>() {
                "http://localhost:20001/",
                "http://localhost:20002/",
                "http://localhost:20003/"
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
            _entrancePipe.Process(context);
        }
    }
}
