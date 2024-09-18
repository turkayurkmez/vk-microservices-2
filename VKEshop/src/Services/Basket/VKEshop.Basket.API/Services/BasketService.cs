
using Grpc.Core;
using VKEshop.Basket.API.Models;
using VKEshop.Basket.API.Protos;
using VKEshop.Basket.API.Repositories;

namespace VKEshop.Basket.API.Services
{
    public class BasketService(ILogger<BasketService> logger, IBasketRepository repository) : Protos.Basket.BasketBase
    {
        public override async Task<AddToBasketResponse> AddToBasket(AddToBasketRequest request, ServerCallContext context)
        {
            logger.LogInformation("Grpc fonksiyonu çalıştı");
            logger.LogInformation($"Gelen talep: {request.Items.Count}");
            logger.LogInformation($"Sepetteki ürünler: {string.Join(",",request.Items.Select(i=>i.ProductId.ToString()))}");

            var response = new AddToBasketResponse();
           

            //TODO 3: Burada; müşterinin sepetini storage'a eklemeli!
            //var userName = context.GetHttpContext().User.Identity.Name;
            //if (string.IsNullOrEmpty(userName))
            //{
            //    throw new RpcException(new Status(StatusCode.Unauthenticated, "Bu talepte kullanıcı bilgisi yok!"));
            //}

            var customerBasket = MapToCustomerBasket("anonym", request);
            var addingBasketRespnse  =  repository.AddToBasket(customerBasket);


            foreach (var basketItem in addingBasketRespnse.Items)
            {
                response.Items.Add(basketItem);
            }
            
        
            return await Task.FromResult(response);
        }

        private CustomerBasket MapToCustomerBasket(string userName, AddToBasketRequest request)
        {
            var response = new CustomerBasket
            {
                CustomerId = userName,
                Items = new List<BasketItem>()

            };

            foreach (var item in request.Items)
            {
                response.Items.Add(new() { ProductId = item.ProductId, Quantity = item.Quantity });
            }

            return response;
        }
    }
}
