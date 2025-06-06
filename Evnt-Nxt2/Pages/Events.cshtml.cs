using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt2.Mapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages
{
    public class EventsModel : PageModel
    {
        private readonly EventService _eventService;
        public List<EventViewModel> Events { get; set; } = new();

        public EventsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public void OnGet()
        {
            var eventPage = _eventService.CreateEventsWithOrganizerAndGenre();
            foreach (var events in eventPage)
            {
                Events = EventViewModelMapper.ToEventViewModelList(eventPage);
            }
        }
    }
}
