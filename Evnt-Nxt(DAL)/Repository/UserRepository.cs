using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

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

        public UserDTO GetUserById(int id)
        {
            const string query = "SELECT * FROM [User] WHERE ID = @id";

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
                            return UserMapper.FullMap(reader);
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

            const string query = "SELECT Password FROM [User] WHERE Email = @email";

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
                            new UserDTO
                            {
                                Email = email,
                                Hashedpassword = (string)reader["Password"]
                            };
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
                                    WHERE Email = @email AND Username = @username";

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
