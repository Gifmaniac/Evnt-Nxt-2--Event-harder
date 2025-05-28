using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_DAL_.DTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class TicketRepository
    {
        public void AddTicketToUser(TicketDTO ticket)
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

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
