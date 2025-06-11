using EvntNxt.DTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class GenreRepository
    {

        public List<GenreDTO> GetAllGenreDtos()
        {
            const string query = "SELECT ID, Name FROM Genres";

            List<GenreDTO> result = new List<GenreDTO>();

            using var connection = DatabaseContext.CreateOpenConnection();
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            {
                while (reader.Read())
                {
                    GenreDTO genreDto = new GenreDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = (string)reader["Name"]
                    };
                    result.Add(genreDto);
                }
            }
            return result;
        }

        public List<GenreDTO> GetGenresByArtistID(int artistId)
        {
            var result = new List<GenreDTO>();

            string query = @"SELECT Genres.ID, Genres.Name FROM Genres JOIN ArtistGenre
                           ON Genres.ID = ArtistGenre.GenreID WHERE ArtistGenre.ArtistName";

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
