using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages.Organizer
{
    public class DetailsModel : PageModel
    {
        private readonly EventService _eventService;

        public DetailsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public void OnGet()
        {
        }
    }
}
