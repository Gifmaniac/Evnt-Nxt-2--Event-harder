using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evnt_Nxt_Business_.Interfaces;
using EvntNxtDTO;

namespace TestProject1
{
    class InMemoryRegisterRepository : IRegisterRepository
    {
        private readonly List<(string Email, string UserName)> Users = new();

        public bool CheckUserByEmailAndUserName(string email, string username)
        {
            return Users.Any(user => user.Email == email || user.UserName == username);
        }

        public void RegisterUser(RegisterDTO user)
        {
            Users.Add((user.Email, user.UserName));
        }
    }
}
