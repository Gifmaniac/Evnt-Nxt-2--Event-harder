using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Enums;
using Evnt_Nxt_DAL_.DTO;

namespace Evnt_Nxt_Business_.Mapper
{
    public static class EventMapper
    {
        public static Event CreateDomainFromDto(EventDTO dto)
        {
            return new Event(dto.ID, dto.Name);
        }

        public static EventDTO CreateDtoFromDomain(Event domain)
        {
            return new EventDTO
            {
                ID = domain.ID,
                Name = domain.Name
            };
        }

        public static List<Event> CreateEventsWithOrganizerAndGenreFromDto(List<EventWithOrganizerAndGenreDTO> dtoList)
        {
            var result = new List<Event>();

            foreach (var dto in dtoList)
            {
                var organizer = new Organizer(dto.Organizer.ID, dto.Organizer.Name, dto.Organizer.Tel);
                var province = Enum.Parse<ProvinceEnums>(dto.Province);
                var genres = dto.Genre.Select(g => new Genre(g.ID, g.Name)).ToList();
                var domainEvent = new Event(dto.ID, dto.Name, organizer, province, dto.Date, genres);

                result.Add(domainEvent);
            }
            return result;
        }
    }
}
