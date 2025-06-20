using EvntNxt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IEventTicketRepository
    {
        public List<EventTicketDTO> GetEventTicketsByEventID(int eventID);
        public List<EventTicketDTO> GetTicketTypesWithEventIDNameDateDto();
    }
}
