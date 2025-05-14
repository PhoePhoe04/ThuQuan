using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThuQuan.Data;
using ThuQuan.Models;
using ThuQuan.ViewModels;

namespace ThuQuan.Controllers
{
    public class ThueController : Controller
    {
        private readonly ThuQuanContext _context;
        public ThueController(ThuQuanContext context)
        {
            _context = context;
        }

        // Thue/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ThueIndexViewModel
            {
                Devices = await _context.Devices.AsNoTracking().ToListAsync(),
                Categories = await _context.Categories.AsNoTracking().ToListAsync()
            };
            return View(viewModel);
        }

        [HttpGet("Thue/Index/{categoryId?}")]
        public async Task<IActionResult> Index(int? categoryId)
        {
            var devicesQuery = _context.Devices.AsQueryable();

            if (categoryId.HasValue)
            {
                devicesQuery = devicesQuery.Where(d => d.CategoryId == categoryId.Value && d.Status == "Available");
            }

            var viewModel = new ThueIndexViewModel
            {
                Devices = await devicesQuery.ToListAsync(),
                Categories = await _context.Categories.ToListAsync()
            };

            return View("Index", viewModel);
        }

        [HttpGet("Thue/Search/{searchTerm?}")]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var thueQuery = _context.Devices.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                thueQuery = thueQuery.Where(t => t.Name.ToLower().Contains(searchTerm) && t.Status == "Available");
            }

            var viewModel = new ThueIndexViewModel
            {
                Devices = await thueQuery.ToListAsync(),
                Categories = await _context.Categories.ToListAsync()
            };

            return View("Index", viewModel);
        }

        // Thue/Details
        public async Task<IActionResult> Details(int id)
        {
            var device = await _context.Devices
                .Include(d => d.Category) // Nếu cần thông tin danh mục
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }
    }
}
