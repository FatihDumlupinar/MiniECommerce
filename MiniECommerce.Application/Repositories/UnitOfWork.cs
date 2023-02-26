using MiniECommerce.Domain.Entities;
using MiniECommerce.Domain.Repositories;
using MiniECommerce.Persistence.Contexts;

namespace MiniECommerce.Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGenericRepository<Category> _category;
        private readonly IGenericRepository<Order> _order;
        private readonly IGenericRepository<OrderItem> _orderItem;
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductCategory> _productCategory;
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(IGenericRepository<Category> category, IGenericRepository<Order> order, IGenericRepository<OrderItem> orderItem, IGenericRepository<Product> product, IGenericRepository<ProductCategory> productCategory, AppDbContext appDbContext)
        {
            _category = category;
            _order = order;
            _orderItem = orderItem;
            _product = product;
            _productCategory = productCategory;
            _appDbContext = appDbContext;
           
        }

        public IGenericRepository<Category> Categories => _category;
        public IGenericRepository<Order> Orders => _order;
        public IGenericRepository<OrderItem> OrderItems => _orderItem;
        public IGenericRepository<Product> Products => _product;
        public IGenericRepository<ProductCategory> ProductCategories => _productCategory;

        /// <summary>
        /// Veritabanı için olan değişiklikleri veritabanına gönderir.
        /// </summary>
        /// <returns>Kaç verinin etkilendiğini geriye döndürür</returns>
        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return _appDbContext.SaveChangesAsync(cancellationToken);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Veritabanı için oluşturulmuş DbContext'leri Dispose eder. (Dispose = kullanılan kaynağı serbest bırakır.)
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
