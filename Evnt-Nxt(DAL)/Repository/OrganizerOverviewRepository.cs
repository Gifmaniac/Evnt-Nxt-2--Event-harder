using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvntNxtDTO;

namespace Evnt_Nxt_DAL_.Repository
{
    public class OrganizerOverviewRepository
    {
        public List<OrganizerOverviewPanelDTO> GetEventTicketOverviewByOrganizerID(int organizerID)
        {
            var result = new List<OrganizerOverviewPanelDTO>();

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                connection.Open();

                var query = @"
                       SELECT
                         Event.ID AS EventID,
                         Event.Name AS EventName,
                         Event.Date AS EventDate,
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
                     Where @OrganizerID = organizerID
                     GROUP BY 
                         Event.ID, 
                         Event.Name, 
                         Event.Date, 
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
    }
}
