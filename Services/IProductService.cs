using System.Collections.Generic;
using System.Threading.Tasks;
using ThuQuan.Models;

namespace ThuQuan.Services
{
    public interface IProductService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Device>> GetAllDevicesAsync();
        Task<List<Device>> GetDevicesByCategoryAsync(int categoryId);
        Task<List<Device>> SearchDevicesAsync(string searchTerm);
    }
}