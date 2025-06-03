using System.Collections.Generic;
using System.Linq;
using System;

namespace Models
{
    public class Reservation
    {
        public Client client { get; set; }
        public List<Destination> destinationList { get; set; } = new List<Destination>();

        public double CalculateTotalWithTax()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return destinationList.Sum(d => d.PriceWithTax());
            Console.ResetColor();
        }

        public double CalculateTotal()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return destinationList.Sum(d => d.BasePrice);
            Console.ResetColor();
        }

        public List<Destination> GetDestinations() => destinationList;
        public void SetDestinations(List<Destination> list) => destinationList = list;
    }

}
