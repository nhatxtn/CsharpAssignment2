using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoleDAO
    {
        private readonly ApplicationDbContext _context;

        public RoleDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void SaveRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRole(int roleId)
        {
            var role = _context.Roles.Find(roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
