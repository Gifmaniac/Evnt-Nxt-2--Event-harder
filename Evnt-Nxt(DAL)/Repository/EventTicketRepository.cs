using Evnt_Nxt_DAL_.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.Repository
{
    public class EventTicketRepository
    {



        public List<EventTicketDTO> GetTicketTypesWithEventIDNameDateDto()
        {
            string getEventTicketNamePriceAmountIsAvailable = SQLQueries.GetEventTicketNamePriceAmountIsAvailable;
            string getEventIDNameDate = SQLQueries.GetEventIDNameDate;
            string query = $@"
                            SELECT
                                {getEventTicketNamePriceAmountIsAvailable}
                                {getEventIDNameDate}
                           FROM EventTicket
                           JOIN Event ON EventTicket.EventID = Event.ID
                           WHERE EventTicket.IsAvailable = 1 AND Event.Date >= GETDATE()
                           ORDER BY Event.Date, EventTicket.Price
                            ";

            var result = new List<EventTicketDTO>();

            using (var connection = DatabaseContext.CreateOpenConnection())
            using (var command = new SqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var dto = new EventTicketDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        EventID = Convert.ToInt32(reader["EventID"]),
                        Name = (string)reader["Name"],
                        Price = Convert.ToDecimal(reader["Price"]),
                        Amount = Convert.ToInt32(reader["Amount"]),
                        IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),

                        Event = new EventDTO
                        {
                            ID = Convert.ToInt32(reader["EventID"]),
                            Name = (string)reader["EventName"],
                            Date = DateOnly.FromDateTime((DateTime)reader["EventDate"])
                        }
                    };
                    result.Add(dto);
                }

                return result;
            }
        }


            public List<EventTicketDTO> GetEventTicketsByEventID(int eventID)
        {

            string query = @"SELECT ID, EventID, Name, Price, Amount, isAvailable FROM EventTicket 
                            WHERE EventID = @EventID AND isAvailable = 1";

            var result = new List<EventTicketDTO>();

            using (var connection = DatabaseContext.CreateOpenConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EventID", eventID);
                //command.Parameters.AddWithValue("@ID", ticketID);
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dto = new EventTicketDTO
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = (string)reader["Name"],
                                Price = Convert.ToDecimal(reader["Price"]),
                                Amount = Convert.ToInt32(reader["Amount"]),
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            };
                            result.Add(dto);
                        }
                    }
                }
            }
            return result;
        }
    }
}

