using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using System.Reflection.PortableExecutable;


namespace Evnt_Nxt_DAL_.Repository
{
    public class ArtistRepository : IArtistRepository

    {
    // Recieves all the information from the database and puts them in a list.
    public List<ArtistDTO> GetAllArtist()
    {
        var result = new List<ArtistDTO>();

        string query = "SELECT * FROM Artist";
        using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var artistDTO = new ArtistDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = (string)reader["Name"]
                    };
                }
            }

            connection.Close();
        }

        return result;
    }

    public ArtistDTO SearchByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Please fill in a Artist name.");
        }

        using var connection = new SqlConnection(DatabaseContext.ConnectionString);
        {
            string query = $"SELECT NAME, ID FROM Artist WHERE Name Like @Name";
            connection.Open();
            using var command = new SqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@Name", "%" + name + "%");
                using var reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var artistDTO = new ArtistDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = (string)reader["Name"]
                        };

                    }
                }
            }
        }
        return null;
    }

    public ArtistDTO GetArtistByName(string name)
    {
        using var connection = new SqlConnection(DatabaseContext.ConnectionString);
        {
            string query = "SELECT ID, Name FROM artist WHERE Name = @Name";

            using var command = new SqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();

                using var reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var artistDTO = new ArtistDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = (string)reader["Name"]
                        };
                    }
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
