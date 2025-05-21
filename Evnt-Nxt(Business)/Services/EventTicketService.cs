using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Services
{
    public class EventTicketService : IEventTicketService

    {
        private readonly EventTicketRepository _eventTicketRepo;

            public List<EventTicket> CreateEventTicketWithEventIDNameAndDate()
        {
            var dtos = _eventTicketRepo.GetTicketTypesWithEventIDNameDateDto();
            var eventTickets = EventTicketMapper.CreateEventTicketWithEventIDNameDate(dtos);

            return eventTickets;
        }

        public List<EventTicket> GetAvailableEventTickets(int eventID)
        {
            List<EventTicket> availableEventTickets = CreateEventTicketWithEventIDNameAndDate();
            return availableEventTickets.Where(eventTicket => eventTicket.Event.ID == eventID && eventTicket.Ticket.IsAvailable).ToList();
        }

        public EventTicket GetEventTicketByID(int eventTicketID)
        {
            var dto = _eventTicketRepo.GetEventTicketsByID(eventTicketID);

            if (dto == null)
            {
                throw new ArgumentException($"Event has not been found please try again.{eventTicketID}");
            }

            var domainEvent = EventMapper.CreateEventWithIDAndNameFromDto(dto);

            return domainEvent;
        }
    }
}
 