using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_
{
    public static class SQLQueries
    {

        public const string GetArtistAndGenreIDWithName = @"
                Artist.ID AS ArtistID,
                Artist.Name AS ArtistName,
                Genre.ID AS GenreID,
                Genre.Name AS GenreName
                FROM Artist
                JOIN ArtistGenre ON Artist.ID = ArtistGenre.ArtistID    
                JOIN Genre ON Genre.ID = ArtistGenre.GenreID";


        public const string GetEventIDNameDateLocationProvince = @" 
                Event.ID AS EventID,
                Event.Name AS EventName,
                Event.Date AS EventDate,
                Event.Location AS EventLocation,
                Event.Province AS EventProvince";


        public const string GetTicketTypeIDNamePriceAmountAvailAble = @"
                TicketType.Name AS TicketTypeName,
                TicketType.Price AS TicketPrice,
                TicketType.Amount AS TicketTypeAmount,
                TicketType.IsAvailable AS TicketTypeNameIsAvailable";

        public const string GetEventTicketNamePriceAmountIsAvailable = @"
                EventTicket.ID AS EventTicketTypeID,
                EventTicket.Name AS EventTicketTypeName
                EventTicket.Price AS EventTicketPrice
                EventTicket.Amount AS EventTicketAmount
                EventTicket.IsAvailable AS EventTicketIsAvailable";

        public const string GetEventIDNameDate = @"                        
                Event.ID AS EventID,
                Event.Name AS EventName,
                Event.Date AS EventDate";

        public const string GetOrganizerIDName = @"
                Organizer.ID AS OrganizerID,
                Organizer.OrganizerName AS OrganizerName";

        public const string GetGenreIDName = @"                        
                Genre.ID AS GenreID,
                Genre.Name AS GenreName";

        public const string GetEventIDName = @"                        
                Event.ID AS EventID,
                Event.Name AS EventName";
    }
}
