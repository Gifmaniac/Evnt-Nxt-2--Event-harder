using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace EvntNxtDTO
{
    public class UserProfileTicketDTO
    {
        public int EventID {get; set; }
        public string EventName {get; set; }
        public DateOnly EventDate { get; set; }

    }
}
