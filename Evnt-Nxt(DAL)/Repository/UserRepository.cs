using Evnt_Nxt_Business_.Mapper;
using Microsoft.Data.SqlClient;
using EvntNxt.DTO;

namespace Evnt_Nxt_DAL_.Repository
{
    public class UserRepository

    {
        private readonly DatabaseContext _db;

        public UserRepository(DatabaseContext db)
        {
            _db = db;
        }

        public UserDTO GetUserByName(string name)
        {
            const string query = "SELECT Username, ID FROM [User] WHERE Username = @Name";

            using (var connection = new SqlConnection(_db.ConnectionString))
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

        public int GetOrganizerIDbyUserID(int userID)
        {
            const string query = "SELECT ID FROM Organizer WHERE UserID = @UserID ";

            using (var connection = new SqlConnection(_db.ConnectionString))
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
    }
}