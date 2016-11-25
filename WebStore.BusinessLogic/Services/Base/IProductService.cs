using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BusinessLogic.DTO.Category;
using WebStore.BusinessLogic.DTO.Product;

namespace WebStore.BusinessLogic.Services.Base
{
    public interface IProductService
    {
        IEnumerable<ProductForIndexView> GetProducts();
        void DelProduct(int id);
        ProductDTO GetProduct(int id);
        IEnumerable<CategoryForDropDownList> GetCategories();
        void UpdateProduct(ProductDTO editedProduct);
        void AddProduct(ProductDTO product);
    }
}