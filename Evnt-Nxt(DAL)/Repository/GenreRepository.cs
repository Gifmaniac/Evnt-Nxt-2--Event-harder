using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_DAL_.DTO;
using Microsoft.Data.SqlClient;

namespace Evnt_Nxt_DAL_.Repository
{
    public class GenreRepository
    {
        public List<GenreDTO> GetGenreDTOs()
        {
            var Result = new List<GenreDTO>();

            using (var Connection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                string Quarry = "Select * FROM Genres";
                Connection.Open();
                using (SqlCommand Command = new SqlCommand(Quarry, Connection))
                using (var Reader = Command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        GenreDTO GenreDto = new GenreDTO();
                        {
                            GenreDto.ID = Convert.ToInt32(Reader["ID"]);
                            GenreDto.Name = Reader["Name"].ToString();
                        }
                        Result.Add(GenreDto);
                    }
                }
                Connection.Close();
            }

            return Result;
        }
    }
}
