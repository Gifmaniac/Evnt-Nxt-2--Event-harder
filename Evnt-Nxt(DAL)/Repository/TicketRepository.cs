using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Interfaces;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class TicketRepository : ITicketRepository
    {
        public void AddTicketToUser(TicketDTO ticket, int quantity)
        {
            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string query =
                    @"INSERT INTO Ticket
                        (UserID, TicketType, PurchaseDate)
                    VALUES 
                        (@UserID, @TicketType, @PurchaseDate)";


                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", ticket.UserID);
                    command.Parameters.AddWithValue("@TicketType", ticket.EventTicketID);
                    command.Parameters.AddWithValue("@PurchaseDate", ticket.PurchaseDate);
                    command.Parameters.AddWithValue("@ID", ticket.EventTicketID);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DecreaseAvailableTickets(int eventTicketID, int quantity)
        {
            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                const string query = @"            
                            UPDATE EventTicket
                                SET Amount = Amount - @Quantity
                                WHERE ID = @ID AND Amount >= @Quantity";

                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", eventTicketID);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
