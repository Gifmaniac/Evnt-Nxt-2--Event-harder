using EvntNxt.DTO;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IEventService
    {
        public List<EventDTO> GetEvent();
    }
}
