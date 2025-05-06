using System;
using System.Collections.Generic;

namespace CameraRental.Models
{
    public class CameraModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal PricePerDay { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> IncludedItems { get; set; }
    }

    public class RentalViewModel
    {
        public CameraModel Camera { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
    }

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