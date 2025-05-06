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
                        GenreDTO genreDTO = new GenreDTO();
                        {
                            genreDTO.ID = Convert.ToInt32(Reader["ID"]);
                            genreDTO.Name = Reader["Name"].ToString();
                        }
                        Result.Add(genreDTO);
                    }
                }
                Connection.Close();
            }

            return Result;
        }
    }
}
