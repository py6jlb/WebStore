using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.BusinessLogic.Services.Base;
using WebStore.UI.Models;

namespace WebStore.UI.Controllers
{
    public class MainController : Controller
    {
        IProductService _productService = null;

        public MainController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetProducts();

            return View(products);
        }

        public ActionResult ProductInfo(int id)
        {
            var product = _productService.GetProduct(id);

            return View(product);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var model = new AddProductModelView()
            {
                Product = _productService.GetProduct(id),
                Category = _productService.GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(AddProductModelView newProduct)
        {



            return RedirectToAction("Index");
        }
    }
}