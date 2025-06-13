using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_Prest.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly EventService _eventService;

        public EventViewModel EventViewModel { get; set; }

        public DetailsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                var eventDomain = _eventService.GetEventByID(id);

                if (eventDomain == null)
                {
                    return NotFound();
                }

                EventViewModel = new EventViewModel
                {
                    ID = eventDomain.ID,
                    Name = eventDomain.Name,
                };

                return Page();
            }
<<<<<<< Updated upstream
            catch (Exception ex)
=======

           EventViewModel = new EventViewModel

>>>>>>> Stashed changes
            {
                ModelState.AddModelError(string.Empty, "Something went wrong while loading the event.");
                return Page();
            }
        }
    }
}
