using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;
using System.Collections.Generic;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RolesController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult<Role> GetRoleById(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public ActionResult<Role> CreateRole(Role role)
        {
            _roleService.CreateRole(role);
            return CreatedAtAction(nameof(GetRoleById), new { id = role.RoleId }, role);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }
            _roleService.UpdateRole(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            _roleService.DeleteRole(role);
            return NoContent();
        }
    }
}
