using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Evnt_Nxt_DAL_
{
    public class ArtistRepository
    {
        private readonly string ConnectionString;

        public ArtistRepository(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString(ConnectionString);
        }

        public List<(string ArtistName, string GenreName)> GetartistList()
        {
            var result = new List<(string, string)>();
            string query = @"SELECT a.Name, g.Name FROM Artist a JOIN ArtistGenre ag ON a.Id = ag.ArtistId
                         JOIN Genre g ON ag.GenreId = g.Id";
            return new List<(string ArtistName, string GenreName)>();
        }
    }
}
