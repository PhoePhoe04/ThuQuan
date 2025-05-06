using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThuQuan.Models
{
    public class ViolationDetail
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        //Foreign Key   
        [Required]
        public string UserId { get; set; }
        [Required]
        public int ViolationId { get; set; }

        //Navigation Property
        [ForeignKey(nameof(UserId))]
        public Users User { get; set; } = null!;
        [ForeignKey(nameof(ViolationId))]
        public Violation Violation { get; set; } = null!;
    }
}