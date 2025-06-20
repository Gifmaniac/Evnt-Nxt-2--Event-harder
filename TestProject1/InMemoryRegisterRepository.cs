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

        public InMemoryRegisterRepository()
        {
            Users.Add(("w.vd.b@live.nl", "Willem"));
            Users.Add(("test@example.com", "TestUser"));
            Users.Add(("hello@world.com", "HelloWorld"));
            Users.Add(("jane@doe.com", "JaneD"));
        }


        public bool CheckUserByEmailAndUserName(string email, string username)
        {
            return Users.Any(user =>
                user.Email.Equals(email) ||
                user.UserName.Equals(username));
        }

        public void RegisterUser(RegisterDTO user)
        {
            Users.Add((user.Email, user.UserName));
        }
    }
}
