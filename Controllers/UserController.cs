using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ThuQuan.Data;
using ThuQuan.Models;

namespace ThuQuan.Controllers
{
    // public class UserController : Controller
    // {
    //     private readonly ThuQuanContext _context;
    //     public UserController(ThuQuanContext context)
    //     {
    //         _context = context;
    //     }
       

    //     public IActionResult Index()
    //     {
    //         return View();
    //     }

    //     public IActionResult Login()
    //     {
    //         return View();
    //     }

    //     [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     public async Task<IActionResult> Login(User user)
    //     {
    //         if(!ModelState.IsValid){
    //             return View(user);
    //         }

    //         var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);

    //         if(existingUser == null){
    //             TempData["Error"] ="Username không tồn tại";
    //             return View(user);
    //         }

    //         if(existingUser.Password != user.Password){
    //             TempData["Error"] = "Sai password";
    //             return View(user);
    //         }

    //         // Tạo claim và đăng nhập
    //         var claims = new List<Claim>
    //         {
    //             new Claim(ClaimTypes.Name, existingUser.Username),
    //             new Claim(ClaimTypes.Role, existingUser.Role)
    //         };

    //         var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    //         var principal = new ClaimsPrincipal(identity);

    //         await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    //         return RedirectToAction("Index", "Home");
    //     }
        
    //     public IActionResult Register()
    //     {
    //         return View();
    //     }

    //     [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     public async Task<IActionResult> Register(User user)
    //     {
    //         if(!ModelState.IsValid){
    //             return View(user);
    //         }

    //         var existingUser = _context.Users
    //                                 .FirstOrDefault(u => u.Email == user.Email || u.Username == user.Username);
            
    //         if(existingUser != null){
    //             ModelState.AddModelError("", "Email hoặc Username đã tồn tại.");
    //             return View(user);
    //         }

    //         _context.Users.Add(user);
    //         await _context.SaveChangesAsync();

    //         return RedirectToAction("Login");
    //     }

    //     public IActionResult Logout()
    //     {
    //         return RedirectToAction("Index", "Home");
    //     }
    // }
}
