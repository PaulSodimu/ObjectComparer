using ObjectComparer.HelperObjects.Interfaces;

namespace ObjectComparer.HelperObjects
{
    public class Dog : IAnimal
    {
        public string Colour { get; set; }
        public string Breed { get; set; }
        public int NumberOfPaws { get; set; }

        public override string ToString()
        {
            return string.Format("A {0} Dog with {1} paws, of {2} breed", Colour, NumberOfPaws, Breed);
        }
    }
}
