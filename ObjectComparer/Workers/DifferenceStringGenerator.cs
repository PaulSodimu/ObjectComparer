using Castle.Core;
using ObjectComparer.Logging;
using ObjectComparer.Workers.Interfaces;

namespace ObjectComparer.Workers
{
    [Interceptor(typeof(LoggingAspect))]
    public class DifferenceStringGenerator : IDifferenceStringGenerator
    {
        public string Generate(string propertyName, object oldValue, object newValue)
        {
            string difference = string.Format("{0} changed from '{1}' to '{2}'", propertyName, oldValue, newValue);

            return difference;
        }
    }
}
