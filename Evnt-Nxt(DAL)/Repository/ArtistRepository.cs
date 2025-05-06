using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;


namespace Evnt_Nxt_DAL_.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        // Recieves all the information from the database and puts them in a list.
        public List<ArtistDTO.ArtistDTO> GetArtistDtos()
        {
            var Result = new List<ArtistDTO.ArtistDTO>();

            using (var Connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string Query = "SELECT * FROM Artist";
                Connection.Open();
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                using (var Reader = Command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        // Holds the DTO information that I want to store
                        ArtistDTO.ArtistDTO artistDTO = new ArtistDTO.ArtistDTO();
                        {
                            artistDTO.ID = Convert.ToInt32(Reader["ID"]);
                            artistDTO.Name = Reader["Name"].ToString();
                        }
                        Result.Add(artistDTO);
                    }
                }

                Connection.Close();
            }

            return Result;
        }

        public ArtistDTO.ArtistDTO GetArtistByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Please fill in a Artist name.");
            }

            ArtistDTO.ArtistDTO Artist = null;

            using (var Connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string Query = $"SELECT NAME, NAME FROM Artist WHERE Name Like @Name";
                Connection.Open();
                using (var Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@Name", "%" + Name + "%");
                    using (var Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())

                            return new ArtistDTO.ArtistDTO(
                            {
                                ID = Reader.GetInt32(0),
                                Name = Reader.GetString(1)
                            };
                    }
                    
                }
            }

            return null;
        }
        //public void AddArtist(ArtistDTO.ArtistDTO artist);
        //public void UpdateArtist(ArtistDTO.ArtistDTO artist);

        //public void DeleteArtist(int ID);
        //{
        //}
    }
}
