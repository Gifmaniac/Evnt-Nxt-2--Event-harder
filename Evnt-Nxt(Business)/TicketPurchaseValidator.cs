using EvntNxt.DTO;
using EvntNxtDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;

namespace Evnt_Nxt_Business_
{
    public class TicketPurchaseValidator
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public static TicketPurchaseValidator Validate(TicketPurchaseRequestDto request, EventTicket selectedTicket)
        {
            if (selectedTicket == null)
            {
                return new TicketPurchaseValidator
                {
                    Success = false,
                    ErrorMessage = "Ticket does not exist, please try again later."
                };
            }

            if (request.Quantity < 1 || request.Quantity > 5)
            {
                return new TicketPurchaseValidator
                {
                    Success = false,
                    ErrorMessage = "The ticket order quantity must be between 1 and 5."
                };
            }

            if (request.Quantity > selectedTicket.Amount || !selectedTicket.IsAvailable)
            {
                return new TicketPurchaseValidator
                {
                    Success = false,
                    ErrorMessage = "Not enough tickets available for your current order."
                };
            }

            return new TicketPurchaseValidator { Success = true };
        }
    }
}
