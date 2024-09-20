using MassTransit;
using VKEshop.MessageBus;

namespace VKEshop.Orders.API.Consumers
{
    public class PaymentFailedEventConsumer(ILogger<PaymentFailedEventConsumer> logger)  : IConsumer<PaymentFailedEvent>
    {

        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            var command = context.Message.PaymentFailedCommand;
            logger.LogInformation($"{command.OrderId} id'li sipariş ödemesi alınamadı. Sebebi: {command.Reason}");
            return Task.CompletedTask;

        }

    }
}
