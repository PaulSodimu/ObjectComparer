using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Workers.Interfaces
{
    public interface IPropertyComparer
    {
        string CompareProperties(KeyValuePair<string, string> propA, KeyValuePair<string, string> propB);
    }
}
