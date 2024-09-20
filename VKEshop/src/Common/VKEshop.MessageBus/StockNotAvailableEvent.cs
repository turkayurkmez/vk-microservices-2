using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEshop.MessageBus
{
    /*
     * StockNotAvailableEvent (StockNotAvailableCommand(OrderId, CustomerId))
     */
    public record StockNotAvailableEvent(StockNotAvailableCommand StockNotAvailableCommand);   

    public record StockNotAvailableCommand(int OrderId, int CustomerId);


}
