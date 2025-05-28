using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.Repository;
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
            var ticket1 = new EventTicket(event1, new EventTicket(1, "Early Bird", 19, false));
            var ticket2 = new EventTicket(event1, new EventTicket(2, "Late Ticket", 29, true));

            var allTickets = new List<EventTicket> { ticket1, ticket2 };
            var fakeRepo = new FakeEventTicketRepository(allTickets);
            //var service = new EventTicketService(fakeRepo);

            // Act

            var available = service.GetAvailableEventTickets(1); 
            // Assert
            Assert.Single(available);
            Assert.Equal("Late Ticket", available[0].Name);

        }
    }
}