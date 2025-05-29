using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
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

        public bool VerifyRegister(string email, string username, string password)
        {
            if (_userRepository.CheckUserByEmailAndUserName(email, username))
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

        public void RegisterUser(string email, string username, string password, string firstName, string lastName, DateOnly birthday)
        {
            string hashedPassword = _passwordHasher.HashPassword(password);
            User domainUser = UserMapper.FromViewModel(email, username, hashedPassword, firstName, lastName, birthday);
            var dto = UserMapper.RegisterToDto(domainUser);
            _userRepository.RegisterUser(dto);
        }
    }
}
