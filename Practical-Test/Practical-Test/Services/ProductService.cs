using Microsoft.EntityFrameworkCore;
using Practical_Test.Interfaces;
using Practical_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_Test.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Product>> FilterProduct(ProductViewModel model)
        {
            List<Product> result = null;
            if (model.ProductTypeId == 0)
            {   
                if(model.SearchText != null)
                     result = await _applicationDbContext.Product.Where(x => x.Name.Contains(model.SearchText)).ToListAsync();
                else
                    result = await _applicationDbContext.Product.ToListAsync();
            }
            else
            {
                if (model.SearchText == null)
                {
                    result = await _applicationDbContext.Product.Where(x => x.ProductTypeId == model.ProductTypeId).ToListAsync();

                }
                else
                {
                    result = await _applicationDbContext.Product.Where(x => x.ProductTypeId == model.ProductTypeId).Where(x=>x.Name.Contains(model.SearchText)).ToListAsync();

                }
            }

           return result;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _applicationDbContext.Product.Include(x=>x.ProductType).ToListAsync();
        }

        public async Task<List<ProductType>> GetAllProductTypes()
        {
            return await _applicationDbContext.ProductType.ToListAsync();
        }
    }
}
