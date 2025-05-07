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
        services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
        services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();

        services.AddDbContext<FunBooksAndVideosDbContext>(options => options.UseInMemoryDatabase("FunBooksAndVideosDb"));

        return services;
    }
}
