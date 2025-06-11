using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Services;
using EvntNxt.DTO;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IEventService
    {
        public Event GetEventByID(int id);
        public EventService CreateEventsWithOrganizerAndGenre();

    }
}
