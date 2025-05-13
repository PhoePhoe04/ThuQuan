namespace ThuQuan.Models
{
    public class BorrowRequest
    {
        public string DeviceId { get; set; }
        public int Quantity { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Days { get; set; }
        public decimal Total { get; set; }
    }
}