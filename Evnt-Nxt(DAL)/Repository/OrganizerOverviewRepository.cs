using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt2.ViewModel;
using EvntNxtDTO;

namespace Evnt_Nxt_DAL_.Repository
{
    public class OrganizerOverviewRepository
    {
        public List<OrganizerOverviewDTO> GetEventTicketOverview()
        {
            var result = new List<OrganizerOverviewDTO>();

            using (var conn = new SqlConnection(DatabaseContext.ConnectionString))
            {
                conn.Open();

                var query = @"
                        SELECT
                            Event.ID AS EventID,
                            Event.Name AS EventName,
                            Event.Date AS EventDate,
                            Organizer.Name AS OrganizerName,
                            Organizer.ID AS OrganizerID,
                            EventTicket.Name AS TicketType,
                            EventTicket.Amount AS AvailableTickets,
                            COUNT(Ticket.ID) AS SoldTickets
                        FROM Event
                        JOIN Organizer ON Event.OrganizerID = Organizer.ID
                        JOIN EventTicket ON EventTicket.EventID = Event.ID
                        LEFT JOIN Ticket ON Ticket.TicketType = EventTicket.ID
                        GROUP BY 
                            Event.ID, 
                            Event.Name, 
                            Event.Date, 
                            Organizer.ID, 
                            Organizer.Name, 
                            EventTicket.Name, 
                            EventTicket.Amount
                        ORDER BY Event.Date, Event.Name, TicketType";


                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int eventId = Convert.ToInt32(reader["EventID"]);

                        var existingEvent = result.FirstOrDefault(e => e.EventID == eventId);

                        if (existingEvent == null)
                        {
                            existingEvent = new OrganizerOverviewDTO
                            {
                                EventID = eventId,
                                EventName = (string)reader["EventName"],
                                EventDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["EventDate"])),
                                OrganizerID = Convert.ToInt32(reader["OrganizerID"]),
                                OrganizerName = (string)reader["OrganizerName"]
                            };

                            result.Add(existingEvent);
                        }

                        existingEvent.TicketTypes.Add(new TicketTypeOverviewDTO
                        {
                            TicketType = (string)reader["TicketType"],
                            AvailableTickets = Convert.ToInt32(reader["AvailableTickets"]),
                            SoldTickets = Convert.ToInt32(reader["SoldTickets"])
                        });
                    }
                }
            }

            return result;
        }
    }
}
