using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebStore.BusinessLogic.DTO.Category;
using WebStore.BusinessLogic.DTO.Product;

namespace WebStore.BusinessLogic.Services.Base
{
    public interface IProductService
    {
        IEnumerable<ProductForIndexView> GetProducts();
        void RemoveProduct(int id);
        ProductDTO GetProduct(int id);
        void UpdateProduct(ProductDTO editedProduct);
        IEnumerable<SelectListItem> GetCategories();
        IEnumerable<ProductForIndexView> GetProducts(int catId);
        IEnumerable<ProductForIndexView> GetProductsByCategoryRecursive(int id);
    }
}