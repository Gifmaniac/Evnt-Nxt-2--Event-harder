using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using EvntNxt.DTO;
using EvntNxtDTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DatabaseContext _db;

        public TicketRepository(DatabaseContext db)
        {
            _db = db;
        }

        public void AddTicketToUser(TicketDTO ticket, int quantity)
        {
            string query =
                @"INSERT INTO Ticket
                        (UserID, TicketType, PurchaseDate)
                    VALUES 
                        (@UserID, @TicketType, @PurchaseDate)";

            using (var connection = new SqlConnection(_db.ConnectionString))
            {
                connection.Open();

                for (int i = 0; i < quantity; i++)
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", ticket.UserID);
                        command.Parameters.AddWithValue("@TicketType", ticket.EventTicketID);
                        command.Parameters.AddWithValue("@PurchaseDate", ticket.PurchaseDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DecreaseAvailableTickets(int eventTicketID, int quantity)
        {
            const string query = @"            
                            UPDATE EventTicket
                                SET Amount = Amount - @Quantity
                                WHERE ID = @ID AND Amount >= @Quantity";

            using (var connection = new SqlConnection(_db.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", eventTicketID);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<UserProfileTicketDTO> GetTicketByUserID(int userID)
        {
            const string query = @"
                                SELECT 
                                    Event.ID AS EventID,
                                    Event.Name AS EventName,
                                    Event.Date AS EventDate
                                FROM Ticket
                                JOIN EventTicket ON Ticket.TicketType = EventTicket.ID
                                JOIN Event ON EventTicket.EventID = Event.ID
                                WHERE Ticket.UserID = @userId";

            var tickets = new List<UserProfileTicketDTO>();

            using (var connection = new SqlConnection(_db.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tickets.Add(new UserProfileTicketDTO()
                            {
                                EventID = Convert.ToInt32(reader["EventID"]),
                                EventName = (string)reader["EventName"],
                                EventDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["EventDate"])),
                            });
                        }
                    }
                }
            }

            return tickets;
        }
    }
}
