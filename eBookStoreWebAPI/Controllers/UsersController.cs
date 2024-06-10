using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.Service;
using System.Collections.Generic;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(user);
            return NoContent();
        }
    }
}
