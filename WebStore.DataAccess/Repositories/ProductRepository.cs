using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebStore.DataAccess.Context;
using WebStore.DataAccess.Repositories.Base;
using WebStore.Domain.Entities;
using System.Data.Entity;

namespace WebStore.DataAccess.Repositories
{
    public class ProductRepository
        : IProductRepository
    {
        WebStoreDbContext _context = null;

        public ProductRepository(WebStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Category).ToArray();
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> func)
        {
            return _context.Products.Include(x => x.Category).Where(func).ToArray();
        }

        public void DelProducts(Product prod)
        {
            _context.Products.Remove(prod);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetCategoryes()
        {
            return _context.Categories.ToArray();
        }

        public void UpdateProduct(Product tmp)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == tmp.Id);
            if(prod != null)
            {
                prod.Name = tmp.Name;
                prod.CategoryId = tmp.CategoryId;
                prod.Description = tmp.Description;
                prod.Price = tmp.Price;
            }

            _context.SaveChanges();
        }

        public void AddProduct(Product tmp)
        {
            _context.Products.Add(tmp);
            _context.SaveChanges();
        }
    }
}