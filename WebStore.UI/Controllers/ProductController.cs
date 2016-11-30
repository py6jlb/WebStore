using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.BusinessLogic.Services.Base;

namespace WebStore.UI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IProductService _productService = null;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult UpdateListDefault()
        {
            var model = _productService.GetProducts();

            return PartialView("ProductList", model);
        }

        [HttpPost]
        public ActionResult UpdateList(ProductFilterDTO filter)
        {
            if (filter.CategoryId <= 0)
                return Json("Redirect");

            var model = _productService.GetProductsRecursiveDyFilter(filter);

            return PartialView("ProductList", model);
        }
    }
}