﻿using EvntNxt.DTO;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Evnt_Nxt_DAL_.Repository
{

    public class EventRepository
    {
        private readonly DatabaseContext _db;

        public EventRepository(DatabaseContext db)
        {
            _db = db;
        }

        public List<EventWithOrganizerAndGenreDTO> GetEventsWithOrganizerAndGenreDtos()
        {
            var result = new List<EventWithOrganizerAndGenreDTO>();
            var eventDict = new Dictionary<int, EventWithOrganizerAndGenreDTO>();
            string eventquery = SQLQueries.GetEventIDNameDateLocationProvince;
            string organizerquery = SQLQueries.GetOrganizerIDName;
            string genrequery = SQLQueries.GetGenreIDName;


            using (var connection = new SqlConnection(_db.ConnectionString))
            {
                string query =
                    $@"SELECT
                        {eventquery},
                        {organizerquery},
                        {genrequery}        
                    FROM Event
                    JOIN EventGenre ON Event.ID = EventGenre.EventID
                    JOIN Genre ON Genre.ID = EventGenre.GenreID
                    JOIN Organizer ON Event.OrganizerID = Organizer.ID";

                connection.Open();

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int eventID = Convert.ToInt32(reader["EventID"]);

                        if (!eventDict.TryGetValue(eventID, out var eventDTO))
                        {

                            eventDTO = new EventWithOrganizerAndGenreDTO
                            {
                                ID = Convert.ToInt32(reader["EventID"]),
                                Name = (string)reader["EventName"],
                                Date = DateOnly.FromDateTime(Convert.ToDateTime(reader["EventDate"])),
                                Province = (string)reader["EventProvince"],
                            };
                            eventDict[eventID] = eventDTO;
                            result.Add(eventDTO);
                        }

                        var genre = new GenreDTO
                        {
                            ID = Convert.ToInt32(reader["GenreID"]),
                            Name = (string)reader["GenreName"]
                        };
                        eventDTO.Genres.Add(genre);

                        var organizer = new OrganizerDTO
                        {
                            ID = Convert.ToInt32(reader["OrganizerID"]),
                            Name = (string)reader["OrganizerName"]
                        };

                        eventDTO.Organizer = organizer;
                    }

                    ;
                }

                connection.Close();
            }

            return result;
        }

        public EventDTO GetEventByID(int ID)
        {
            try
            {
                using var connection = new SqlConnection(_db.ConnectionString);
                string query = "SELECT ID, Name FROM Event WHERE ID = @ID";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();

                EventDTO eventDTO = null;

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    eventDTO = new EventDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = (string)reader["Name"]
                    };
                }

                return eventDTO;
            }
            catch (Exception ex)
            {
                // Log the error if you have logging set up
                Debug.WriteLine($"[ERROR] GetEventByID failed: {ex.Message}");

                // Optional: You could also rethrow or return null
                return null;
            }
        }
    }
}
