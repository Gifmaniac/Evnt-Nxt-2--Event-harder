using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Mapper;
using Evnt_Nxt_DAL_.DTO;
using Evnt_Nxt_DAL_.Repository;

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

        public User GetByEmail(string email)
        {
            UserDTO dto = _userRepository.GetPasswordByMail(email);

            if (dto == null)
                return null;

            User user = UserMapper.FromDtoToLogin(dto);

            return user;
        }

        public bool CheckUserByEmailAndUserName(string email, string userName)
        {
            bool doesUserExist = _userRepository.CheckUserByEmailAndUserName(email, userName);

            if (doesUserExist)
                return false;

            return doesUserExist;

        }
    }
}
