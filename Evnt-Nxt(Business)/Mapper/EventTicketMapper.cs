using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Enums;
using Evnt_Nxt_DAL_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Evnt_Nxt_Business_.Mapper
{
    public static class EventTicketMapper
    {
        public static List<EventTicket> CreateEventTicketWithEventIDNameDate(List<EventTicketDTO> dtoList)
        {
            var result = new List<EventTicket>();

            foreach (var dto in dtoList)
            {
                var @event = new Event(dto.Event.ID, dto.Event.Name, dto.Event.Date);
                var EventTicket = new EventTicket(dto.ID, dto.Name, dto.Price, dto.Amount, dto.IsAvailable);
                var domainEventTicket = new EventTicket(EventTicket, @event);
                
                result.Add(domainEventTicket);
            }
            return result;
        }

        public static List<EventTicket> CreateEventTicketsBuyPage(List<EventTicketDTO> dtoList)
        {
            var result = new List<EventTicket>();

            foreach (var dto in dtoList)
            {
                var domainEventTicket = new EventTicket(dto.ID, dto.Name, dto.Price, dto.IsAvailable, dto.Amount);
                result.Add(domainEventTicket);
            }
            return result;
        }

        public static List<EventTicket> CreateEventTicketsFromDtoList(List<EventTicketDTO> dtoList)
        {
            var result = new List<EventTicket>();

            foreach (var dto in dtoList)
            {
                var @event = new Event(dto.Event.ID, dto.Event.Name, dto.Event.Date);
                var ticketInfo = new EventTicket(dto.ID, dto.Name, dto.Price, dto.Amount, dto.IsAvailable);
                var domainEventTicket = new EventTicket(ticketInfo, @event);

                result.Add(domainEventTicket);
            }

            return result;
        }
    }
}
