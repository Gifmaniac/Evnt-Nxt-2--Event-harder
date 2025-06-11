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

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
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

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
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
    }
}
