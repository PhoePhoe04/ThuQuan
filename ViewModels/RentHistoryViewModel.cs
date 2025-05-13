using ThuQuan.Models;

namespace ThuQuan.ViewModels
{
    public class RentHistoryViewModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public DateTime BorrowTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
    }
}
