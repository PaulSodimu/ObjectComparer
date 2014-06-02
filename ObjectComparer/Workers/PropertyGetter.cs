using Castle.Core;
using ObjectComparer.Logging;
using ObjectComparer.Workers.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace ObjectComparer.Workers
{
    [Interceptor(typeof(LoggingAspect))]
    public class PropertyGetter : IPropertyGetter
    {
        public Dictionary<string, string> GetProperties(object obj)
        {
            var properties = new Dictionary<string, string>();

            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                properties[pi.Name] = pi.GetValue(obj, null).ToString();
            }

            return properties;
        }
    }
}
