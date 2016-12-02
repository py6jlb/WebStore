using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.BusinessLogic.DTO.Product;

namespace WebStore.UI.Models.Cart
{
    public class CartProductWithQuatntity
    {
        public ProductForIndexView product { get; set; }
        public int Quantity { get; set; }
    }
}