using Evnt_Nxt_DAL_.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.Repository
{
    public class ArtistGenreRepository
    {
        public List<ArtistGenreDTO> GetArtistGenresDTOs()
        {
            var Result = new List<ArtistGenreDTO>();

            using (var Connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string Query = " SELECT DISTINCT Artist.ID as ArtistID, Artist.Name as ArtistName, Genre.ID as GenreID, Genre.Name as GenreName FROM Artist JOIN ArtistGenre on Artist.ID = ArtistGenre.ArtistID JOIN Genre on Genre.ID = ArtistGenre.GenreID;";
                Connection.Open();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                using (var Reader = Command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        ArtistGenreDTO artistGenres = new ArtistGenreDTO();
                        {
                            artistGenres.ArtistName = Reader["ArtistName"].ToString();
                            artistGenres.GenreName = Reader["GenreName"].ToString();
                            artistGenres.ArtistID = Convert.ToInt32(Reader["ArtistID"]);
                            artistGenres.GenreID = Convert.ToInt32(Reader["GenreID"]);
                        }
                        Result.Add(artistGenres);
                        Console.WriteLine(artistGenres.ArtistName + artistGenres.GenreName);
                    }
                }
                Connection.Close();
            }

            return Result;
        }
    }
}
