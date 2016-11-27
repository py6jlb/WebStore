using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.BusinessLogic.DTO.Category;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.BusinessLogic.Services.Base;

namespace WebStore.UI.Controllers
{
    public class MainController : Controller
    {
        #region init service
        IProductService _productService = null;

        public MainController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Categories = _productService.GetCategories();
            //var products = _productService.GetProducts();

            return View();
        }

        [HttpPost]
        public ActionResult UpdateList(CategoryForDropDownList category)
        {
            if (category.Id <= 0)
                return Json(new { result = "Redirect", url = Url.Action("Index")});

            var model = _productService.GetProducts(category.Id);

            return PartialView("ProductList", model);
        }

        #endregion

        #region ProductInfo
        [HttpGet]
        public ActionResult ProductInfo(int id)
        {
            var product = _productService.GetProduct(id);

            return View(product);
        }
        #endregion


        #region Product manipulation
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ViewBag.IsEdit = true;
            ViewBag.Categories = _productService.GetCategories();

            var product = _productService.GetProduct(id);
            
            return View("ManipulateProduct", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ProductDTO editedProduct)
        {
            ViewBag.IsEdit = true;

            if (!ModelState.IsValid)
                return View("ManipulateProduct", editedProduct);

            _productService.UpdateProduct(editedProduct);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeletProduct(int id)
        {
            _productService.RemoveProduct(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = _productService.GetCategories();

            return View("ManipulateProduct");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductDTO newProduct)
        {
            _productService.UpdateProduct(newProduct);

            return RedirectToAction("Index");
        }
        #endregion

        //Нашел этот способ в интернете, хотелось бы услышать подробнее про его реализацию
        //public ActionResult GetCategoriesDropdown(int id)
        //{
        //    var model = from cat in _productService.GetCategories()
        //                     select new SelectListItem
        //                     {
        //                         Text = cat.Name,
        //                         Value = cat.Id.ToString(),
        //                         Selected = (cat.Id == id)
        //                     };
        //    ViewData.ModelMetadata = new ModelMetadata(
        //        ModelMetadataProviders.Current,
        //        null,
        //        null,
        //        typeof(int),
        //        "Id"
        //        )

        //        { NullDisplayText = "choose" };

        //    return View("CategoriesDropdown", model);
        //}

    }
}