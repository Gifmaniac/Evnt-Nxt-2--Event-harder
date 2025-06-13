using Microsoft.Data.SqlClient;
using Evnt_Nxt_DAL_.Mapper;
using EvntNxt.DTO;

namespace Evnt_Nxt_DAL_.Repository
{
    public class UserRepository

    {
        public List<UserDTO> GetUsersDtos()
        {
            const string query = "SELECT * FROM Users";
            var result = new List<UserDTO>();

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Add(UserMapper.FullMap(reader));
                    }
                }
            }

            return result;
        }

        public UserDTO GetUserByName(string name)
        {
<<<<<<< Updated upstream
            const string query = "SELECT Username, ID FROM [User] WHERE Username = @Name";
=======
            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                const string query =
                    @"INSERT INTO [User]
                        (Role, Username, Password, FirstName, LastName, Birthday, Email)
                    VALUES 
                        (@Role, @Username, @Password, @FirstName, @LastName, @Birthday, @Email)";


                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Role", user.RoleID);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Hashedpassword);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Birthday", user.Birthday.ToDateTime(TimeOnly.MinValue));
                    command.Parameters.AddWithValue("@Email", user.Email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public UserDTO GetUserById(int id)
        {
            const string query = "SELECT ID, FirstName, LastName, Email FROM [User] WHERE ID = @id";
>>>>>>> Stashed changes

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
<<<<<<< Updated upstream
                            return new UserDTO((string)reader["Username"], Convert.ToInt32(reader["ID"]));
=======
                            return UserMapper.BasicMap(reader);
>>>>>>> Stashed changes
                        }
                    }
                }
            }

            throw new Exception("User not found");
        }

        public int GetOrganizerIDbyUserID(int userID)
        {
            const string query = "SELECT ID FROM Organizer WHERE UserID = @UserID ";

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int OrganizerID = reader.GetInt32(0);
                            return OrganizerID;
                        }
                    };
                }
            }
            throw new Exception("User not found");
        }
<<<<<<< Updated upstream
=======

        public UserDTO GetPasswordByMail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            const string query = @"SELECT Password FROM [User] 
                                    WHERE Email = @email";

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO(email, (string)reader["Password"]);
                        }
                        return null;
                    }
                }
            }
        }

        public bool CheckUserByEmailAndUserName(string email, string username)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            const string query = @"SELECT 1
                                 From [user] 
                                 WHERE 
                                    Email = @email OR 
                                    Username = @username";

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
>>>>>>> Stashed changes
    }
}