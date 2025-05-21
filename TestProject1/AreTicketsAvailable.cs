using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Microsoft.Extensions.Logging;


namespace TestProject1
{
    public class AreTicketsAvailable
    {
        [Fact]
        public void GetEventDTOWithGenresandOrganizer()
        {
            //Arrange
            var event1 = new Event(1, "Lake Dance");
            var event2 = new Event(2, "Tomorrowland");
            var ticket1 = new Ticket(1, "Early Bird", 19, true);
            var ticket2 = new Ticket(2, "Late Ticket", 29,false);
            var ticket3 = new Ticket(3, "VIP", 99, true);

            var eventTicket1 = new EventTicket(event1, ticket1);
            var eventTicket2 = new EventTicket(event1, ticket2);
            var eventTicket3 = new EventTicket(event2, ticket3);

            var allTickets = new List<EventTicket> { eventTicket1, eventTicket2, eventTicket3 };
            var service = new EventTicketService(allTickets);

            // Act

            var available = service.GetAvailableEventTickets(1);

            // Assert
            Assert.Single(available);
            Assert.Equal("Late Ticket", available[0].Ticket.Name);

        }
    }
}