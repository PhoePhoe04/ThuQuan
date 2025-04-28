using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThuQuan.Models;
using ThuQuan.ViewModels;
using YourProjectNamespace.Models;

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

        [HttpGet("rentHistory")]
        public async Task<IActionResult> RentHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["ActiveTab"] = "RentHistory";

            // Giả sử bạn có một nguồn dữ liệu về lịch sử thuê (ví dụ: từ database)
            var rentHistoryItems = new List<RentHistoryItem>
            {
                new RentHistoryItem
                {
                    ShopName = "Thư Quán N7",
                    Status = "Thuê thành công | HOÀN THÀNH",
                    RentItems = new List<RentProductItem>
                    {
                        new RentProductItem
                        {
                            ProductName = "Canon EOS C200",
                            Variant = "Phân loại: Máy ảnh",
                            Price = 825.200m,
                            ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/16/8600fc5ae3f4599cf22f01b09dae9718_8031910330149908909.png"
                        }
                    },
                    TotalAmount = 825.200m
                },
                new RentHistoryItem
                {
                    ShopName = "Thư Quán N7",
                    Status = "Thuê thành công | HOÀN THÀNH",
                    RentItems = new List<RentProductItem>
                    {
                        new RentProductItem
                        {
                            ProductName = "DJI Ronin-S",
                            Variant = "Phân loại: Gimbal",
                            Price = 897.296m,
                            ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/16/8600fc5ae3f4599cf22f01b09dae9718_8031910330149908909.png"
                        },
                        new RentProductItem
                        {
                            ProductName = "Sony A7 III",
                            Variant = "Phân loại: Máy ảnh",
                            Price = 449.680m,
                            ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/16/8600fc5ae3f4599cf22f01b09dae9718_8031910330149908909.png"
                        }
                    },
                    TotalAmount = 1_346.976m
                }
            };

            var model = new RentHistoryViewModel
            {
                UserName = user.UserName,
                RentHistoryItems = rentHistoryItems
            };

            return View(model);
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

            var violationHistoryItems = new List<ViolationHistoryItem>
            {
                new ViolationHistoryItem
                {
                    Code = "V123",
                    Date = DateTime.Now,
                    ProductName = "Camera Canon",
                    Type = "Hư hỏng",
                    Description = "Máy ảnh bị vỡ màn hình.",
                    StatusText = "Chưa xử lý",
                    StatusClass = "status-pending",
                    Penalty = "100,000 VND",
                    CanAppeal = true,
                    ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/09/9639186/3077cacc073eac5bda7056efb243cd0b_177967252842891613.jpg"
                },
                new ViolationHistoryItem
                {
                    Code = "V124",
                    Date = DateTime.Now.AddDays(-1),
                    ProductName = "Sony A7",
                    Type = "Mất sản phẩm",
                    Description = "Sản phẩm bị mất khi giao hàng.",
                    StatusText = "Đã xử lý",
                    StatusClass = "status-resolved",
                    Penalty = "500,000 VND",
                    CanAppeal = false,
                    ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/09/9639186/3077cacc073eac5bda7056efb243cd0b_177967252842891613.jpg"
                }
            };

            var model = new ViolationHistoryViewModel
            {
                ViolationHistoryItems = violationHistoryItems
            };

            return View(model);
        }
    }
}
