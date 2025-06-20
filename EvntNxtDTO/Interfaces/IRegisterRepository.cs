using EvntNxtDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IRegisterRepository
    {
        bool CheckUserByEmailAndUserName(string email, string username);
        void RegisterUser(RegisterDTO user);
    }
}
