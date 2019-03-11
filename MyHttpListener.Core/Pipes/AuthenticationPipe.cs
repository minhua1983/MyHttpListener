using MyHttpListener.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Pipes
{
    public class AuthenticationPipe : BasePipe
    {
        public AuthenticationPipe(BasePipe basePipe) : base(basePipe)
        {

        }

        public override void Process(HttpListenerContext context)
        {
            NextPipe.Process(context);
        }
    }
}
