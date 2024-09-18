using VKEshop.Basket.API.Models;

namespace VKEshop.Basket.API.Repositories
{
    public interface IBasketRepository
    {
        CustomerBasket? AddToBasket(CustomerBasket basket);
        CustomerBasket GetBasket(string customerId);
    }
}