using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Common
{
    public interface IPipe
    {
        void Process(HttpListenerContext context);
    }
}
