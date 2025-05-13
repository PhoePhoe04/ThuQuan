using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThuQuan.Services;

namespace ThuQuan.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int? categoryId, string searchTerm)
        {
            var categories = await _productService.GetAllCategoriesAsync();
            ViewBag.Categories = categories;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var searchResults = await _productService.SearchDevicesAsync(searchTerm);
                ViewBag.SearchTerm = searchTerm;
                return View(searchResults);
            }
            else if (categoryId.HasValue)
            {
                var categoryDevices = await _productService.GetDevicesByCategoryAsync(categoryId.Value);
                ViewBag.SelectedCategoryId = categoryId.Value;
                return View(categoryDevices);
            }
            else
            {
                var allDevices = await _productService.GetAllDevicesAsync();
                return View(allDevices);
            }
        }
    }
}