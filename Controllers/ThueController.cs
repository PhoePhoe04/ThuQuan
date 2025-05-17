using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThuQuan.Data;
using ThuQuan.Models;
using ThuQuan.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ThuQuan.Controllers
{
    public class ThueController : Controller
    {
        private readonly ThuQuanContext _context;
        private const int PageSize = 6; // Số sản phẩm mỗi trang

        public ThueController(ThuQuanContext context)
        {
            _context = context;
        }

        // Thue/Index
        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, int page = 1)
        {
            // Đảm bảo page >= 1
            page = page < 1 ? 1 : page;

            // Lấy danh sách thiết bị
             var devicesQuery = _context.Devices.AsNoTracking()
                .Where(d => d.Status == "Available")
                .AsQueryable();

            // Lọc theo categoryId nếu có
            if (categoryId.HasValue)
            {
                devicesQuery = devicesQuery.Where(d => d.CategoryId == categoryId.Value && d.Status == "Available");
            }

            // Tính tổng số thiết bị và số trang
            var totalItems = await devicesQuery.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            // Lấy thiết bị cho trang hiện tại
            var devices = await devicesQuery
                .OrderBy(d => d.Id) // Có thể thay đổi tiêu chí sắp xếp
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            // Tạo ViewModel
            var viewModel = new ThueIndexViewModel
            {
                Devices = devices,
                Categories = await _context.Categories.AsNoTracking().ToListAsync(),
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = PageSize,
                CategoryId = categoryId
            };

            return View(viewModel);
        }

        [HttpGet("Thue/Search")]
        public async Task<IActionResult> Search(string searchTerm, int page = 1)
        {
            // Đảm bảo page >= 1
            page = page < 1 ? 1 : page;

            // Lấy danh sách thiết bị
            var devicesQuery = _context.Devices.AsNoTracking()
                .Where(d => d.Status == "Available")
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                devicesQuery = devicesQuery.Where(t => t.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            // Tính tổng số thiết bị và số trang
            var totalItems = await devicesQuery.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            // Lấy thiết bị cho trang hiện tại
            var devices = await devicesQuery
                .OrderBy(d => d.Id) // Có thể thay đổi tiêu chí sắp xếp
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            // Tạo ViewModel
            var viewModel = new ThueIndexViewModel
            {
                Devices = devices,
                Categories = await _context.Categories.AsNoTracking().ToListAsync(),
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = PageSize,
                SearchTerm = searchTerm
            };

            return View("Index", viewModel);
        }

        // Thue/Details
        public async Task<IActionResult> Details(int id)
        {
            var device = await _context.Devices
                .Include(d => d.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }
    }
}