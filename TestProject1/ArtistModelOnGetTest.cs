using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt2.Interface;
using Evnt_Nxt2.Pages;
using Moq;

namespace TestProject1
{
    public class ArtistModelOnGetTest

    {
        [Fact]
        public void OnGetFillArtistListTest()
        {
            // Assamble
            var fakeArtistList = new List<Artist>
            {
                new Artist(1, "Pietje Drummer", new List<Genre>
                {
                    new Genre(0, "HipHop")
                }),

                new Artist(2, "PindaBakkertje", new List<Genre>
                {
                    new Genre(1, "Techno")
                })
            };

            var _artistServiceMock = new Mock<ArtistService>();

            //_artistServiceMock.Setup(artistService => artistService.CreateAllArtist()).Returns(fakeArtistList);

            var artistModel = new ArtistModel(_artistServiceMock.Object);

            // Act
            artistModel.OnGet();

            // Assert
            Assert.Equal(2, artistModel.ArtistList.Count);
            Assert.Equal("PindaBakkertje", artistModel.ArtistList[1].Name);
        }
    }
}

