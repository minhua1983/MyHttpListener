using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Common
{
    public abstract class BaseService<TRequest, TResponse>
        where TRequest : BaseRequest<TResponse>
        where TResponse : BaseResponse
    {
        public abstract TResponse Process(TRequest model);
    }
}
