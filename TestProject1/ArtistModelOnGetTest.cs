using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_;
using Evnt_Nxt_Business_.Enums;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt2.Pages;
using Moq;

namespace TestProject1
{
    public class ArtistModelOnGetTest

    {
    [Fact]
    public void OnGetFillArtistList()
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

        var _artistServiceMock = new Mock<IArtistService>(null, null);
        _artistServiceMock.Setup(artistService => artistService.CreateAllArtist()).Returns(fakeArtistList);

        var pageModel = new ArtistModel(_artistServiceMock.Object);

        // Act
        pageModel.OnGet();

        // Assert
        Assert.Equal(2, pageModel.ArtistList.Count);
        Assert.Equal("PindaBakkertje", pageModel.ArtistList[1].Name);
        Assert.Contains("HipHop", pageModel.ArtistList[0].Genres);
        }
    }
}
