using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt2.Interface;
using Evnt_Nxt2.Pages;
using Xunit.Abstractions;


//  TestProject1
// {
//    public class UserTicketTest

//    {
//        [Fact]
//        public void BuyTicket_ShouldAddTicketToUser()
//        {

//            // Arrange
//            var user = new User(1, "test@test.nl", "Willem", "Van den Broek");

//            var eventTicket = new Event(1, "Normal", "10-10-2025");
            
//            ITicketService ticketService = new TicketService();

//            // Act
//            ticketService.BuyTicket(user, eventTicket, 2);

//            // Assert
//            Assert.Single(user.PurchasedTickets);
//            Ticket purchasedTicket = user.PurchasedTickets[0];
//            Assert.Equal(user.ID, purchasedTicket.UserID);
//            Assert.Equal(eventTicket.ID, purchasedTicket.EventTicketID);
//            Assert.Equal(DateOnly.FromDateTime(DateTime.Today), purchasedTicket.PurchaseDate);
//        }
//    }
//}

