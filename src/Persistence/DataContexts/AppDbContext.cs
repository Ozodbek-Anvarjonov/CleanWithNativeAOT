using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using System.Reflection;

namespace Persistence.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}