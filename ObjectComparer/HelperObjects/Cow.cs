using ObjectComparer.HelperObjects.Interfaces;

namespace ObjectComparer.HelperObjects
{
    public class Cow : IAnimal
    {
        public string Colour { get; set; }
        public int NumberOfUdders { get; set; }

        public override string ToString()
        {
            return string.Format("A {0} Cow with {1} udders", Colour, NumberOfUdders);
        }
    }
}
