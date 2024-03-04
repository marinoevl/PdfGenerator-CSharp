using API.Infrastructure;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API;

public static class DependencyInjection
{
    public const string AllowAll = "AllowAll";
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddHealthChecks()
            .AddDbContextCheck<DefaultDbContext>();
        
        services.AddExceptionHandler<CustomExceptionHandler>();
        
        services.AddCors(options =>
        {
            options.AddPolicy(name: AllowAll,
                policy  =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                });
        });
        
        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}