using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ThuQuan.Models;

namespace ThuQuan.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // In a real application, you would fetch this data from a database
            var products = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    Id = 1,
                    Name = "Canon EOS C200",
                    Category = "Máy ảnh",
                    Price = 750000,
                    ShortDescription = "Máy quay phim chuyên nghiệp với khả năng quay phim 4K Raw",
                    ImageUrl = "/images/canon-eos-c200.jpg"
                },
                new ProductViewModel
                {
                    Id = 2,
                    Name = "Sony A7 III",
                    Category = "Máy ảnh",
                    Price = 450000,
                    ShortDescription = "Máy ảnh mirrorless full-frame với khả năng quay video 4K",
                    ImageUrl = "/images/sony-a7iii.jpg"
                },
                new ProductViewModel
                {
                    Id = 3,
                    Name = "DJI Ronin-S",
                    Category = "Phụ kiện",
                    Price = 250000,
                    ShortDescription = "Gimbal cầm tay chuyên nghiệp cho máy ảnh DSLR và mirrorless",
                    ImageUrl = "/images/dji-ronin-s.jpg"
                }
            };
            
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            // In a real application, you would fetch this data from a database
            var model = new ProductDetailViewModel
            {
                Id = 1,
                Name = "Canon EOS C200",
                Category = "Máy ảnh",
                Price = 750000,
                Description = "Máy quay phim chuyên nghiệp Canon EOS C200 với khả năng quay phim 4K Raw. Dễ sử dụng và linh hoạt, phù hợp cho nhiều dự án.",
                ImageUrl = "/images/canon-eos-c200.jpg",
                Specifications = new List<string>
                {
                    "Quay Canon RAW (CRM) + Canon MP4 (4K UHD, Full HD)",
                    "Cảm biến CMOS Super 35mm",
                    "Tốc độ 59.94P",
                    "Built-in ND Filters/mic, External Control Panel, Side handle",
                    "Rotating Grip, Dual Pixel CMOS AF, Up to 12 stops"
                }
            };
            
            return View(model);
        }
    }
}
