using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shawbrook.FunBooksAndVideos.Application.Models.Responses;
using Shawbrook.FunBooksAndVideos.Application.Processors;
using Shawbrook.FunBooksAndVideos.Application.Queries;
using Shawbrook.FunBooksAndVideos.WebApi.Models.Requests;

namespace Shawbrook.FunBooksAndVideos.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/purchase-order")]
    public class PurchaseOrderController : Controller
    {
        [HttpGet("{purchaseOrderId}")]
        public async Task<ActionResult<PurchaseOrderResponse>> Submit(
            [FromServices] IGetPurchaseOrderQuery query,
            int purchaseOrderId)
        {
            var result = await query.Get(purchaseOrderId);

            return this.ToActionResult(result);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit(
            [FromServices] IPurchaseOrderProcessor processor,
            PurchaseOrderRequest request)
        {
            // TODO: add validator for request.
            var result = await processor.Process(request);

            return this.ToActionResult(result);
        }
    }
}
