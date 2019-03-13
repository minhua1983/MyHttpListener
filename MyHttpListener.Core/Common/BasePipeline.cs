using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Common
{
    public abstract class BasePipeline : IPipeline
    {
        //指定下一个Pipe实例
        protected BasePipeline NextPipeline { get; private set; }

        //抽象方法，强制子类实现Process方法
        protected abstract void InnerProcess(HttpListenerContext context);

        public BasePipeline(BasePipeline nextPipeline)
        {
            NextPipeline = nextPipeline;
        }

        /// <summary>
        /// 实现接口Process方法来处理当前请求
        /// </summary>
        /// <param name="context"></param>
        public void Process(HttpListenerContext context)
        {
            //InnerProcess之前
            OnInnerProcessExecuting(context);

            //切片前
            InnerProcess(context);
            //切片后

            //InnerProcess之后
            OnInnerProcessExecuted(context);
        }

        /// <summary>
        /// InnerProcess处理之前的拦截
        /// </summary>
        /// <param name="context"></param>
        protected virtual void OnInnerProcessExecuting(HttpListenerContext context)
        {
            //InnerProcess执行之前
        }

        /// <summary>
        /// InnerProcess处理之后的拦截
        /// </summary>
        /// <param name="context"></param>
        protected virtual void OnInnerProcessExecuted(HttpListenerContext context)
        {
            //InnerProcess执行之后
        }
    }
}
