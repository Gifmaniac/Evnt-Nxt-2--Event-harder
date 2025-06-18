using Evnt_Nxt_DAL_;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace TestProject1
{
    public class RegisterIntergrationTest
    {
        private readonly DatabaseContext _db;

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
        }

        [Fact]
        {

        }
    }
}