using MyHttpListener.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyHttpListener.Core
{
    public class PipelineBuilder
    {
        /// <summary>
        /// 管道类类型列表
        /// </summary>
        static List<Type> _pipeTypes = new List<Type>();

        /// <summary>
        /// 创建管道实例（这里用了参考了webapi中的DelegatingHandler和owin中的OwinMiddleware的连接概念，可以理解成一个类似装饰者模式的运用）
        /// </summary>
        /// <returns>返回第一个管道实例</returns>
        public static BasePipeline Build()
        {
            BasePipeline nextPipe = null;
            _pipeTypes.Reverse();
            foreach (Type pipeType in _pipeTypes)
            {
                BasePipeline basePipe = (BasePipeline)Activator.CreateInstance(pipeType, nextPipe);
                nextPipe = basePipe;
            }
            return nextPipe;
        }

        /// <summary>
        /// 绑定管道类类型（参数T不用传递，这里只是为了用到泛型T而用的）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        public static void Bind<T>(T model = default(T))
        {
            _pipeTypes.Add(typeof(T));
        }
    }
}
