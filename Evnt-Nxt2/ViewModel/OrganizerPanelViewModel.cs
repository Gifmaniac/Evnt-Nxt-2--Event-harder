using Evnt_Nxt_Business_.ViewModel;
using EvntNxt.DTO;

namespace Evnt_Nxt2.ViewModel
{
    public class OrganizerPanelViewModel
    {
        public List<EventWithOrganizerAndGenreDTO> Events { get; set; } = new();
        public string OrganizerName { get; set; }
    }
}