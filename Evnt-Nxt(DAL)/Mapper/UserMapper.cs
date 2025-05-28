using Evnt_Nxt_DAL_.DTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Mapper
{
    public static class UserMapper
    {
        public static UserDTO FullMap(SqlDataReader reader)
        {
            return new UserDTO
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
        }
    }
}
