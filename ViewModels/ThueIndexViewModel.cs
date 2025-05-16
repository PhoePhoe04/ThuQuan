using System;
using System.Collections.Generic;
using ThuQuan.Models;

namespace ThuQuan.ViewModels
{
    public class ThueIndexViewModel
    {
        public List<Device>? Devices { get; set; }
        public List<Category>? Categories { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int? CategoryId { get; set; }
        public string? SearchTerm { get; set; } // Added to support search
    }
}