using System.Collections.Generic;

namespace ThuQuan.Models
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string FormattedPrice => $"{Price:N0}/ngày";
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Specifications { get; set; }
    }
}