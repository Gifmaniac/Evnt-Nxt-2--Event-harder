using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt_Prest.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly EventService _eventService;

        public EventViewModel Event { get; set; }

        public DetailsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult OnGet(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound();
            }

            var domainEvent = _eventService.GetEventByName(name);

            if (domainEvent == null)
            {
                return NotFound();
            }

            Event = new EventViewModel
            {
                ID = domainEvent.ID,
                Name = domainEvent.Name
            };

            return Page();
        }
    
    }
}
