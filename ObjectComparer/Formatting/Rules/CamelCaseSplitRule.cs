using System;
using System.Text.RegularExpressions;
using ObjectComparer.Formatting.Rules.Interfaces;

namespace ObjectComparer.Formatting.Rules
{
    public class CamelCaseSplitRule : IFormatRule
    { 
        public string Apply(string input)
        {
            var formattedString = Regex.Replace(input, "(\\B[A-Z])", " $1");

            return formattedString;
        }
    }
}
