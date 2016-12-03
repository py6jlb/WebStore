using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.BusinessLogic.Services.Base;
using WebStore.UI.Models.Cart;

namespace WebStore.UI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private const string cookieName = "cart";
        IProductService _productService = null;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult CurrentCart()
        {
            var cookie = Request.Cookies.Get(cookieName);
            CartViewModel cart = null;

            if (cookie == null)
            {
                cart = new CartViewModel();
                cookie = new HttpCookie(cookieName);
            }
            else
            {
                var cartValue = cookie.Values.Get("cart");

                if (string.IsNullOrWhiteSpace(cartValue))
                    cart = new CartViewModel();
                else
                    cart = Newtonsoft.Json.JsonConvert.DeserializeObject<CartViewModel>(cartValue);
            }

            return PartialView("_CurrentCart", cart);
        }

        public ActionResult AddToCart(int id)
        {
            var cookie = Request.Cookies.Get(cookieName);
            CartViewModel cart = null;

            if (cookie == null)
            {
                cart = new CartViewModel();
                cookie = new HttpCookie(cookieName);
            }
            else
            {
                var cartValue = cookie.Values.Get("cart");

                if (string.IsNullOrWhiteSpace(cartValue))
                    cart = new CartViewModel();
                else
                    cart = Newtonsoft.Json.JsonConvert.DeserializeObject<CartViewModel>(cartValue);
            }

            cookie.Expires = DateTime.Now.AddDays(1);

            if (cart.Items == null)
                cart.Items = new List<CartItem>();

            var product = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (product == null)
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            else
                product.Quantity++;

            cookie.Values.Clear();

            cookie.Values.Add("cart", Newtonsoft.Json.JsonConvert.SerializeObject(cart));

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Main");
        }


        public ActionResult UserCart()
        {
            var cookie = Request.Cookies.Get(cookieName);
            CartViewModel cart = null;
            List<CartProductWithQuatntity> model =  new List<CartProductWithQuatntity>();

            if (cookie == null)
            {
                cart = new CartViewModel();
                cookie = new HttpCookie(cookieName);
            }
            else
            {
                var cartValue = cookie.Values.Get("cart");
                cart = Newtonsoft.Json.JsonConvert.DeserializeObject<CartViewModel>(cartValue);
            }

            if (cart.Items == null)
            {
                return View(model);
            }
            else
            {
                var products = _productService.GetProducts(cart.Items.Select(x => x.ProductId));
                foreach(var prod in products)
                {
                    model.Add(new CartProductWithQuatntity { product = prod, Quantity = cart.Items.FirstOrDefault(y => y.ProductId == prod.Id).Quantity});
                }
            }
            
            return View(model);
        }


        public ActionResult DelFromCart(int id)
        {
            var cookie = Request.Cookies.Get(cookieName);
            CartViewModel cart = null;
            List<CartProductWithQuatntity> model = new List<CartProductWithQuatntity>();

            var cartValue = cookie.Values.Get("cart");

            cart = Newtonsoft.Json.JsonConvert.DeserializeObject<CartViewModel>(cartValue);

            if (cart.Items.First(x => x.ProductId == id).Quantity > 1)
            {
                cart.Items.First(x => x.ProductId == id).Quantity--;
            }
            else
            {
                cart.Items.Remove(cart.Items.First(x => x.ProductId == id));
            }

            cookie.Values.Set("cart", Newtonsoft.Json.JsonConvert.SerializeObject(cart));

            Response.Cookies.Set(cookie);

            return RedirectToAction("UserCart");
        }

    }
}