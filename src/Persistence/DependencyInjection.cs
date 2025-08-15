using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataContexts;
using Persistence.Interceptors;
using Persistence.Repositories;
using Persistence.UnitOfWork.Interfaces;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddServices();

        return services;
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditCreationInterceptor>();
        services.AddScoped<AuditModificationInterceptor>();
        services.AddScoped<AuditDeletionInterceptor>();

        //services.AddScoped<DbContext>();

        services.AddDbContext<DbContext, AppDbContext>((provider, options) =>
        {
            var auditCreationInterceptor = provider.GetRequiredService<AuditCreationInterceptor>();
            var auditModificationInterceptor = provider.GetRequiredService<AuditModificationInterceptor>();
            var auditDeletionInterceptor = provider.GetRequiredService<AuditDeletionInterceptor>();

            options
                .UseNpgsql(configuration.GetConnectionString("DefaultDbConnection"))
                .AddInterceptors(auditCreationInterceptor)
                .AddInterceptors(auditModificationInterceptor)
                .AddInterceptors(auditDeletionInterceptor);
        });
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}