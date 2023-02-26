using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace MiniECommerce.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNull] DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    }
}
