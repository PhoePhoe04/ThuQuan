using Microsoft.AspNetCore.Identity;

namespace ThuQuan.Models;

public class Users : IdentityUser
{
    public string FullName { get; set; }
    public DateTime CreatedAt { get; set; }
}
