using System.Data.Common;
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

        public (bool Succes, List<string> Errors) UpdateEvent(OrganizerOverviewPanelDTO organizerDTO)
        {
            var errors = new List<string>();

            if (organizerDTO == null)
            {
                return (false, new List<string> { "No event has been found, please try again later." });
            }

            if (string.IsNullOrWhiteSpace(organizerDTO.EventName))
            {
                errors.Add("Event name is required.");
            }

            if (string.IsNullOrWhiteSpace(organizerDTO.EventLocation))
            {
                errors.Add("Location is required.");
            }

            if (errors.Any())
            {
                return (false, errors);
            }

            _eventOverviewRepository.ChangeEventDetails(organizerDTO);
            _eventOverviewRepository.ChangeTicketDetails(organizerDTO);
            
            return (true, new List<string>());

        }


    }
}