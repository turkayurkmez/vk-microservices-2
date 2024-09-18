using MassTransit;
using VKEshop.MessageBus;

namespace VKEshop.Basket.API.Consumers
{
    public class ProductPriceDiscountedConsumer(ILogger<ProductPriceDiscountedConsumer> logger) : IConsumer<ProductPriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<ProductPriceDiscountedEvent> context)
        {
            /*
             * indirim yapılan ürünü sepet db'sinde bul. Fiyatını güncelle.
             * 
             */

            var command = context.Message.ProductPriceDiscountCommand;
            logger.LogInformation($"{command.ProductId} id'li ürünün fiyatı {command.OldPrice} TL'den {command.NewPrice} TL'ye düştü!");
            return Task.CompletedTask;
        }
    }
}
