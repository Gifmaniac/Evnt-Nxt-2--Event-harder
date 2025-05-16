using Microsoft.Data.SqlClient;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;



namespace Evnt_Nxt_DAL_.Repository
{
    public class ArtistRepository

    {
        // Recieves the artist with genre and puts them in a list. It also checks if an artist has multiple genres, if so we save the ID in a dictionary and add the genre to the id. 

        public List<ArtistDTO> GetAllArtistDtos()
        {
            const string query =
                "SELECT ID, Name FROM Artist;";

            List<ArtistDTO> result = new List<ArtistDTO>();

            using var connection = DatabaseContext.CreateOpenConnection();
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                ArtistDTO artistDto = new ArtistDTO()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Name = (string)reader["ArtistName"]
                };
                result.Add(artistDto);
            }
            return result;
        }



        //public List<ArtistWithGenresDTO> GetArtistWithGenresList()
        //{
        //    const string query =
        //        @" SELECT 
        //Artist.ID AS ArtistID,
        //Artist.Name AS ArtistName,
        //Genre.ID AS GenreID,
        //Genre.Name AS GenreName
        //FROM Artist
        //JOIN ArtistGenre ON Artist.ID = ArtistGenre.ArtistID
        //JOIN Genre ON Genre.ID = ArtistGenre.GenreID;";

        //    var result = new List<ArtistWithGenresDTO>();
        //    var artistDict = new Dictionary<int, ArtistWithGenresDTO>();

        //    using (var connection = DatabaseContext.CreateOpenConnection())
        //    using (var command = new SqlCommand(query, connection))
        //    using (var reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            int artistID = Convert.ToInt32(reader["ArtistID"]);

        //            if (!artistDict.TryGetValue(artistID, out var artistDto))
        //            {
        //                artistDto = new ArtistWithGenresDTO
        //                {
        //                    ID = artistID,
        //                    Name = (string)reader["ArtistName"]
        //                };
        //                artistDict[artistID] = artistDto;
        //                result.Add(artistDto);
        //            }

        //            var genre = new GenreDTO
        //            {
        //                ID = Convert.ToInt32(reader["GenreID"]),
        //                Name = (string)reader["GenreName"]
        //            };
        //            artistDto.Genres.Add(genre);
        //        }
        //    }

        //    return result;
        //}





        public ArtistDTO GetArtistByName(string name)
    {
        using var connection = new SqlConnection(DatabaseContext.ConnectionString);
        string query = "SELECT ID, Name FROM artist WHERE Name = @Name";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Name", name);

        connection.Open();

        ArtistDTO artistDTO = null;

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            artistDTO = new ArtistDTO
            {
                ID = Convert.ToInt32(reader["ID"]),
                Name = (string)reader["Name"]
            };
        }
        return artistDTO;
    }


    //public void AddArtist(ArtistDTO.ArtistDTO artist);
    //public void UpdateArtist(ArtistDTO.ArtistDTO artist);

    //public void DeleteArtist(int ID);
    //{
    //}
    }
}
