using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_DAL_.ArtistDTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Evnt_Nxt_DAL_
{
    public class ArtistRepository
    {
        private static readonly string ConnectionString =
            "Server=mssqlstud.fhict.local;Database=dbi567108_nxtevnt;User Id=dbi567108_nxtevnt;Password=Test123;TrustServerCertificate=True;";

        // Recieves all the information from the database and puts them in a list.
        public List<ArtistDTO.ArtistDTO> GetAllArtist()
        {
            var result = new List<ArtistDTO.ArtistDTO>();

            using (var Connection = new SqlConnection(ConnectionString))
            {
                string Quarry = "SELECT * FROM Artist";
                Connection.Open();
                using (SqlCommand cmd = new SqlCommand(Quarry, Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Creates an DTO of the artist that I want to create
                        ArtistDTO.ArtistDTO ArtistDTO = new ArtistDTO.ArtistDTO();
                        {
                            ArtistDTO.ID = Convert.ToInt32(reader["ID"]);
                            ArtistDTO.Name = reader["Name"].ToString();
                        }
                        result.Add(ArtistDTO);
                    }
                }

                Connection.Close();
            }

            return result;
        }
    }
}
