using System.Configuration;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_DAL_.Repository;
using EvntNxtDTO;
using Microsoft.IdentityModel.Tokens;

namespace Evnt_Nxt_Business_.Services
{
    public class RegisterService
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRegisterValidator _registerValidator;

        public RegisterService(IRegisterRepository registerRepository, IPasswordHasher passwordHasher,
            IRegisterValidator registerValidator)
        {
            _registerRepository = registerRepository;
            _passwordHasher = passwordHasher;
            _registerValidator = registerValidator;

        }

        public (bool succes, List<String> Errors) VerifyRegister(RegisterDTO newUser)
        {
            var errors = new List<string>();

            // removes all the uppercases, this helps with not getting duplicated information in my database. 
            var normalizedEmail = newUser.Email.ToLowerInvariant();
            var normalizedUsername = newUser.UserName.ToLowerInvariant();

            // Validates normalized values
            errors.AddRange(_registerValidator.ValidateAll(normalizedEmail, newUser.Password, normalizedUsername));

            // Check for duplicates only if valid so far

            if (!errors.Any() && _registerRepository.CheckUserByEmailAndUserName(normalizedEmail, normalizedUsername))
            {
                errors.Add("A user already exists with this email or username.");
            }

            return (errors.Count == 0, errors);
        }

        public (bool Success, List<string> Errors) RegisterUser(RegisterDTO newUser)
        {
            var (isValid, errors) = VerifyRegister(newUser);

            if (!isValid)
            {
                return (false, errors);
            }


            string hashedPassword = _passwordHasher.HashPassword(newUser.Password);

            RegisterDTO dto = new RegisterDTO
            {
                Email = newUser.Email,
                Password = hashedPassword,
                UserName = newUser.UserName,
                BirthDay = newUser.BirthDay,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                RoleID = 1, // 1 Is default User
            };

            _registerRepository.RegisterUser(dto);
            return (true, new List<string>());
        }
    }
}

