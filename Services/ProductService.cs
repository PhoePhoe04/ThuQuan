using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThuQuan.Data;
using ThuQuan.Models;

namespace ThuQuan.Services
{
    public class ProductService : IProductService
    {
        private readonly ThuQuanContext _context;

        public ProductService(ThuQuanContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Device>> GetAllDevicesAsync()
        {
            var devices = await _context.Devices
                .Include(d => d.Category)
                .ToListAsync();

            return devices;
        }

        public async Task<List<Device>> GetDevicesByCategoryAsync(int categoryId)
        {
            var devices = await _context.Devices
                .Where(d => d.CategoryId == categoryId)
                .Include(d => d.Category)
                .ToListAsync();

            return devices;
        }

        public async Task<List<Device>> SearchDevicesAsync(string searchTerm)
        {
            var devices = await _context.Devices
                .Where(d => d.Name.Contains(searchTerm) || d.Description.Contains(searchTerm))
                .Include(d => d.Category)
                .ToListAsync();

            return devices;
        }
    }
}