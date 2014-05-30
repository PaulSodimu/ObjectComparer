using Castle.Core;
using ObjectComparer.Logging;
using ObjectComparer.Workers.Interfaces;
using System.Collections.Generic;

namespace ObjectComparer.Workers
{
    [Interceptor(typeof(LoggingAspect))]
    public class PropertyComparer : IPropertyComparer
    {
        private readonly IDifferenceStringGenerator _diffStringGenerator;

        public PropertyComparer(IDifferenceStringGenerator diffStringGenerator)
        {
            _diffStringGenerator = diffStringGenerator;
        }

        public string CompareProperties(KeyValuePair<string, string> propA, KeyValuePair<string, string> propB)
        {
            string result = string.Empty; 

            //Check property names are the same
            if (propA.Key == propB.Key)
            {
                //If first property is not the same as second generate string else return empty string
                result = propA.Value != propB.Value ? _diffStringGenerator.Generate(propA.Key, propA.Value, propB.Value) : string.Empty; 
            }

            return result;
        }

        
    }
}
