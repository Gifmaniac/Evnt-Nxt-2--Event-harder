using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.DomainClass
{
    public class User
    {
        public int ID { get; }
        public int RoleID { get; }
        public string Username { get; }                 
        public string Hashedpassword { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime Birthday { get; }

        public List<Ticket> PurchasedTickets = new ();

        public User(int id, string email, string firstName, string lastName)
        {
            ID = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
