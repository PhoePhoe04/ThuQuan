using Microsoft.EntityFrameworkCore;
using ThuQuan.Models;

namespace ThuQuan.Data
{
    public class ThuQuanContext : DbContext
    {
        public ThuQuanContext(DbContextOptions<ThuQuanContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình các entity
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("devices");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name").IsRequired();
                entity.Property(e => e.ImageUrl).HasColumnName("ImageUrl");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.Status).HasColumnName("Status");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryId");

                entity.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name").IsRequired();
            });

        }
    }
}