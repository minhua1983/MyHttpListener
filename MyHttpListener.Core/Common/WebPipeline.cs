using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;

namespace MyHttpListener.Core.Common
{
    public class WebPipeline : BasePipeline
    {
        public WebPipeline(BasePipeline nextPipeline) : base(nextPipeline)
        {

        }

        protected override void InnerProcess(HttpListenerContext context)
        {
            //作为整个管道的最后一步，则自己处理请求
            object returnObject;
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string path = context.Request.RawUrl;
            if (path.IndexOf("?") >= 0) path = path.Split('?')[0];
            //尝试清空一下最后的一个“/”符号
            if (path.EndsWith("/")) path = path.Substring(0, path.Length - 1);
            //如果还有“/”符号
            if (path.IndexOf(@"/") >= 0)
            {
                //分割path
                string[] pathArray = path.Split('/');
                //获取服务名称
                string serviceName = pathArray[pathArray.Length - 1];
                //获取服务完整名称
                string serviceFullName = path.Replace("/", ".");
                //获取服务类类型
                Type type = Type.GetType("MyHttpListener.Core.Services" + serviceFullName, false, true);
                if (type != null)
                {
                    //实例化服务类
                    object service = Activator.CreateInstance(type);
                    //获取方法信息类
                    MethodInfo methodInfo = type.GetMethods().ToList().Where(mi => mi.Name == "Process").FirstOrDefault();
                    //获取参数信息类
                    ParameterInfo parameterInfo = methodInfo.GetParameters()[0];
                    //获取参数类型
                    Type parameterType = parameterInfo.ParameterType;
                    //读取请求体的内容
                    string requestParameter = "";
                    if (request.HttpMethod.ToUpper() == "POST")
                    {
                        using (StreamReader reader = new StreamReader(request.InputStream))
                        {
                            requestParameter = reader.ReadToEnd();
                        }
                    }
                    else
                    {
                        //string querystring = request.QueryString;
                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        foreach (string key in request.QueryString.Keys)
                        {
                            dictionary.Add(key, request.QueryString[key]);
                        }
                        requestParameter = JsonConvert.SerializeObject(dictionary);
                    }
                    //序列化成方法的参数实例
                    object parameter = JsonConvert.DeserializeObject(requestParameter, parameterType);
                    //执行方法并返回对象
                    returnObject = methodInfo.Invoke(service, new object[] { parameter });
                }
                else
                {
                    returnObject = new BaseResponse()
                    {
                        ReturnCode = -1,
                        ReturnMsg = "未找到相关服务"
                    };
                }
                //序列化返回对象
                string responseBody = JsonConvert.SerializeObject(returnObject);
                response.ContentType = "application/json";
                response.ContentEncoding = Encoding.UTF8;
                //将序列化后的内容写入响应流
                using (StreamWriter writer = new StreamWriter(response.OutputStream))
                {
                    writer.Write(responseBody);
                }
            }
        }
    }
}
