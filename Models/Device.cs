using System;
using System.ComponentModel.DataAnnotations;

namespace ThuQuan.Models;

public class Device
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
    
    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
