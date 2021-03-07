namespace Almostengr.PropertyAgeLookup.Entities
{
    public interface IProperty
    {
        string EnteredAddress { get; set; }
        string Address { get; set; }
        int Built { get; set; }
        string Owner { get; set; }
    }
}