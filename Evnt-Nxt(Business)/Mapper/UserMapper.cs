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

        public static User RegisterFromViewModel(UserDTO user)
        {
            return new User(user.Username, user.Hashedpassword, user.Email, user.FirstName, user.LastName, user.Birthday);
        }

<<<<<<< Updated upstream
        public static UserDTO RegisterToDto(UserDTO user, string hashedPassword)
        {
            return new UserDTO(user.Username, hashedPassword, user.Email, user.FirstName, user.LastName, user.Birthday,
                1); // RoleID 1 == Default user.
=======
        public static UserDTO RegisterToDto(User user, string hashedPassword)
        {
            return new UserDTO(user.Email, user.Username, hashedPassword, user.FirstName, user.LastName, user.Birthday, user.RoleID);
>>>>>>> Stashed changes
        }

    }
}
