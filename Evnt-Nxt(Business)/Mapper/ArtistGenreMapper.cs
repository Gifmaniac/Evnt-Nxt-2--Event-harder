using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_DAL_.DTO;

namespace Evnt_Nxt_Business_.Mapper
{
    public class ArtistGenreMapper
    {
        public static List<ArtistWithGenresDTO> MapToDto(List<ArtistDTO> artistDtoList, List<GenreDTO> genreDtoList, List<ArtistGenreDTO> artistGenreLinks)
        {
            Dictionary<int, GenreDTO> genreMap = genreDtoList.ToDictionary(genreDto => genreDto.ID, genreDto => genreDto);

            // Groups the artistID with their genreID in a dictionary.

            Dictionary<int, List<int>> artistGenreMap = artistGenreLinks
                .GroupBy(artistGenreLinks => artistGenreLinks.ArtistId)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(link => link.GenreId).ToList()
                );

            //Loops through the ArtistDto and turns it into an ArtistWithGenre.

            List<ArtistWithGenresDTO> result = artistDtoList
                .Select(artistDto =>
                {
                    // A fake list that prevents crashes. 
                    List<int> genreIds = new();

                    if (artistGenreMap.ContainsKey(artistDto.ID))
                    {
                        genreIds = artistGenreMap[artistDto.ID];
                    }
                    else
                    {
                        genreIds = new List<int>();
                    }

                    // Loops through the dictionary to create the objects!
                    List<GenreDTO> genres = genreIds
                        .Where(id => genreMap.ContainsKey(id))          //Checks if the genreID is in the dictionary
                        .Select(id => genreMap[id])                     //Gets the GenreDTO
                        .ToList();                                

                    return new ArtistWithGenresDTO
                    {
                        ID = artistDto.ID,
                        Name = artistDto.Name,
                        Genres = genres
                    };
                })
                .ToList();

            return result;
        }
    }
}
