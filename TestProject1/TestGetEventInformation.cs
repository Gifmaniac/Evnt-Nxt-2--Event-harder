using Azure.Core;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.ViewModel;
using Evnt_Nxt_DAL_;
using Evnt_Nxt_DAL_.DTO;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Data.SqlClient;

namespace TestProject1
{
    public class TestGetEventInformation
    {
        [Fact]
        public void GetEventDTOWithGenresandOrganizer()
        {
            //Arrange
            var genreList = new List<GenreDTO> { new GenreDTO{ ID = 1, Name = "Techno" }};
            var organizer = new OrganizerDTO { ID = 2, Name = "Awakenings", Tel = 020-1234567 };

            // Act
            var dto = new EventWithOrganizerAndGenreDTO()
            {
                ID = 100,
                Name = "Verknipt Damsco",
                Date = new DateOnly(2025, 3, 1),
                Province = "Noord-Holland",
                Organizer = organizer,
                Genre = genreList.Select(genre => new GenreDTO
                {
                    ID = genre.ID,
                    Name = genre.Name
                }).ToList()
            };

            Assert.Equal(100, dto.ID);
            Assert.Equal("Awakenings", dto.Organizer.Name);
            Assert.Equal("Techno", dto.Genre.First().Name);
            Assert.Equal(020 - 1234567, dto.Organizer.Tel);


        }
    }
}