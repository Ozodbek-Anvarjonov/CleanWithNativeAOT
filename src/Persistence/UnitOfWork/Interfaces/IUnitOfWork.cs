using Domain.Entities;
using Persistence.Repositories;

namespace Persistence.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    IRepository<User> Users { get; }

    IRepository<RefreshToken> RefreshTokens { get; }

    IRepository<Notification> Notifications { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}