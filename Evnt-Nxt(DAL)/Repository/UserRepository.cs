using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
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

        public void RegisterUser(UserDTO user)
        {
            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string query =
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
            const string query = "SELECT ID FROM [User] WHERE ID = @id";

            using (var connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO(Convert.ToInt32(reader["ID"]));
                        }
                    }
                }
            }
            throw new Exception("User not found");
        }

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
                            return new UserDTO(email, (string)reader["Passpword"]);
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
    }
}
