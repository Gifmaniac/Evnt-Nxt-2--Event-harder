using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class GenreRepository : IGenreRepository
    {
        public List<GenreDTO> GetGenresByArtistID(int artistId)
        {
            var result = new List<GenreDTO>();

            string query = " SELECT Genre.ID, Genre.Name FROM Genre JOIN ArtistGenre " +
                           "ON Genre.ID = ArtistGenre.GenreID WHERE ArtistGenre.ArtistID = @ArtistID;";

            using var connection = new SqlConnection(DatabaseContext.ConnectionString);
            using var command = new SqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@ArtistID", artistId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var genre = new GenreDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = (string)reader["Name"]
                        };
                        result.Add(genre);
                    }

                    connection.Close();
                }
                return result;
            }
        }
    }
}
