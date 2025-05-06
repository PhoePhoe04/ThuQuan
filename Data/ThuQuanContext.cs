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
    public DbSet<Borrow> Borrows{ get; set; }
    public DbSet<Violation> Violations { get; set; }
    public DbSet<ViolationDetail> ViolationDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Device>()
            .HasOne(d => d.Category)
            .WithMany()
            .HasForeignKey(d => d.CategoryId);
    }
}
