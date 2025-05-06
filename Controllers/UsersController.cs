using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThuQuan.Models;

namespace ThuQuan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;

        public UsersController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userManager.Users.Select(u => new {
                u.Id,
                u.UserName,
                u.FullName,
                u.Email
            }).ToList();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Users model)
        {
            var result = await _userManager.CreateAsync(model, "Your@Default123");
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Users model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.UserName = model.UserName;
            user.FullName = model.FullName;
            user.Email = model.Email;

            await _userManager.UpdateAsync(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);
            return Ok();
        }
    }
}