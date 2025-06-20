using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class EventTicket
    {
        public int ID { get;}
        public int EventID { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Amount { get; }
        public bool IsAvailable { get; }

        public Event Event { get; }
        public Ticket Ticket { get; }

        public EventTicket(int id, string name, decimal price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public EventTicket(int id, string name, decimal price, bool isAvailable)
        {
            ID = id;
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
        }


        public EventTicket(int id, string name, decimal price, bool isAvailable, int amount)
        {
            ID = id;
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
            Amount = amount;
        }

        public EventTicket(int id, string name, decimal price, int amount, bool isAvailable)
        {
            ID = id;
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
            Amount = amount;
        }

        public EventTicket(EventTicket ticketInfo, Event @event)
        {
            ID = ticketInfo.ID;
            Name = ticketInfo.Name;
            Price = ticketInfo.Price;
            Amount = ticketInfo.Amount;
            IsAvailable = ticketInfo.IsAvailable;
            Event = @event;
        }

        public EventTicket(Event @event, EventTicket eventTicket)
        {
            Event = @event;
            ID = eventTicket.ID;
            Name = eventTicket.Name;
            Price = eventTicket.Price;
            Amount = eventTicket.Amount;
            IsAvailable = eventTicket.IsAvailable;
        }

        public EventTicket(int id, string name, decimal price, int amount, bool isAvailable, int eventId)
        {
            ID = id;
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
            Amount = amount;
            EventID = eventId;
        }
    }
}
