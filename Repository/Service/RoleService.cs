using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class RoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAll().ToList();
        }

        public Role GetRoleById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public void CreateRole(Role role)
        {
            _roleRepository.Add(role);
        }

        public void UpdateRole(Role role)
        {
            _roleRepository.Update(role);
        }

        public void DeleteRole(Role role)
        {
            _roleRepository.Delete(role);
        }
    }
}
