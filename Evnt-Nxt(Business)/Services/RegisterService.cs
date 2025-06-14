﻿using System.Configuration;
using Evnt_Nxt_Business_.Interfaces;
<<<<<<< Updated upstream
=======
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.DTO;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
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
=======

        public void VerifyRegister(UserDTO newUser)
        {
            if (_userRepository.CheckUserByEmailAndUserName(newUser.Email, newUser.Username))
            {
                throw new Exception("A user already exist with this mail and or username");
            }

            List<string> errors = _registerValidator.ValidateAll(newUser.Hashedpassword, newUser.Username);

            if (errors.Any())
            {
                throw new Exception(string.Join(" | ", errors));
            }
        }

        public void RegisterUser(UserDTO newUser)
        {
            string hashedPassword = _passwordHasher.HashPassword(newUser.Hashedpassword);
            User domainUser = UserMapper.RegisterFromViewModel(newUser);
            var dto = UserMapper.RegisterToDto(domainUser, hashedPassword);
            _userRepository.RegisterUser(dto);
>>>>>>> Stashed changes
        }
    }
}
