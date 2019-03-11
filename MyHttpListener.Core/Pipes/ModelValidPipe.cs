using MyHttpListener.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Pipes
{
    public class ModelValidPipe : BasePipe
    {
        public ModelValidPipe(BasePipe basePipe) : base(basePipe)
        {

        }

        public override void Process(HttpListenerContext context)
        {
            NextPipe.Process(context);
        }
    }
}
