using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThuQuan.Data;
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
       
        public async Task<IActionResult> Index()
        {
            var viewModel = new ThueIndexViewModel
            {
                Devices = await _context.Devices.ToListAsync(),
                Categories = await _context.Categories.ToListAsync()
            };
            return View(viewModel);
        }
    }
}
