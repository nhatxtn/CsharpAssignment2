using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void CreateUser(User user)
        {
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }
    }
}
