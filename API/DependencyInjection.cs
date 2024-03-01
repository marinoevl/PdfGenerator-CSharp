using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using PdfGenerator_CSharp.API.Infrastructure;

namespace PdfGenerator_CSharp.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddHealthChecks()
            .AddDbContextCheck<DefaultDbContext>();
        
        services.AddExceptionHandler<CustomExceptionHandler>();
        
        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}