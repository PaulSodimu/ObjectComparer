using System.Text.RegularExpressions;
using Castle.Core;
using ObjectComparer.Formatting.Interfaces;
using ObjectComparer.Logging;
using ObjectComparer.Workers.Interfaces;

namespace ObjectComparer.Workers
{
    [Interceptor(typeof(LoggingAspect))]
    public class DifferenceStringGenerator : IDifferenceStringGenerator
    {
        private readonly IFormatRulesEngine _rulesEngine;

        public DifferenceStringGenerator(IFormatRulesEngine rulesEngine)
        {
            _rulesEngine = rulesEngine;
        }

        public string Generate(string propertyName, object oldValue, object newValue)
        {
            string formattedName = _rulesEngine.ApplyRules(propertyName);

            string difference = string.Format("{0} changed from '{1}' to '{2}'", Regex.Replace(formattedName, "(\\B[A-Z])", " $1"), oldValue, newValue);

            return difference;
        }
    }
}
