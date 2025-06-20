using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_;
using Evnt_Nxt_DAL_.Repository;
using Evnt_Nxt_DAL_;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Interfaces;
using EvntNxtDTO;
using Xunit.Sdk;

namespace TestProject1
{
    public class LoginIntergrationTest
    {
        private readonly DatabaseContext _db;
        private readonly IPasswordHasher _passwordHasher;
        private readonly LoginRepository _userLoginRepository;
        private readonly LoginService _loginService;

        public LoginIntergrationTest()
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
            _userLoginRepository = new LoginRepository(_db);
            _passwordHasher = new PasswordHasher();
            _loginService = new LoginService(_passwordHasher, _userLoginRepository);
        }

        [Fact]
        public void Login_WithValidCredentials_ReturnsUserDoesNotExist()
        {
            // Arrange
            var loginDto = new LoginDTO
            {
                Email = "testuser@mail.com",
                Password = "ValidPassword123!"
            };

            // Act
            var result = _loginService.ValidateLogin(loginDto);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("email", result.ErrorMessage);
        }

        [Fact]
        public void Login_WithValidCredentials_ReturnsUserLogsIn()
        {
            // Arrange
            var loginDto = new LoginDTO
            {
                Email = "w.vd.b@live.nl",
                Password = "Test123!"
            };

            // Act
            var result = _loginService.ValidateLogin(loginDto);

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
        }
    }
}