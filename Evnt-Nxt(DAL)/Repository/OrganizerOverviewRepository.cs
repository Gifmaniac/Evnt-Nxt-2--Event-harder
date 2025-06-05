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
                            U.Username AS OrganizerName,
                            U.ID AS OrganizerUserID,
                            EventTicket.Name AS TicketType,
                            EventTicket.Amount AS AvailableTickets,
                            COUNT(Ticket.ID) AS SoldTickets
                        FROM Event
                        LEFT JOIN [User] U ON Event.OrganizerID = U.ID
                        JOIN EventTicket ON EventTicket.EventID = Event.ID
                        LEFT JOIN Ticket ON Ticket.TicketType = EventTicket.ID
                        WHERE OrganizerID = @organizerID
                        GROUP BY 
                            Event.ID, 
                            Event.Name, 
                            Event.Date, 
                            U.ID, 
	                        U.Username, 
                            EventTicket.Name, 
                            EventTicket.Amount
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
                                    OrganizerUserID = Convert.ToInt32(reader["OrganizerUserID"]),
                                    TicketTypes = new List<TicketTypeOverviewDTO>()
                                };

                                result.Add(existingEvent);
                            }

                            // Always add the ticket type
                            existingEvent.TicketTypes.Add(new TicketTypeOverviewDTO
                            {
                                TicketType = (string)reader["TicketType"],
                                AvailableTickets = Convert.ToInt32(reader["AvailableTickets"]),
                                SoldTickets = Convert.ToInt32(reader["SoldTickets"])
                            });
                        }
                    }

                    return result;
                }
            }
        }
    }
}
