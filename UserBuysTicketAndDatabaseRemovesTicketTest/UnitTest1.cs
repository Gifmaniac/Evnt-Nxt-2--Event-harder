using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace UserBuysTicketAndDatabaseRemovesTicketTest
{
    [TestClass]
    public class UnitTest1
    {
        [Fact]
        public void BuyTicket_ShouldCallAddTicketToUser_WithCorrectData()
        {
            // Arrange
            var mockRepo = new Mock<ITicketRepository>();
            var service = new TicketService(mockRepo.Object);
            var user = new User { ID = 1 };
            int eventTicketID = 100;
            int quantity = 2;

            // Act
            service.BuyTicket(user, eventTicketID, quantity);

            // Assert
            mockRepo.Verify(repo => repo.AddTicketToUser(
                It.Is<TicketDTO>(t => t.UserID == 1 && t.EventTicketID == 100),
                2), Times.Once);
        }
    }
}