using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shawbrook.FunBooksAndVideos.Application.Repositories;
using Shawbrook.FunBooksAndVideos.Infrastructure.Persistence;
using Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Repositories;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // This project exists to register the infrastructure services, without the need for the main project to depend on the infrastructure project.

        services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IMembershipRepository, MembershipRepository>();

        services.AddDbContext<FunBooksAndVideosDbContext>(options => options.UseInMemoryDatabase("FunBooksAndVideosDb"));

        return services;
    }
}
