using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt_DAL_.DTO;

namespace Evnt_Nxt_Business_.Services;

public class EventService
    {
        private readonly EventRepository _eventRepo;

        public EventService(EventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public List<Event> GetEvent()
        {
            return null;
        }


    //public List<EventViewModel> GetAllEvents()
    //{
    //    var dtos = EventRepo.GetEventDtos();
    //    var result = new List<EventViewModel>();

    //    foreach (var dto in dtos)
    //    {
    //        result.Add(new EventViewModel
    //        {
    //            ID = dto.ID,
    //            LineUpID = dto.LineUpID,
    //            Name = dto.Name,
    //            Date = dto.Date,
    //            GenreID = dto.GenreID,
    //            Location = dto.Location,
    //            Organizer = dto.Organizer,
    //            Price = dto.Price,
    //            Province = ProvinceMapper.ToEnum(dto.Province)
    //        });
    //    }
    //    return result;
    //}
}
