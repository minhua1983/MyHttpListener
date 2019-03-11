using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Common
{
    public abstract class BasePipe : IPipe
    {
        //指定下一个Pipe实例
        protected BasePipe NextPipe { get; private set; }

        //抽象方法，强制子类实现Process方法
        public abstract void Process(HttpListenerContext context);

        public BasePipe(BasePipe nextPipe)
        {
            NextPipe = nextPipe;
        }
    }
}
