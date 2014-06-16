using System.Collections.Generic;

namespace ObjectComparer.Workers.Interfaces
{
    public interface IPropertyComparer
    {
        string CompareProperties(KeyValuePair<string, string> propA, KeyValuePair<string, string> propB);
    }
}
