using Microsoft.Extensions.DependencyInjection;
using Shawbrook.FunBooksAndVideos.Application.Processors;
using Shawbrook.FunBooksAndVideos.Application.Queries;
using Shawbrook.FunBooksAndVideos.Application.Repositories;

namespace Shawbrook.FunBooksAndVideos.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPurchaseOrderProcessor, PurchaseOrderProcessor>();
        services.AddScoped<IGetPurchaseOrderQuery, GetPurchaseOrderQuery>();
                

        return services;
    }
}
