using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Products.Core.Interfaces;
using Products.Core.Services;
using Products.Core.Validators;

namespace Products.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        services.AddValidatorsFromAssembly(typeof(AddProductsValidator).Assembly);

        return services;
    }
}