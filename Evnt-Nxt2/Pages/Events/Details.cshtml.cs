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

        public EventViewModel Event { get; set;}

        public DetailsModel(EventService eventService)
        {
            _eventService = eventService;
        }
        //public void OnGet(string name)
        //{
            //{
            //    var dto = _eventService.GetEventByName(name);

            //    if (dto != null)
            //    {
            //        Event = new EventViewModel()
            //        {
            //            ID = dto.ID,
            //            Name = dto.Name
            //        };
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
    }
}
