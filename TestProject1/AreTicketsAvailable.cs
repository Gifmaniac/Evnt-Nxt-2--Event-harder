using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;
using Moq;


namespace TestProject1
{
    public class AreTicketsAvailable
    {
        [Fact]
        public void GetEventDTOWithGenresandOrganizerReturnsNoErrors()
        {
            // Arrange
            int eventID = 1;
            var fakeTickets = new List<EventTicketDTO>
            {
                new EventTicketDTO { ID = 1, EventID = eventID, IsAvailable = true },
                new EventTicketDTO { ID = 2, EventID = eventID, IsAvailable = true }
            };

            // Creates a mock repo
            var mockRepo = new Mock<IEventTicketRepository>();

            // Calls the EventTicketRepo method that get the EventTickets but it returns the fake ticket list instead
            mockRepo.Setup(r => r.GetEventTicketsByEventID(eventID)).Returns(fakeTickets);

            var service = new EventTicketService(mockRepo.Object);

            // Act
            var result = service.GetAvailableEventTickets(eventID);

            // Assert
            Assert.True(result.All(t => t.IsAvailable));
        }
    }
}