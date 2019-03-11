using MyHttpListener.Core.Pipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core
{
    public class PipeConfig
    {
        public static void Register()
        {
            PipeBuilder.Bind(typeof(AuthenticationPipe));
            PipeBuilder.Bind(typeof(ModelValidPipe));
        }
    }
}
