using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.Extensions.Configuration;

namespace TestProject1
{
    public class LoadArtistWithGenres
    {
        private readonly IArtistService _artistService;
        private readonly DatabaseContext _db;

        public LoadArtistWithGenres()
        {
            // Load configuration
            var configWithOverride = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "DatabaseMode", "TestDatabase" } // Forces test DB usage
                })
                .Build();

            // Set up repositories (assuming they accept IConfiguration or connection string)
            _db = new DatabaseContext(configWithOverride);
            var artistRepo = new ArtistRepository(_db);

            _artistService = new ArtistService(artistRepo);
        }

        [Fact]
        public void CreateAllArtistsWithGenre_ReturnsArtistsFromTestDatabase()
        {
            // Act
            var result = _artistService.CreateAllArtistsWithGenre();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            var artist = result.Find(a => a.Name == "The Rockers");
            Assert.NotNull(artist);
            Assert.Equal("The Rockers", artist.Name);
            Assert.Contains(artist.Genres, g => g.Name == "Rock");
        }

        [Fact]
        public void CreateAllArtistsWithGenre_DoesNotReturnsArtistsFromTestDatabase()
        {
            // Act
            var result = _artistService.CreateAllArtistsWithGenre();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            var artist = result.Find(a => a.Name == "The Smooshers");
            Assert.Null(artist);
        }
    }
}
