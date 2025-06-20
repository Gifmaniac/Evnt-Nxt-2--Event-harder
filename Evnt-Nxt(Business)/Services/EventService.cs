﻿using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt_DAL_.DTO;
using System.Collections.Generic;

namespace Evnt_Nxt_Business_.Services;

public class EventService : IEventService
{
    private readonly EventRepository _eventRepo;

    public EventService(EventRepository eventRepo)
    {
        _eventRepo = eventRepo;
    }

    public Event GetEventByID(int id)
    {
        var dto = _eventRepo.GetEventByID(id);

        if (dto == null)
        {
            return null;
        }

        var domainEvent = EventMapper.CreateEventWithIDAndNameFromDto(dto);

        return domainEvent;
    }

    public List<Event> CreateEventsWithOrganizerAndGenre()
    {
        var dtoList = _eventRepo.GetEventsWithOrganizerAndGenreDtos();
        var events = EventMapper.CreateEventsWithOrganizerAndGenreFromDto(dtoList);


        return events;
    }

}
