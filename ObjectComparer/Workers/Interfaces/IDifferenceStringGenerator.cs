namespace ObjectComparer.Workers.Interfaces
{
    public interface IDifferenceStringGenerator
    {
        /// <summary>
        /// This class will generate a string to describe the change between two property values.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        /// <param name="oldValue">The old value of the changed property.</param>
        /// <param name="newValue">The new value of the changed property.</param>
        /// <returns>Returns a string describing the change</returns>
        string Generate(string propertyName, object oldValue, object newValue);
    }
}
