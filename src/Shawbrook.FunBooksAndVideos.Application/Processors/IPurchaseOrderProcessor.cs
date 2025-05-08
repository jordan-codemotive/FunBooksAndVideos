using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.WebApi.Models.Requests;

namespace Shawbrook.FunBooksAndVideos.Application.Processors;

public interface IPurchaseOrderProcessor
{
    public Task<Result> Process(PurchaseOrderRequest request);
}
