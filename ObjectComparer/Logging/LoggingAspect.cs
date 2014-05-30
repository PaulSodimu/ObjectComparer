using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace ObjectComparer.Logging
{
    public class LoggingAspect : IInterceptor
    {
        private ILogger Logger { get; set; }

        public LoggingAspect(ILogger logger)
        {
            Logger = logger;
        } 
        public void Intercept(IInvocation invocation)
        {

            if (Logger.IsDebugEnabled) Logger.Debug(CreateInvocationLogString(invocation));
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(CreateInvocationLogString(invocation), ex);
            }
        }

        public String CreateInvocationLogString(IInvocation invocation)
        {
            StringBuilder sb = new StringBuilder(100);

            sb.AppendFormat("{0}.{1}(", invocation.TargetType.Name, invocation.Method.Name);

            foreach (object argument in invocation.Arguments)
            {
                String argumentDescription = argument == null ? "null" : DumpObject(argument);
                sb.Append(argumentDescription).Append(",");
            }

            if (invocation.Arguments.Count()   > 0) sb.Length--;

            sb.Append(")");

            return sb.ToString();
        }

        private string DumpObject(object argument)
        {
            Type objtype = argument.GetType(); 

            return objtype.Name.ToString(); 
        }
    }
    
}
