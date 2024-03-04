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
        services.AddScoped<AuditableDomainInterceptor>();
        services.AddScoped<DispatchDomainEventsInterceptor>();
        
        
        services.AddDbContext<DefaultDbContext>((sp,
            options) =>
        {
            var dispatchInterceptor = sp.GetService<DispatchDomainEventsInterceptor>();
            var auditInterceptor = sp.GetService<AuditableDomainInterceptor>();

            
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .AddInterceptors(auditInterceptor!)
                    .AddInterceptors(dispatchInterceptor!);
        });
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<DefaultDbContext>());
        services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));
        return services;
    }
}