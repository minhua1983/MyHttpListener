using MyHttpListener.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Pipelines
{
    public class ModelValidPipeline : BasePipeline
    {
        public ModelValidPipeline(BasePipeline basePipeline) : base(basePipeline)
        {

        }

        protected override void InnerProcess(HttpListenerContext context)
        {
            NextPipeline.Process(context);
        }
    }
}
