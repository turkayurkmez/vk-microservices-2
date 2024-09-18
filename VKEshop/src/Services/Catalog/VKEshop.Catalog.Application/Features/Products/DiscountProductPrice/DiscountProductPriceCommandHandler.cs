using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Application.Contracts.Repository;

namespace VKEshop.Catalog.Application.Features.Products.DiscountProductPrice
{
    public record DiscountProductPriceResponse(int Id, decimal? NewPrice, decimal? OldPrice);
    public record DiscountProductPriceCommand(int Id, decimal? Rate): IRequest<DiscountProductPriceResponse>;
    internal class DiscountProductPriceCommandHandler(IProductRepository repository) : IRequestHandler<DiscountProductPriceCommand, DiscountProductPriceResponse>
    {
        public async Task<DiscountProductPriceResponse> Handle(DiscountProductPriceCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.GetAsync(request.Id);
            var oldPrice = product.Price;
            product.Price *= (1 - request.Rate);
            var newPrice = product.Price;
            var response = new DiscountProductPriceResponse(product.Id, newPrice, oldPrice);
            await repository.Update(product);
            return response;
        }
    }
}
