using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.DataAccess.Repositories.Base
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> func);
        void DelProducts(Product prod);
        IEnumerable<Category> GetCategoryes();
        void UpdateProduct(Product tmp);
        void AddProduct(Product tmp);
    }
}