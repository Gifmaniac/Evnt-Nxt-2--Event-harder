using System.Configuration;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;

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

        public void VerifyRegister(UserDTO newUser)
        {
            if (_userRepository.CheckUserByEmailAndUserName(newUser.Email, newUser.Username))
            {
                throw new ArgumentException("A user already exist with this mail and or username");
            }
            
            List<string> errors = _registerValidator.ValidateAll(newUser.Email, newUser.Hashedpassword, newUser.Username);

            if (errors.Any())
            {
                throw new ArgumentException(string.Join(" | ", errors));
            }
        }

        public void RegisterUser(UserDTO newUser)
        {
            string hashedPassword = _passwordHasher.HashPassword(newUser.Hashedpassword);
            var dto = UserMapper.RegisterToDto(newUser, hashedPassword);
            _userRepository.RegisterUser(dto);
        }
    }
}
