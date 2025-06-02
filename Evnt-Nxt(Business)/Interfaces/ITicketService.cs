using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using EvntNxtDTO;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface ITicketService
    {
        public void BuyTicket(User user, int eventID, int quantity);

        public TicketPurchaseValidator TryTicketPurchase(TicketPurchaseRequestDto request);
    }
}
