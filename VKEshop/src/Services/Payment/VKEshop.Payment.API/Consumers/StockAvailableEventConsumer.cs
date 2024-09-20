using MassTransit;
using VKEshop.MessageBus;

namespace VKEshop.Payment.API.Consumers
{
    public class StockAvailableEventConsumer(ILogger<StockAvailableEventConsumer> logger, IPublishEndpoint publishEndpoint) : IConsumer<StockAvailableEvent>
    {
        public async Task Consume(ConsumeContext<StockAvailableEvent> context)
        {
            var command = context.Message.StockAvailableCommand;
            

            if (paymentCompleted(command.CreditCardInfo))
            {
                var @event = new PaymentSuccessEvent(new PaymentSuccessedCommand(command.OrderId, command.CustomerId));
               await  publishEndpoint.Publish(@event);

                logger.LogInformation($"Ödeme başarıyla tamamlandı. Yapılan ödeme: {command.TotalPrice} TL");
            }
            else
            {
                var @event = new PaymentFailedEvent(new PaymentFailedCommand(command.OrderId, command.CustomerId,"Kredi kardtında limit yok"));

                await publishEndpoint.Publish(@event);
                logger.LogInformation($"Ödeme başarısız oldu. Sebebi: {@event.PaymentFailedCommand.Reason}");

            }

            

        }

        private bool paymentCompleted(string creditCardInfo)
        {
            return new Random().Next(1, 500) % 2 == 0;
        }
    }

}
