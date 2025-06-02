using Evnt_Nxt_DAL_.DTO;
using EvntNxt.DTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Mapper
{
    public static class UserMapper
    {
        public static UserDTO FullMap(SqlDataReader reader)
        {
            return new UserDTO((string)reader["UserName"], (string)reader["Password"], (string)reader["Email"],
                (string)reader["FirstName"],
                (string)reader["LastName"], (DateOnly)reader["BirthDate"]);
        }
    }
}
