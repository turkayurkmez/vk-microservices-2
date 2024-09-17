using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Domain;

namespace VKEshop.Catalog.Application.Features.Products.GetAllProducts
{
    public record GetAllProductsResponse(IEnumerable<ProductCardDisplay> Products);
    public record GetAllProductsQuery(): IRequest<GetAllProductsResponse> ;

    public record ProductCardDisplay(int Id, string Name, string? Description, decimal? Price, double? Rating, string? ImageUrl);
  
   
}
