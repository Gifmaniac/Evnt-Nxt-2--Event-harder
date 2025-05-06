using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt_DAL_.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Managers
{
    public class EventService
    {
        private readonly EventRepository EventRepo;

        public EventService(EventRepository eventRepo)
        {
            EventRepo = eventRepo;
        }

        public List<EventViewModel> GetAllEvents()
        {
            var dtos = EventRepo.GetEventDtos();
            var result = new List<EventViewModel>();

            foreach (var dto in dtos)
            {
                result.Add(new EventViewModel
                {
                    ID = dto.ID,
                    LineUpID = dto.LineUpID,
                    Name = dto.Name,
                    Date = dto.Date,
                    GenreID = dto.GenreID,
                    Location = dto.Location,
                    Organizer = dto.Organizer,
                    Price = dto.Price,
                    Province = ProvinceMapper.ToEnum(dto.Province)
                });
            }
            return result;
        }
    }
}
