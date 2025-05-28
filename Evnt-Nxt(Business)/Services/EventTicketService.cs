using System.Reflection.Metadata.Ecma335;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Services
{
    public class EventTicketService : IEventTicketService

    {
        private readonly EventTicketRepository _eventTicketRepo;

        public EventTicketService(EventTicketRepository eventTicketRepo)
        {
            _eventTicketRepo = eventTicketRepo;
        }


        public List<EventTicket> CreateEventTicketWithEventIDNameAndDate()
        {
            var dtos = _eventTicketRepo.GetTicketTypesWithEventIDNameDateDto();
            var eventTickets = EventTicketMapper.CreateEventTicketWithEventIDNameDate(dtos);

            return eventTickets;
        }

        public List<EventTicket> GetAvailableEventTickets(int eventID)
        {
            var dtoList = _eventTicketRepo.GetEventTicketsByEventID(eventID);
            var result = EventTicketMapper.CreateEventTicketsBuyPage(dtoList);

            if (dtoList == null)
            {
                throw new ArgumentException($"Event has not been found please try again.");
            }

            return result;
        }
    }
}
 