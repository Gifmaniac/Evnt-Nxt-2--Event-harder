using Microsoft.AspNetCore.Mvc;

namespace Evnt_Nxt2.ViewModel
{
    public class UserPageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }


        [BindProperty]
        public List<TicketViewModel> Tickets { get; set; } = new();
    }
}
