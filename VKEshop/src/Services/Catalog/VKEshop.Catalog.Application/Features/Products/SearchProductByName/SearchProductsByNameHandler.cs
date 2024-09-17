using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Application.Contracts.Repository;

namespace VKEshop.Catalog.Application.Features.Products.SearchProductByName
{

    public record SearchProductsByNameQuery(string Name) : IRequest<SearchProductsByNameResponse>;


    public record ProductListDisplay(int Id, string Name, string? Description, decimal? Price, double? Rating, string? ImageUrl);    

    public record SearchProductsByNameResponse(IEnumerable<ProductListDisplay> Results, int Count);
    //{
    //    public SearchProductsByNameResponse()
    //    {
    //        this.Count = Results.Count();
    //    }
    //    public IEnumerable<ProductListDisplay> Results { get; set; }
    //    public int Count { get; set; }
    //}




    internal class SearchProductsByNameHandler(IProductRepository repository) : IRequestHandler<SearchProductsByNameQuery, SearchProductsByNameResponse>
    {
        //public async Task<IEnumerable<SearchProductsByNameResponse>> Handle(SearchProductsByNameQuery request, CancellationToken cancellationToken)
        //{
        //    var products = await repository.SearchByName(request.Name);
        //    var result = products.Adapt<IEnumerable<SearchProductsByNameResponse>>();
        //    return result;
        //}
        public async Task<SearchProductsByNameResponse> Handle(SearchProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.SearchByName(request.Name);
            var searched = products.Adapt<IEnumerable<ProductListDisplay>>();
            var response = new SearchProductsByNameResponse( Results: searched, Count: searched.Count());
            return response;
        }
    }


}
