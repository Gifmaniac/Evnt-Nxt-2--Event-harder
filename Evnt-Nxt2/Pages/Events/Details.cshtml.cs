using Evnt_Nxt_Business_.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly EventService EventManager;

        public DetailsModel(EventService eventManager)
        {
            EventManager = eventManager;
        }
        public void OnGet()
        {
        }
    }
}
