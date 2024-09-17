using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKEshop.Catalog.Domain
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
//category.Products.Add(new Product{});
//product.Category.Name = "Başka";
