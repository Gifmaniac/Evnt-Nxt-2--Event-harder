using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
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

    public EventDTO GetEventByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Event has not bin found please try again.");
        }

        var eventList = _eventRepo.GetEventByName(name);
        return eventList;
    }

    public List<Event> CreateEventsWithOrganizerAndGenre()
    {
        var dtoList = _eventRepo.GetEventsWithOrganizerAndGenreDtos();
        var EventList = new List<Event>();

        foreach (var dto in dtoList)
        {
            var province = ProvinceMapper.ToEnum(dto.Province);

            var genreList = dto.Genre.Select(genre => new Genre(genre.ID, genre.Name)).ToList();
            var organizer = new Organizer(dto.Organizer.ID, dto.Organizer.Name, dto.Organizer.Tel);
            var domainEvent = new Event(dto.ID, dto.Name, organizer, province, dto.Date, genreList);

            EventList.Add(domainEvent);
        }

        return EventList;
    }
}
