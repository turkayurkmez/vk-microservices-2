using MediatR;

namespace VKEshop.Catalog.Application.Features.Products.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdResponse>;
   

    public record GetProductByIdResponse(int Id, string Name, string? Description, decimal? Price, double? Rating, string? ImageUrl);
}


   
