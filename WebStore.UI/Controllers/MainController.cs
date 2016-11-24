using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.BusinessLogic.Services.Base;

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
    }
}