using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEshop.MessageBus
{
    public record OrderCreatedEvent
    {
        public OrderCreatedCommand OrderCreatedCommand { get; set; }
    }

    public record OrderCreatedCommand(int OrderId, int CustomerId, string CreditCardInfo, IEnumerable<OrderItems> OrderItems);

    public record OrderItems(int ProductId, int Quantity, decimal? Price);
    
}
