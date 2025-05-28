using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_DAL_.DTO;

namespace Evnt_Nxt_Business_.Mapper
{
    public static class UserMapper
    {

        public static User GetUserIDMailFirstAndLastName(UserDTO user)
        {
            var result = new User(user.ID, user.Email, user.FirstName, user.LastName);

            return result;
        }
    }
}
