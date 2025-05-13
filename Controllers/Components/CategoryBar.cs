using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThuQuan.Services;

namespace ThuQuan.Controllers.Components
{
    public class CategoryBar : ViewComponent
    {
        private readonly IProductService _productService;

        public CategoryBar(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? selectedCategoryId = null)
        {
            var categories = await _productService.GetAllCategoriesAsync();
            ViewBag.SelectedCategoryId = selectedCategoryId;
            return View(categories);
        }
    }
}