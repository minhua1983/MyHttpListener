using MyHttpListener.Core.Common;
using MyHttpListener.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Services.Product
{
    public class ListService : BaseService<ListServiceRequest, ListServiceResponse>
    {
        public override ListServiceResponse Process(ListServiceRequest model)
        {
            //throw new NotImplementedException();
            return new ListServiceResponse()
            {
                ReturnData = model
            };
        }
    }
}
