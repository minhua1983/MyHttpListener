using MyHttpListener.Core.Common;
using MyHttpListener.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Services.Product
{
    public class ListService : BaseService<ListServiceResponse>
    {
        public override ListServiceResponse Process(BaseRequest<ListServiceResponse> model)
        {
            //throw new NotImplementedException();
            return new ListServiceResponse();
        }
    }
}
