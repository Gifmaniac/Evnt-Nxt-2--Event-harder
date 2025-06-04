using System.Configuration;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.Repository;
using EvntNxtDTO;

namespace Evnt_Nxt_Business_.Services
{
    public class RegisterService
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRegisterValidator _registerValidator;

        public RegisterService(IRegisterRepository registerRepository, IPasswordHasher passwordHasher, IRegisterValidator registerValidator)
        {
            _registerRepository = registerRepository;
            _passwordHasher = passwordHasher;
            _registerValidator = registerValidator; 

        }

        public (bool succes, List<String> Errors) VerifyRegister(RegisterDTO newUser)
        {
            var errors = new List<string>();

            if (_registerRepository.CheckUserByEmailAndUserName(newUser.Email, newUser.UserName))
            {
                errors.Add("A user already exists with this email or username.");
            }

            errors.AddRange(_registerValidator.ValidateAll(newUser.Email, newUser.Password, newUser.UserName));

            return (errors.Count == 0, errors);
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
