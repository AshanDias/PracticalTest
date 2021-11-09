using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practical_Test.Interfaces;
using Practical_Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_Test.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ProductViewModel model = new ProductViewModel();
            model.Product = new List<Product>();
            model.ProductType = new List<ProductType>();
            model.Product = await _productService.GetAllProduct();
            model.ProductType = await _productService.GetAllProductTypes();

            return View(model);
        }
        
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }


        [Route("Filter")]
        public async Task<IActionResult> Filter(ProductViewModel model)
        {
            model.Product = await _productService.FilterProduct(model);
            model.ProductType = await _productService.GetAllProductTypes();
            return View("Index", model);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
