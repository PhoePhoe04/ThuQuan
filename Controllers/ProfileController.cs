using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThuQuan.Data;
using ThuQuan.Models;
using ThuQuan.ViewModels;

namespace ThuQuan.Controllers
{
    [Route("Account/[controller]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly ThuQuanContext _context;

        public ProfileController(UserManager<Users> userManager, ThuQuanContext context)
        {
            _userManager = userManager;
            _context = context;
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
                UserName = user.UserName,
                CreatedAt = user.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")
            };

            return View(model);
        }

        [HttpGet("rentHistory")]
        public async Task<IActionResult> RentHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["ActiveTab"] = "RentHistory";

            CapNhatTrangThai();

            // Lấy dữ liệu từ Database
            var borrows = _context.Borrows
                .Include(b => b.Device)
                .ThenInclude(d => d.Category)
                .Where(b => b.UserId == user.Id)
                .Select(b => new RentHistoryViewModel
                {
                    Id = b.Id,
                    ImageUrl = b.Device.ImageUrl,
                    DeviceName = b.Device.Name,
                    CategoryName = b.Device.Category.Name,
                    BorrowTime = b.BorrowTime,
                    ReturnTime = b.ReturnTime,
                    Quantity = b.Quantity,
                    Total = b.Total,
                    Status = b.Status
                })
                .ToList();
            
            return View("rentHistory",borrows);
        }

        [HttpPost]
        [Route("thanh-toan/{id}")]
        public async Task<IActionResult> ThanhToan(int id)
        {
            var borrow = _context.Borrows.Find(id);
            if (borrow != null && borrow.Status == "Chờ thanh toán")
            {
                borrow.Status = "Đang thuê";
                _context.SaveChanges();
            }
            return RedirectToAction("RentHistory");
        }
        
       [HttpPost]
       [Route("tra-thiet-bi/{id}")]
        public IActionResult TraThietBi(int id)
        {
            var borrow = _context.Borrows.Find(id);
            if (borrow != null && borrow.Status == "Đang thuê")
            {
                borrow.Status = "Đã trả";
                _context.SaveChanges();
            }
            return RedirectToAction("RentHistory");
        }

        [HttpPost]
        [Route("cap-nhat-trang-thai")]
        public async Task<IActionResult> CapNhatTrangThai()
        {
            var borrows = _context.Borrows.ToList();
            foreach (var borrow in borrows)
            {
                if (borrow.ReturnTime < DateTime.Now.AddDays(-2) && borrow.Status == "Đang thuê")
                {
                    borrow.Status = "Trễ hạn";
                }
            }
            _context.SaveChanges();
            return RedirectToAction("RentHistory");
        }
        // Violation History
        [HttpGet("violationHistory")]
        public async Task<IActionResult> ViolationHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["ActiveTab"] = "RentHistory";

            // Lấy dữ liệu từ Database
            var violationDetails = _context.ViolationDetails
                .Include(v => v.Device)
                .Include(v => v.Violation)
                .Include(v => v.User)
                .Select(b => new ViolationHistoryViewModel
                {
                    CreatedAt = b.CreatedAt,
                    Status = b.Status,
                    ImageUrl = b.Device.ImageUrl,
                    DeviceName = b.Device.Name,
                    UserId = b.UserId,
                    Name = b.Violation.Name,
                    Penalty = b.Violation.Penalty,
                    Description = b.Violation.Description
                })
                .ToList();
            
            return View("violationHistory", violationDetails);
        }
    }
}
