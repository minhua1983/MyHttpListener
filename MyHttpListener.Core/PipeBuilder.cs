using MyHttpListener.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyHttpListener.Core
{
    public class PipeBuilder
    {
        static List<Type> _pipeTypes = new List<Type>();

        public static BasePipe Build()
        {
            BasePipe nextPipe = null;
            _pipeTypes.Reverse();
            foreach (Type pipeType in _pipeTypes)
            {
                BasePipe basePipe = (BasePipe)Activator.CreateInstance(pipeType, nextPipe);
                nextPipe = basePipe;
            }
            return nextPipe;
        }

        public static void Bind(Type t)
        {
            _pipeTypes.Add(t);
        }
    }
}
