using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class Ticket
    {
        public int ID { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Amount { get; }
        public bool IsAvailable { get; }

        public Ticket(int id, string name, decimal price, int amount, bool isAvailable)
        {
            ID = id;
            Name = name;
            Price = price;
            Amount = amount;
            IsAvailable = isAvailable;
        }

        public Ticket(int id, string name, decimal price, bool isAvailable)
        {
            ID = id;
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
        }

        public Ticket(int id, string name, decimal price)
        {
            ID = id;
            Name = name;
            Price = price;
        }
    }
}
