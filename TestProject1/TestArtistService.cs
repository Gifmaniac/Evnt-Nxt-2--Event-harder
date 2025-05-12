using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Moq;
using Xunit;

namespace TestProject1
{
    public class TestArtistService
    {
        [Theory]
        [InlineData(1, "Carv")]
        [InlineData(2, "Gerard Joling")]
        [InlineData(3, "Katy Perry")]

        public void TestCrea(int id, string name)
        {
            //Arrange
            var artistDTO = new List<ArtistDTO>
            {
                new ArtistDTO{ID = id, Name = name}
            };

            var genreDTO = new List<GenreDTO>
            {
                new GenreDTO { ID = 0, Name = "Techno" }
            };

            var _artistRepoMock = new Mock<IArtistRepository>();
            var _genreRepoMock = new Mock<IGenreRepository>();


            _artistRepoMock.Setup(artistRepo => artistRepo.GetAllArtist()).Returns(artistDTO);

            var service = new ArtistService(_artistRepoMock.Object, _genreRepoMock.Object);
            // Act
            var result = service.CreateAllArtist();
            // Assert
            Assert.Single(result);
            var artist = result[0];

            Assert.Equal(id, artist.ID);
            Assert.Equal(name, artist.Name);         
        }
    }
}