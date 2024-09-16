using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VKEshop.Catalog.Application.Features.Products.GetAllProducts;

namespace VKEshop.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllProductsQuery request = new GetAllProductsQuery();
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
