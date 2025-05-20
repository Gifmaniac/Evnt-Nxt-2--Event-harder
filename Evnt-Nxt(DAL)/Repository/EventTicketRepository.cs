using Evnt_Nxt_DAL_.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.Repository
{
    public class EventTicketRepository
    {
        private SQLQueries _query = new();

        public List<EventTicketDTO> GetTicketTypesWithEventIDNameDateDto()
        {
            string getEventTicketNamePriceAmountIsAvailable = _query.GetEventTicketNamePriceAmountIsAvailable();
            string getEventIDNameDate = _query.GetEventIDNameDate();
            string query = $@"
                            SELECT 
                                {getEventTicketNamePriceAmountIsAvailable}
                                {getEventIDNameDate}
                           FROM EventTicket
                           JOIN Event ON EventTicket.EventID = Event.ID
                           WHERE EventTicket.IsAvailable = 1 AND Event.Date >= GETDATE()
                           ORDER BY Event.Date, EventTicket.Price;
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
                        Event = new EventDTO
                        {
                            ID = Convert.ToInt32(reader["EventID"]),
                            Name = (string)reader["EventName"],
                            Date = DateOnly.FromDateTime((DateTime)reader["EventDate"])
                        },
                        Ticket = new TicketDTO
                        {
                            ID = Convert.ToInt32(reader["TicketTypeID"]),
                            Name = (string)reader["TicketTypeName"],
                            Price = Convert.ToDecimal(reader["Price"]),
                            Amount = Convert.ToInt32(reader["Amount"]),
                            IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                        }
                    };
                    result.Add(dto);
                }
            }
            return result;
        }
    }
}