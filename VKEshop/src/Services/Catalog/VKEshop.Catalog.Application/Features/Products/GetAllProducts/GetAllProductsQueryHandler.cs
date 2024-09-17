using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Application.Contracts.Repository;
using VKEshop.Catalog.Domain;

namespace VKEshop.Catalog.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler(IProductRepository repository) : IRequestHandler<GetAllProductsQuery, GetAllProductsResponse>
    {
        //public IEnumerable<ProductCardDisplay> Execute(GetAllProductsQuery query)
        //{

      


        //    return null;
        //}

        public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync();

            // TODO 1: Repository'ye buradan erişecek.
            // TODO 2: db'den tüm ürünleri getirecek


            //var productResponse = products.Select(p => new ProductCardDisplay(

            //     Id: p.Id,
            //     Name: p.Name,
            //     Description: p.Description,
            //     Price: p.Price,
            //     Rating: p.Rating,
            //     ImageUrl: p.ImageUrl

            //    ));


            var productResponse = products.Adapt<IEnumerable<ProductCardDisplay>>();
            var getAllProductsResponse = new GetAllProductsResponse(productResponse);

            return  await Task.FromResult(getAllProductsResponse);

         
        }
    }
}
