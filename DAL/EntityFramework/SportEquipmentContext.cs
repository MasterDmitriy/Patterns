using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework
{
    public sealed class SportEquipmentContext : DbContext
    {
        public DbSet<Product> Products { set; get; }
        public DbSet<Brand> Brands { set; get; }
        public DbSet<BrandType> BrandTypes { set; get; }
        public DbSet<Category> Categories { set; get; }

        public SportEquipmentContext(DbContextOptions<SportEquipmentContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;user=root;password=Killer916$;database=sportDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);

            modelBuilder
                .Entity<Product>()
                .HasOne(product => product.Brand)
                .WithMany(brand => brand.Products)
                .HasForeignKey(product => product.BrandId);

            modelBuilder
                .Entity<Brand>()
                .HasOne(brand => brand.BrandType)
                .WithMany(brandType => brandType.Brands)
                .HasForeignKey(brand => brand.BrandTypeId);

            modelBuilder
                .Entity<User>()
                .HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId);
        }
    }
}