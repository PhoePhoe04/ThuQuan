using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThuQuan.Data;

namespace ThuQuan.Controllers.Components
{
    public class CategoryBar : ViewComponent
    {
        private readonly ThuQuanContext _context;
        public CategoryBar(ThuQuanContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
    }
}
