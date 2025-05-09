using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_DAL_.DTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class EventRepository
    {
        public List<EventDTO> GetEvents()
        {
            var result = new List<EventDTO>();

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string query = "Select * FROM Event";
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var eventDTO = new EventDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            LineUpID = Convert.ToInt32(reader["LineUpID"]),
                            Name = (string)reader["Name"],
                            GenreID = Convert.ToInt32(reader["GenreID"]),
                            Organizer = (string)reader["Organizer"],
                            Location = (string)reader["Location"],
                            Province = (string)reader["Province"],
                            Date = DateOnly.FromDateTime(Convert.ToDateTime(reader["Date"])),
                            Price = Convert.ToInt32(reader["Price"]),
                        };
                        result.Add(eventDTO);
                    }
                }
                connection.Close();
            }

            return result;
        }
    }
}
