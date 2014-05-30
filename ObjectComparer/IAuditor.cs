using System.Collections.Generic;

namespace ObjectComparer
{
    public interface IAuditor
    { 
        List<string> GetChanges(object objectA, object objectB);
    }
}
