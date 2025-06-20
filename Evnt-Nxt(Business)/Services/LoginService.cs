using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;
using EvntNxtDTO;

namespace Evnt_Nxt_Business_.Services
{
    public class LoginService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly LoginRepository _userLoginRepository;

        public LoginService(IPasswordHasher password, LoginRepository user)
        {
            _passwordHasher = password;
            _userLoginRepository = user;
        }

        public (bool Success, string ErrorMessage) ValidateLogin(LoginDTO loginDto)
        {
            // Tries to fetch the user login data
            LoginDTO userInDb = _userLoginRepository.FetchUserLoginData(loginDto.Email);

            if (userInDb == null)
            {
                return (false, "Invalid email or password.");
            }

            // If the user exist verifies the password with the Email.
            bool passwordMatches = _passwordHasher.VerifyPassword(loginDto.Password, userInDb.Password);
            if (!passwordMatches)
            {
                return (false, "Invalid email or password.");
            }

            return (true, null);
        }

        public LoggedInUserDTO GetLoginInfo(string email)
        {
            // Gets the user info (ID, UserID, Username)
            return _userLoginRepository.GetLoginInfoByEmail(email);
        }
    }
}
