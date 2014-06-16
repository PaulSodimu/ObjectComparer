using System.Collections.Generic;

namespace ObjectComparer.Workers.Interfaces
{
    public interface IPropertyGetter
    {   
        /// <summary>
        /// Returns all the public properties of object in a dictionary.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns a dictionary containing the names and values of the object properties</returns>
        Dictionary<string, string> GetProperties(object obj);
    }
}
