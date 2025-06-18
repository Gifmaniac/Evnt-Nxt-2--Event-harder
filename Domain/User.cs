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
        public string HashedPassword { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateOnly Birthday { get; }

        public List<Ticket> PurchasedTickets = new ();

        public User(string email, string hashedPassword)
        {
            Email = email;
            HashedPassword = hashedPassword;
        }

        public User(int id, string email, string firstName, string lastName)
        {
            ID = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string username, string hashedPassword, string email, string firstName, string lastName,
            DateOnly birthday)
        {
            Username = username;
            HashedPassword = hashedPassword;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            RoleID = 1; // Default role = Basic User
        }
    }
}
