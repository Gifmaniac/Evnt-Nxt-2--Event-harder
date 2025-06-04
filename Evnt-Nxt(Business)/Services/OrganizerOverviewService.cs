using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt2.ViewModel;


namespace Evnt_Nxt_Business_.Services
{
    public class OrganizerOverviewService
    {
        private readonly OrganizerOverviewRepository _eventOverviewRepository;

        public OrganizerOverviewService()
        {
            _eventOverviewRepository = new OrganizerOverviewRepository();
        }

        public List<OrganizerOverviewDTO> GetEventsByOrganizerId(int organizerId)
        {
            var allEvents = _eventOverviewRepository.GetEventTicketOverview();
            return allEvents
                .Where(overview => overview.OrganizerID == organizerId)
                .ToList();
        }
    }
}