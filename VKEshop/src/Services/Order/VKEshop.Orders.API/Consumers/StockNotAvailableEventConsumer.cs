using MassTransit;
using VKEshop.MessageBus;

namespace VKEshop.Orders.API.Consumers
{
    public class StockNotAvailableEventConsumer(ILogger<StockNotAvailableEventConsumer> logger) : IConsumer<StockNotAvailableEvent>
    {
        public Task Consume(ConsumeContext<StockNotAvailableEvent> context)
        {
            var command = context.Message.StockNotAvailableCommand;
            logger.LogInformation($"{command.OrderId}, stok yetersizliği sebebiyle reddedildi");
            return Task.CompletedTask;

        }
    }
}
