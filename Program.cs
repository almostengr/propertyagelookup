using System;
using Almostengr.PropertyAgeLookup.Entities;
using Almostengr.PropertyAgeLookup.Logic;

namespace Almostengr.PropertyAgeLookup.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the address to lookup: ");

            IProperty property = new Property();
            property.EnteredAddress = Console.ReadLine();

            PropertyLookup.PerformLookup(property.EnteredAddress);

            Console.ReadLine();
        }
    }
}
