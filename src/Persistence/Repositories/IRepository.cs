using Domain.Common.Entities;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>>? predicate = default,
        bool asNoTracking = false,
        string[]? includes = default
        );

    Task<TEntity?> GetByIdAsync(
        long id,
        bool asNoTracking = false,
        string[]? includes = default,
        CancellationToken cancellationToken = default
        );

    Task<long> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}