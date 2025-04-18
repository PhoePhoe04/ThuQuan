using System;
using System.ComponentModel.DataAnnotations;

namespace ThuQuan.Models;

public class User
{
    [Key]
    public int Id {get; set;}

    [Required]
    [StringLength(50)]
    public required string Username {get; set;}

    [Required]
    [EmailAddress]
    public required string Email {get; set;}

    [Required]
    [StringLength(50)]
    public required string Password {get; set;}
    public string? Role {get; set;}

}
