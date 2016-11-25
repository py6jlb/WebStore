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

        [HttpGet]
        public ActionResult Index()
        {
            var products = _productService.GetProducts();

            return View(products);
        }

        [HttpGet]
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
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(AddProductModelView editedProduct)
        {
            _productService.UpdateProduct(editedProduct.Product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeletProduct(int id)
        {
            _productService.DelProduct(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var model = new AddProductModelView()
            {
                Product = new BusinessLogic.DTO.Product.ProductDTO(),
                Category = _productService.GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(AddProductModelView newProduct)
        {
            _productService.AddProduct(newProduct.Product);

            return RedirectToAction("Index");
        }

    }
}