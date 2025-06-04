using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;
using Moq;


namespace TestProject1
//{
//    public class AreTicketsAvailable
//    {
//        [Fact]
//        public void GetEventDTOWithGenresandOrganizer()
//        {
//            // Arrange
//            var mockRepo = new Mock<IEventTicketRepository>();
//            int eventId = 1;

//            var fakeTickets = new List<EventTicketDTO>
//            {
//                new EventTicketDTO { ID = 1, EventID = eventId },
//                new EventTicketDTO { ID = 2, EventID = eventId }
//            };

//            mockRepo.Setup(r => r.GetEventTicketsByEventID(eventId)).Returns(fakeTickets);

//            var service = new EventTicketService(mockRepo.Object);

//            // Act
//            var result = service.GetAvailableEventTickets(eventId);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(2, result.Count);

//        }
//    }
//}