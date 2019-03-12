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
        public abstract void Process(HttpListenerContext context);

        public BasePipeline(BasePipeline nextPipeline)
        {
            NextPipeline = nextPipeline;
        }
    }
}
