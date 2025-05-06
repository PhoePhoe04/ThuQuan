using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuQuan.Models;

public class Device
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required double Price { get; set; }

    [Required]
    public required int Quantity { get; set; }
    
    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    // Foreign keys
    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    // Navigation properties
}
