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
        public List<EventDTO> GetEventDtos()
        {
            var Result = new List<EventDTO>();

            using (var Connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string Quarry = "Select * FROM Event";
                Connection.Open();
                using (SqlCommand Command = new SqlCommand(Quarry, Connection))
                using (var Reader = Command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        EventDTO eventDTO = new EventDTO();
                        {
                            eventDTO.ID = Convert.ToInt32(Reader["ID"]);
                            eventDTO.LineUpID = Convert.ToInt32(Reader["LineUpID"]);
                            eventDTO.Name = Reader["Name"].ToString();
                            eventDTO.GenreID = Convert.ToInt32(Reader["GenreID"]);
                            eventDTO.Organizer = Reader["Organizer"].ToString();
                            eventDTO.Location = Reader["Location"].ToString();
                            eventDTO.Province = Reader["Province"].ToString();
                            eventDTO.Date = DateOnly.FromDateTime((DateTime)Reader["Date"]);
                            eventDTO.Price = Convert.ToInt32(Reader["Price"].ToString());
                        }
                        Result.Add(eventDTO);
                    }
                }
                Connection.Close();
            }

            return Result;
        }
    }
}
