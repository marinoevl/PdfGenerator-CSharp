using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PdfGenerator.Domain.Shared;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);   
        return services;
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableDomainInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        
        
        services.AddDbContext<DefaultDbContext>((sp,
            options) =>
        {
            options.AddInterceptors(sp.GetRequiredService<ISaveChangesInterceptor>());
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<DefaultDbContext>());
        services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));
        return services;
    }
}