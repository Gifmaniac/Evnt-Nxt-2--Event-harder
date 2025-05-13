using Evnt_Nxt_DAL_.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    while (reader.Read())
                    {
                        UserDTO CreateUserDto = new UserDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            RoleID = Convert.ToInt32(reader["Role"]),
                            Username = (string)reader["Username"],
                            Hashedpassword = (string)reader["Password"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Birthday = (DateTime)reader["BirthDate"],
                            Email = (string)reader["Email"]
                        };
                        result.Add(CreateUserDto);
                    }
                }
                connection.Close();
            }

            return result;
        }

    }
}
