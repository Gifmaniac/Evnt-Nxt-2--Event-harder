using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt2.Interface;
using Evnt_Nxt2.Pages;
using Xunit.Abstractions;


namespace TestProject1
{
    public class UserTicketTest

    {
        [Fact]
        public void BuyTicket_ShouldAddTicketToUser()
        {

            // Arrange
            var user = new User
            {
                ID = 1,
                Username = "Test",
                FirstName = "Willem",
                LastName = "Van den Broek"
            };

            var ticket = new Ticket(12, "Normal", 49);

            var @event = new Event(13, "Lake Dance");


            var eventTicket = new EventTicket(@event, ticket);
            
            ITicketService ticketService = new TicketService();

            // Act
            ticketService.BuyTicket(user, eventTicket);

            // Assert
            Assert.Single(user.PurchasedTickets);
            Assert.Equal(ticket, user.PurchasedTickets[0]);
            Assert.True(user.PurchasedTickets.Any(ticket => ticket.Name == "Normal"));
            Assert.True(user.PurchasedTickets.Any(ticket => eventTicket.Event.Name == "Lake Dance"));
        }
    }
}

