using Evnt_Nxt_Business_;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1
{
    public class PasswordHashingTest
    {
        private readonly ITestOutputHelper _output;
        public PasswordHashingTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void HashPasswordTEST()
        {
            // Arrange
            var _passwordHasher = new PasswordHasher();
            string input = "Test1";


            // Act
            string result = _passwordHasher.HashPassword(input);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(result));
            Assert.True(result.Length > 10);
            _output.WriteLine(result);
        }
    }
}
