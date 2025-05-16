using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_DAL_.DTO;

namespace Evnt_Nxt_DAL_.Repository
{
    public class ArtistGenreRepository
    {
        public List<ArtistGenreDTO> GetAllArtistGenreLinks()
        { 
            const string query = 
                "SELECT ArtistID, GenreID FROM ArtistGenre;";

            List<ArtistGenreDTO> result = new();

            using var connection = DatabaseContext.CreateOpenConnection();
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var dto = new ArtistGenreDTO
                {
                    ArtistId = Convert.ToInt32(reader["ArtistID"]),
                    GenreId = Convert.ToInt32(reader["GenreID"])
                };

                result.Add(dto);
            }

            return result;
        }
    }
}
