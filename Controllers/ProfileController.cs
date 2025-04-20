using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThuQuan.Models;
using ThuQuan.ViewModels;

namespace ThuQuan.Controllers
{
    [Route("Account/[controller]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<Users> _userManager;

        public ProfileController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("Detail")]
        public async Task<IActionResult> Detail()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new ProfileViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName
            };

            return View(model);
        }

    }
}
