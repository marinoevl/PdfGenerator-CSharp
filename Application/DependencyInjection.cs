using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this ServiceCollection service)
    {
        service.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return service;
    }
}