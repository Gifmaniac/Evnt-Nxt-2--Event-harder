using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Microsoft.AspNetCore.Mvc;
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
            var eventObject = _eventService.CreateEventsWithOrganizerAndGenre();
            Events = eventObject.Select(dtos => new EventViewModel
            {
                ID = dtos.ID,
                Name = dtos.Name,
                Location = dtos.Location,
                Date = dtos.Date,
            }).ToList();
        }
    }
}
