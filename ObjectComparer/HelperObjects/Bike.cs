namespace ObjectComparer.HelperObjects
{
    public class Bike : Vehicle
    {
        public bool HasHandleBars { get; set; }

        public override string ToString()
        {
            return string.Format("A Bike with {0} wheels {1} handlebars.", Wheels, HasHandleBars?"with":"without");
        }
    }
}
