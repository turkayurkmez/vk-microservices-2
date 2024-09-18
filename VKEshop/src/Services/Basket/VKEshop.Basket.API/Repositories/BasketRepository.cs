using VKEshop.Basket.API.Models;
using VKEshop.Basket.API.Protos;

namespace VKEshop.Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private List<CustomerBasket> baskets = new List<CustomerBasket>();
        public CustomerBasket? AddToBasket(CustomerBasket basket)
        {
            baskets.Add(basket);
            return GetBasket(basket.CustomerId);

        }

        public CustomerBasket GetBasket(string customerId)
        {
            var basket = baskets.Where(x => x.CustomerId == customerId).ToList();
            var total = new List<BasketItem>();

            foreach (var item in basket)
            {
                foreach (var basketItem in item.Items)
                {
                    total.Add(basketItem);
                }
            }

            return new CustomerBasket { CustomerId = customerId, Items = total };
        }

    }
}
