using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Application.Contracts.Repository;

namespace VKEshop.Catalog.Application.Features.Products.GetProductById
{
    

    internal class GetProductByIdQueryHandler(IProductRepository repository) : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetAsync(request.Id);
            return product.Adapt<GetProductByIdResponse>();

                
        }
    }
}


   
