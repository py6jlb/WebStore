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
        IEnumerable<Category> GetCategoryes();
        void UpdateProduct(Product tmp);
        void AddProduct(Product tmp);
        Product GetProduct(int id);
        void SaveChanges();
        void RemoveProduct(Product product);
        IEnumerable<Product> GetProductsByFilter(IEnumerable<int> categories, string name, string descr, double priceMax, double priceMin);
    }
}