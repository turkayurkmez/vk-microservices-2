using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEshop.MessageBus
{
    public record StockAvailableEvent(StockAvailableCommand StockAvailableCommand);   

    public record StockAvailableCommand(int OrderId, int CustomerId, string CreditCardInfo, decimal? TotalPrice);
}
