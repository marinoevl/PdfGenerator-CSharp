using Infrastructure.Persistence.mongo;
using Infrastructure.Persistence.mssql;
using Infrastructure.Persistence.mssql.Interceptors;
using Infrastructure.Persistence.mssql.Repositories;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PdfGenerator.Domain.Shared;
using MongoDB.Driver;

using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;


namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddPersistence(configuration);
        services.AddMongoPersistence(configuration);
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
    }private static IServiceCollection AddMongoPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableDomainInterceptor>();
        services.AddScoped<DispatchDomainEventsInterceptor>();

        var connectionString = configuration.GetConnectionString("MongoConnection"); 
        //Environment.GetEnvironmentVariable("MONGODB_URI");
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
            Environment.Exit(0);
        }
        var client = new MongoClient(connectionString);
        
        
        services.AddDbContext<DefaultDbContext>((sp,
            options) =>
        {
            var dispatchInterceptor = sp.GetService<DispatchDomainEventsInterceptor>();
            var auditInterceptor = sp.GetService<AuditableDomainInterceptor>();

            options
                .UseMongoDB(client, "pdfGenerator")
                .AddInterceptors(auditInterceptor!)
                .AddInterceptors(dispatchInterceptor!);

        });
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MongoDbContext>());
        services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));
        return services;
    }
}