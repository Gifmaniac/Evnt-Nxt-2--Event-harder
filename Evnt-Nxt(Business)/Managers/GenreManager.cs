using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Managers
{
    class GenreManager
    {
        private int ID { get; set; }
        private GenreEnums Name { get; set; }

        public GenreEnums GetGenreName()
        {
            return Name;
        }

        public int GetID()
        {
            return ID;
        }
    }
}
