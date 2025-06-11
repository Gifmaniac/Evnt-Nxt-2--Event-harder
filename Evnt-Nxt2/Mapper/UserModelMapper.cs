using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt2.ViewModel;
using EvntNxt.DTO;

namespace Evnt_Nxt2.Mapper
{
    public static class UserModelMapper
    {
        public static User FromRegisterViewModel(RegisterViewModel newUser)
        {
            return new User(newUser.UserName, newUser.Password, newUser.Email, newUser.FirstName, newUser.LastName,
                newUser.BirthDay);
        }

        public static UserDTO LoginDto(LoginViewModel newLogin)
        {
            return new UserDTO(newLogin.Email, newLogin.Password);
        }

        public static UserDTO RegisterDto(RegisterViewModel newUser)
        {
            return new UserDTO(newUser.UserName, newUser.Password, newUser.Email, newUser.FirstName, newUser.LastName,
                newUser.BirthDay);
        }
    }
}
