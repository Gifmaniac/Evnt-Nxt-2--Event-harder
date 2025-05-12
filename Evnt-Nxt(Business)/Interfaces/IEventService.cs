using Evnt_Nxt_DAL_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IEventService
    {
        public List<EventDTO> GetEvent();
    }
}
