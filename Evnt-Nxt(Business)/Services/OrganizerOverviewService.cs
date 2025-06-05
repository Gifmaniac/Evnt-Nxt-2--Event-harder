using Evnt_Nxt_DAL_.Repository;
using EvntNxtDTO;


namespace Evnt_Nxt_Business_.Services
{
    public class OrganizerOverviewService
    {
        private readonly OrganizerOverviewRepository _eventOverviewRepository;

        public OrganizerOverviewService()
        {
            _eventOverviewRepository = new OrganizerOverviewRepository();
        }

        public List<OrganizerOverviewPanelDTO> GetEventsByOrganizerId(int organizerID)
        {
            var allEvents = _eventOverviewRepository.GetEventTicketOverviewByOrganizerID(organizerID);
            return allEvents
                .Where(overview => overview.OrganizerID == organizerID)
                .ToList();
        }
    }
}