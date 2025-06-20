using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt_DAL_;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TestProject1
{
    public class DeleteEventIntergrationTest
    {
        private readonly DatabaseContext _db;
        private readonly OrganizerOverviewRepository _organizerRepo;
        private readonly UserRepository _userRepo;
        private readonly OrganizerOverviewService _organizerService;
        private readonly EventRepository _eventRepository;

        public DeleteEventIntergrationTest()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var configWithOverride = new ConfigurationBuilder()
                .AddConfiguration(config)
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "DatabaseMode", "TestDatabase" }
                })
                .Build();

            _db = new DatabaseContext(configWithOverride);
            _organizerRepo = new OrganizerOverviewRepository(_db);
            _userRepo = new UserRepository(_db);
            _eventRepository = new EventRepository(_db);
            _organizerService = new OrganizerOverviewService(_organizerRepo, _userRepo, _eventRepository);
        }

        [Fact]
        public void DeleteEvent_Success_WhenOrganizerOwnsEvent()
        {
            // Arrange
            int eventID = 11;
            int userID = 49;
            int organizerID = 4;

            // Act
            var result = _organizerService.DeleteEvent(eventID, userID, organizerID);

            // Assert
            Assert.True(result.Success);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void DeleteEvent_Fails_WhenOrganizerIdMismatch()
        {
            // Arrange
            int eventId = 7;
            int userId = 49;
            int wrongOrganizerId = 6;

            // Act
            var result = _organizerService.DeleteEvent(eventId, userId, wrongOrganizerId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("You do not have permission to delete this event.", result.Errors);
        }

        [Fact]
        public void DeleteEvent_Fails_WhenEventDoesNotExist()
        {
            // Arrange
            int nonExistingEventId = 99999;
            int userId = 49;
            int organizerId = 4;

            // Act
            var result = _organizerService.DeleteEvent(nonExistingEventId, userId, organizerId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("The event you are trying to delete does not exist.", result.Errors);
        }
    }
}
