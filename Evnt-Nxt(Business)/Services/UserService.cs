using System.Runtime.CompilerServices;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.Repository;
using EvntNxt.DTO;

namespace Evnt_Nxt_Business_.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO GetUserName(string username)
        {
            return _userRepository.GetUserByName(username);

        }

        public int GetOrganizerIDFromUserID(int userID)
        {
            return _userRepository.GetOrganizerIDbyUserID(userID);
        }
    }
}
