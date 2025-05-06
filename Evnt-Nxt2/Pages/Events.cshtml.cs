using Evnt_Nxt_Business_.Managers;
using Evnt_Nxt_Business_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages
{
    public class EventsModel : PageModel
    {
        private readonly EventService EventManager;
        public List<EventViewModel> EventList; 
        public EventsModel(EventService eventManager)
        {
            EventManager = eventManager;
        }

        public void OnGet()
        {
            EventList = EventManager.GetAllEvents();
        }
    }
}
