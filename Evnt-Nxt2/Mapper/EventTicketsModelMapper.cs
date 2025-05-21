using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt2.ViewModel;

namespace Evnt_Nxt2.Mapper
{
    public class EventTicketsModelMapper
    {
        public static List<EventTicketViewModel> ToEventTicketsViewModelList(List<EventTicket> domainList)
        {
            return domainList
                .Select(eventTicket => new EventTicketViewModel
                    {
                        Event = eventTicket.Event,
                        Ticket = eventTicket.Ticket,
                    })
                .ToList();
        }
    }
}
 