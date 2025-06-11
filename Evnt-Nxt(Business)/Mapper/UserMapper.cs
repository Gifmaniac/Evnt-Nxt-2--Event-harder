using System.ComponentModel.DataAnnotations;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_DAL_.DTO;
using EvntNxt.DTO;

namespace Evnt_Nxt_Business_.Mapper
{
    public static class UserMapper
    {

        // Contains ID, Email, FirstName and LastName
        public static User FromDtoToBasic(UserDTO user)
        {
            return new User(user.ID, user.Email, user.FirstName, user.LastName);
        }

        public static User FromDtoToLogin(UserDTO user)
        {
            return new User(user.Email, user.HashedPassword);
        }

        public static User FromViewModel(string email, string username, string password, string firstName, string lastName,
            DateOnly birthday)
        {
            return new User(username, password, email, firstName, lastName, birthday);
        }

        public static UserDTO RegisterToDto(UserDTO user, string hashedPassword)
        {
            return new UserDTO(user.Username, hashedPassword, user.Email, user.FirstName, user.LastName, user.Birthday,
                1); // RoleID 1 == Default user.
        }

    }
}
