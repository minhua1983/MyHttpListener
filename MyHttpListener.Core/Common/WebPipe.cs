using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Common
{
    public class WebPipe : BasePipe
    {
        public WebPipe(BasePipe nextPipe) : base(nextPipe)
        {

        }

        public override void Process(HttpListenerContext context)
        {
            //作为整个管道的最后一步，则自己处理请求

            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            /*
            string json = @"{""title"":""test"",""id"":1,""time"":""" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"""}";

            response.ContentType = "application/json";
            using (StreamWriter writer = new StreamWriter(response.OutputStream))
            {
                writer.Write(json);
            }
            //*/

            string path = context.Request.RawUrl;
            if (path.IndexOf("?") >= 0) path = path.Split('?')[0];
            //尝试清空一下最后的一个“/”符号
            if (path.EndsWith("/")) path = path.Substring(0, path.Length - 1);
            //如果还有“/”符号
            if (path.IndexOf(@"/") >= 0)
            {
                //获取服务名称
                string serviceName = path.Replace("/",".");
                //获取服务类
                Type type = Type.GetType("MyHttpListener.Core.Services" + serviceName, false, true);
                int i = 0;
            }
        }
    }
}
