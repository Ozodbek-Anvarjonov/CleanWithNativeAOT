using Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interceptors;

internal class AuditCreationInterceptor(IUserContext userContext) : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var entries = eventData.Context?.ChangeTracker
            .Entries<IAuditableEntity>()
            .Where(entry => entry.State == EntityState.Added)
            .ToList();

        entries?.ForEach(entry =>
        {
            entry.Entity.CreatedById = userContext.GetCurrentUserId();
            entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
        });

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var entries = eventData.Context?.ChangeTracker
            .Entries<IAuditableEntity>()
            .Where(entry => entry.State == EntityState.Added)
            .ToList();

        entries?.ForEach(entry =>
        {
            entry.Entity.CreatedById = userContext.GetCurrentUserId();
            entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
        });

        return base.SavingChanges(eventData, result);
    }
}