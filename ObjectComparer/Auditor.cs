using System.Linq;
using Castle.Core;
using ObjectComparer.Logging;
using ObjectComparer.Workers.Interfaces;
using System.Collections.Generic;

namespace ObjectComparer
{
    [Interceptor(typeof(LoggingAspect))]
    public class Auditor : IAuditor
    {
        private readonly IPropertyComparer _propertyComparer;
        private readonly IPropertyGetter _propertyGetter;

        public Auditor(IPropertyComparer propertyComparer, IPropertyGetter propertyGetter)
        {
            _propertyComparer = propertyComparer;
            _propertyGetter = propertyGetter;
        }


        public List<string> GetChanges(object objectA, object objectB)
        {
            List<string> changes = new List<string>();

            if (objectA.GetType() != objectB.GetType())
            {
                //Spec says only changed props should be in list. Nice message could be added here.
                //changes.Add("The objects supplied are not of the same type.");
                return changes;
            }

            //Get the properties of both objects
            var objAProps = _propertyGetter.GetProperties(objectA);
            var objBProps = _propertyGetter.GetProperties(objectB);

            //Loop through all objA properties. 
            foreach (var property in objAProps)
            {
                //probably redundant.. 
                if (objBProps.ContainsKey(property.Key))
                {
                    string result = _propertyComparer.CompareProperties(property, objBProps.FirstOrDefault(p => p.Key == property.Key));

                    if (!string.IsNullOrEmpty(result)) changes.Add(result);
                }
            }

            //Spec says only changed props should be in list. Nice message could be added here.
            //if (changes.Count == 0) changes.Add("No differences detected.");

            return changes;
        }
    }
}
