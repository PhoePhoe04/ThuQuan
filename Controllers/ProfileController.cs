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

            var rentHistoryItems = new List<RentHistoryItem>
            {
                new RentHistoryItem
                {
                    RentItems = new List<RentProductItem>
                    {
                        new RentProductItem
                        {
                            ProductName = "DJI Ronin-S",
                            Variant = "Phân loại: Gimbal",
                            Price = 897.296m,
                            ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/16/8600fc5ae3f4599cf22f01b09dae9718_8031910330149908909.png",
                            RentDate = new DateTime(2025, 4, 1, 9, 0, 0),
                            ReturnDate = new DateTime(2025, 4, 3, 18, 0, 0),
                            Status = "Đã thanh toán"
                        },
                        new RentProductItem
                        {
                            ProductName = "DJI Ronin-S",
                            Variant = "Phân loại: Gimbal",
                            Price = 897.296m,
                            ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/16/8600fc5ae3f4599cf22f01b09dae9718_8031910330149908909.png",
                            RentDate = new DateTime(2025, 4, 1, 9, 0, 0),
                            ReturnDate = new DateTime(2025, 4, 3, 18, 0, 0),
                            Status = "Chờ thanh toán"
                        },
                        new RentProductItem
                        {
                            ProductName = "DJI Ronin-S",
                            Variant = "Phân loại: Gimbal",
                            Price = 897.296m,
                            ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/16/8600fc5ae3f4599cf22f01b09dae9718_8031910330149908909.png",
                            RentDate = new DateTime(2025, 4, 1, 9, 0, 0),
                            ReturnDate = new DateTime(2025, 4, 3, 18, 0, 0),
                            Status = "Chờ thanh toán"
                        },
                        new RentProductItem
                        {
                            ProductName = "DJI Ronin-S",
                            Variant = "Phân loại: Gimbal",
                            Price = 897.296m,
                            ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/16/8600fc5ae3f4599cf22f01b09dae9718_8031910330149908909.png",
                            RentDate = new DateTime(2025, 4, 1, 9, 0, 0),
                            ReturnDate = new DateTime(2025, 4, 3, 18, 0, 0),
                            Status = "Trễ hạn"
                        },
                        new RentProductItem
                        {
                            ProductName = "DJI Ronin-S",
                            Variant = "Phân loại: Gimbal",
                            Price = 897.296m,
                            ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/16/8600fc5ae3f4599cf22f01b09dae9718_8031910330149908909.png",
                            RentDate = new DateTime(2025, 4, 1, 9, 0, 0),
                            ReturnDate = new DateTime(2025, 4, 3, 18, 0, 0),
                            Status = "Đã thanh toán"
                        }
                    },

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
                    Date = new DateTime(2025, 4, 1, 9, 0, 0),
                    ProductName = "Camera Canon",
                    Type = "Hư hỏng",
                    Description = "Máy ảnh bị vỡ màn hình.",
                    StatusText = "Chưa xử lý",
                    StatusClass = "status-pending",
                    CanAppeal = true,
                    ImageUrl = "https://upload-os-bbs.hoyolab.com/upload/2025/04/09/9639186/3077cacc073eac5bda7056efb243cd0b_177967252842891613.jpg"
                },
                new ViolationHistoryItem
                {
                    Code = "V124",
                    Date = new DateTime(2025, 4, 1, 9, 0, 0),
                    ProductName = "Sony A7",
                    Type = "Mất sản phẩm",
                    Description = "Sản phẩm bị mất khi giao hàng.",
                    StatusText = "Đã xử lý",
                    StatusClass = "status-resolved",
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

        [HttpGet("bookingHistory")]
        public async Task<IActionResult> BookingHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewData["ActiveTab"] = "BookingHistory";
            var bookingHistoryItems = new List<BookingHistoryItem>
            {
                new BookingHistoryItem
                {
                    BookedRooms = new List<BookedRoom>
                    {
                        new BookedRoom
                        {
                            RoomName = "Phòng Studio VIP",
                            ImageUrl = "https://example.com/room1.jpg",
                            BookingDate = new DateTime(2025, 5, 1, 14, 30, 0),
                            Status = "Đã xử lý",
                            DeviceName = "Micro AKG Pro"
                        },
                        new BookedRoom
                        {
                            RoomName = "Phòng Hội Nghị 2A",
                            ImageUrl = "https://example.com/room2.jpg",
                            BookingDate = new DateTime(2025, 5, 2, 9, 0, 0),
                            Status = "Đang xử lý",
                            DeviceName = "Máy chiếu Panasonic"
                        }
                    }
                }
            };
            var model = new BookingHistoryViewModel
            {
                BookingHistoryItems = bookingHistoryItems
            };
            return View(model);
        }
    }
}
