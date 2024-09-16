using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Domain;

namespace VKEshop.Catalog.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResponse>
    {
        //public IEnumerable<ProductCardDisplay> Execute(GetAllProductsQuery query)
        //{

        //    //TODO 1: Veritabanına git, tüm ürünleri çek ve donüş değerine dönüştür.


        //    return null;
        //}

        public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = new List<Product>
            {
                 new(){ Id=1, Name="A", Description="Ürün 1", ImageUrl="resimAdresi", Price=1, Rating=4.6},
                 new(){ Id=1, Name="A", Description="Ürün 1", ImageUrl="resimAdresi", Price=1, Rating=4.6},
                 new(){ Id=1, Name="A", Description="Ürün 1", ImageUrl="resimAdresi", Price=1, Rating=4.6},

            }.AsEnumerable();

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

            //TODO 1: Veritabanına git, tüm ürünleri çek ve donüş değerine dönüştür.
        }
    }
}
