using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThuQuan.Models;

namespace ThuQuan.Data;

public class ThuQuanContext:IdentityDbContext<Users>
{
    public ThuQuanContext(DbContextOptions<ThuQuanContext> options)
            : base(options) { }

    public DbSet<Device> Devices { get; set; }
    public DbSet<Category> Categories { get; set; }
        
}
