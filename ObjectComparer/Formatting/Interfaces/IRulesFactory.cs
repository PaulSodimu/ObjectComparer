using System.Collections.Generic;
using ObjectComparer.Formatting.Rules.Interfaces;

namespace ObjectComparer.Formatting.Interfaces
{
    public interface IRulesFactory
    {
        /// <summary>
        /// Returns a list of all format rules.
        /// </summary>
        /// <returns></returns>
        List<IFormatRule> Get();
    }
}