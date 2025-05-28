using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;

namespace Evnt_Nxt_Business_.Services
{
    public class LoginService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly UserService _userService;
        public LoginService(IPasswordHasher password, UserService user)
        {
            _passwordHasher = password;
            _userService = user;
        }

        public bool VerifyLogin(string email, string password)
        {
            User user = _userService.GetUserByEmailAndPassword(email);

            if (user == null) 
                return false;

            return _passwordHasher.VerifyPassword(password, user.HashedPassword);
        }
    }
}
