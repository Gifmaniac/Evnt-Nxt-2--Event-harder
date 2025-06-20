using Evnt_Nxt_Business_.DomainClass;
using EvntNxt.DTO;

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
                var domainEventTicket = new EventTicket(dto.ID, dto.Name, dto.Price, dto.Amount, dto.IsAvailable, @event);
                
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
                var domainEventTicket = new EventTicket(dto.ID, dto.Name, dto.Price, dto.Amount, dto.IsAvailable, @event);

                result.Add(domainEventTicket);
            }

            return result;
        }
    }
}
