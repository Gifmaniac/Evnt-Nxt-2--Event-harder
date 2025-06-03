using System.Configuration;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;
using EvntNxtDTO;

namespace Evnt_Nxt_Business_.Services
{
    public class RegisterService
    {
        private readonly RegisterRepository _registerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly RegisterValidator _registerValidator;

        public RegisterService(RegisterRepository registerRepository, IPasswordHasher passwordHasher, RegisterValidator registerValidator)
        {
            _registerRepository = registerRepository;
            _passwordHasher = passwordHasher;
            _registerValidator = registerValidator; 

        }

        public void VerifyRegister(RegisterDTO newUser)
        {
            // Verifies the user info
            if (_registerRepository.CheckUserByEmailAndUserName(newUser.Email, newUser.UserName))
                throw new ArgumentException("A user already exists with this email or username.");
            
            List<string> errors = _registerValidator.ValidateAll(newUser.Email, newUser.Password, newUser.UserName);

            if (errors.Any())
                throw new ArgumentException(string.Join(" | ", errors));
        }

        public void RegisterUser(RegisterDTO newUser)
        {
            string hashedPassword = _passwordHasher.HashPassword(newUser.Password);

            RegisterDTO dto = new RegisterDTO
            {
                Email = newUser.Email,
                Password = hashedPassword,
                UserName = newUser.UserName,
                BirthDay = newUser.BirthDay,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                RoleID = 1,                     // 1 Is default User
            };

            _registerRepository.RegisterUser(dto);
        }
    }
}
