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
            var resultEvent = new List<EventDTO>();

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string query = @"Select ID as   FROM Event";
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var eventDTO = new EventDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = (string)reader["Name"],
                            Date = DateOnly.FromDateTime(Convert.ToDateTime(reader["Date"])),
                            Organiser = (string)reader["Organiser"],
                            Province = (string)reader["Province"],

                        };
                        resultEvent.Add(eventDTO);

                        var genreDTO = new GenreDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = (string)reader["Name"]
                        };
                    }
                }
                connection.Close();
            }

            return resultEvent;
        }
    }
}
