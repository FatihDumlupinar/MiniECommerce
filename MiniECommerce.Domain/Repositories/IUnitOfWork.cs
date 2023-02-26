using MiniECommerce.Domain.Repositories;
using MiniECommerce.Domain.Entities;

namespace MiniECommerce.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Order> Orders { get; }
        public IGenericRepository<OrderItem> OrderItems { get; }
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<ProductCategory> ProductCategories { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
