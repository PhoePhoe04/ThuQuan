namespace ThuQuan.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string FormattedPrice => $"{Price:N0}/ngày";
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}