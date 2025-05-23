using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt2.ViewModel;

namespace Evnt_Nxt2.Mapper
{
    public class EventTicketsModelMapper
    {
        public static EventTicketViewModel ToEventViewModel(EventTicket domain)
        {
            return new EventTicketViewModel
            {
                ID = domain.ID,
                EventID = domain.EventID,
                Name = domain.Name,
                Price = domain.Price,
                Amount = domain.Amount,
                IsAvailable = domain.IsAvailable,
                Event = domain.Event,
                Ticket = domain.Ticket
            };
        }
        public static List<EventTicketViewModel> ToEventTicketsViewModelList(List<EventTicket> domainList)
        {
            return domainList
                .Select(ToEventViewModel)
                .ToList();
        }
    }
}
 