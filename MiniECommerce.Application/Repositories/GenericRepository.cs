using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain.Common;
using MiniECommerce.Domain.Repositories;
using MiniECommerce.Persistence.Contexts;
using System.Linq.Expressions;

namespace MiniECommerce.Application.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public virtual async ValueTask AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _ = await _appDbContext.Set<T>().AddAsync(entity, cancellationToken);
        }

        public virtual async ValueTask<T> AddAsyncReturnEntity(T entity, CancellationToken cancellationToken = default)
        {
            var data = await _appDbContext.Set<T>().AddAsync(entity, cancellationToken);
            return data.Entity;
        }

        public virtual Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            return _appDbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        public virtual Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                entity.IsActive = false;
                _ = _appDbContext.Set<T>().Update(entity);
            }, cancellationToken);
        }

        public virtual Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                foreach (var entity in entities)
                {
                    entity.IsActive = false;
                    _ = _appDbContext.Set<T>().Update(entity);
                }
            }, cancellationToken);
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>>? expression = default)
        {
            return expression == null ? _appDbContext.Set<T>() : _appDbContext.Set<T>().Where(expression);
        }

        public virtual Task<T?> FindOneAsync(Expression<Func<T?, bool>> expression, CancellationToken cancellationToken = default)
        {
            return _appDbContext.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
        }

        public virtual Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _appDbContext.Set<T>().FirstOrDefaultAsync(i => i.IsActive && i.Id == id, cancellationToken);
        }

        public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                _ = _appDbContext.Set<T>().Update(entity);
            }, cancellationToken);
        }

        public virtual Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                foreach (var entity in entities)
                {
                    _ = _appDbContext.Set<T>().Update(entity);
                }
            }, cancellationToken);
        }
    }
}
