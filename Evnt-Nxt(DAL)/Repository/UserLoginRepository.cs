using System.Diagnostics.CodeAnalysis;
using EvntNxtDTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class LoginRepository
    {
        public LoginDTO FetchUserLoginData(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            const string query = @"SELECT Password FROM [User] WHERE Email = @email";

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
                            return new LoginDTO
                            {
                                Email = email,
                                Password = (string)reader["Password"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public LoggedInUserDTO GetLoginInfoByEmail(string email)
        {
            const string query = @"SELECT ID, Username, Role 
                           FROM [User] 
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
                            return new LoggedInUserDTO
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                UserName = (string)reader["Username"],
                                RoleID = Convert.ToInt32(reader["Role"])
                            };
                        }
                    }
                }
            }

            return null;
        }

    }
}