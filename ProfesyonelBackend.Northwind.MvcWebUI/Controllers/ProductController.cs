using ProfesyonelBackend.Northwind.Business.Abstract;
using ProfesyonelBackend.Northwind.Entities.Concrete;
using ProfesyonelBackend.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfesyonelBackend.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "IPhone",
                QuantityPerUnit = "1",
                UnitPrice = 21
            });

            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(
            new Product //Validation kuralına uygun olan ürün 
            {
                CategoryId = 1,
                ProductName = "Computer 1",
                QuantityPerUnit = "1",
                UnitPrice = 2
            },

            new Product //Validation kuralına aykırı olan ürün 
            {
                ProductId = 84,
                CategoryId = 1,
                ProductName = "Computer 2",
                QuantityPerUnit = "1",
                UnitPrice = 2
            });

            return "Done";
        }
    }
}