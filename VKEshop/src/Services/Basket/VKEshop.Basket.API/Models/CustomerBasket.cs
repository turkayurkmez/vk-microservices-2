using VKEshop.Basket.API.Protos;

namespace VKEshop.Basket.API.Models
{

    public class CustomerBasket
    {
        public string CustomerId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
