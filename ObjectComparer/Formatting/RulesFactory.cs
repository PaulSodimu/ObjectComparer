using System.Collections.Generic;
using ObjectComparer.Formatting.Interfaces;
using ObjectComparer.Formatting.Rules;
using ObjectComparer.Formatting.Rules.Interfaces;

namespace ObjectComparer.Formatting
{
    public class RulesFactory : IRulesFactory
    {
        public List<IFormatRule> Get()
        {
            var formatRules = new List<IFormatRule>
            {
                new CamelCaseSplitRule()
            };

            return formatRules;
        }
    }
}
