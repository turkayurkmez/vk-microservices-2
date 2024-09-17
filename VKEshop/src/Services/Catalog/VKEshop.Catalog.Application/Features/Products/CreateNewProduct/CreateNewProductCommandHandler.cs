using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Application.Contracts.Repository;
using VKEshop.Catalog.Domain;

namespace VKEshop.Catalog.Application.Features.Products.CreateNewProduct
{
    internal class CreateNewProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateNewProductCommand, int>
    {
        public async Task<int> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await repository.Create(product);
            return product.Id;
        }
    }

    public record CreateNewProductCommand([Required(ErrorMessage ="Ürün Adı zorunlu")] string Name, 
                                          [Required] string Description, 
                                          decimal? Price, 
                                          double? Rating, 
                                          string ImageUrl) : IRequest<int>;
    
}
