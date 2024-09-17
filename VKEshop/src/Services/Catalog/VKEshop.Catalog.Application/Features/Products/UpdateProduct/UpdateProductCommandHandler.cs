using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Application.Contracts.Repository;

namespace VKEshop.Catalog.Application.Features.Products.UpdateProduct
{

    public record UpdateProductCommand(int Id,
                                          [Required(ErrorMessage = "Ürün Adı zorunlu")] string Name,
                                          [Required] string Description,
                                          decimal? Price,
                                          double? Rating,
                                          string ImageUrl) : IRequest;
    internal class UpdateProductCommandHandler(IProductRepository repository) : IRequestHandler<UpdateProductCommand>
    {

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Domain.Product>();
            await repository.Update(product);
            await Task.CompletedTask;
        }
    }
}
