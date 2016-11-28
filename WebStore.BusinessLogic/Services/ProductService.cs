﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.BusinessLogic.Services.Base;
using WebStore.DataAccess.Repositories.Base;
using WebStore.BusinessLogic.DTO.Category;
using WebStore.Domain.Entities;
using System.Web.Mvc;

namespace WebStore.BusinessLogic.Services
{
    public class ProductService
        : IProductService
    {
        ICategoryRepository _categoryRepository = null;
        IProductRepository _productRepository = null;
        IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductForIndexView> GetProducts()
        {
            return _productRepository.GetProducts().Select(_mapper.Map<ProductForIndexView>).ToArray();
        }

        public IEnumerable<ProductForIndexView> GetProducts(int catId)
        {
            return _productRepository.GetProducts().Where(x => x.CategoryId == catId).Select(_mapper.Map<ProductForIndexView>).ToArray();
        }

        public void RemoveProduct(int id)
        {
            var prod = _productRepository.GetProduct(id);

            if (prod != null)
            {
                _productRepository.RemoveProduct(prod);
            }
        }

        public ProductDTO GetProduct(int id)
        {
            return _productRepository.GetProducts(x => x.Id == id).Select(_mapper.Map<ProductDTO>).FirstOrDefault();
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _categoryRepository.GetCategories().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToArray();
        }

        public void UpdateProduct(ProductDTO viewModel)
        {
            var product = _mapper.Map<Product>(viewModel);

            if (product.Id != 0)
            {
                var oldProduct = _productRepository.GetProduct(product.Id);

                oldProduct.Name = product.Name;
                oldProduct.Description = product.Description;
                oldProduct.CategoryId = product.CategoryId;
                oldProduct.IsDeleted = product.IsDeleted;
            }
            else if (product.Id == 0)
            {
                _productRepository.AddProduct(product);
            }

            _productRepository.SaveChanges();

        }

        private IEnumerable<Category> GetRecursiveCategory(IEnumerable<Category> data)
        {
            var result = new List<Category>();

            if (data != null)
            {
                foreach (var item in data)
                {
                    result.Add(item);
                    result.AddRange(GetRecursiveCategory(item.ChildCategories));
                }
            }

            return result;

        }

        public IEnumerable<ProductForIndexView> GetProductsRecursiveDyFilter(ProductFilterDTO filter)
        {
            List<Category> selectedCateory = new List<Category>();

            var data = _categoryRepository.GetCategories().Where(x => x.Id == filter.CategoryId).ToArray();
            selectedCateory.AddRange(GetRecursiveCategory(data));
            var selectedCateoryId = selectedCateory.Select(m => m.Id);
            string name, descr;
            double priceMin, priceMax;

            name = filter.Name != null ? filter.Name : "";
            descr = filter.Description != null ? filter.Description : "";
            priceMin = filter.PriceMin != 0 ? filter.PriceMin : 0.0D;
            priceMax = filter.PriceMax != 0 ? filter.PriceMin : double.MaxValue;

            return _productRepository.GetProductsByFilter(selectedCateoryId, name, descr, priceMin, priceMax).Select(_mapper.Map<ProductForIndexView>).ToArray();         

        }
    }
}
