using EvntNxt.DTO;
using EvntNxtDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;

namespace Evnt_Nxt_Business_
{
    public class TicketPurchaseValidator
    {
        public string ErrorMessage { get; set; }

        public List<string> errors = new();

        public List<string> Validate(TicketPurchaseRequestDto request, EventTicket selectedTicket)
        {

            if (selectedTicket == null)
                errors.Add("Ticket does not exist, please try again later.");


            if (request.Quantity < 1 || request.Quantity > 5)
                   errors.Add("The ticket order quantity must be between 1 and 5.");


            if (request.Quantity > selectedTicket.Amount || !selectedTicket.IsAvailable)
                   errors.Add("Not enough tickets available for your current order.");

            return errors;
        }
    }
}
