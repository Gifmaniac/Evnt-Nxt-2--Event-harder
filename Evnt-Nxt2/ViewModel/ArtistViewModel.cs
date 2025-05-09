using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.ViewModel;

namespace Evnt_Nxt_Prest.ViewModel
{
    public class ArtistViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string?> Genres { get; set; }
    }
}