﻿using MyHttpListener.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core.Pipes
{
    public class ModelValidPipeline : BasePipeline
    {
        public ModelValidPipeline(BasePipeline basePipeline) : base(basePipeline)
        {

        }

        public override void Process(HttpListenerContext context)
        {
            NextPipeline.Process(context);
        }
    }
}