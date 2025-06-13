using EvntNxt.DTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Mapper
{
    public static class UserMapper
    {
        public static UserDTO FullMap(SqlDataReader reader)
        {
<<<<<<< Updated upstream
            return new UserDTO((string)reader["UserName"], (string)reader["Password"], (string)reader["Email"],
                (string)reader["FirstName"],
                (string)reader["LastName"], (DateOnly)reader["BirthDay"]);
=======
            return new UserDTO(
                Convert.ToInt32(reader["ID"]),
                (string)reader["Email"],
                (string)reader["Username"],
                (string)reader["Password"],
                (string)reader["FirstName"],
                (string)reader["FirstName"],
                (DateOnly)reader["BirthDate"],
                (int)reader["Role"]);
        }

        public static UserDTO BasicMap(SqlDataReader reader)
        {
            return new UserDTO(
                Convert.ToInt32(reader["ID"]), 
                (string)reader["Email"],
                (string)reader["FirstName"], 
                (string)reader["LastName"]
            );
>>>>>>> Stashed changes
        }
    }
}
