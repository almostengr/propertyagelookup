namespace Almostengr.PropertyAgeLookup.Entities
{

    public class Property : IProperty
    {
        public string EnteredAddress { get; set; }
        public string Address { get; set; }
        public int Built { get; set; }
        public string Owner { get; set; }
    }
}