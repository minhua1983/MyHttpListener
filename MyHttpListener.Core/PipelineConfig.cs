using MyHttpListener.Core.Pipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpListener.Core
{
    public class PipelineConfig
    {
        /// <summary>
        /// 注册自定义管道
        /// </summary>
        public static void Register()
        {
            PipelineBuilder.Bind<AuthenticationPipeline>();
            PipelineBuilder.Bind<ModelValidPipeline>();
        }
    }
}
