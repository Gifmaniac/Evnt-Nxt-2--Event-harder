using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.ViewModel;

namespace Evnt_Nxt2.Mapper
{
    public static class EventViewModelMapper
    {
        public static EventViewModel ToEventViewModel(Event domain)
        {
            return new EventViewModel
            {
                Name = domain.Name,
                Organizer = domain.Organizer,
                Date = domain.Date.ToString("dd-MM-yyyy"),
                Genres = domain.Genres,
                ID = domain.ID,
                Location = domain.Location,
                Province = domain.Province.ToString(),
            };
        }

        public static List<EventViewModel> ToEventViewModelList(List<Event> domainList)
        {
            return domainList
                .Select(ToEventViewModel)
                .ToList();
        }
    }
}
