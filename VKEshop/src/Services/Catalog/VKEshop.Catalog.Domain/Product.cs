using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEshop.Catalog.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public double? Rating { get; set; }
        public int? StockCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; } = true;

        public string? ImageUrl { get; set; }
        public Category? Category { get; set; }

        public int? CategoryId { get; set; }

    }
}
