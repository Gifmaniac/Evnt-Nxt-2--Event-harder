using Evnt_Nxt_Business_.Interfaces;
using EvntNxtDTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly DatabaseContext _db;

        public RegisterRepository(DatabaseContext db)
        {
            _db = db;
        }

        public void RegisterUser(RegisterDTO user)
        {
            using (var connection = new SqlConnection(_db.ConnectionString))
            {
                string query = @"INSERT INTO [User]
                                (Role, Username, Password, FirstName, LastName, Birthday, Email)
                                VALUES
                                (@Role, @Username, @Password, @FirstName, @LastName, @Birthday, @Email)";

                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Role", user.RoleID);
                    command.Parameters.AddWithValue("@Username", user.UserName);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Birthday", user.BirthDay.ToDateTime(TimeOnly.MinValue));
                    command.Parameters.AddWithValue("@Email", user.Email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CheckUserByEmailAndUserName(string email, string username)
        {
            const string query = @"SELECT 1 FROM [User]
                                    WHERE Email = @email OR Username = @username";


            using (var connection = new SqlConnection(_db.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }
    }
}