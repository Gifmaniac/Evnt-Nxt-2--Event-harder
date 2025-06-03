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

        public User GetUserIDEmailFirstAndLastName(int userID)
        {
            UserDTO dto = _userRepository.GetUserById(userID);
            var user = UserMapper.FromDtoToBasic(dto);

            return user;
        }
    }
}
