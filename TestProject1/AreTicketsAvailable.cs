using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;
using EvntNxtDTO;
using Moq;


namespace TestProject1
{
    public class AreTicketsAvailable
    {
        [Fact]
        public void GetAvailableEventTickets_ShouldReturnOnlyTicketsThatAreAvailableAndHaveStock()
        {
            // Arrange
            var service = new FakeEventTicketRepository();
            int testEventId = 1;

            // Act
            var availableTickets = service.GetAvailableEventTickets(testEventId);

            // Assert
            Assert.NotNull(availableTickets);
            Assert.Equal(2, availableTickets.Count); // Should return Regular and Backstage
            Assert.All(availableTickets, t => Assert.True(t.IsAvailable && t.Amount > 0));
        }
    }
}