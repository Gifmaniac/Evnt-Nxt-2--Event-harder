using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Enums;

namespace Evnt_Nxt_Business_.ViewModel
{
    public class ArtistGenreViewModel
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public int GenreID { get; set; }
        public GenreEnums GenreName { get; set; }

         public List<string> GenreNames { get; set; }
    }
}
