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
using System.Text.RegularExpressions;

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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Category).ToArray();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> func)
        {
            return _context.Products.Include(x => x.Category).Where(func).ToArray();
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

        public void RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetProductsByFilter(IEnumerable<int> categories, string name, string descr, double priceMax, double priceMin)
        {
           //Как заставить выбрать с сервера все продукты у которых есть совпадения имени и описания, в одном запросе у меня не получилось
           //И как лучше реализвать метод LIKE чтоб искать входение по строке?
            var m = _context.Products.Include(p => p.Category).Where(x => categories.Contains(x.CategoryId)).ToArray();

            return from prod in m
                   where prod.Name.ToLower().Contains(name.ToLower())
                   && prod.Description.ToLower().Contains(descr.ToLower())
                   //&& prod.Price >= priceMin
                   //&& prod.Price <= priceMax
                   select prod;
        }
    }
}