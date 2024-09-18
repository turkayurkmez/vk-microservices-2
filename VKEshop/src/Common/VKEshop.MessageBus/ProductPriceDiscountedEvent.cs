using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEshop.MessageBus
{
    /*
     *  Producer: Catalog.API 
     *  Consumer(s): Basket.API ve Order.API
     */
    public class ProductPriceDiscountedEvent
    {

        public ProductPriceDiscountCommand ProductPriceDiscountCommand { get; set; }
    }

    public class ProductPriceDiscountCommand
    {
        public int ProductId { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }
    }

}
