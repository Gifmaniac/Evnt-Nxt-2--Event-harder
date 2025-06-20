using Evnt_Nxt_Business_;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_;
using Evnt_Nxt_DAL_.Repository;
using EvntNxtDTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace TestProject1
{
    public class RegisterIntergrationTest
    {
        private readonly DatabaseContext _db;
        private readonly RegisterService _service;

        public RegisterIntergrationTest()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Force override of DatabaseMode
            var configWithOverride = new ConfigurationBuilder()
                .AddConfiguration(config)
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "DatabaseMode", "TestDatabase" }
                })
                .Build();

            _db = new DatabaseContext(configWithOverride);

            var repo = new RegisterRepository(_db);
            var hasher = new PasswordHasher();
            var validator = new RegisterValidator();

            _service = new RegisterService(repo, hasher, validator);
        }

        [Fact]
        public void RegisterService_ShouldInsertIntoDataBase_ReturnOneUser()
        {
            // Arrange
            var testUser = new RegisterDTO
            {
                Email = "integrationtest2@test.com",
                Password = "StrongPassword123!",
                UserName = "IntergrationTest123",
                FirstName = "BLL",
                LastName = "Flow",
                BirthDay = DateOnly.FromDateTime(DateTime.Today),
                RoleID = 1
            };

            // Act
            var (success, errors) = _service.RegisterUser(testUser);

            // Assert
            Assert.True(success);
            Assert.Empty(errors);

            // Cleanup
            using var cleanupConn = _db.CreateOpenConnection();
            using var cleanup = new SqlCommand("DELETE FROM [User] WHERE Email = @Email", cleanupConn);
            cleanup.Parameters.AddWithValue("@Email", testUser.Email);
            cleanup.ExecuteNonQuery();
        }

        [Fact]
        public void RegisterService_ShouldInsertIntoDataBase_ReturnErrorDuplicatedAccount()
        {
            // Arrange
            var testUser = new RegisterDTO
            {
                Email = "pizza4life@mail.com",
                Password = "StrongPassword123!",
                UserName = "IntergrationTest",
                FirstName = "BLL",
                LastName = "Flow",
                BirthDay = DateOnly.FromDateTime(DateTime.Today),
                RoleID = 1
            };

            // Act
            var (success, errors) = _service.RegisterUser(testUser);

            // Assert
            Assert.False(success);
            Assert.Contains(errors, error => error.Contains("email"));
        }
    }
}