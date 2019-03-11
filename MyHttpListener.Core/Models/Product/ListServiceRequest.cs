using MyHttpListener.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Models.Product
{
    public class ListServiceRequest : BaseRequest<ListServiceResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
