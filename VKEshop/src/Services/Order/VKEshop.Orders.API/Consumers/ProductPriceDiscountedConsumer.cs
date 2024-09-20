using MassTransit;
using VKEshop.MessageBus;

namespace VKEshop.Orders.API.Consumers
{
    public class ProductPriceDiscountedConsumer(ILogger<ProductPriceDiscountedConsumer> logger) : IConsumer<ProductPriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<ProductPriceDiscountedEvent> context)
        {
            var message = context.Message;
            var command = message.ProductPriceDiscountCommand;

            logger.LogInformation($"{command.ProductId} id'li ürünü sipariş eden müşterilerde; {command.NewPrice} fiyatı yansıtıldı");

            return Task.CompletedTask;

            /*
             * UPDATE Products SET ProductPrice = command.NewPrice WHERE ProductId = command.Id
             */

        }
    }
}
