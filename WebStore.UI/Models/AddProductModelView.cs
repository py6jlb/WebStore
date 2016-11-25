using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.BusinessLogic.DTO.Category;
using WebStore.BusinessLogic.DTO.Product;

namespace WebStore.UI.Models
{
    public class AddProductModelView
    {
        public ProductDTO Product { get; set; }
        public IEnumerable<CategoryForDropDownList> Category { get; set; }
    }
}