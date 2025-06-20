using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Interfaces
{
    public interface IRegisterValidator
    {
        public List<string> ValidateAll(string email, string password, string username);
    }
}
