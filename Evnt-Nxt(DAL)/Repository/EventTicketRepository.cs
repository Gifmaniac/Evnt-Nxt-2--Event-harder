using Evnt_Nxt_Business_.Interfaces;
using Microsoft.Data.SqlClient;
using EvntNxt.DTO;


namespace Evnt_Nxt_DAL_.Repository
{
    public class EventTicketRepository : IEventTicketRepository
    {

        private readonly DatabaseContext _db;

        public EventTicketRepository(DatabaseContext db)
        {
            _db = db;
        }


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

            using (var connection = _db.CreateOpenConnection())
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

            string query = @"SELECT ID, EventID, Name, Price, Amount, isAvailable, EventID FROM EventTicket 
                            WHERE EventID = @EventID AND isAvailable = 1";

            var result = new List<EventTicketDTO>();

            using (var connection = _db.CreateOpenConnection())
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
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                                EventID = Convert.ToInt32(reader["EventID"])
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

