using Microsoft.Extensions.DependencyInjection;
using Products.Core.Interfaces;
using Products.Infrastructure.DbContexts;
using Products.Infrastructure.Repositories;

namespace Products.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ProductDbContext>();
        return services;
    }
}