using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VKEshop.Catalog.Application.Features.Products.CreateNewProduct;
using VKEshop.Catalog.Application.Features.Products.DeleteProduct;
using VKEshop.Catalog.Application.Features.Products.DiscountProductPrice;
using VKEshop.Catalog.Application.Features.Products.GetAllProducts;
using VKEshop.Catalog.Application.Features.Products.GetProductById;
using VKEshop.Catalog.Application.Features.Products.SearchProductByName;
using VKEshop.Catalog.Application.Features.Products.UpdateProduct;
using VKEshop.MessageBus;

namespace VKEshop.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllProductsQuery request = new GetAllProductsQuery();
            var response = await mediator.Send(request);
            //GetAllProductsQueryHandler handler = new GetAllProductsQueryHandler();
            //var response = await handler.Handle(request, CancellationToken.None);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetProductByIdQuery(id);
            var response = await mediator.Send(request);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> Search(string name)
        {
            var request = new SearchProductsByNameQuery(name);
            var respnse = await mediator.Send(request);
            return Ok(respnse);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProductCommand command)
        {
            if (ModelState.IsValid)
            {
                var lastId = await mediator.Send(command);
                return CreatedAtAction(nameof(Get), routeValues: new { id = lastId }, command);
            }

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (ModelState.IsValid)
            {
                await mediator.Send(command);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPut("discount/{id:int}")]
        public async Task<IActionResult> DiscountPrice(int id, DiscountProductPriceCommand command)
        {
            if (ModelState.IsValid)
            {
              var response =  await mediator.Send(command);

                //ürün fiyatında indirim yapıldıktan sonra; broker'a bu bilgiyi gönderdik:
                var @event = new ProductPriceDiscountedEvent
                {
                    ProductPriceDiscountCommand = new ProductPriceDiscountCommand
                    {
                        NewPrice = response.NewPrice,
                        OldPrice = response.OldPrice,
                        ProductId = response.Id
                    }
                };
               await  publishEndpoint.Publish(@event);

              return Ok(response);
            }
            return BadRequest();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteProductCommand command = new DeleteProductCommand(id);
            await mediator.Send(command);
            return NoContent();

        }


    }
}
