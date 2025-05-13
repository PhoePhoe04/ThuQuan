namespace ThuQuan.ViewModels
{
    public class RentHistoryViewModel
    {
        public string UserName { get; set; }
        public List<RentHistoryItem> RentHistoryItems { get; set; }
    }

    public class RentHistoryItem
    {
        public List<RentProductItem> RentItems { get; set; }
    }

    public class RentProductItem
    {
        public string ProductName { get; set; }
        public string Variant { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime RentDate { get; set; }
        public TimeSpan TimeRent => RentDate.TimeOfDay;
        public DateTime ReturnDate { get; set; }
        public TimeSpan TimeReturn => ReturnDate.TimeOfDay;
        public string Status { get; set; }
    }
}
