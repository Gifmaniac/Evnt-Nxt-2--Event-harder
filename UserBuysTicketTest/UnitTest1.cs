using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using EvntNxt.DTO;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace UserBuysTicketTest
{
    public class UnitTest1
    {
        //private readonly Mock<ITicketRepository> _ticketRepoMock = new();

        //[Fact]
        //void UserTriesToBuyATicket_TicketReturnsWithUserInfo()
        //{
        //    // Arrange
        //    var mockTicketRepo = new Mock<ITicketRepository>();
        //    var mockEventTicketService = new Mock<IEventTicketService>();
        //    var mockUserService = new Mock<UserService>();

        //    var service = new TicketService(
        //        mockTicketRepo.Object,
        //        mockEventTicketService.Object
        //    );

        //    User user = new User(1, "test@test.nl", "Willem", "van den Broek");
        //    int eventTicketID = 12;
        //    int quantity = 3;
        //    DateOnly purchaseDate = DateOnly.Parse("2024-05-28");


        //    // Act
        //    ticketService.BuyTicket(user, eventTicketID, quantity);

        //    // Assert
        //    _ticketRepoMock.Verify(repo => repo.AddTicketToUser(It.IsAny<TicketDTO>(), 1),
        //        Times.Exactly(quantity));
        //    _ticketRepoMock.Verify(repo => repo.DecreaseAvailableTickets(It.IsAny<int>(), 1),
        //        Times.Exactly(quantity));
        //}
    }
}