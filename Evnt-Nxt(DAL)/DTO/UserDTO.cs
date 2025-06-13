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

        public UserDTO(string email, string password)
        {
            Email = email;
            Hashedpassword = password;
        }

        public UserDTO(int id, string email, string firstName, string lastName)
        {
            ID = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public UserDTO(string email, string username, string password, string firstName, string lastName,
            DateOnly birthday)
        {
            Email = email;
            Username = username;
            Hashedpassword = password;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public UserDTO(string email, string username, string password, string firstName, string lastName,
            DateOnly birthday, int roleID)
        {
            Email = email;
            Username = username;
            Hashedpassword = password;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            RoleID = roleID;
        }

        public UserDTO(int id, string email, string username, string password, string firstName, string lastName,
            DateOnly birthday, int roleID)
        {
            ID = id;
            Email = email;
            Username = username;
            Hashedpassword = password;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            RoleID = roleID;
        }

    }
}
