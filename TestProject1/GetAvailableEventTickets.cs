using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_;
using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt_Business_.Interfaces;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace TestProject1
{
    public class GetAvailableEventTickets
    {
        private readonly DatabaseContext _db;
        private readonly IEventTicketRepository _repo;
        private readonly IEventTicketService _service;

        public GetAvailableEventTickets()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var configWithConfigOverrride = new ConfigurationBuilder()
                .AddConfiguration(config)
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "DatabaseMode", "TestDatabase" }
                })
                .Build();

            _db = new DatabaseContext(configWithConfigOverrride);
            _repo = new EventTicketRepository(_db);
            _service = new EventTicketService(_repo);
        }

        [Fact]
        public void GetAvailableEventTickets_ShouldReturnTicketList_WhenTicketsExist()
        {
            // Arrange
            int testEventId = 9; 

            // Act
            var result = _service.GetAvailableEventTickets(testEventId);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result); // At least one ticket should exist
            Assert.All(result, ticket => Assert.Equal(testEventId, ticket.EventID));
        }
    }
}