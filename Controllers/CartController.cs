using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThuQuan.Data;
using ThuQuan.Models;
using ThuQuan.Utils;

namespace ThuQuan.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "Cart";
        private readonly ThuQuanContext _context;

        public CartController(ThuQuanContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(string deviceId, string name, double price, string imageUrl, int quantity)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(x => x.DeviceId == deviceId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    DeviceId = deviceId,
                    Name = name,
                    Price = price,
                    ImageUrl = imageUrl,
                    Quantity = quantity
                });
            }

            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);

            TempData["CartMessage"] = "Đã thêm vào giỏ hàng!";
            // Quay lại trang trước (giữ nguyên vị trí người dùng)
            return Redirect(Request.Headers["Referer"].ToString());
        }


        [HttpPost]
        public IActionResult RemoveFromCart(string deviceId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var itemToRemove = cart.Find(c => c.DeviceId == deviceId);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
            }
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] UpdateQuantityRequest request)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var item = cart.FirstOrDefault(c => int.Parse(c.DeviceId) == request.DeviceId);
            if (item != null)
            {
                if (request.Quantity > 0)
                {
                    item.Quantity = request.Quantity;
                }
                else
                {
                    cart.Remove(item);
                }
            }
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            var total = cart.Sum(c => c.Price * c.Quantity);
            return Json(new { total });
        }

        public class UpdateQuantityRequest
        {
            public int DeviceId { get; set; }
            public int Quantity { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrow([FromBody] BorrowRequest request)
        {
            // Lấy userId hiện tại
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // hoặc User.FindFirst(ClaimTypes.NameIdentifier)?.Value nếu dùng Identity
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var now = DateTime.Now;
            var borrow = new Borrow
            {
                DeviceId = int.Parse(request.DeviceId),
                UserId = userId,
                Quantity = request.Quantity,
                Total = (double)request.Total,
                BorrowTime = now,
                ReturnTime = now.AddDays(request.Days),
                Status = "Đang xử lý"
            };

            // Lưu vào database
            _context.Borrows.Add(borrow);
            await _context.SaveChangesAsync();

            // xóa item khỏi giỏ hàng trong session
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var itemToRemove = cart.FirstOrDefault(c => c.DeviceId == request.DeviceId);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            }

            return Ok();
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Borrow([FromBody] BorrowRequest request)
        // {
        //     // Kiểm tra request
        //     if (request == null || string.IsNullOrEmpty(request.DeviceId))
        //     {
        //         return BadRequest("Dữ liệu không hợp lệ.");
        //     }

        //     // Lấy userId hiện tại
        //     var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     if (string.IsNullOrEmpty(userId))
        //     {
        //         return Unauthorized();
        //     }

        //     // Tạo đối tượng Borrow
        //     var now = DateTime.Now;
        //     var borrow = new Borrow
        //     {
        //         DeviceId = request.DeviceId,
        //         UserId = userId,
        //         Quantity = request.Quantity,
        //         Total = request.Total,
        //         BorrowTime = now,
        //         ReturnTime = now.AddDays(request.Days),
        //         Status = "Đang xử lý"
        //     };

        //     // Lưu vào database
        //     try
        //     {
        //         _context.Borrows.Add(borrow);
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"Lỗi khi lưu vào database: {ex.Message}");
        //     }

        //     // Xóa item khỏi giỏ hàng trong session
        //     var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
        //     var itemToRemove = cart.FirstOrDefault(c => c.DeviceId == request.DeviceId);
        //     if (itemToRemove != null)
        //     {
        //         cart.Remove(itemToRemove);
        //         HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
        //     }

        //     return Ok();
        // }

    }
}
