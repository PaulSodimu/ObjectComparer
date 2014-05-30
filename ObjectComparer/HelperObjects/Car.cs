
namespace ObjectComparer.HelperObjects
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public override string ToString()
        {
            return string.Format("A Car with {0} wheels and {1} doors.", Wheels, NumberOfDoors);
        }
    }
}
