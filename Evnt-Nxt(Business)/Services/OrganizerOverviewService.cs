using Evnt_Nxt_DAL_.Repository;
using EvntNxtDTO;


namespace Evnt_Nxt_Business_.Services
{
    public class OrganizerOverviewService
    {
        private readonly OrganizerOverviewRepository _eventOverviewRepository;
        private readonly UserRepository _userRepository;

        public OrganizerOverviewService(OrganizerOverviewRepository eventOverviewRepository, UserRepository userRepository)
        {
            _eventOverviewRepository = eventOverviewRepository;
            _userRepository = userRepository;
        }

        public List<OrganizerOverviewPanelDTO> GetEventsByOrganizerId(int userID)
        {
            var organizerID = _userRepository.GetOrganizerIDbyUserID(userID);
            var allEvents = _eventOverviewRepository.GetEventTicketOverviewByOrganizerID(organizerID);

            return allEvents
                .Where(overview => overview.OrganizerID == organizerID)
                .ToList();
        }
    }
}