using Practical_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_Test.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProduct();
        public Task<List<ProductType>> GetAllProductTypes();
        public Task<List<Product>> FilterProduct(ProductViewModel model);
    }
}
