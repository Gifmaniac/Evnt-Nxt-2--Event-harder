using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_
{
    public class SQLQueries
    {
        public string GetArtistAndGenreDto()
        {
            string query = @"
                Artist.ID AS ArtistID,
                Artist.Name AS ArtistName,
                Genre.ID AS GenreID,
                Genre.Name AS GenreName
                FROM Artist
                JOIN ArtistGenre ON Artist.ID = ArtistGenre.ArtistID    
                JOIN Genre ON Genre.ID = ArtistGenre.GenreID;";

            return query;
        }

        public string GetEventIDNameDateLocationProvince()
        {
            string query = @" 
                Event.ID AS EventID,
                Event.Name AS EventName,
                Event.Date AS EventDate,
                Event.Location AS EventLocation,
                Event.Province AS EventProvince";

            return query;
        }

        public string GetTicketTypeIDNamePriceAmountAvailAble()
        {
            string query = @"
                TicketType.Name AS TicketTypeName,
                TicketType.Price AS TicketPrice,
                TicketType.Amount AS TicketTypeAmount,
                TicketType.IsAvailable AS AS TicketTypeNameIsAvailable";

            return query;
        }

        public string GetEventTicketNamePriceAmountIsAvailable()
        {
            string query = @"
                EventTicket.ID AS EventTicketTypeID,
                EventTicket.Name AS EventTicketTypeName
                EventTicket.Price AS EventTicketPrice
                EventTicket.Amount AS EventTicketAmount
                EventTicket.IsAvailable AS EventTicketIsAvailable";

            return query;
        }
        public string GetEventIDNameDate()
        {
            string query = @"                        
                Event.ID AS EventID,
                Event.Name AS EventName
                Event.Date as EventDate";

            return query;
        }
        public string GetOrganizerIDName()
        {
            string query = @"
                Organizer.ID AS OrganizerID,
                Organizer.Name AS OrganizerName";

            return query;
        }

        public string GetGenreIDName()
        {
            string query = @"                        
                Genre.ID AS GenreID,
                Genre.Name AS GenreName";

            return query;
        }

        public string GetEventIDName()
        {
            string query = @"                        
                Event.ID AS EventID,
                Event.Name AS EventName";

            return query;
        }
    }
}
