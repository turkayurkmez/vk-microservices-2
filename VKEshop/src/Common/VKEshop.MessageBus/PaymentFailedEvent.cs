using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEshop.MessageBus
{
    /*
     * PaymentFailedEvent(PaymentFailedCommand(OrderId, Reason))
     */
    public record PaymentFailedEvent(PaymentFailedCommand PaymentFailedCommand);

    public record PaymentFailedCommand(int OrderId, int CustomerId, string Reason);
}
