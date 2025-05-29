using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_DAL_.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Hashedpassword { get; set; }
        public string Email { get; set; }
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday {get; set; }
    }
}
