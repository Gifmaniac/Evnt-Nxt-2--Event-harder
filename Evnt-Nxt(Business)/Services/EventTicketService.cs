﻿using System.Reflection.Metadata.Ecma335;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;


namespace Evnt_Nxt_Business_.Services
{
    public class EventTicketService : IEventTicketService

    {
        private readonly IEventTicketRepository _eventTicketRepo;

        public EventTicketService(IEventTicketRepository eventTicketRepo)
        {
            _eventTicketRepo = eventTicketRepo;
        }


        public List<EventTicket> CreateEventTicketWithEventIDNameAndDate()
        {
            var dtos = _eventTicketRepo.GetTicketTypesWithEventIDNameDateDto();
            var eventTickets = EventTicketMapper.CreateEventTicketWithEventIDNameDate(dtos);

            return eventTickets;
        }

        public List<EventTicket> GetAvailableEventTickets(int eventID)
        {
            var dtoList = _eventTicketRepo.GetEventTicketsByEventID(eventID);

            if (dtoList == null)
            {
                return null;
            }

            var result = EventTicketMapper.CreateEventTicketsBuyPage(dtoList);
            return result;
        }
    }
}
 