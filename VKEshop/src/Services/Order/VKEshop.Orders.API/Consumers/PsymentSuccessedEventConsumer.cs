using MassTransit;
using VKEshop.MessageBus;

namespace VKEshop.Orders.API.Consumers
{

    public class PaymentSuccesedEventConsumer(ILogger<PaymentSuccesedEventConsumer> logger) : IConsumer<PaymentSuccessEvent>



    {
        public Task Consume(ConsumeContext<PaymentSuccessEvent> context)
        {
            var command = context.Message.PaymentSuccessedCommand;
            logger.LogInformation($"{command.CustomerId} id'li müşterinin {command.OrderId} id'li siparişi onaylandı ");
            return Task.CompletedTask;
        }




    }
}
