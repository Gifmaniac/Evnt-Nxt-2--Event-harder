﻿using Microsoft.Data.SqlClient;
using EvntNxt.DTO;


namespace Evnt_Nxt_DAL_.Repository
{
    public class ArtistRepository

    {

        private readonly DatabaseContext _db;

        public ArtistRepository(DatabaseContext db)
        {
            _db = db;
        }

        // Recieves the artist with genre and puts them in a list. It also checks if an artist has multiple genres, if so we save the ID in a dictionary and add the genre to the id. 


        public List<ArtistWithGenresDTO> GetArtistWithGenresList()
        {
            string getArtistAndGenreQuery = SQLQueries.GetArtistAndGenreIDWithName;
            string query = $@"SELECT 
                            {getArtistAndGenreQuery}";

            var result = new List<ArtistWithGenresDTO>();
            var artistDict = new Dictionary<int, ArtistWithGenresDTO>();

            using (var connection = _db.CreateOpenConnection())
            using (var command = new SqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int artistID = Convert.ToInt32(reader["ArtistID"]);

                    if (!artistDict.TryGetValue(artistID, out var artistDto))
                    {
                        artistDto = new ArtistWithGenresDTO
                        {
                            ID = artistID,
                            Name = (string)reader["ArtistName"]
                        };
                        artistDict[artistID] = artistDto;
                        result.Add(artistDto);
                    }

                    var genre = new GenreDTO
                    {
                        ID = Convert.ToInt32(reader["GenreID"]),
                        Name = (string)reader["GenreName"]
                    };
                    artistDto.Genres.Add(genre);
                }
            }

            return result;
        }





        public ArtistDTO GetArtistByName(string name)
    {
        using var connection = new SqlConnection(_db.ConnectionString);
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
