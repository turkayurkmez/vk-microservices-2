using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEshop.MessageBus
{

    /*
     * PaymentSuccessedEvent(PaymentSuccessedCommand( OrderId, CustomerId))
     */
    public record PaymentSuccessEvent(PaymentSuccessedCommand PaymentSuccessedCommand);   

    public record PaymentSuccessedCommand(int OrderId, int CustomerId);
}
