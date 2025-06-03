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
            const string query = "SELECT Username, ID FROM [User] WHERE Username = @Name";

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
                            return new UserDTO((string)reader["Username"], Convert.ToInt32(reader["ID"]));
                        }
                    }
                }
            }
            throw new Exception("User not found");
        }
    }
}