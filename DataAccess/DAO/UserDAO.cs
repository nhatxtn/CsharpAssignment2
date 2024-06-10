using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        private readonly ApplicationDbContext _context;

        public UserDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.Include(u => u.Publisher).ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Include(u => u.Publisher)
                                 .FirstOrDefault(u => u.UserId == userId);
        }

        public void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
