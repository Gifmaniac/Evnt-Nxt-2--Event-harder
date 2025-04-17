using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_
{
    class Genre
    {
        private int Id { get; set; }
        private GenreEnums Name { get; set; }

        public GenreEnums GetGenreName()
        {
            return Name;
        }
    }
}
