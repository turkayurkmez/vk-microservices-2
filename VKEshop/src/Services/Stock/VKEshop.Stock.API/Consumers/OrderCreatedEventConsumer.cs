using MassTransit;
using VKEshop.MessageBus;

namespace VKEshop.Stock.API.Consumers
{
    public class OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger, IPublishEndpoint publishEndpoint) : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var command = context.Message.OrderCreatedCommand;

            bool isStockAvailable = checkStock(command.OrderItems);

            if (isStockAvailable) {

               
                decimal? totalPrice = getTotalPrice(command.OrderItems);
                var @event = new StockAvailableEvent(new StockAvailableCommand(command.OrderId, command.CustomerId, command.CreditCardInfo, totalPrice));

               await publishEndpoint.Publish(@event);
                logger.LogInformation($"{string.Join(",", command.OrderItems.Select(o => o.ProductId))} id'li ürünler kontrol edildi");
                logger.LogInformation("Stok uygun. StockAvailableEvent olayı fırlatıldı ");
            
            }
            else
            {
                var @event = new StockNotAvailableEvent(new StockNotAvailableCommand(command.OrderId, command.CustomerId));
                await publishEndpoint.Publish(@event);
                logger.LogInformation("Stok uygun değil. StocNotkAvailableEvent olayı fırlatıldı ");

            }
           
        }

        private decimal? getTotalPrice(IEnumerable<OrderItems> orderItems)
        {
            var total = orderItems.Sum(o => o.Price * o.Quantity);
            return total;
        }

        private bool checkStock(IEnumerable<OrderItems> orderItems)
        {
            return new Random().Next(1, 1000) % 2 == 0;
        }
    }
}
