using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Services
{
    public class EventTicketService
    {
        private readonly EventTicketRepository _eventTicketRepo;

        public List<EventTicket> CreateEventsWithOrganizerAndGenre()
        {
            var dtos = _eventTicketRepo.GetTicketTypesWithEventIDNameDateDto();
            var eventTickets = EventTicketMapper.CreateEventTicketWithEventIDNameDate(dtos);

            return eventTickets;
        }
    }
}
 