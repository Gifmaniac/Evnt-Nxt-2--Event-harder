using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.Repository;

namespace Evnt_Nxt_Business_.Services
{
    public class RegisterService
    {
        private readonly UserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly RegisterValidator _registerValidator;

        public RegisterService(UserRepository userRepository, IPasswordHasher passwordHasher, RegisterValidator registerValidator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _registerValidator = registerValidator; 

        }

        public List<string> GetValidationErrors(string email, string username, string password)
        {
            List<string> errors = _registerValidator.ValidateAll(email, password, username);

            return errors;
        }

        public bool VerifyRegister(string email, string username, string password, string fristName, string lastName, DateOnly birthday)
        {
            if (_userRepository.CheckUserByEmailAndUserName(email, username) != null)
            {
                return false;
            }

            List<string> errors = _registerValidator.ValidateAll(email, password, username);

            if (errors.Any())
            {
                return false;
            }

            return true;
        }
    }
}
