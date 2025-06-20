using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvntNxt.DTO;
using EvntNxtDTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Reflection;

namespace Evnt_Nxt_DAL_.Repository
{
    public class OrganizerOverviewRepository
    {
        private readonly DatabaseContext _db;

        public OrganizerOverviewRepository(DatabaseContext db)
        {
            _db = db;
        }

        public List<OrganizerOverviewPanelDTO> GetEventTicketOverviewByOrganizerID(int organizerID)
        {
            var result = new List<OrganizerOverviewPanelDTO>();

            using (var connection = new SqlConnection(_db.ConnectionString))
            {
                connection.Open();

                var query = @"
                     SELECT
                         Event.ID AS EventID,
                         Event.Name AS EventName,
                         Event.Date AS EventDate,
                         Event.Location AS EventLocation,
                         Event.Province AS EventProvince,
                         Organizer.ID AS OrganizerID,
                         Organizer.OrganizerName AS OrganizerName,
                         EventTicket.Name AS TicketType,
                         EventTicket.Amount AS AvailableTickets,
                         EventTicket.Price AS EventTicketPrice,
                         COUNT(Ticket.ID) AS SoldTickets
                     FROM Event
                     JOIN Organizer ON Event.OrganizerID = Organizer.ID
                     JOIN [User] ON Organizer.UserID = [User].ID
                     JOIN EventTicket ON EventTicket.EventID = Event.ID
                     LEFT JOIN Ticket ON Ticket.TicketType = EventTicket.ID
                     WHERE @OrganizerID = organizerID
                     GROUP BY 
                         Event.ID, 
                         Event.Name, 
                         Event.Date,
                         Event.Province,
                         Event.Location,
                         Organizer.ID,
                         Organizer.OrganizerName,
                         EventTicket.Name, 
                         EventTicket.Amount,
                         EventTicket.Price
                     ORDER BY Event.Date, Event.Name, TicketType";


                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrganizerID", organizerID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int eventID = Convert.ToInt32(reader["EventID"]);

                            // Find existing event in the result list
                            var existingEvent = result.FirstOrDefault(e => e.EventID == eventID);

                            // If not found, create it and add it to the list
                            if (existingEvent == null)
                            {
                                existingEvent = new OrganizerOverviewPanelDTO
                                {
                                    EventID = eventID,
                                    EventName = (string)reader["EventName"],
                                    EventDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["EventDate"])),
                                    EventLocation = (string)reader["EventLocation"],
                                    EventProvince = (string)reader["EventProvince"],
                                    OrganizerID = organizerID,
                                    OrganizerName = (string)reader["OrganizerName"],
                                    OrganizerUserID = Convert.ToInt32(reader["OrganizerID"]),
                                    TicketTypes = new List<TicketTypeOverviewDTO>()
                                };

                                result.Add(existingEvent);
                            }

                            // Always add the ticket type
                            existingEvent.TicketTypes.Add(new TicketTypeOverviewDTO
                            {
                                TicketType = (string)reader["TicketType"],
                                AvailableTickets = Convert.ToInt32(reader["AvailableTickets"]),
                                SoldTickets = Convert.ToInt32(reader["SoldTickets"]),
                                Price = Convert.ToDecimal(reader["EventTicketPrice"])
                            });
                        }
                    }

                    return result;
                }
            }
        }

        public void ChangeEventDetails(OrganizerOverviewPanelDTO organizerDto)
        {
            var query = @"
                        UPDATE Event 
                        SET Name = @Name, Date = @Date, Location = @Location, Province = @Province WHERE ID = @EventID";

            using (var connection = new SqlConnection(_db.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", organizerDto.EventName);
                command.Parameters.AddWithValue("@Date", organizerDto.EventDate);
                command.Parameters.AddWithValue("@Location", organizerDto.EventLocation);
                command.Parameters.AddWithValue("@Province", organizerDto.EventProvince);
                command.Parameters.AddWithValue("@EventID", organizerDto.EventID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ChangeTicketDetails(OrganizerOverviewPanelDTO organizerDto)
        {
            var query = @"
                        UPDATE EventTicket 
                        SET Amount = @Amount, Price = @Price  
                        WHERE EventID = @EventID AND Name = @TicketName";

            using (var connection = new SqlConnection(_db.ConnectionString))
            {
                connection.Open();

                foreach (var ticket in organizerDto.TicketTypes)
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Amount", ticket.AvailableTickets);
                        command.Parameters.AddWithValue("@Price", ticket.Price);
                        command.Parameters.AddWithValue("@EventID", organizerDto.EventID);
                        command.Parameters.AddWithValue("@TicketName", ticket.TicketType);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteEventWithTickets(int eventID)
        {
            using var connection = new SqlConnection(_db.ConnectionString);

            // This subquery selects all EventTicket IDs that belong to a specific event and deletes them from the Ticket table.  
            const string deleteTicket =
                "DELETE FROM Ticket WHERE TicketType IN (SELECT ID FROM EventTicket WHERE EventID = @eventID)";

            const string deleteEventTicket =
                "DELETE FROM EventTicket WHERE EventID = @eventID";

            const string deleteEventGenre =
                "DELETE FROM EventGenre WHERE EventID = @eventID";

            const string deleteEvent =
                "DELETE FROM Event WHERE ID = @ID";


            connection.Open();

            // Because I use multiple queries here I use BeginTransaction so if anything fails I can restore all the deleted data.
            using var transaction = connection.BeginTransaction();

            try
            {
                // 1. Delete Tickets
                using (var cmd1 = new SqlCommand(deleteTicket, connection, transaction))
                {
                    cmd1.Parameters.AddWithValue("@eventID", eventID);
                    cmd1.ExecuteNonQuery();
                }

                // 2. Delete EventTickets
                using (var cmd2 = new SqlCommand(deleteEventTicket, connection, transaction))
                {
                    cmd2.Parameters.AddWithValue("@eventID", eventID);
                    cmd2.ExecuteNonQuery();
                }

                // 3. Deletes the Event Genre.
                using (var cmd3 = new SqlCommand(deleteEventGenre, connection, transaction))
                {
                    cmd3.Parameters.AddWithValue("@eventID", eventID);
                    cmd3.ExecuteNonQuery();
                }

                // 4. Delete Event
                using (var cmd4 = new SqlCommand(deleteEvent, connection, transaction))
                {
                    cmd4.Parameters.AddWithValue("@ID", eventID);
                    cmd4.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                // If anything fails the program will roll it all back
                transaction.Rollback();
                throw;
            }
        }
    }
}
