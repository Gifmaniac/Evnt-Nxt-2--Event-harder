using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Model
{
    public class ArtistViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<string> Genres { get; set; } = new();
    }
}
