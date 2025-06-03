namespace EvntNxt.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday {get; set; }

        public UserDTO(string username, int id)
        {
            Username = username;
            ID = id;
        }
        public UserDTO(string email, string password)
        {
            Email = email;
            HashedPassword = password;
        }
        public UserDTO(string username, string hashedpassword, string email, string firstName, string lastName, DateOnly birthday)
        {
            Username = username;
            HashedPassword = hashedpassword;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public UserDTO(string username, string hashedpassword, string email, string firstName, string lastName, DateOnly birthday, int roleID)
        {
            Username = username;
            HashedPassword = hashedpassword;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            RoleID = roleID;
        }
    }
}
