using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practical_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_Test.DbSeed
{
    public class DbSeed
    {
        public static void Seed(IServiceScope serviceScope)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.ProductType.Any())
            {
                context.ProductType.Add(new ProductType { Id = 1, Name = "Unknown" });
                context.ProductType.Add(new ProductType { Id = 2, Name = "Road" });
                context.ProductType.Add(new ProductType { Id = 3, Name = "Mountain" });
                context.ProductType.Add(new ProductType { Id = 4, Name = "Touring" });
                context.ProductType.Add(new ProductType { Id = 5, Name = "Standard" });
                context.SaveChanges();
            }

            if (!context.Product.Any())
            {
                context.Product.Add(new Product { Id = 1, Name = "Test", Description = "test Desc", ProductTypeId = 1 });
                context.Product.Add(new Product { Id = 2, Name = "Test abc", Description = "test Desc", ProductTypeId = 2 });
                context.Product.Add(new Product { Id = 3, Name = "aaaa", Description = "test Desc", ProductTypeId = 3 });
                context.Product.Add(new Product { Id = 4, Name = "bcsd", Description = "test Desc", ProductTypeId = 4 });
                context.SaveChanges();
            }
        }
    }
}
