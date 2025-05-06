using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuQuan.Models
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }
        public DateTime BorrowTime { get; set; }
        [Required]
        public DateTime ReturnTime { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Total { get; set; }

        public string? Status { get; set; }

        // Foriegn Key
        [Required]
        public string UserId { get; set; }
        [Required]
        public int DeviceId { get; set; }
        
        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public Users User { get; set; } = null!;

        [ForeignKey(nameof(DeviceId))]
        public Device Device { get; set; } = null!;
    }
}