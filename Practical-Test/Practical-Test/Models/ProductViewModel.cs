using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_Test.Models
{
    public class ProductViewModel
    {
        public List<Product> Product { get; set; }
        public List<ProductType> ProductType { get; set; }

        public int ProductTypeId { get; set; }
        public string SearchText { get; set; }
    }
}
