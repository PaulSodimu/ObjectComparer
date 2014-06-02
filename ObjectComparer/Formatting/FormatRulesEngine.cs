using ObjectComparer.Formatting.Interfaces;
using ObjectComparer.Workers.Interfaces;

namespace ObjectComparer.Formatting
{
    public class FormatRulesEngine : IFormatRulesEngine
    {
        private readonly IRulesFactory _rulesFactory;

        public FormatRulesEngine(IRulesFactory rulesFactory)
        {
            _rulesFactory = rulesFactory;
        }

        public string ApplyRules(string propertyName)
        {
            var rules = _rulesFactory.Get();

            foreach (var rule in rules)
            {
                rule.Apply(propertyName);
            }

            return propertyName;
        }
    }
}
