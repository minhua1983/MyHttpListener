using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Common
{
    public class BaseRequest<TResponse> where TResponse : BaseResponse
    {
        public TResponse GetResponse()
        {
            return default(TResponse);
        }
    }
}
