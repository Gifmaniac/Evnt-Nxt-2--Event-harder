using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Enums;
using Evnt_Nxt_DAL_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Mapper
{
    public class EventTicketMapper
    {
        public static List<EventTicket> CreateEventTicketWithEventIDNameDate(List<EventTicketDTO> dtoList)
        {
            var result = new List<EventTicket>();

            foreach (var dto in dtoList)
            {
                var @event = new Event(dto.Event.ID, dto.Event.Name, dto.Event.Date);
                var ticket = new Ticket(dto.Ticket.ID, dto.Ticket.Name, dto.Ticket.Price, dto.Ticket.Amount, dto.Ticket.IsAvailable);
                var domainEventTicket = new EventTicket(@event, ticket);


                result.Add(domainEventTicket);
            }
            return result;
        }
    }
}
