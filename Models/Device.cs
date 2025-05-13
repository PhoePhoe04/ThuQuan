using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuQuan.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int CategoryId { get; set; }
        
        // Navigation property
        public Category Category { get; set; }
        
        // Các thuộc tính không ánh xạ vào cơ sở dữ liệu
        [NotMapped]
        public string Technology { get; set; }
        
        [NotMapped]
        public string Resolution { get; set; }
        
        [NotMapped]
        public string Brightness { get; set; }
        
        [NotMapped]
        public string Contrast { get; set; }
        
        [NotMapped]
        public string Zoom { get; set; }
        
        [NotMapped]
        public string LampPower { get; set; }
    }
}