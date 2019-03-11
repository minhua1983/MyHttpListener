using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Common
{
    public class BaseResponse
    {
        public int ReturnCode { get; set; } = 1;
        public string ReturnMsg { get; set; } = "成功";
        public object ReturnData { get; set; }
        public DateTime ReturnTime { get; set; } = DateTime.Now;
    }
}
